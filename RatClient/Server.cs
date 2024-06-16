using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace MaliceRAT.RatClient
{
    public class Server
    {
        public event EventHandler<string> MessageReceived;
        private TcpListener server;
        private const int BufferSize = 1024;

        public Server()
        {
            MessageReceived += LogMessage;
        }

        public void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(ipAddress, 6666);
            server.Start();
            Console.WriteLine("Server started at " + server.LocalEndpoint);
            Task.Run(async () => await AcceptClients());
        }

        private async Task AcceptClients()
        {
            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                await Task.Run(async () => await HandleClient(client));
            }
        }

        private async Task HandleClient(TcpClient client)
        {
            using (client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[BufferSize];
                int bytesRead;

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    dynamic jsonMessage = JsonConvert.DeserializeObject(receivedMessage);
                    if (jsonMessage.type == "message")
                    {
                        OnMessageReceived(jsonMessage.text.ToString());
                    }

                    // Send hello back to the client
                    var response = new
                    {
                        type = "message",
                        text = "Hello from the server"
                    };
                    string jsonResponse = JsonConvert.SerializeObject(response);
                    byte[] helloBytes = Encoding.UTF8.GetBytes(jsonResponse);
                    await stream.WriteAsync(helloBytes, 0, helloBytes.Length);
                }
            }
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, message);
        }

        private void LogMessage(object sender, string message)
        {
            Console.WriteLine("Received message: " + message);
        }
    }
}