using System;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace MaliceRAT
{
    class Server
    {
        public async Task Start(string url)
        {
            HttpListener httpListener = new HttpListener();
            httpListener.Prefixes.Add(url);
            httpListener.Start();
            Console.WriteLine("WebSocket Server started at " + url);

            while (true)
            {
                HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                if (httpListenerContext.Request.IsWebSocketRequest)
                {
                    HttpListenerWebSocketContext webSocketContext = await httpListenerContext.AcceptWebSocketAsync(null);
                    WebSocket webSocket = webSocketContext.WebSocket;
                    // Handle the WebSocket connection here
                }
            }
        }
    }
}
