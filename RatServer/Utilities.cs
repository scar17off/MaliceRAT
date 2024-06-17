using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace MaliceRAT
{
    public static class Utilities
    {
        public static async Task<string> GetPublicIPAddress()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string publicIP = await client.GetStringAsync("https://api.ipify.org");
                    return publicIP;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error getting public IP: " + e.Message);
                    return null;
                }
            }
        }

        public static void SaveImage(string imageUrl, string filename, ImageFormat format)
        {    
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap;  bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }
                
            stream.Flush();
            stream.Close();
            client.Dispose();
        }

        public static async Task<string> GetCountryCodeFromIP(string ip) {
            using (var client = new WebClient()) {
                string jsonResponse;
                try {
                    jsonResponse = await client.DownloadStringTaskAsync(new Uri($"http://ip-api.com/json/{ip}?fields=countryCode"));
                } catch (WebException) {
                    throw new HttpRequestException("Request failed while trying to get country code.");
                }

                var jsonSerializer = new JavaScriptSerializer();
                var jsonObject = jsonSerializer.Deserialize<dynamic>(jsonResponse);
                return jsonObject["countryCode"];
            }
        }

        public static async Task<Image> GetFlagFromIP(string ip) {
            string countryCode = await GetCountryCodeFromIP(ip);
            string flagsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "flags");
            string flagPath = Path.Combine(flagsDirectory, $"{countryCode.ToLower()}.png");

            if (File.Exists(flagPath)) {
                Image flagImage;
                using (var stream = new FileStream(flagPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                    flagImage = Image.FromStream(stream);
                }
                return flagImage;
            }

            throw new FileNotFoundException("Flag file not found.");
        }
    }
}