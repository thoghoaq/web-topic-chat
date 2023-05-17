using System.Net.Sockets;
using System.Net;
using System.Text;
using WebTopicChat.ClientMVC.Controllers;

namespace WebTopicChat.ClientMVC.ClientSocketHandler
{
    public class ClientSocket
    {
        private readonly Socket _clientSocket;
        private const int BUFFER_SIZE = 2048;
        private const int PORT = 100;

        public ClientSocket(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        public void ConnectToServer()
        {
            int attempts = 0;

            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine($"{_clientSocket}: Connection attempt " + attempts);
                    _clientSocket.Connect(IPAddress.Loopback, PORT);
                }
                catch (SocketException)
                {

                }
            }
            Console.WriteLine("Connected");
        }

        public void RequestLoop()
        {
            Console.WriteLine(@"<Type ""exit"" to properly disconnect client>");
            var receiveThread = new Thread(ReceiveResponse);
            receiveThread.Start();
        }

        public void Exit()
        {
            SendString("exit");
            _clientSocket.Shutdown(SocketShutdown.Both);
            _clientSocket.Close();
            //Environment.Exit(0);
        }

        public void SendRequest(string request)
        {
            SendString(request);

            if (request.ToLower() == "exit")
            {
                Exit();
            }
        }

        private void SendString(string text)
        {
            byte[] data = new byte[BUFFER_SIZE];
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            Array.Copy(buffer, data, buffer.Length);
            _clientSocket.Send(data, 0, data.Length, SocketFlags.None);
        }

        public void ReceiveResponse()
        {
            while (true)
            {
                var buffer = new byte[BUFFER_SIZE];
                int received = _clientSocket.Receive(buffer, SocketFlags.None);
                if (received == 0) return;
                var data = new byte[received];
                Array.Copy(buffer, data, received);
                string text = Encoding.ASCII.GetString(data);
                Console.WriteLine(text);
                var testController = new TestController();
                testController.ReceiveMessageCallBack(text);
            }
        }
    }
}
