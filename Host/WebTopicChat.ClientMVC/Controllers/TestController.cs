using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using WebTopicChat.ClientMVC.ClientSocketHandler;

namespace WebTopicChat.ClientMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: TestController
        public ActionResult Index()
        {
            // Start client socket.
            ClientSocket clientSocket = new(new Socket
                        (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp));
            clientSocket.ConnectToServer();
            clientSocket.RequestLoop();
            clientSocket.SendRequest("hello");
            return View();
        }

        public ActionResult ReceiveMessageCallBack(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}
