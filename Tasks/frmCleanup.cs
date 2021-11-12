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

namespace Tasks {
    public partial class frmCleanup : Form {
        public frmCleanup() { InitializeComponent(); }

        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);
        enum RecycleFlag : int {
            SHERB_NOCONFIRMATION = 0x00000001,  // No confirmation, when emptying
            SHERB_NOPROGRESSUI = 0x00000001,    // No progress tracking window during the emptying of the recycle bin
            SHERB_NOSOUND = 0x00000004          // No sound when the emptying of the recycle bin is complete
        }
        
        private bool DeleteAllFiles(DirectoryInfo[] directoryInfos, bool condition) {
            if (condition)
                foreach(dirInfo in directoryInfos) {
                    foreach (var file in dirInfo.GetFiles())
                        try { file.Delete(); CleanupLogsLBox.Items.Add("Deleted " + file.FullName); }
                        catch (Exception ex) { CleanupLogsLBox.Items.Add("Exception: " + ex.Message); }
                    
                    foreach (var dir in dirInfo.GetDirectories())
                        try { dir.Delete(true); CleanupLogsLBox.Items.Add("Deleted Folder " + dir.FullName); }
                        catch (Exception ex) { CleanupLogsLBox.Items.Add("Exception: " + ex.Message); }
                }
            
            return condition;
        }



        private void btnCleanup_Click(object sender, EventArgs e) {
            var _up             = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            
            var chrome_ud_nodef = _up + "\\AppData\\Local\\Google\\Chrome\\User Data\\";
            var chrome_ud       = chrome_ud_nodef + "Default\\";
            var discord         = _up + "\\AppData\\Roaming\\discord";
            var edge_ud_nodef   = _up + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\";
            var edge_ud         = edge_ud_nodef + "Default\\";
            
            var localappdata    = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata  = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var temp            = { new DirectoryInfo(Path.GetTempPath()), new DirectoryInfo("C:\\Windows\\Temp") };
            var downloads       = { new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads") };
            var prefetch        = { new DirectoryInfo("C:\\Windows\\Prefetch") };
            
            var chrome_cache    = {
                new DirectoryInfo(chrome_ud + "Cache"),
                new DirectoryInfo(chrome_ud + "Code Cache"),
                new DirectoryInfo(chrome_ud + "GPUCache"),
                new DirectoryInfo(chrome_ud_nodef + "ShaderCache"),
                new DirectoryInfo(chrome_ud + "Service Worker\\CacheStorage"),
                new DirectoryInfo(chrome_ud + "Service Worker\\ScriptCache"),
                new DirectoryInfo(chrome_ud_nodef + "GrShaderCache\\GPUCache"),
                new DirectoryInfo(chrome_ud + "File System")
            };
            var chrome_sessions = { new DirectoryInfo(chrome_ud + "Sessions"), new DirectoryInfo(chrome_ud + "Session Storage"), new DirectoryInfo(chrome_ud + "Extension State") };
            var chrome_cookies  = { new DirectoryInfo(chrome_ud + "IndexedDB"), new DirectoryInfo(chrome_ud + "Cookies"), new DirectoryInfo(chrome_ud + "Cookies-journal") };
            var chrome_history  = { new DirectoryInfo(chrome_ud + "History"), new DirectoryInfo(chrome_ud + "History Provider Cache"), new DirectoryInfo(chrome_ud + "History-journal") };
            var chrome_ld       = { new DirectoryInfo(_up + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Login Data\\") };
            var discord_cache   = { new DirectoryInfo(discord + "Cache"), new DirectoryInfo(discord + "Code Cache"), new DirectoryInfo(discord + "GPUCache") };
            var discord_cookies = { new DirectoryInfo(discord + "Cookies"), new DirectoryInfo(discord + "Cookies-journal") };
            var edge_history    = { new DirectoryInfo(edge_ud + "History") };
            var edge_cache      = {
                new DirectoryInfo(edge_ud + "Cache\\");
                new DirectoryInfo(edge_ud + "Code Cache\\");
                new DirectoryInfo(edge_ud + "GPUCache\\");
                new DirectoryInfo(edge_ud_nodef + "ShaderCache\\");
                new DirectoryInfo(edge_ud + "Service Worker\\CacheStorage\\");
                new DirectoryInfo(edge_ud + "Service Worker\\ScriptCache\\");
                new DirectoryInfo(edge_ud_nodef + "GrShaderCache\\GPUCache\\");
                new DirectoryInfo(edge_ud + "Service Worker\\Database\\");
            };
            var edge_cookies    = { new DirectoryInfo(edge_ud + "Cookies"), new DirectoryInfo(edge_ud + "IndexedDB") };
            var edge_session    = { new DirectoryInfo(edge_ud + "Sessions"), new DirectoryInfo(edge_ud + "Default\\Session Storage"), new DirectoryInfo(edge_ud + "Default\\Extension State") };
            var dxcache         = {
                new DirectoryInfo(_up + "\\AppData\\Local\\D3DSCache")
            };
            
            if (cbSystemRecycleBin.Checked) {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                CleanupLogsLBox.Items.Add("Recycle Bin Cleared.");
            }
            
            if (DeleteAllFiles(downloads, cbExplorerDownloads.Checked)) CleanupLogsLBox.Items.Add("Downloads Folder Cleared.");
            if (DeleteAllFiles(temp, cbSystemTempFolders.Checked)) CleanupLogsLBox.Items.Add("Temp Folder Cleaned.");
            if (DeleteAllFiles(prefetch, cbSystemPrefetch.Checked)) CleanupLogsLBox.Items.Add("Prefetch Cleaned.");
            
            // Chrome
            if (DeleteAllFiles(chrome_cache, cbChromeCache.Checked)) CleanupLogsLBox.Items.Add("Chrome Cache cleaned.");
            if (DeleteAllFiles(chrome_sessions, cbChromeSessions.Checked)) CleanupLogsLBox.Items.Add("Chrome Sessions cleaned."); 
            if (DeleteAllFiles(chrome_cookies, cbChromeCookies.Checked)) CleanupLogsLBox.Items.Add("Chrome Cookies cleaned.");
            if (DeleteAllFiles(chrome_history, cbChromeSearchHistory.Checked)) CleanupLogsLBox.Items.Add("Chrome Search History cleaned.");
            if (DeleteAllFiles(chrome_ld, cbChromeSavedPasswords.Checked)) CleanupLogsLBox.Items.Add("Chrome Saved Passwords cleared.");
            
            // Discord
            if (DeleteAllFiles(discord_cache, cbDiscordCache.Checked)) CleanupLogsLBox.Items.Add("Discord Cache cleaned.");
            if (DeleteAllFiles(discord_cookies, cbDiscordCookies.Checked)) CleanupLogsLBox.Items.Add("Discord Cookies cleaned.");

            //Firefox
            // Firefox Cache
            if (cbFirefoxCache.Checked) {
                foreach (string dir in Directory.EnumerateDirectories(localappdata + "\\Mozilla\\Firefox\\Profiles\\"))
                    if (dir.Contains("release") == true) DeleteAllFiles({ new DirectoryInfo(dir + "\\cache2") }, cbFirefoxCache.Checked);

                foreach (string dir in Directory.EnumerateDirectories(roamingappdata + "\\Mozilla\\Firefox\\Profiles\\"))
                    if (dir.Contains("release") == true) DeleteAllFiles({ new DirectoryInfo(dir + "\\shader-cache") }, cbFirefoxCache.Checked);
                
                CleanupLogsLBox.Items.Add("Firefox Cache cleaned");
            }

            // Firefox Cookies
            if (cbFirefoxCookies.Checked) {
                foreach (string dir in Directory.EnumerateDirectories(roamingappdata + "\\Mozilla\\Firefox\\Profiles\\"))
                    if (dir.Contains("release") == true) DeleteAllFiles({ new DirectoryInfo(dir + "\\cookies.sqlite") }, cbFirefoxCookies.Checked));
                
                CleanupLogsLBox.Items.Add("Firefox Cookies cleaned.");
            }
            
            // Firefox Search History
            if (cbFirefoxSearchHistory.Checked) {
                foreach (string dir in Directory.EnumerateDirectories(roamingappdata + "\\Mozilla\\Firefox\\Profiles\\")) {
                    if (dir.Contains("release")) DeleteAllFiles({ new DirectoryInfo(dir + "\\places.sqlite") }, cbFirefoxSearchHistory.Checked);

                CleanupLogsLBox.Items.Add("Firefox History Cleaned.");
            }
            
            // DNS & ARP
            // Clear DNS
            if (cbSystemDNSCache.Checked) {
                try {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/c ipconfig /flushdns";
                    startInfo.RedirectStandardError = true;
                    process.StartInfo = startInfo;
                    process.Start();
                    CleanupLogsLBox.Items.Add("DNS Cache Cleared.");
                } catch (Exception ex) { CleanupLogsLBox.Items.Add("Error while trying to clear DNS cache!" + ex); }
            }
            
            // Clear ARP
            if (cbSystemARPCache.Checked) {
                try {
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
                } catch (Exception ex) {
                    CleanupLogsLBox.Items.Add("Error while trying to clear ARP cache. " + ex);
                    MessageBox.Show(ex.ToString());
                }
            }

            // Recent Files
            if (cbExplorerRecents.Checked) {
                try {
                    CleanRecentFiles.CleanRecents.ClearAll();
                    CleanupLogsLBox.Items.Add("Recent Files Cleared.");
                } catch (Exception ex) {
                    CleanupLogsLBox.Items.Add("Error while clearing Recent Files. " + ex);
                }
            }


            if (DeleteAllFiles(edge_history, cbEdgeSearchHistory.Checked)) CleanupLogsLBox.Items.Add("Edge Search History cleaned.");
            if (DeleteAllFiles(edge_cookies, cbEdgeCookies.Checked)) CleanupLogsLBox.Items.Add("Edge Cookies cleaned.");
            if (DeleteAllFiles(edge_cache, cbEdgeCache.Checked)) CleanupLogsLBox.Items.Add("Edge Cache cleaned.");
            if (DeleteAllFiles(edge_session, cbEdgeSessions.Checked)) CleanupLogsLBox.Items.Add("Edge Session Deleted.");
                
            if (DeleteAllFiles(dxcache, cbSystemDirectXCache.Checked)) CleanupLogsLBox.Items.Add("DirectX Shader Cache Deleted.");
                

            if (DeleteAllFiles({ new DirectoryInfo(_up + "\\AppData\\Local\\CrashDumps\\") }, cbSystemMemDumps.Checked)) CleanupLogsLBox.Items.Add("System Memory Dumps cleaned.");
            if (DeleteAllFiles({ new DirectoryInfo("C:\\ProgramData\\Microsoft\\Windows\\WER\\ReportArchive") }, cbSystemErrorReporting.Checked)) CleanupLogsLBox.Items.Add("System Error Reports cleaned.");

            if (cbExplorerThumbCache.Checked)
                foreach (string file in Directory.EnumerateFiles(_up + "\\AppData\\Local\\Microsoft\\Windows\\Explorer\\"))
                    if (file.Contains("thumbcache"))
                        try { File.Delete(file); CleanupLogsLBox.Items.Add("Deleted " + file); }
                        catch (Exception) { CleanupLogsLBox.Items.Add("Could not delete " + file); }

            if (cbExplorerIconCache.Checked)
                foreach (string file in Directory.EnumerateFiles(_up + "\\AppData\\Local\\Microsoft\\Windows\\Explorer\\"))
                    if (file.Contains("iconcache") == true)
                        try { File.Delete(file); CleanupLogsLBox.Items.Add("Deleted " + file); }
                        catch (Exception) { CleanupLogsLBox.Items.Add("Could not delete " + file); }

            if (cbSystemEventLogs.Checked)
                foreach (var eventLog in EventLog.GetEventLogs())
                    try { eventLog.Clear(); eventLog.Dispose(); }
                    catch (Exception ex) { CleanupLogsLBox.Items.Add("Error deleting Event Logs: " + ex); }

            WriteCleanupSummary();
        }


        private void Tabs_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedTab.Text == "Browser Extensions") btnCleanup.Visible = false;
            else btnCleanup.Visible = true;
        }
        
        private void frmCleanup_Load(object sender, EventArgs e) {
            tabControl1.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            
            DirectoryExists();
            
            // Extension Finder
            if (Directory.Exists(Dirs.chromeExtDir)) comboBox1.Items.Add("Google Chrome");
            if (Directory.Exists(Dirs.firefoxDir)) comboBox1.Items.Add("Mozilla Firefox");
            if (Directory.Exists(Dirs.edgeDir)) comboBox1.Items.Add("Microsoft Edge");
        }

        // DisplayDNS
        private void button1_Click(object sender, EventArgs e) {
            try {
                Process process = new Process();
                process.StartInfo.FileName = "Scripts/BatFiles/displaydns.bat";
                process.Start();
                //Directory.SetCurrentDirectory(@"/");
                //Directory.SetCurrentDirectory(@"Scripts/BatFiles");
                //Process.Start("displaydns.bat");
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        // DisplayARP
        private void button2_Click(object sender, EventArgs e) {
            try {
                Process process = new Process();
                process.StartInfo.FileName = "Scripts/BatFiles/displayarp.bat";
                process.Start();
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var g = new Dirs();

            if (comboBox1.Text == "Google Chrome") {
                ExtensionsBox.Items.Clear();

                foreach (string ext in Directory.EnumerateDirectories(Dirs.chromeExtDir)) {
                    FileInfo fi = new FileInfo(ext);
                    ListViewItem extb = ExtensionsBox.Items.Add(fi.Name, 0);
                    DirectoryInfo fol = new DirectoryInfo(ext);
                    fol.EnumerateDirectories();
                    extb.SubItems.Add("~ " + ByteSize.FromBytes(ext.Length).ToString());

                    extb.SubItems.Add(ext);
                }
            } else if (comboBox1.Text == "Mozilla Firefox") {
                ExtensionsBox.Items.Clear();
                try {
                    foreach (string fol in Directory.EnumerateDirectories(Dirs.firefoxExtDir)) {
                        if (fol.Contains("-release")) {
                            string prf = (fol + "\\extensions\\");

                            try {
                                foreach (string ext in Directory.EnumerateFiles(prf)) {
                                    FileInfo fi = new FileInfo(ext);
                                    ListViewItem extb = ExtensionsBox.Items.Add(fi.Name, 0);
                                    extb.SubItems.Add("~ " + ByteSize.FromBytes(fi.Length).ToString());
                                    extb.SubItems.Add(ext);
                                }
                            }
                            catch (Exception Exc) {
                                MessageBox.Show(Exc.ToString());
                            }
                        }
                    }
                } catch (Exception Exc) { MessageBox.Show(Exc.ToString()); }
            } else if (comboBox1.Text == "Microsoft Edge") {
                ExtensionsBox.Items.Clear();
                foreach (string ext in Directory.EnumerateDirectories(Dirs.edgeExtDir)) {
                    FileInfo fi = new FileInfo(ext);

                    ListViewItem extb = ExtensionsBox.Items.Add(fi.Name, 0);
                    DirectoryInfo fol = new DirectoryInfo(ext);
                    fol.EnumerateDirectories();
                    extb.SubItems.Add("~ " + ByteSize.FromBytes(ext.Length).ToString());

                    extb.SubItems.Add(ext);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) {
            if (ExtensionsBox.SelectedItems.Count >= 0) { //Check if the user selected extensions for deletion.
                /*Process process = new Process();
                process.StartInfo.FileName = "Scripts/BatFiles/killfirefox.bat";
                process.Start();
                process.WaitForExit();*/
                if (comboBox1.Text == "Google Chrome") {
                    foreach (ListViewItem eachItem in ExtensionsBox.SelectedItems) {
                        try {
                            Taskkill.Browser(1);
                            Thread.Sleep(75);
                            var item = ExtensionsBox.SelectedItems[0];
                            var subItem = item.SubItems[2].Text;
                            RemoveExt.RemoveExtension(subItem, 2);
                            ExtensionsBox.Items.Remove(eachItem);
                            CleanupLogsLBox.Items.Add("Extension Removed.");
                        } catch (Exception ex) { CleanupLogsLBox.Items.Add("Error while trying to remove extension." + ex); }
                    }
                }

                if (comboBox1.Text == "Mozilla Firefox") {
                    Taskkill.Browser(2);
                    Thread.Sleep(75); //Short threadsleep or else the extension deleter would start before firefox is fully killed for some reasons ?

                    try {
                        RemoveExt.RemoveExtension(ExtensionsBox.SelectedItems[0].SubItems[2].Text, 1);

                        foreach (ListViewItem eachItem in ExtensionsBox.SelectedItems) {
                            ExtensionsBox.Items.Remove(eachItem);
                            CleanupLogsLBox.Items.Add("Extension Removed.");
                        }
                    } catch { CleanupLogsLBox.Items.Add("Failed to remove extension"); }
                }


                if (comboBox1.Text == "Microsoft Edge") {
                    foreach (ListViewItem eachItem in ExtensionsBox.SelectedItems) {
                        try {
                            Taskkill.Browser(3);
                            Thread.Sleep(75);
                            var item = ExtensionsBox.SelectedItems[0];
                            var subItem = item.SubItems[2].Text;
                            RemoveExt.RemoveExtension(subItem, 2);
                            ExtensionsBox.Items.Remove(eachItem);
                            CleanupLogsLBox.Items.Add("Extension Removed.");
                        } catch (Exception ex) { CleanupLogsLBox.Items.Add("Error while trying to remove extension." + ex); }
                    }
                }
            } else MessageBox.Show("Please select an extension to remove.");
        }



        private void button5_Click(object sender, EventArgs e) {
            try { RunFile.RunBat("Scripts/BatFiles/byesolitaire.bat", true); }
            catch (Exception ex) { MessageBox.Show("An error occurred." + ex); }
        }

        private void button7_Click(object sender, EventArgs e) {
            try { Process.Start("powershell", "-ExecutionPolicy Bypass -File Scripts/Debloater/DisableCortana.ps1"); }
            catch (Exception ex) { MessageBox.Show("An error occurred." + ex); }
        }

        private void button6_Click(object sender, EventArgs e) {
            try { Process.Start("powershell", "-ExecutionPolicy Bypass  -File Scripts/Debloater/UninstallOneDrive.ps1"); }
            catch (Exception ex) { MessageBox.Show("An error occurred." + ex); }
        }

        private void button4_Click(object sender, EventArgs e) {
            RunFile.RunBat("removeedge.bat", true);
        }
        
        private void DirectoryExists() {
            // Todo: Check if the applications are on the computer and disable the checkboxes if it doesn't exist.
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Dirs.chromeDir = localappdata + "\\Google\\Chrome\\";
            Dirs.chromeExtDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions");
            Dirs.firefoxDir = localappdata + "\\Mozilla\\Firefox\\";
            Dirs.firefoxExtDir = roamingappdata + "\\Mozilla\\Firefox\\Profiles\\";
            Dirs.edgeDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\");
            Dirs.edgeExtDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Extensions\\");
            Dirs.discordDir = localappdata + "\\Discord\\"; // Makes more sense checking appdata than program files


            if (!Directory.Exists(Dirs.chromeDir)) {
                cbChromeCache.Enabled = false;
                cbChromeCookies.Enabled = false;
                cbChromeSearchHistory.Enabled = false;
                cbChromeSessions.Enabled = false;
                cbChromeSavedPasswords.Enabled = false;
                lblChromeNotDetected.Visible = true;
            }

            if (!Directory.Exists(Dirs.firefoxDir)) {
                cbFirefoxCache.Enabled = false;
                cbFirefoxCookies.Enabled = false;
                cbFirefoxSearchHistory.Enabled = false;
                lblFirefoxNotDetected.Visible = true;
            }

            if (!Directory.Exists(Dirs.discordDir)) {
                cbDiscordCache.Enabled = false;
                cbDiscordCookies.Enabled = false;
                lblDiscordNotDetected.Visible = true;

            }

            if (!Directory.Exists(Dirs.edgeDir)) {
                cbEdgeCache.Enabled = false;
                cbEdgeCookies.Enabled = false;
                cbEdgeSearchHistory.Enabled = false;
                cbEdgeSessions.Enabled = false;
                lblEdgeNotDetected.Visible = true;
            }
        }

        private void cbEdgeCookies_CheckStateChanged(object sender, EventArgs e) {
            try { taskDialog1.Show(); } catch { Console.WriteLine("An error has occurred."); }
        }

        private void cbChromeCache_CheckStateChanged(object sender, EventArgs e) {}

        private void cbFirefoxCookies_CheckStateChanged(object sender, EventArgs e) {
            try { taskDialog1.Show(); } catch { Console.WriteLine("An error has occurred."); }
        }

        private void cbChromeCookies_CheckStateChanged(object sender, EventArgs e) {
            try { taskDialog1.Show(); } catch { Console.WriteLine("An error has occurred."); }
        }

        public void WriteCleanupSummary() {
            int t = (int)((DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            
            File.WriteAllLines(
              Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks"), "Cleanup Summary") + "\\tasks-cleanup-summary-" + t + ".txt",
              CleanupLogsLBox.Items.Cast<string>().ToArray()
            );
            
            MessageBox.Show("Cleanup is logged at " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "Tasks\\" + "Cleanup Summary" +"\\tasks-cleanup-summary-" + t + ".txt");
        }
    }
}
