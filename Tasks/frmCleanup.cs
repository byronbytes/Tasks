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

// TODO: Cleanup and change the code style
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

            foreach (var file in directoryInfo.GetFiles())
            {
                try
                {
                    file.Delete();
                    CleanupLogsLBox.Items.Add("Deleted " + file.FullName);
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Exception Thrown: " + ex.Message);

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
                    CleanupLogsLBox.Items.Add("Exception Thrown: " + ex.Message);
                }

            }

            return true;
        }
        

        
        private void btnCleanup_Click(object sender, EventArgs e)
        {
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData");
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var windowstemp = new DirectoryInfo("C:\\Windows\\Temp");
            var usertemp = new DirectoryInfo(Path.GetTempPath());
            var downloads = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads");

            if (checkBox1.Checked)
                try
                {

                    if (DeleteAllFiles(downloads)) CleanupLogsLBox.Items.Add("Downloads Folder Cleaned.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error deleting the Downloads Folder. " + ex);

                }

            if (checkBox2.Checked)
                try {

                    SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                    CleanupLogsLBox.Items.Add("Recycle Bin Cleaned.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error deleting the Recycle Bin. " + ex);

                }







            if (checkBox3.Checked)
            {
                try
                {
                    if (DeleteAllFiles(windowstemp)) CleanupLogsLBox.Items.Add("System Temp Folder Cleaned.");
                    if (DeleteAllFiles(usertemp)) CleanupLogsLBox.Items.Add("User Temp Folder Cleaned.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while deleting temp folders. " + ex);
                }

            }

            if (checkBox4.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo("C:\\Windows\\Prefetch");
                    if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Prefetch Cleaned.");
                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while cleaning Prefetch. " + ex);
                }
            }

            // Chrome

            if (checkBox5.Checked)
            {
                try
                {
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cache\\");
                    var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Code Cache\\");
                    var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\GPUCache\\");
                    var directory4 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\ShaderCache\\");
                    var directory5 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Service Worker\\CacheStorage\\");
                    var directory6 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Service Worker\\ScriptCache\\");
                    var directory7 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\GrShaderCache\\GPUCache\\");
                    var directory8 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\File System\\000\\p\\");
                    if(DeleteAllFiles(directory) & DeleteAllFiles(directory2) & DeleteAllFiles(directory3) & DeleteAllFiles(directory4) & DeleteAllFiles(directory5) & DeleteAllFiles(directory6) & DeleteAllFiles(directory7) & DeleteAllFiles(directory8)) CleanupLogsLBox.Items.Add("Chrome Cache Cleaned.");
                }
                catch (Exception)
                {

                }
            }

            if (checkBox6.Checked) //Chrome Session 
            {

                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Sessions");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Session Storage");
                var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extension State");
                if (DeleteAllFiles(directory) & DeleteAllFiles(directory2) & DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Chrome Sessions Deleted.");
            }

            if (checkBox7.Checked) //Chrome cookies
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\IndexedDB\\");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Cookies-journal");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Cookies Deleted.");
            }


            if (checkBox8.Checked) //Chrome search history
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History Provider Cache");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History-journal");
                CleanupLogsLBox.Items.Add("Chrome Search History Deleted.");
            }



            // Discord

            if (checkBox9.Checked) //Discord cache
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Cache");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Code Cache");
                var directory3 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\GPUCache");
                if (DeleteAllFiles(directory) & DeleteAllFiles(directory2) & DeleteAllFiles(directory3)) CleanupLogsLBox.Items.Add("Discord Cache Cleaned.");
            }


            if (checkBox25.Checked) //Discord cookies
                try
                {

                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Cookies");
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\discord\\Cookies-journal");
                    CleanupLogsLBox.Items.Add("Discord Cookies Cleaned.");

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("There was an error trying to clean Discord Cookies." + ex);
                }

            //Firefox

            if (checkBox14.Checked) //Firefox cache
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
                                    CleanupLogsLBox.Items.Add("Firefox Cache Cleaned.");
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
                        CleanupLogsLBox.Items.Add("Error while trying to delete Firefox Shader Cache! \n" + ex);
                    }

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while trying to delete firefox cache! \n" + ex);
                }



            }

            if (checkBox15.Checked) //Firefox cookies
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
                            catch (Exception ex)
                            {

                                CleanupLogsLBox.Items.Add("Error while trying to delete Firefox cookies! \n" + ex);
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error while trying to delete Firefox cookies! \n" + ex);
                }


            }
            if (checkBox16.Checked) //Firefox search history
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
                            catch (Exception ex)
                            {

                                CleanupLogsLBox.Items.Add("Error while trying to clean Firefox History." + ex);

                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error when trying to delete Firefox History! \n" + ex);
                }
            }



            //DNS & ARP
            if (checkBox19.Checked) //Clear DNS
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
                catch (Exception ex)
                {

                    CleanupLogsLBox.Items.Add("Error while trying to clear DNS cache!" + ex);

                }
            }
            if (checkBox20.Checked) //Clear ARP
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
                catch (Exception ex)
                {

                    CleanupLogsLBox.Items.Add("Error while trying to clear ARP cache. " + ex);
                    MessageBox.Show(ex.ToString());

                }
            }

            if (checkBox21.Checked)     //RECENT FILES
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


            if (checkBox18.Checked) //Edge search history
            {

                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\History");
                CleanupLogsLBox.Items.Add("Edge Search History Deleted.");
            }
            if (checkBox22.Checked) //Edge cookies
            {
           
                     File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Cookies");
                    var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\IndexedDB\\");
                    if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Edge Cookies Deleted.");



                CleanupLogsLBox.Items.Add("Edge Cookies Cleaned.");
            }

            if (checkBox23.Checked) //Edge cache
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

            if (checkBox10.Checked)
            {
                try
                {
                    foreach (var eventLog in EventLog.GetEventLogs())
                    {
                        eventLog.Clear();
                        eventLog.Dispose();
                        CleanupLogsLBox.Items.Add("Event Logs Deleted.");
                    }
                } catch (Exception ex)
                {
                    CleanupLogsLBox.Items.Add("Error deleting Event Logs: " + ex);
                }


            }

            if (checkBox11.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Sessions");
                var directory2 = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default\\Session Storage");
                if (DeleteAllFiles(directory) & DeleteAllFiles(directory2) ) CleanupLogsLBox.Items.Add("Edge Session Deleted.");
            }

            if (checkBox12.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\D3DSCache");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("DirectX Shader Cache Cleaned.");
            }

            if (checkBox13.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\CrashDumps\\");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("System Memory Dumps Cleaned.");
            }


            if (checkBox17.Checked)
            {
                var directory = new DirectoryInfo("C:\\ProgramData\\Microsoft\\Windows\\WER\\ReportArchive");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Deleted " + directory);
            }

            if (checkBox24.Checked)
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

            if(checkBox25.Checked)
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

            if(checkBox26.Checked)
            {
                var directory = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Login Data\\");
                if (DeleteAllFiles(directory)) CleanupLogsLBox.Items.Add("Chrome Saved Passwords Deleted.");
            }


            if (CleanupLogsLBox.Items.Count < 2) btnCopyLogs.Enabled = true;




        }

        private void btnCopyLogs_Click_1(object sender, EventArgs e)
        {
            CleanupLogsLBox.Items.Add("Cleanup Logs copied to clipboard.");
            Clipboard.SetText(string.Join("\n", CleanupLogsLBox.Items.Cast<string>()));
        }


        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Browser Extensions") // i dont want it to show up in the extensions thing because i'll use a diff button to make the code less messy
            {
                btnCleanup.Visible = false;
                btnCopyLogs.Visible = false;
            }
            else
            {
                if (!btnCleanup.Visible && !btnCopyLogs.Visible)
                {

                    btnCleanup.Visible = true;
                    btnCopyLogs.Visible = true;

                }
            }


        }


        private void frmCleanup_Load(object sender, EventArgs e)
           
        {
            tabControl1.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            var g = new Dirs();


            // Todo: Check if the applications are on the computer and disable the checkboxes if it doesn't exist.
            var localappdata = Environment.GetEnvironmentVariable("LocalAppData"); 
            var roamingappdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Dirs.chromeDir = localappdata + "\\Google\\Chrome\\";
            Dirs.chromeExtDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions");
            Dirs.firefoxDir = localappdata + "\\Mozilla\\Firefox\\";
            Dirs.firefoxExtDir = roamingappdata + "\\Mozilla\\Firefox\\Profiles\\"; 
            Dirs.edgeDir = (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Microsoft\\Edge\\");
            Dirs.edgeExtDir = "";
            Dirs.discordDir = localappdata + "\\Discord\\"; // Makes more sense checking appdata than program files


            if (!Directory.Exists(Dirs.chromeDir))
            {
                checkBox5.Enabled = false;
                checkBox7.Enabled = false;
                checkBox8.Enabled = false;
                checkBox6.Enabled = false;
                checkBox27.Enabled = false;
                lblChromeNotDetected.Visible = true;
            }

            if (!Directory.Exists(Dirs.firefoxDir))
            {
                checkBox14.Enabled = false;
                checkBox15.Enabled = false;
                checkBox16.Enabled = false;
                lblFirefoxNotDetected.Visible = true;
            }

            if (!Directory.Exists(Dirs.discordDir))
            {
                checkBox9.Enabled = false;
                checkBox25.Enabled = false;
                lblDiscordNotDetected.Visible = true;
               
            }

            if (!Directory.Exists(Dirs.edgeDir))
            {
                checkBox23.Enabled = false;
                checkBox22.Enabled = false;
                checkBox18.Enabled = false;
                checkBox11.Enabled = false;
                lblEdgeNotDetected.Visible = true;

            }


            // Extention Finder
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
                // this will be a pain it might be for 2.1.0
            }

        }





        private void button1_Click(object sender, EventArgs e) //DisplayDNS
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var g = new Dirs();

            
            if (comboBox1.Text == "Google Chrome")
            {
                ExtensionsBox.Items.Clear();

                foreach (string ext in Directory.EnumerateDirectories(Dirs.chromeExtDir))

                {

                    FileInfo fi = new FileInfo(ext);
                  ListViewItem extb = ExtensionsBox.Items.Add(fi.Name, 0);
                    DirectoryInfo fol = new DirectoryInfo(ext);
                    fol.EnumerateDirectories();
                    extb.SubItems.Add("~ " + ByteSize.FromBytes(ext.Length).ToString());
                   
                    extb.SubItems.Add(ext);


   

                } 
  


            }
            else if (comboBox1.Text == "Mozilla Firefox")  
            {
                ExtensionsBox.Items.Clear();
                try
                {
                    foreach(string fol in Directory.EnumerateDirectories(Dirs.firefoxExtDir))
                    {
                        if (fol.Contains("-release"))
                        {
                            string prf = (fol + "\\extensions\\");
                            try
                            {
                                foreach(string ext in Directory.EnumerateFiles(prf))                                 
                                {
                                    FileInfo fi = new FileInfo(ext);
                                    ListViewItem extb = ExtensionsBox.Items.Add(fi.Name, 0);
                                    extb.SubItems.Add("~ "+ ByteSize.FromBytes(fi.Length).ToString());
                                    extb.SubItems.Add(ext);

                                }

                            }
                            catch (Exception Exc)
                            {

                                MessageBox.Show(Exc.ToString());

                            }
                        }
                    }

                }
                catch(Exception Exc)
                {

                    MessageBox.Show(Exc.ToString());

                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ExtensionsBox.SelectedItems.Count > 0) //Check if the user selected extensions for deletion.
            {

                /*Process process = new Process();
                process.StartInfo.FileName = "Scripts/BatFiles/killfirefox.bat";
                process.Start();
                process.WaitForExit();*/


                int aa = RunFile.RunBat("Scripts/BatFiles/killfirefox.bat", true);

                if (aa == 1)
                {

                }
                else if (aa == 0)
                {

                }
                Thread.Sleep(75); //Short threadsleep or else the extension deleter would start before firefox is fully killed for some reasons ?

                int go = RemoveExt.RemoveExtFirefox(ExtensionsBox.SelectedItems[0].SubItems[2].Text);
                if (go == 0)
                {
                    foreach (ListViewItem eachItem in ExtensionsBox.SelectedItems)
                    {
                        ExtensionsBox.Items.Remove(eachItem);
                        CleanupLogsLBox.Items.Add("Extension Removed.");
                    }
                }
                else if (go == 1)
                {
                    CleanupLogsLBox.Items.Add("Error while trying to remove extension.");
                }
            }
            else
            {
                MessageBox.Show("Please select an extension to remove.");
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            taskDialog1.Show();
        }
    }
    }

    

