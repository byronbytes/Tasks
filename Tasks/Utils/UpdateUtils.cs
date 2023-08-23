/*
    Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Tasks.Utils
{
    public class UpdateUtils
    {

        /// <summary>
        /// Gets the latest version string from a server.
        /// </summary>
        /// <returns></returns>
        public static string UpdateString()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://pastebin.com/raw/02qyhKX7"); // retrieves the text from the server
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();

            return content; // returns it here.
        }


        public static string stableVer;
        public static string betaVer;
        public static string nightlyVer;
        public static void GetVersionString()
        {
            var json = UpdateStringBranch();
            dynamic jsonItems = JsonConvert.DeserializeObject(json);
            string stable = jsonItems.stable;
            string beta = jsonItems.beta;
            string nightly = jsonItems.nightly;
            stableVer = stable;
            betaVer = beta;
            nightlyVer = nightly;
        }

        public static string UpdateStringBranch()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://pastebin.com/SUXU9Wha"); // retrieves the text from the server
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();

            return content; // returns it here.
        }

        /// <summary>
        /// Send a messagebox if the version is up to date.
        /// </summary>
        public static void CheckForUpdates()
        {
            try
            {
                if (isUpToDate() == false)
                {
                    MessageBox.Show("There is a new update available! You can download it at: https://github.com/LiteTools/tag/" + UpdateString(), "Tasks");
                }
                  
                else
                    MessageBox.Show("There are no new updates.", "Tasks");
            }
            catch
            {
                MessageBox.Show("Unable to check for updates.", "Tasks");
            }
        }

        /// <summary>
        /// Checks if the string recieved is greater / less than the one hard-coded
        /// </summary>
        /// <returns></returns>
        public static bool isUpToDate()
        {
            if (betaVer == UpdateString() || nightlyVer == UpdateString() || stableVer == "4.0.2")
                return true;
            else
                return false;

        }

        /// <summary>
        /// Experimental: Downloads the latest version from GitHub releases.
        /// </summary>
        public static void InstallUpdate()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile("https://github.com/LiteTools/Tasks/releases/latest/Tasks.zip", "Tasks.zip");
                ZipFile.ExtractToDirectory("Tasks.zip", "../", true);
                File.Delete("Tasks.zip");
            }
        }
    }
}
