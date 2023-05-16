using Microsoft.AspNetCore.Mvc;
using WebTopicChat.ClientMVC.Models;
using System.Text.Json;
using System.Net.Http.Headers;
using WebTopicChat.ClientMVC.Common;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using WebTopicChat.Domain.Entities;

namespace WebTopicChat.ClientMVC.Controllers
{
    public class TopicController : Controller
    {
        private readonly HttpClient clients = null;
        private string apiUrl = "";

        public TopicController()
        {
            clients = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            clients.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> GetList()
        {
            // get the id from session
            var userid = HttpContext.Session.GetInt32("UserID");

            apiUrl = ApiUrls.reUrl + $"topic?clientId={userid}";
            HttpResponseMessage response = await clients.GetAsync(apiUrl);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<TopicViewModel> listTopic = System.Text.Json.JsonSerializer.Deserialize<List<TopicViewModel>>(data, options);
            return View(listTopic);
        }

        public async Task<IActionResult> GetMessage(int id)
        {
            apiUrl = ApiUrls.reUrl + $"topic/{id}/message";

            HttpResponseMessage response = await clients.GetAsync(apiUrl);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Models.Message> listMessage = System.Text.Json.JsonSerializer.Deserialize<List<Models.Message>>(data, options);
            return View(listMessage);
        }

        public async Task<IActionResult> Sub(int id)
        {
            apiUrl = ApiUrls.reUrl + "topic/sub";
            int clientId = (int)HttpContext.Session.GetInt32("UserID");
            int topicId = id;
            var data = new { clientId, topicId };
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await clients.PostAsync(apiUrl, content);
            return RedirectToAction("GetList", "Topic");
        }

        public async Task<IActionResult> UnSub(int id)
        {
            apiUrl = ApiUrls.reUrl + "topic/unsub";
            int clientId = (int)HttpContext.Session.GetInt32("UserID");

            var requestBody = new
            {
                clientiD = clientId,
                topicId = id
            };

            var requestBodyJson = System.Text.Json.JsonSerializer.Serialize(requestBody);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, apiUrl);
                
            request.Content = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await clients.SendAsync(request);
            return RedirectToAction("GetList", "Topic");
        }

        public async Task<IActionResult> Create(string topicName)
        {
            apiUrl = ApiUrls.reUrl + "topic";
            int clientId = (int)HttpContext.Session.GetInt32("UserID");

            var requestBody = new
            {
                name = topicName,
                ownerId = clientId
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await clients.PostAsync(apiUrl, content);
            return RedirectToAction("GetList", "Topic");
        }

        public IActionResult GoToChat(int id)
        {
            return RedirectToAction("Index", "Chat", new {topicId = id});
        }
    }
}
