using Microsoft.AspNetCore.Mvc;
using WebTopicChat.ClientMVC.Models;
using System.Text.Json;
using System.Net.Http.Headers;

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
            apiUrl = "https://localhost:7033/topic";
        }

        public async Task<IActionResult> GetList()
        {
            HttpResponseMessage response = await clients.GetAsync(apiUrl);
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<TopicViewModel> listTopic = JsonSerializer.Deserialize<List<TopicViewModel>>(data, options);
            return View(listTopic);
        }
    }
}
