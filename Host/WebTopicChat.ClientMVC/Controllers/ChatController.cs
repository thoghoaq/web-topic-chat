using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using WebTopicChat.ClientMVC.Common;
using System.Net.Http.Headers;
using WebTopicChat.ClientMVC.Models;
using WebTopicChat.ClientMVC.ClientSocketHandler;
using System.Net.Sockets;

namespace WebTopicChat.ClientMVC.Controllers
{
    public class ChatController : Controller
    {
        private readonly HttpClient clients;
        private string apiUrl = "";

        public ChatController()
        {
            clients = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            clients.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index(int topicId, string topicName)
        {
            var listMessage = await GetMessage(topicId);
            ViewBag.TopicId = topicId;
            ViewBag.TopicName = topicName;
            return View(listMessage);
        }

        public IActionResult InitialChatRoom(int topicId, string topicName)
        {
            // Start client socket.
            ClientSocket clientSocket = new(new Socket
                        (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
            clientSocket.ConnectToServer();
            clientSocket.RequestLoop();
            return RedirectToAction("Index", "Chat", new { topicId, topicName });
        }

        public async Task<List<Message>?> GetMessage(int id)
        {
            apiUrl = ApiUrls.reUrl + $"topic/{id}/message";

            HttpResponseMessage response = await clients.GetAsync(apiUrl);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Message> listMessage = JsonSerializer.Deserialize<List<Message>>(data, options);
            return listMessage;
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int topicIdParam, string message)
        {
            apiUrl = ApiUrls.reUrl + $"topic/{topicIdParam}/send-message";
            int clientId = (int)HttpContext.Session.GetInt32("UserID");
            // Create the request body
            var requestBody = new
            {
                senderId = clientId,
                content = message
            };

            // Convert the request body to JSON
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request
            HttpResponseMessage response = await clients.PostAsync(apiUrl, content);

            // Check the response status
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("POST request succeeded");
            }
            else
            {
                Console.WriteLine("POST request failed with status code: " + response.StatusCode);
            }
            return RedirectToAction("Index", "Chat", new { topicId = topicIdParam });
        }
    }
}
