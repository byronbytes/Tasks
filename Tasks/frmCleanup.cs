using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class frmCleanup : Form
    {
        public frmCleanup()
        {
            InitializeComponent();
        }

        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);
        enum RecycleFlag : int
        {
            SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying
            SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin
            SHERB_NOSOUND = 0x00000004 // No sound when the emptying of the recycle bin is complete
        }



        private bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {
            try
            {
                foreach (var file in directoryInfo.GetFiles())
                {
                    file.Delete();
                    CleanupLogsLBox.Items.Add("Deleted File " + file.FullName);
                }

                foreach (var dir in directoryInfo.GetDirectories())
                {
                    dir.Delete(true);
                    CleanupLogsLBox.Items.Add("Deleted Folder " + dir.FullName);
                }

                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is DirectoryNotFoundException || ex is UnauthorizedAccessException || ex is SecurityException)
            {
                CleanupLogsLBox.Items.Add("Exception Error: " + ex.Message);
            }

            return false;
        }

        private void btnCleanup_Click(object sender, EventArgs e)
        {
            // Note to self, change the exception error message,

            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (checkBox1.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Downloads Folder Cleaned.");
            }

            if (checkBox2.Checked)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                CleanupLogsLBox.Items.Add("Recycle Bin Cleaned.");
            }

            if (checkBox3.Checked)
            {
                var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
                var usertemp = new DirectoryInfo(Path.GetTempPath());

                if (DeleteAllFiles(windowstemp)) CleanupLogsLBox.Items.Add("System Temp Folder Cleaned.");
                if (DeleteAllFiles(usertemp)) CleanupLogsLBox.Items.Add("User Temp Folder Cleaned.");
            }

            if (checkBox4.Checked)
            {
                var directory = new DirectoryInfo("C:\\Windows\\Prefetch");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Prefetch Cleaned.");
            }

            // Chrome

            if (checkBox5.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Code Cache");
                var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\GPUCache");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Cache Cleaned.");
                if (DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("Chrome Code Cache Cleaned.");
                if (DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Chrome GPU Cache Cleaned.");
            }

            if (checkBox6.Checked)
            {

                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Sessions");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Session Storage");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Session Cleaned.");
                if (DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("Chrome Session Storage Cleaned.");
            }

            if (checkBox7.Checked)
            {

                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies-journal");
                CleanupLogsLBox.Items.Add("Chrome Cookies Cleaned.");
            }


            if (checkBox8.Checked)
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History Provider Cache");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History-journal");
                CleanupLogsLBox.Items.Add("Chrome Search History Cleaned.");
            }

            if (checkBox13.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Crashpad");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Crashdumps Cleaned.");
            }

            // Discord

            if (checkBox9.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Cache");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Code Cache");
                var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\GPUCache");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Discord Cache Cleaned.");
                if (DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("Discord Code Cache Cleaned.");
                if (DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Discord GPU Cache Cleaned.");
            }

            if (checkBox10.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Crashpad\\reports");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Discord Crashdumps Cleaned.");
            }


            // Steam

            if (checkBox11.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Steam\\htmlcache\\Cache");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Steam\\htmlcache\\Code Cache");
                var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Steam\\htmlcache\\GPUCache");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Steam Cache Cleaned.");
                if (DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("Steam Code Cache Cleaned.");
                if (DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Steam GPU Cache Cleaned.");
            }


            //Firefox

            if (checkBox14.Checked)
            {
                try
                {

                    var cache = (localappdata + "\\Mozilla\\Firefox\\Profiles\\");
                    foreach (string direc in Directory.EnumerateDirectories(cache))
                    {
                        if (direc.Contains("release") == true)
                        {
                            var cachefile = (direc + "\\cache2");
                            foreach (string file in Directory.EnumerateFiles(cachefile))
                            {
                                try
                                {
                                    File.Delete(file);
                                    CleanupLogsLBox.Items.Add("Firefox Cache Cleaned.");
                                }
                                catch (Exception exc)
                                {
                                    CleanupLogsLBox.Items.Add("Exception Error: " + exc);
                                }

                            }
                            foreach (string dir in Directory.EnumerateDirectories(cachefile))
                            {
                                try
                                {
                                    Directory.Delete(dir, true);
                                    CleanupLogsLBox.Items.Add("Firefox Cache Cleaned.");
                                }
                                catch (Exception exc)
                                {
                                    CleanupLogsLBox.Items.Add("Exception Error:" + exc);
                                }

                            }
                        }
                    }

                }
                catch (Exception exc)
                {
                    CleanupLogsLBox.Items.Add("Error when trying to clean firefox cache! \n" + exc);
                }



            }

            if (checkBox15.Checked)
            {
                try
                {
                    var cookies = (roamingappdata + "\\Mozilla\\Firefox\\Profiles\\");
                    foreach (string direc in Directory.EnumerateDirectories(cookies))
                    {
                        if (direc.Contains("release") == true)
                        {
                            try
                            {
                                var cookiefile = (direc + "\\cookies.sqlite");
                                File.Delete(cookiefile);
                                CleanupLogsLBox.Items.Add("Firefox Cookies Cleaned.");

                            }
                            catch (Exception exc)
                            {

                                //do nothing

                            }

                        }
                    }

                }
                catch (Exception exc)
                {
                    CleanupLogsLBox.Items.Add("Error when trying to delete Firefox cookies! \n" + exc);
                }


            }
            if (checkBox16.Checked)
            {
                try
                {

                    var cookies = (roamingappdata + "\\Mozilla\\Firefox\\Profiles\\");
                    foreach (string direc in Directory.EnumerateDirectories(cookies))
                    {
                        if (direc.Contains("release") == true)
                        {
                            try
                            {
                                var cookiefile = (direc + "\\places.sqlite");
                                File.Delete(cookiefile);
                                CleanupLogsLBox.Items.Add("Firefox History Cleaned.");

                            }
                            catch (Exception exc)
                            {

                                //do nothing

                            }

                        }
                    }

                }
                catch (Exception exc)
                {
                    CleanupLogsLBox.Items.Add("Error when trying to delete Firefox History! \n" + exc);
                }
            }

            if (checkBox18.Checked)
            {
                try
                {

                    var profile = (roamingappdata + "\\Mozilla\\Firefox\\Profiles\\");
                    foreach (string direc in Directory.EnumerateDirectories(profile))
                    {
                        if (direc.Contains("release") == true)
                        {
                            try
                            {
                                var shadercache = (direc + "\\shader-cache");
                                foreach (string file in Directory.EnumerateFiles(shadercache))
                                {
                                    try
                                    {
                                        File.Delete(file);
                                        CleanupLogsLBox.Items.Add("Firefox Shader Cache File " + file + " Removed.");
                                    }
                                    catch (Exception exc)
                                    {
                                        //do nothing
                                    }

                                }

                            }
                            catch (Exception exc)
                            {

                                //do nothing

                            }

                        }
                    }

                }
                catch (Exception exc)
                {
                    CleanupLogsLBox.Items.Add("Error while trying to delete Firefox Shader Cache! \n" + exc);
                }
            }

            //DNS & ARP
            if (checkBox19.Checked)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c ipconfig /flushdns";
                    startInfo.RedirectStandardError = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    CleanupLogsLBox.Items.Add("DNS Cache Cleared.");
                }
                catch (Exception esc)
                {

                    CleanupLogsLBox.Items.Add("Error while trying to clear DNS cache! \n" + esc);

                }
            }
            if (checkBox20.Checked)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Verb = "runas"; //give cmd admin perms
                    startInfo.UseShellExecute = true;
                    startInfo.Arguments = @"/C arp -a -d";
                    process.StartInfo = startInfo;
                    process.Start();
                    CleanupLogsLBox.Items.Add("ARP Cache Cleared.");
                }
                catch (Exception esc)
                {

                    CleanupLogsLBox.Items.Add("Error while trying to clear ARP cache! \n" + esc);
                    MessageBox.Show(esc.ToString());

                }
            }

            //DNS & ARP

            //FILES

            if (checkBox21.Checked)
            {
                CleanRecentFiles.CleanRecents.ClearAll();
                CleanupLogsLBox.Items.Add("Recent Files Cleared.");
            }

            if (checkBox17.Checked)
            {
                try
                {

                    var imgs = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                    foreach (string file in Directory.EnumerateFiles(imgs))
                    {
                        try
                        {

                            File.Delete(file);
                            CleanupLogsLBox.Items.Add(file + " Deleted!");

                        }
                        catch(Exception esc)
                        {

                            CleanupLogsLBox.Items.Add("Failed to delete file" + file + " " + esc);

                        }

                    }
                    foreach (string file in Directory.EnumerateDirectories(imgs))
                    {
                        try
                        {

                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(file);

                            dir.Delete(true);
                            CleanupLogsLBox.Items.Add(file + " Deleted!");

                        }
                        catch (Exception esc)
                        {

                            CleanupLogsLBox.Items.Add("Failed to delete directory" + file + " " + esc);

                        }

                    }
                    CleanupLogsLBox.Items.Add("Cleared images folder successfully.");

                }
                catch(Exception esc)
                {
                    CleanupLogsLBox.Items.Add("Failed to clear images folder " + esc);
                }



            }
            if (CleanupLogsLBox.Items.Count > 2) btnCopyLogs.Enabled = true;
        }


        private void btnCopyLogs_Click(object sender, EventArgs e)
        {
            CleanupLogsLBox.Items.Add("Cleanup logs copied to clipboard.");
            Clipboard.SetText(string.Join("\n", CleanupLogsLBox.Items.Cast<string>()));
        }
        private void frmCleanup_Load(object sender, EventArgs e)
        {

        }



        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            taskDialog1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Browser #1")
            {
                listBox1.Items.Add("Extention #1");
            }else
            {
                //wip
            }
        
        }

        private void button1_Click(object sender, EventArgs e) //DISPLAYDNS
        {

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "BatFiles/displaydns.bat";
                process.Start();
                //Directory.SetCurrentDirectory(@"/");
                //Directory.SetCurrentDirectory(@"BatFiles");
                //Process.Start("displaydns.bat");
            }
            catch (Exception esc)
            {

                MessageBox.Show(esc.ToString());

            }

        }

        private void button2_Click(object sender, EventArgs e) //displayarp
        {


            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "BatFiles/displayarp.bat";
                process.Start();
            }
            catch (Exception esc)
            {

                MessageBox.Show(esc.ToString());

            }



        }
    }
}
    

