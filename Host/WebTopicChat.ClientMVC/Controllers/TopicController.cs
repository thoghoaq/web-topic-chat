using Microsoft.AspNetCore.Mvc;
using WebTopicChat.ClientMVC.Models;
using System.Text.Json;
using System.Net.Http.Headers;
using WebTopicChat.ClientMVC.Common;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;

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
            List<TopicViewModel> listTopic = JsonSerializer.Deserialize<List<TopicViewModel>>(data, options);
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
            List<Message> listMessage = JsonSerializer.Deserialize<List<Message>>(data, options);
            return View(listMessage);
        }

    }
}
