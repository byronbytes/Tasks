using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tasks.Core
{
    class Update
    {
        public static string CurrentVersion = "4.0.2";

        public static string GetCloudVersion()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://pastebin.com/02qyhKX7");
            StreamReader reader = new StreamReader(stream);
            var json = reader.ReadToEnd();

            dynamic jsonItems = JsonConvert.DeserializeObject(json);
            return jsonItems.version;
        }

        /// <summary>
        /// Checks if NoLexa is up to date by matching the current version and the online release.
        /// </summary>
        /// <returns>A true or false boolean if NoLexa is up to date.</returns>
        public static bool IsUpToDate()
        {
            if (GetCloudVersion() == CurrentVersion)
            {
                return true;

            }
            return false;
        }

       

        /// <summary>
        /// Starts the update process.
        /// </summary>
        public static void StartUpdate()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NoLexa\\UpdateCache");
            // Download latest files from GitHub.
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Tasks-Update");
                client.DownloadFile(
                    "https://github.com/LiteTools/Tasks/releases/download/v4.0.2/Tasks.v4.0.2.zip",
                    "NoLexa-Update.zip");
            }

            File.Move(@Directory.GetCurrentDirectory() + "\\NoLexa-Update.zip", @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NoLexa\\UpdateCache\\NoLexa-Update.zip");
            ZipFile.ExtractToDirectory(@Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NoLexa\\UpdateCache\\NoLexa-Update.zip", @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NoLexa\\UpdateCache\\");
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\NoLexa\\UpdateCache\\Tasks.exe");
            Debug.WriteLine("Install completed.");
        }

    }
}
