using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MaliceRAT.RatClient
{
    public class Server
    {
        public event EventHandler<string> MessageReceived;
        private TcpListener server;
        private const int BufferSize = 1024;

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
                    OnMessageReceived(receivedMessage);

                    // Send hello back to the client
                    byte[] helloBytes = Encoding.UTF8.GetBytes("Hello from the server");
                    await stream.WriteAsync(helloBytes, 0, helloBytes.Length);
                }
            }
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, message);
        }
    }
}