using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

class Program
{
    static TcpClient client;
    static NetworkStream stream;
    static readonly string Server = "127.0.0.1";
    static readonly int Port = 6666;

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
                byte[] data = new byte[1024];
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
}