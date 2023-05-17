using Microsoft.AspNetCore.Mvc;
using WebTopicChat.ClientMVC.Models;
using Newtonsoft.Json;
using System.Text;
using WebTopicChat.ClientMVC.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using WebTopicChat.Domain.Entities;

namespace WebTopicChat.ClientMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexRegistError()
        {
            // Toggle modal on screen initialization
            string script = "window.onload = function() {\r\n    var modal = document.getElementById('modalForm');\r\n    var modalToggle = new bootstrap.Modal(modal);\r\n    modalToggle.toggle();\r\n  }";
            ViewBag.Script = script;
            ViewBag.ErrorMessage1 = "Username already exists. Please choose a different one.";
            return View("Index");
        }

        private readonly HttpClient clients = null;
        private string apiUrl = "";

        public HomeController()
        {
            clients = new HttpClient();
        }

        public async Task<IActionResult> Auth(Models.Client client)
        {
            apiUrl = ApiUrls.reUrl + "auth/login";
            var content = new StringContent(JsonConvert.SerializeObject(client), Encoding.UTF8, "application/json");
            var response = await clients.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                // extract the id from the JSON response
                var json = JObject.Parse(result);
                var userid = json["id"].Value<int>();

                // store the id in session
                HttpContext.Session.SetInt32("UserID", userid);
                return RedirectToAction("GetList", "Topic");
            }
            else
            {
                ViewBag.ErrorMessage = "Wrong username or password. Please try again.";
                return View("Index");
            }
        }

        public async Task<IActionResult> Regist(string userName, string password, string displayName)
        {
            apiUrl = ApiUrls.reUrl + "auth/register";

            var requestBody = new
            {
                userName = userName,
                password = password,
                displayName = displayName
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await clients.PostAsync(apiUrl, content);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // extract the id from the JSON response
                var json = JObject.Parse(result);
                var userid = json["id"].Value<int>();

                // store the id in session
                HttpContext.Session.SetInt32("UserID", userid);
                return RedirectToAction("GetList", "Topic");
            }
            else
            {
                return RedirectToAction("IndexRegistError");
            }
            
        }
    }
}






