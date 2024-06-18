using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Drawing;
using System.Text.Json;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MaliceRAT
{
    public static class Utilities
    {
        #region IP
        public static string GetLanIp()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet))
                {
                    var gatewayAddresses = ni.GetIPProperties().GatewayAddresses;
                    if (gatewayAddresses.Count > 0)
                    {
                        var gatewayAddress = gatewayAddresses[0];
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork && ip.AddressPreferredLifetime != UInt32.MaxValue)
                            {
                                return ip.Address.ToString();
                            }
                        }
                    }
                }
            }

            return "N/A";
        }

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
        #endregion

        #region Flag
        public static async Task<string> GetCountryCodeFromIP(string ip)
        {
            using (var client = new HttpClient())
            {
                string jsonResponse;
                try
                {
                    jsonResponse = await client.GetStringAsync($"http://ip-api.com/json/{ip}?fields=countryCode");
                }
                catch (HttpRequestException)
                {
                    throw new HttpRequestException("Request failed while trying to get country code.");
                }

                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonResponse, jsonOptions);
                if (data.TryGetValue("countryCode", out string countryCode))
                {
                    return countryCode;
                }
                else
                {
                    return "Country code not found";
                }
            }
        }

        public static async Task<Image> GetFlagFromIP(string ip)
        {
            string countryCode = await GetCountryCodeFromIP(ip);
            string flagsDirectory = Path.Combine(Application.StartupPath, "flags");
            string flagPath = Path.Combine(flagsDirectory, $"{countryCode.ToLower()}.png");

            if (!File.Exists(flagPath))
            {
                throw new FileNotFoundException("Flag file not found.", flagPath);
            }

            Image flagImage;
            using (var stream = new FileStream(flagPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                flagImage = Image.FromStream(stream);
            }
            return flagImage;
        }
        #endregion
    }
}