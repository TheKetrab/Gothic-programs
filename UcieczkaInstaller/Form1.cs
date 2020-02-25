using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UcieczkaInstaller
{
    public partial class MainWindow : Form
    {
        private readonly InstalationManager instalationManager;
        private int page;

        public string GothicPath;

        public MainWindow()
        {
            InitializeComponent();
            instalationManager = new InstalationManager(this);

            // set pages
            page = 0;
            DisablePage1();
            DisablePage2();
            DisablePage3();
            EnablePage0();

            // music
            Task.Factory.StartNew(() =>
            {
                System.IO.Stream stream = Properties.Resources.Music;
                System.Media.SoundPlayer snd = new System.Media.SoundPlayer(stream);
                snd.Play();
            });

        }



        /// <summary>
        /// Detect if that dir seems to be basic Gothic directory.
        /// </summary>
        public bool IsFolderWithGothic(string path)
        {
            if (Directory.Exists(path)
             && Directory.Exists(path + @"\_Work")
             && Directory.Exists(path + @"\Data")
             && Directory.Exists(path + @"\System"))
            {
                return true;
            }

            return false;
        }

        public void NextPage()
        {
            if (page == 0)
            {
                DisablePage0();
                EnablePage1();
                page++;
            }
            else if (page == 1)
            {
                var path = GetTextBoxPage1();

                // ignore click if empty
                if (path.Equals(""))
                {
                    return;
                }

                if (!IsFolderWithGothic(path))
                {
                    MessageBox.Show("Ten folder nie wydaje się być folderem z Gothiciem.");
                }

                GothicPath = path;
                DisablePage1();
                EnablePage2();
                page++;
            }
            else if (page == 2)
            {
                DisablePage2();
                EnablePage3();
                page++;
            }
            else if (page == 3)
            {
                instalationManager.Start();
            }
        }

        public void PreviousPage()
        {
            if (page == 3)
            {
                DisablePage3();
                EnablePage2();
                page--;
            }
            else if (page == 2)
            {
                DisablePage2();
                EnablePage1();
                page--;
            }
            else if (page == 1)
            {
                DisablePage1();
                EnablePage0();
                page--;
            }
            else if (page == 0)
            {
                Application.Exit();
            }

        }




        public void EnablePage0()
        {
            ButtonPrev.Text = "< Wyjście";
            Header.Text = "Licencja";
            GroupBoxPage0.Visible = true;
            GroupBoxPage0.Enabled = true;
        }

        public void DisablePage0()
        {
            ButtonPrev.Text = "< Wstecz";
            GroupBoxPage0.Visible = false;
            GroupBoxPage0.Enabled = false;
        }

        public void EnablePage1()
        {
            Header.Text = "Miejsce instalacji";
            GroupBoxPage1.Visible = true;
            GroupBoxPage1.Enabled = true;
        }

        public void DisablePage1()
        {
            GroupBoxPage1.Visible = false;
            GroupBoxPage1.Enabled = false;
        }

        public void EnablePage2()
        {
            Header.Text = "Opcje instalacji";
            GroupBoxPage2.Visible = true;
            GroupBoxPage2.Enabled = true;
        }

        public void DisablePage2()
        {
            GroupBoxPage2.Visible = false;
            GroupBoxPage2.Enabled = false;
        }

        public void EnablePage3()
        {
            ButtonNext.Text = "Instaluj >";
            Header.Text = "Gotowy?";
            GroupBoxPage3.Visible = true;
            GroupBoxPage3.Enabled = true;

            labelPage3Info.Text = GetInfo();
        }

        public void DisablePage3()
        {
            ButtonNext.Text = "Dalej >";
            GroupBoxPage3.Visible = false;
            GroupBoxPage3.Enabled = false;
        }


        private void ButtonNext_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            PreviousPage();
        }

        private void buttonBrowse1_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxPage1.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        public string GetTextBoxPage1()
        {
            return textBoxPage1.Text;
        }

        private void checkBoxDubbing_MouseEnter(object sender, EventArgs e)
        {
            labelPage2Info.Text = "Instaluje polski dubbing.";
        }

        private void checkBoxDubbing_MouseLeave(object sender, EventArgs e)
        {
            labelPage2Info.Text = "";
        }

        private void checkBoxDeveloper_MouseEnter(object sender, EventArgs e)
        {
            labelPage2Info.Text = "Wypakowuje nieskompilowane \n" +
                                  "pliki uzywane w modyfikacji \n" +
                                  "do folderów: Meshes (3d), \n" +
                                  "Anims (animacje), Textures (tekstury).";
        }

        private void checkBoxDeveloper_MouseLeave(object sender, EventArgs e)
        {
            labelPage2Info.Text = "";
        }

        private void checkBoxScripts_MouseEnter(object sender, EventArgs e)
        {
            labelPage2Info.Text = "Wypakowuje skrypty do folderu \n" +
                                  "_Work/Data/Scripts. Przydatne, \n" +
                                  "gdy trzeba coś odbugować \n" +
                                  "lub gdy ktoś chce skorzystać \n" +
                                  "ze skryptów niczym jako poradnik \n" +
                                  "do gry (podejrzeć rutyny, warunki).";
        }

        private void checkBoxScripts_MouseLeave(object sender, EventArgs e)
        {
            labelPage2Info.Text = "";
        }

        private void checkBoxIcon_MouseEnter(object sender, EventArgs e)
        {
            labelPage2Info.Text = "Tworzy na pulpicie plik exe, \n" +
                                  "który odpala modyfikację bezpośrednio. \n" +
                                  "";
        }

        private void checkBoxIcon_MouseLeave(object sender, EventArgs e)
        {
            labelPage2Info.Text = "";
        }

        private void checkBoxDX11_MouseEnter(object sender, EventArgs e)
        {
            labelPage2Info.Text = "Gra będzie korzystała z moda DX11 \n" +
                                  "(uwaga, wczytywanie podczas deszczu \n" +
                                  "wywala często do pulpitu!).";
        }

        private void checkBoxDX11_MouseLeave(object sender, EventArgs e)
        {
            labelPage2Info.Text = "";
        }


        public string GetInfo()
        {
            string result = "";

            result += "Folder z Gothiciem:\n";
            result += GothicPath + "\n\n";

            if (checkBoxDubbing.Checked)
                result += "Zainstaluj dubbing.\n";
            if (checkBoxScripts.Checked)
                result += "Zainstaluj skrypty.\n";
            if (checkBoxDeveloper.Checked)
                result += "Zainstaluj werję developerską.\n";
            if (checkBoxIcon.Checked)
                result += "Utwórz ikonę na pulpicie.";
            //if (InstallDX11)
            //    result += "Zainstaluj DX11";


            return result;
        }

        public CheckBox GetCheckBox(int i)
        {
            if (i == 1)
                return checkBoxDubbing;
            else if (i == 2)
                return checkBoxScripts;
            else if (i == 3)
                return checkBoxDeveloper;
            else if (i == 4)
                return checkBoxIcon;
            else if (i == 5)
                return checkBoxDX11;
            else
                throw new Exception("Unknown checkbox");

        }

        public ProgressBar GetProgressBar()
        {
            return progressBarInstallation;
        }

        public Label GetInstallationLabel()
        {
            return labelInstallationInfo;
        }

    }
}
