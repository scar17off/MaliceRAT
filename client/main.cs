using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static TcpClient client;
    static NetworkStream stream;

    static void Main(string[] args)
    {
        string server = "127.0.0.1"; // Server IP
        int port = 6666; // Server port

        try
        {
            client = new TcpClient(server, port);
            stream = client.GetStream();

            string message = "Hello from victim client!";
            string jsonMessage = JsonConvert.SerializeObject(new {
                type = "message",
                text = message
            });
            byte[] data = Encoding.UTF8.GetBytes(jsonMessage);

            SendInfo();
            // Send the message to the server
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);

            // Receive the response from the server
            data = new byte[1024];
            int bytes = stream.Read(data, 0, data.Length);
            string responseData = Encoding.UTF8.GetString(data, 0, bytes);
            dynamic responseJson = JsonConvert.DeserializeObject(responseData);
            Console.WriteLine("Received: {0}", responseJson.text);
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

        // Prevent the console window from closing immediately
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    static Tuple<string, string> GetOSInfo()
    {
        return new Tuple<string, string>(Environment.OSVersion.ToString(), Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit");
    }
    static void SendInfo()
    {
        var osInfo = GetOSInfo();
        string jsonOSInfo = JsonConvert.SerializeObject(new {
            type = "info",
            text = osInfo.Item1 + " " + osInfo.Item2
        });
        byte[] data = Encoding.UTF8.GetBytes(jsonOSInfo);
        stream.Write(data, 0, data.Length);
    }
}