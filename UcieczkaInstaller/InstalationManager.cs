using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using wsh = IWshRuntimeLibrary;
using System.Threading;

namespace UcieczkaInstaller
{
    public class InstalationManager
    {
        private delegate void SafeCallSetInstallationText(string text);
        private delegate void SafeCallUpdateProgressBar(int x);
        private readonly MainWindow window;
        private readonly Thread instalationThread;

        public InstalationManager(MainWindow window)
        {
            this.window = window;
            instalationThread = new Thread(() =>
            {
                Install();
            });

        }

        public void Start()
        {
            instalationThread.Start();
        }



        /// <summary>
        /// Creates executable shortcut to the mod
        /// </summary>
        public void CreateExe()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            object shDesktop = (object)"Desktop";
            wsh.WshShell shell = new wsh.WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Ucieczka.lnk";
            wsh.IWshShortcut shortcut = (wsh.IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Uruchom modyfikację G2 Ucieczka";
            shortcut.TargetPath = window.GothicPath + @"\System\Gothic2.exe";
            shortcut.IconLocation = window.GothicPath + @"\System\Ucieczka.ico";
            shortcut.Arguments = "-game:Ucieczka.ini";
            shortcut.Save();
        }
        
        /// <summary>
        /// Extracts zip to the given dir (by path)
        /// </summary>
        /// <param name="archive">zip</param>
        /// <param name="destinationDirectoryName">path</param>
        /// <param name="overwrite">overwrite if file with the same name already exists?</param>
        public static void ExtractToDirectory(ZipArchive archive, string destinationDirectoryName, bool overwrite)
        {
            if (!overwrite)
            {
                archive.ExtractToDirectory(destinationDirectoryName);
                return;
            }

            DirectoryInfo di = Directory.CreateDirectory(destinationDirectoryName);
            string destinationDirectoryFullPath = di.FullName;

            foreach (ZipArchiveEntry file in archive.Entries)
            {
                string completeFileName = Path.GetFullPath(Path.Combine(destinationDirectoryFullPath, file.FullName));

                if (file.Name == "")
                {   // Assuming Empty for Directory
                    Directory.CreateDirectory(Path.GetDirectoryName(completeFileName));
                    MessageBox.Show(Path.GetDirectoryName(completeFileName));
                    continue;
                }
                file.ExtractToFile(completeFileName, true);
            }
        }

        /// <summary>
        /// Copy an archive from resources and then extract it.
        /// </summary>
        public void MoveFilesFromZip(byte[] zip, string archiveName)
        {
            CopyDataToFile(zip, archiveName);

            using (ZipArchive z = ZipFile.OpenRead(window.GothicPath + archiveName))
            {
                try
                {
                    z.ExtractToDirectory(window.GothicPath);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                };
            }

        }

        /// <summary>
        /// Copy a file from resourcesa to the new location.
        /// </summary>
        private void CopyDataToFile(byte[] data, string fileName)
        {
            using (FileStream fs = System.IO.File.Open(window.GothicPath + fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }

            //Array.Clear(data, 0, data.Length);
        }

        
        /// <summary>
        /// Update progress bar (safe!) from a different thread.
        /// </summary>
        /// <param name="val"></param>
        public void UpdateProgressBar(int val)
        {
            var progressBar = window.GetProgressBar();

            if (progressBar.InvokeRequired)
            {
                var d = new SafeCallUpdateProgressBar(UpdateProgressBar);
                progressBar.Invoke(d, new object[] { val });
            }
            else
            {
                progressBar.Increment(val);
            }

        }

        
        public void SetInstallationText(string text)
        {
            var label = window.GetInstallationLabel();

            if (label.InvokeRequired)
            {
                var d = new SafeCallSetInstallationText(SetInstallationText);
                label.Invoke(d, new object[] { text });
            }
            else
            {
                label.Text = text;
            }
            
        }


        public void Install()
        {
            try
            {
                UpdateProgressBar(5);
                SetInstallationText("Wypakowywanie plików gry.");

                // -----
                // Mod file and ini, ico, etc
                MoveFilesFromZip(Properties.Resources.Mod, @"\Mod.zip");

                // VIDEO
                if (!Directory.Exists(window.GothicPath + @"\_Work\data\Video"))
                    Directory.CreateDirectory(window.GothicPath + @"\_Work\data\Video");

                //CopyDataToFile(Properties.Resources.G2UcieczkaAfterKap3, @"/_Work/data/Video/G2UcieczkaAfterKap3.bik");
                //CopyDataToFile(Properties.Resources.G2UcieczkaIntro, @"/_Work/data/Video/G2UcieczkaIntro.bik");
                //CopyDataToFile(Properties.Resources.G2UcieczkaIntro, @"/_Work/data/Video/G2UcieczkaOutro.bik");
                //CopyDataToFile(Properties.Resources.G2UcieczkaIntro, @"/_Work/data/Video/G2UcieczkaCredits.bik");

                UpdateProgressBar(30);
                if (window.GetCheckBox(1).Checked)
                {
                    SetInstallationText("Wgrywanie dubbingu.");
                    CopyDataToFile(Properties.Resources.UcieczkaDubbing, @"/Data/UcieczkaDubbing.vdf");
                }

                UpdateProgressBar(30);
                if (window.GetCheckBox(2).Checked)
                {
                    SetInstallationText("Kopiowanie skryptów.");
                    MoveFilesFromZip(Properties.Resources.Scripts,"Scripts.zip");

                }

                UpdateProgressBar(10);
                if (window.GetCheckBox(3).Checked)
                {
                    SetInstallationText("Rozpakowywanie paczki developerskiej.");
                    MoveFilesFromZip(Properties.Resources.Developer,"Developer.zip");
                }

                UpdateProgressBar(20);
                if (window.GetCheckBox(4).Checked)
                {
                    SetInstallationText("Tworzenie ikony na pulpicie.");
                    CreateExe();
                        
                }

                UpdateProgressBar(5);

                SetInstallationText("Zakończono.");
                MessageBox.Show("Instalacja zakończona.");
                Application.Exit();
            }

            catch ( Exception ex )
            {
                while ( ex != null )
                {
                    MessageBox.Show(string.Format("{0} {1}", ex.GetType(), ex.Message));
                    ex = ex.InnerException;
                }
            };

        }









    }
}
