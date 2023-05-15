using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

// Context: Room is as topicId, when client open a topic, client will connect to this topic room

namespace MultiServer
{
    public class Program
    {
        public static readonly Socket serverSocket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static readonly List<Socket> clientSockets = new();
        public const int BUFFER_SIZE = 2048;
        public const int PORT = 100;
        public static readonly byte[] buffer = new byte[BUFFER_SIZE];
        public static readonly Dictionary<int, List<Socket>> topicClients = new ();

        static void Main()
        {
            Console.Title = "Server Socket";
            SetupServer();
            Console.ReadLine(); // When we press enter close everything
            CloseAllSockets();
        }

        public static void SetupServer()
        {
            Console.WriteLine("Setting up server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            serverSocket.Listen(1);
            serverSocket.BeginAccept(AcceptCallback, null);
            Console.WriteLine("Server setup complete");
        }

        /// <summary>
        /// Close all connected client (we do not need to shutdown the server socket as its connections
        /// are already closed with the clients).
        /// </summary>
        public static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }

            serverSocket.Close();
        }

        public static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
                return;
            }

            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
            Console.WriteLine($"Client {clientSockets.IndexOf(socket)} connected, waiting for request...");
            serverSocket.BeginAccept(AcceptCallback, null);
        }

        public static void ReceiveCallback(IAsyncResult AR)
        {
            Socket current = (Socket)AR.AsyncState;
            int received;
            try
            {
                received = current.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine($"Client {clientSockets.IndexOf(current)} forcefully disconnected");
                // Don't shutdown because the socket may be disposed and its disconnected anyway.
                current.Close();
                clientSockets.Remove(current);
                return;
            }

            byte[] recBuf = new byte[received];
            Array.Copy(buffer, recBuf, received);
            string text = Encoding.ASCII.GetString(recBuf.TakeWhile(e => e != byte.MinValue).ToArray()).Trim();
            Console.WriteLine($"Received Text from client {clientSockets.IndexOf(current)}: " + text);

            if (text.ToLower() == "exit") // Client wants to exit gracefully
            {
                // Always Shutdown before closing
                current.Shutdown(SocketShutdown.Both);
                current.Close();
                clientSockets.Remove(current);
                Console.WriteLine("Client disconnected");
                return;
            }
            else if (text.StartsWith("/"))
            {
                if (text.StartsWith("/join "))
                {
                    var topicId = int.Parse(text["/join ".Length..]);
                    if (topicClients.Keys.Any(k => k == topicId)) {
                        ConnectTopicRoom(topicId, current);
                    } else
                    {
                        StartTopicRoom(topicId, current);
                    }
                }
                else if (text.StartsWith("/send "))
                {
                    string pattern = @"""([^""]+)""\s+""([^""]+)"""; // Matches two quoted strings

                    Match match = Regex.Match(text, pattern);

                    if (match.Success)
                    {
                        string arg1 = match.Groups[1].Value; // Topic
                        string arg2 = match.Groups[2].Value; // Message

                        // Send message to all client subcribe topic
                        var listClient = topicClients.Single(e => e.Key == int.Parse(arg1)).Value;
                        foreach (Socket client in listClient)
                        {
                            client.Send(Encoding.ASCII.GetBytes(arg2));
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Client {clientSockets.IndexOf(current)}: Input string doesn't match pattern.");
                        current.Send(Encoding.ASCII.GetBytes("Input string doesn't match pattern."));
                    }
                }
                else
                {
                    current.Send(Encoding.ASCII.GetBytes("Invalid command"));
                }
            }
            else
            {
                byte[] data = Encoding.ASCII.GetBytes("Message from server: " + text);
                foreach (var client in clientSockets)
                {
                    client.Send(data);
                }
            }

            current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
        }

        private static void ConnectTopicRoom(int topicId,Socket client)
        {
            if (topicClients.Single(e => e.Key == topicId).Value.All(e => !e.Equals(client))) {
                topicClients.Single(e => e.Key == topicId).Value.Add(client);
            }
        }

        private static void StartTopicRoom(int topicId, Socket socket)
        {
            topicClients.Add(topicId, new List<Socket> () { socket });
        }
    }
}
