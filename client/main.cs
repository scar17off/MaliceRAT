using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string server = "127.0.0.1"; // Server IP
        int port = 6666; // Server port

        try
        {
            using (TcpClient client = new TcpClient(server, port))
            using (NetworkStream stream = client.GetStream())
            {
                string message = "Hello from victim client!";
                byte[] data = Encoding.UTF8.GetBytes(message);

                // Send the message to the server
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);

                // Receive the response from the server
                data = new byte[1024];
                int bytes = stream.Read(data, 0, data.Length);
                string responseData = Encoding.UTF8.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e);
        }

        // Prevent the console window from closing immediately
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}