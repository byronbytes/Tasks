/*
    Tasks was developed by @byronbytes
    All rights reserved under the GNU General Public License v3.0.
*/

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
        

        public static string UpdateString2()
        {
            return "test";
        }

        /// <summary>
        /// Send a messagebox if the version is up to date.
        /// </summary>
        public static void CheckForUpdates()
        {
            try
            {
                if (isUpToDate() == false)
                    MessageBox.Show("There is a new update available! You can download it at: https://github.com/LiteTools/tag/" + UpdateString(), "Tasks");
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
            if (UpdateString() == "v5.0.0") // lazy coding, will fix.
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
