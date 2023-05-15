using Microsoft.AspNetCore.Mvc;
using WebTopicChat.ClientMVC.Models;
using Newtonsoft.Json;
using System.Text;
using WebTopicChat.ClientMVC.Common;

namespace WebTopicChat.ClientMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly HttpClient clients = null;
        private string apiUrl = "";

        public HomeController()
        {
            clients = new HttpClient();
            apiUrl = ApiUrls.reUrl + "auth/login";
        }

        public async Task<IActionResult> Auth(Client client)
        {
            var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
            var response = await clients.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return RedirectToAction("GetList", "Topic");
            }
            else
            {
                ViewBag.ErrorMessage = "Wrong username or password. Please try again.";
                return View("Index");
            }
        }
    }
}






