// (c) LiteTools 2021
// All rights reserved under the MIT license.

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
using System.Threading;
using System.Windows.Forms;
using ByteSizeLib;

namespace Tasks
{

    public partial class frmCleanup : Form
    {
        public frmCleanup() { InitializeComponent(); CheckTheme(); }

        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);
        enum RecycleFlag : int
        {
            SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying
            SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin
            SHERB_NOSOUND = 0x00000004 // No sound when the emptying of the recycle bin is complete
        }

        public void CheckTheme()
        {
            if (Properties.Settings.Default.Theme == "dark")
            {
                this.BackColor = Color.FromArgb(18, 18, 18);
                label1.ForeColor = Color.White;
                // Most of the stuff already goes back to default, no need to change everything again.
            }

            if (Properties.Settings.Default.Theme == "light")
            {
                this.BackColor = Color.FromArgb(250, 250, 250);
                cbChromeCache.ForeColor = Color.Black;
                cbChromeCookies.ForeColor = Color.Black;
                cbChromeSavedPasswords.ForeColor = Color.Black;
                cbChromeSearchHistory.ForeColor = Color.Black;
                cbChromeSessions.ForeColor = Color.Black;
                cbDiscord.ForeColor = Color.Black;
                cbEdgeCache.ForeColor = Color.Black;
                cbEdgeCookies.ForeColor = Color.Black;
                cbEdgeSearchHistory.ForeColor = Color.Black;
                cbEdgeSessions.ForeColor = Color.Black;
                cbExplorerDownloads.ForeColor = Color.Black;
                cbExplorerIconCache.ForeColor = Color.Black;
                cbExplorerRecents.ForeColor = Color.Black;
                cbExplorerThumbCache.ForeColor = Color.Black;
                cbFirefoxCache.ForeColor = Color.Black;
                cbFirefoxCookies.ForeColor = Color.Black;
                cbFirefoxSearchHistory.ForeColor = Color.Black;
                cbSystemARPCache.ForeColor = Color.Black;
                cbSystemDirectXCache.ForeColor = Color.Black;
                cbSystemDNSCache.ForeColor = Color.Black;
                cbSystemErrorReporting.ForeColor = Color.Black;
                cbSystemEventLogs.ForeColor = Color.Black;
                cbSystemMemDumps.ForeColor = Color.Black;
                cbSystemPrefetch.ForeColor = Color.Black;
                cbSystemRecycleBin.ForeColor = Color.Black;
                cbSystemTempFolders.ForeColor = Color.Black;


                tabPage1.BackColor = Color.White;
                tabPage3.BackColor = Color.White;
                tabPage4.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;
                label10.ForeColor = Color.Black;
                label14.ForeColor = Color.DarkRed;
                label15.ForeColor = Color.Black;
                label16.ForeColor = Color.Black;
                label17.ForeColor = Color.DarkRed;
                label18.ForeColor = Color.Black;
                comboBox1.BackColor = Color.Gray;
                ExtensionsBox.BackColor = Color.White;
                ExtensionsBox.ForeColor = Color.Black;
                textBox1.BackColor = Color.Gray;
                textBox1.ForeColor = Color.Black;

            }
        }

        private bool DeleteAllFiles(DirectoryInfo directoryInfo)
        {

            foreach (var file in directoryInfo.GetFiles())
            {
                try
                {
                    file.Delete();
                    CleanupLogsLBox.Items.Add("Deleted " + file.FullName);
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Exception: " + ex.Message);
                }

            }
            foreach (var dir in directoryInfo.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                    CleanupLogsLBox.Items.Add("Deleted Folder " + dir.FullName);
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Exception: " + ex.Message);
                }

            }

            return true;
        }

        public void WriteCleanupSummary()
        {
            int t = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            File.WriteAllLines(
              Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks"), "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt",
              CleanupLogsLBox.Items.Cast<string>().ToArray()
            );

            if (Properties.Settings.Default.CleanupMessageBox == true)
            {
                MessageBox.Show("Cleanup has been logged to: " + Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "Tasks") + "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt", "Tasks");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // List our local directories.
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
            var usertemp = new DirectoryInfo(Path.GetTempPath());
            var downloads = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");


            if (cbExplorerDownloads.Checked)
                try
                {
                    if (DeleteAllFiles(downloads)) CleanupLogsLBox.Items.Add("Downloads Folder Cleared.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error deleting the Downloads Folder. " + ex);
                }

            if (cbSystemRecycleBin.Checked)
                try
                {
                    // Silently deletes the recycle bin.
                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                    CleanupLogsLBox.Items.Add("Recycle Bin Cleared.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error clearing the Recycle Bin. " + ex);

                }


            if (cbSystemTempFolders.Checked)
            {
                try
                {
                    if (DeleteAllFiles(windowstemp)) CleanupLogsLBox.Items.Add("System Temp Folder Deleted.");
                    if (DeleteAllFiles(usertemp)) CleanupLogsLBox.Items.Add("User Temp Folder Deleted.");

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while deleting temp folders. " + ex);
                }

            }

            if (cbSystemPrefetch.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo("C:\\Windows\\Prefetch");
                    if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Prefetch Deleted.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while deleting Prefetch. " + ex);
                }
            }


            if (cbChromeCache.Checked)
            {
                try
                {
                    string mainSubdirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\";
                    string[] userDataCacheDirs = { "Default\\Cache", "Default\\Code Cache\\", "Default\\GPUCache", "ShaderCache", "Default\\Service Worker\\CacheStorage", "Default\\Service Worker\\ScriptCache", "GrShaderCache\\GPUCache", "\\Default\\File System\\", "\\Default\\JumpListIconsMostVisited\\", "\\Default\\JumpListIconsRecentClosed\\", "Default\\Service Worker\\Database" };
                    List<DirectoryInfo> directoryInfos = new List<DirectoryInfo>();

                    foreach (string subdir in userDataCacheDirs)
                    {
                        // Make a new DirectoryInfo with the info of that subdirectory and then add it into the directoryInfos array
                        directoryInfos.Add(new DirectoryInfo(mainSubdirectory + subdir + "\\"));

                    }

                    bool isDeleted = true;
                    // For each DirectoryInfo inside of the directoryInfos array
                    foreach (DirectoryInfo d in directoryInfos)
                    {
                        try
                        {
                            DeleteAllFiles(d);
                        }
                        catch (Exception ex)
                        {
                            CleanupLogsLBox.Items.Add("Error deleting Chrome Cache. " + ex);
                        }

                        // If DeleteAllFiles returns false, set the isDeleted value to false
                        if (!DeleteAllFiles(d))
                            isDeleted = false;
                    }

                    if (isDeleted)
                        CleanupLogsLBox.Items.Add("Chrome Cache Deleted.");
                }
                catch (Exception)
                {

                }
            }

            if (cbChromeSessions.Checked)
            {

                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Sessions");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Session Storage");
                var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extension State");
                if (DeleteAllFiles(directory) & DeleteAllFiles(directory2) & DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Chrome Sessions Deleted.");
            }

            if (cbChromeCookies.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\IndexedDB\\");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies-journal");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Cookies Deleted.");
            }


            if (cbChromeSearchHistory.Checked)
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History Provider Cache");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History-journal");
                CleanupLogsLBox.Items.Add("Chrome Search History Deleted.");
            }


            if (cbDiscord.Checked)
            {
                try
                {

                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Cookies");
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Cookies-journal");
                    CleanupLogsLBox.Items.Add("Discord Cookies Deleted.");

                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Cache");
                    var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Code Cache");
                    var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\GPUCache");
                    if (DeleteAllFiles(directory) & DeleteAllFiles(directory2) & DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Discord Cache Deleted.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error deleting Discord Cache." + ex);
                }

            }

            if (cbFirefoxCache.Checked)
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
                                    CleanupLogsLBox.Items.Add("Firefox Cache Deleted.");
                                }
                                catch (Exception ex)
                                {
                                    CleanupLogsLBox.Items.Add("Exception Error: " + ex);
                                }

                            }
                            foreach (string dir in Directory.EnumerateDirectories(cachefile))
                            {
                                try
                                {
                                    Directory.Delete(dir, true);
                                    CleanupLogsLBox.Items.Add("Firefox Cache Deleted.");
                                }
                                catch (Exception ex)
                                {
                                    CleanupLogsLBox.Items.Add("Exception Error:" + ex);
                                }

                            }
                        }
                    }
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
                                            CleanupLogsLBox.Items.Add("Deleted File: " + file);
                                        }
                                        catch
                                        {
                                            //do nothing
                                        }

                                    }

                                }
                                catch
                                {
                                    //do nothing
                                }

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        CleanupLogsLBox.Items.Add("Error trying to delete Firefox Shader Cache. " + ex);
                    }

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error trying to delete firefox cache. " + ex);
                }



            }

            if (cbFirefoxCookies.Checked)
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
                                CleanupLogsLBox.Items.Add("Firefox Cookies Deleted.");

                            }
                            catch (Exception ex)
                            {

                                CleanupLogsLBox.Items.Add("Error while trying to delete Firefox cookies. " + ex);
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while trying to delete Firefox cookies. " + ex);
                }


            }
            if (cbFirefoxSearchHistory.Checked)
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
                                CleanupLogsLBox.Items.Add("Firefox History Deleted.");

                            }
                            catch (Exception ex)
                            {

                                CleanupLogsLBox.Items.Add("Error while trying to delete Firefox History." + ex);

                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error when trying to delete Firefox History. " + ex);
                }
            }

            if (cbSystemDNSCache.Checked)
            {
                try
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c ipconfig /flushdns";
                    startInfo.RedirectStandardError = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    CleanupLogsLBox.Items.Add("DNS Cache Cleared.");
                }
                catch (Exception ex)
                {

                    CleanupLogsLBox.Items.Add("Error while trying to clear DNS cache." + ex);

                }
            }
            if (cbSystemARPCache.Checked)
            {
                try
                {
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Verb = "runas"; //give cmd admin perms
                    startInfo.UseShellExecute = true;
                    startInfo.Arguments = @"/C arp -a -d";
                    process.StartInfo = startInfo;
                    process.Start();
                    CleanupLogsLBox.Items.Add("ARP Cache Cleared.");
                }
                catch (Exception ex)
                {

                    CleanupLogsLBox.Items.Add("Error while trying to clear ARP cache. " + ex);
                    MessageBox.Show(ex.ToString());

                }
            }

            if (cbExplorerRecents.Checked)
            {
                try
                {
                    CleanRecentFiles.CleanRecents.ClearAll();
                    CleanupLogsLBox.Items.Add("Recent Files Cleared.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while clearing Recent Files. " + ex);
                }

            }


            if (cbEdgeSearchHistory.Checked)
            {

                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\History");
                CleanupLogsLBox.Items.Add("Edge Search History Deleted.");
            }
            if (cbEdgeCookies.Checked)
            {

                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cookies");
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\IndexedDB\\");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Edge Cookies Deleted.");
            }

            if (cbEdgeCache.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cache\\");
                    var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Code Cache\\");
                    var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\GPUCache\\");
                    var directory4 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\ShaderCache\\");
                    var directory5 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Service Worker\\CacheStorage\\");
                    var directory6 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Service Worker\\ScriptCache\\");
                    var directory7 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\GrShaderCache\\GPUCache\\");
                    var directory8 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Service Worker\\Database\\");
                    if (DeleteAllFiles(directory) & DeleteAllFiles(directory2) & DeleteAllFiles(directory3) & DeleteAllFiles(directory4) & DeleteAllFiles(directory5) & DeleteAllFiles(directory6) & DeleteAllFiles(directory7) & DeleteAllFiles(directory8)) CleanupLogsLBox.Items.Add("Edge Cache Deleted.");
                }
                catch
                {
                    CleanupLogsLBox.Items.Add("Error while deleting Edge Cache.");
                }
            }

            if (cbSystemEventLogs.Checked)
            {
                try
                {
                    foreach (var eventLog in EventLog.GetEventLogs())
                    {
                        eventLog.Clear();
                        CleanupLogsLBox.Items.Add("Event Logs Deleted.");
                    }
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error deleting Event Logs. " + ex);
                }


            }

            if (cbEdgeSessions.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Sessions");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Session Storage");
                var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Extension State");
                if (DeleteAllFiles(directory) & DeleteAllFiles(directory2) & DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Edge Session Deleted.");
            }

            if (cbSystemDirectXCache.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\D3DSCache");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("DirectX Shader Cache Deleted.");
            }

            if (cbSystemMemDumps.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\CrashDumps\\");
                    var directory2 = new DirectoryInfo("C:\\Windows\\MiniDump\\");
                    File.Delete("C:\\Windows\\MEMORY.DMP");
                    if (DeleteAllFiles(directory) & DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("System Memory Dumps Deleted.");
                }
                catch
                {
                    CleanupLogsLBox.Items.Add("Error Deleting System Memory Dumps.");
                }
             
            }


            if (cbSystemErrorReporting.Checked)
            {
                var directory = new DirectoryInfo("C:\\ProgramData\\Microsoft\\Windows\\WER\\ReportArchive");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Deleted " + directory);
            }

            if (cbExplorerThumbCache.Checked)
            {

                var tc = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Windows\\Explorer\\");
                foreach (string file in Directory.EnumerateFiles(tc))

                    if (file.Contains("thumbcache") == true)
                    {
                        try
                        {
                            File.Delete(file);
                            CleanupLogsLBox.Items.Add("Deleted " + file);
                        }
                        catch (Exception)
                        {
                            CleanupLogsLBox.Items.Add("Could not delete " + file);
                        }

                    }
            }

            if (cbExplorerIconCache.Checked)
            {
                var ic = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Windows\\Explorer\\");
                foreach (string file in Directory.EnumerateFiles(ic))

                    if (file.Contains("iconcache") == true)
                    {
                        try
                        {
                            File.Delete(file);
                            CleanupLogsLBox.Items.Add("Deleted " + file);
                        }
                        catch (Exception)
                        {
                            CleanupLogsLBox.Items.Add("Could not delete " + file);
                        }

                    }
            }

            if (cbChromeSavedPasswords.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Login Data\\");
                    if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Saved Passwords Deleted.");
                }
                catch
                {
                    CleanupLogsLBox.Items.Add("Error while deleting Chrome Saved Passwords.");
                }

            }

            if (cbIECache.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Windows\\INetCache\\IE\\");
                    var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Windows\\WebCache.old\\");
                    if (DeleteAllFiles(directory) & DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("Internet Explorer Cache Deleted.");
                }
                catch
                {
                    CleanupLogsLBox.Items.Add("Error while deleting Internet Explorer Cache.");
                }

            }

            if (cbWindowsLogFiles.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo("C:\\WINDOWS\\Logs\\MeasuredBoot");
                    var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\CLR_v4.0\\UsageLogs");
                    if (DeleteAllFiles(directory) & DeleteAllFiles(directory2)) CleanupLogsLBox.Items.Add("Windows Log Files Deleted.");
                }
                catch
                {
                    CleanupLogsLBox.Items.Add("Error while deleting Windows Log Files.");
                }

            }
            
            if (cbSpotifyCache.Checked)
           {
           
           try
            {
           
            }
           catch
            {
           
            }
           
           }



            WriteCleanupSummary();

            // END OF CLEANUP.

        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Browser Extensions") // i dont want it to show up in the extensions thing because i'll use a diff button to make the code less messy
            {
                btnCleanup.Visible = false;

            }
            else
            {
                if (!btnCleanup.Visible)
                {
                    btnCleanup.Visible = true;

                }
            }
        }
        private void frmCleanup_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            DirectoryExists();
            CheckTheme();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "Scripts/BatFiles/displaydns.bat";
                process.Start();
                //Directory.SetCurrentDirectory(@"/");
                //Directory.SetCurrentDirectory(@"Scripts/BatFiles");
                //Process.Start("displaydns.bat");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e) //DisplayARP
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "Scripts/BatFiles/displayarp.bat";
                process.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }

        }
        private void GetExtensionList(DirectoryInfo directoryInfo)
        {
            foreach (var ext in directoryInfo.GetDirectories())

            {

                FileInfo fi = new FileInfo(ext.ToString());
                ListViewItem extb = ExtensionsBox.Items.Add(fi.Name, 0);

                long dirSize = DirSize(new DirectoryInfo(ext.ToString()));
                double dirsizeMB = ConvertBytesToMegabytes(dirSize);
                extb.SubItems.Add("~ " + dirsizeMB + "MB");
                extb.SubItems.Add(ext.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var g = new Dirs();

            if (comboBox1.Text == "Google Chrome")
            {
                ExtensionsBox.Items.Clear();

                GetExtensionList(new DirectoryInfo(Dirs.chromeExtDir));


            }
            else if (comboBox1.Text == "Mozilla Firefox")
            {
                ExtensionsBox.Items.Clear();
                try
                {
                    foreach (string fol in Directory.EnumerateDirectories(Dirs.firefoxExtDir))
                    {
                        if (fol.Contains("-release"))
                        {
                            string prf = (fol + "\\extensions\\");
                            try
                            {
                                GetExtensionList(new DirectoryInfo(Dirs.firefoxExtDir));

                            }
                            catch (Exception Exc)
                            {
                                MessageBox.Show(Exc.ToString());
                            }
                        }
                    }

                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.ToString());
                }

            }

            else if (comboBox1.Text == "Microsoft Edge")
            {
                ExtensionsBox.Items.Clear();

                GetExtensionList(new DirectoryInfo(Dirs.edgeExtDir));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ExtensionsBox.SelectedItems.Count >= 0) //Check if the user selected extensions for deletion.
                {

                if (comboBox1.Text == "Google Chrome")
                {
                    Remove.KillBrowser(1);
                    Thread.Sleep(75);

                    foreach (ListViewItem eachItem in ExtensionsBox.SelectedItems)
                    {
                        try
                        {
                            var item = ExtensionsBox.SelectedItems[0];
                            var subItem = item.SubItems[2].Text;
                            Remove.DeleteExtension(subItem, false);
                            ExtensionsBox.Items.Remove(eachItem);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while trying to remove extension." + ex);
                        }
                    }
                }

                if (comboBox1.Text == "Mozilla Firefox")
                {
                    Remove.KillBrowser(2);
                    Thread.Sleep(75); //Short threadsleep or else the extension deleter would start before firefox is fully killed for some reasons?

                    try
                    {
                        Remove.DeleteExtension(ExtensionsBox.SelectedItems[0].SubItems[2].Text, true);

                        foreach (ListViewItem eachItem in ExtensionsBox.SelectedItems)
                        {
                            ExtensionsBox.Items.Remove(eachItem);
                            CleanupLogsLBox.Items.Add("Extension Removed.");
                        }
                    }
                    catch
                    {
                        CleanupLogsLBox.Items.Add("Failed to remove extension.");

                    }

                }


                if (comboBox1.Text == "Microsoft Edge")
                {
                   Remove.KillBrowser(3);
                   Thread.Sleep(75);
                   
                     foreach (ListViewItem eachItem in ExtensionsBox.SelectedItems)
                    {
                        try
                        {       
                            var item = ExtensionsBox.SelectedItems[0];
                            var subItem = item.SubItems[2].Text;
                            Remove.DeleteExtension(subItem, false);
                            ExtensionsBox.Items.Remove(eachItem);
                            CleanupLogsLBox.Items.Add("Extension Removed.");

                        }
                        catch (Exception ex)
                        {
                            CleanupLogsLBox.Items.Add("Error while trying to remove extension." + ex);
                        }
                    }
                }

            }

            else
            {
                MessageBox.Show("Please select an extension to remove.");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { RunFile.RunBat("Scripts/BatFiles/byesolitaire.bat", true); }
            catch (Exception ex) { MessageBox.Show("An error occurred." + ex); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try { Process.Start("powershell", "-ExecutionPolicy Bypass -File Scripts/Debloater/DisableCortana.ps1"); }
            catch (Exception ex) { MessageBox.Show("An error occurred." + ex); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try { Process.Start("powershell", "-ExecutionPolicy Bypass  -File Scripts/Debloater/UninstallOneDrive.ps1"); }
            catch (Exception ex) { MessageBox.Show("An error occurred." + ex); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { RunFile.RunBat("Scripts/BatFiles/removeedge.bat", true); }
            catch (Exception ex) { MessageBox.Show("An error occurred." + ex); }
        }
        


        private void DirectoryExists()
        {
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Dirs.chromeDir = localappdata + "\\Google\\Chrome\\";
            Dirs.chromeExtDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions");
            Dirs.firefoxDir = localappdata + "\\Mozilla\\Firefox\\";
            Dirs.firefoxExtDir = roamingappdata + "\\Mozilla\\Firefox\\Profiles\\";
            Dirs.edgeDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\");
            Dirs.edgeExtDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Extensions\\");
            Dirs.discordDir = localappdata + "\\Discord\\";

            if (!Directory.Exists(Dirs.chromeDir))
            {
                cbChromeCache.Enabled = false;
                cbChromeCookies.Enabled = false;
                cbChromeSearchHistory.Enabled = false;
                cbChromeSessions.Enabled = false;
                cbChromeSavedPasswords.Enabled = false;
            }

            if (!Directory.Exists(Dirs.firefoxDir))
            {
                cbFirefoxCache.Enabled = false;
                cbFirefoxCookies.Enabled = false;
                cbFirefoxSearchHistory.Enabled = false;
            }

            if (!Directory.Exists(Dirs.discordDir))
            {
                cbDiscord.Enabled = false;
            }

            if (!Directory.Exists(Dirs.edgeDir))
            {
                cbEdgeCache.Enabled = false;
                cbEdgeCookies.Enabled = false;
                cbEdgeSearchHistory.Enabled = false;
                cbEdgeSessions.Enabled = false;

            }

            // Extention Finder & More
            if (Directory.Exists(Dirs.chromeExtDir))
            {
                comboBox1.Items.Add("Google Chrome");
            }

            if (Directory.Exists(Dirs.firefoxDir))
            {
                comboBox1.Items.Add("Mozilla Firefox");
            }

            if (Directory.Exists(Dirs.edgeDir))
            {
                comboBox1.Items.Add("Microsoft Edge");
            }
        }

        private void cbEdgeCookies_CheckStateChanged(object sender, EventArgs e)
        {
            try { taskDialog1.Show(); }
            catch { Console.WriteLine("An error has occurred."); }
        }
        private void cbFirefoxCookies_CheckStateChanged(object sender, EventArgs e)
        {
            try { taskDialog1.Show(); }
            catch { Console.WriteLine("An error has occurred."); }
        }

        private void cbChromeCookies_CheckStateChanged(object sender, EventArgs e)
        {
            try { taskDialog1.Show(); }
            catch { Console.WriteLine("An error has occurred."); }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (Directory.Exists(Dirs.chromeDir)) // Would be used to imploment a Browser Cache for Quick Clean.
            {
                long size5 = DirSize(new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\"));

            }

            label11.Visible = true;
            button9.Visible = true;
            label13.Visible = true;
            label19.Visible = true;
            long size1 = DirSize(new DirectoryInfo("C:\\Windows\\Temp"));
            progressBar1.PerformStep();
            long size2 = DirSize(new DirectoryInfo(Path.GetTempPath()));
            progressBar1.PerformStep();
            long size3 = DirSize(new DirectoryInfo((Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\D3DSCache\\")));
            progressBar1.PerformStep();
            long size4 = DirSize(new DirectoryInfo(("C:\\ProgramData\\Microsoft\\Windows\\WER\\ReportArchive\\  ")));
            progressBar1.PerformStep();


            long allsize = size1 + size2 + size3 + size4;
            long tempsize = size1 + size2;
            long systemsize = size3 + size4;
            
            // Conversion stuff
            double allsizeMB = ConvertBytesToMegabytes(allsize);
            progressBar1.PerformStep();
            double tempsizeMB = ConvertBytesToMegabytes(tempsize);
            progressBar1.PerformStep();
            double systemsizeMB = ConvertBytesToMegabytes(systemsize);
            progressBar1.PerformStep();
            label11.Text = "Quick Clean can delete " + allsizeMB + "MB of temp files.";
            label13.Text = tempsizeMB + "MB";
            label19.Text = systemsizeMB + "MB";
        }

        public static long DirSize(DirectoryInfo d)
        {

            long size = 0;
            // Add file sizes.
            try
            {
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
                return size;
            }
            catch
            {
            // Needs a more advanced catch method.
                return size;
            }
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            double ConvertedByte = Math.Round(bytes / 1024f / 1024f, 2);
            return (ConvertedByte);
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
            var usertemp = new DirectoryInfo(Path.GetTempPath());
            try
            {
                if (DeleteAllFiles(windowstemp)) TasksDebug.Null();
                if (DeleteAllFiles(usertemp)) TasksDebug.Null(); 
            }
            catch
            {

            }
        
        }
    }
}

