using System;
using System.Net;
using System.Net.Sockets;

namespace MaliceRAT.RatServer
{
    public class Victim
    {
        public string IP { get; set; }
        public string OS { get; set; }
        public TcpClient TcpClient { get; private set; }
        public int Id { get; set; }
        public string PC { get; set; }
        public string User { get; set; }

        public Victim(TcpClient client, int id)
        {
            TcpClient = client;
            IP = "N/A";
            OS = "N/A";
            Id = id;
            PC = "N/A";
            User = "N/A";
        }
    }
}
