/*
    Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Tasks.Utils
{
    public class UpdateUtils
    {
        public static string stableVer; // Version number for stable.
        public static string betaVer; // Version number for beta.
        public static string nightlyVer; // Version number for nightly. (Might go as a different versioning method, idk)

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

        /// <summary>
        /// Retrieves all the version strings from the "server" and sets them to their designated variables.
        /// </summary>
        public static void GetVersionString()
        {
            var json = GetRawBranchJSON();
            dynamic jsonItems = JsonConvert.DeserializeObject(json);
            string stable = jsonItems.stable;
            string beta = jsonItems.beta;
            string nightly = jsonItems.nightly;
            stableVer = stable;
            betaVer = beta;
            nightlyVer = nightly;
        }

        /// <summary>
        /// Retrieves the raw JSON data on the branches so it works with GetVersionString()
        /// </summary>
        /// <returns></returns>
        public static string GetRawBranchJSON()
        {

            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://pastebin.com/raw/SUXU9Wha");
            StreamReader reader = new StreamReader(stream);
            String content = reader.ReadToEnd();
            return content;
        }

        /// <summary>
        /// Send a messagebox if the version is up to date.
        /// </summary>
        public static void CheckForUpdates()
        {
           GetVersionString(); // Must call this or else it doesn't work. (For whatever reason).
            try
            {
                if (isUpToDate() == false)
                {
                    MessageBox.Show("There is a new update available! You can download it at: https://github.com/LiteTools/tag/" + UpdateString(), "Tasks");  
                }      
                else
                {
                    MessageBox.Show("There are no new updates.", "Tasks");
                } 
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
            if (betaVer == UpdateString() || UpdateString() == nightlyVer || stableVer == "4.0.2")
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
