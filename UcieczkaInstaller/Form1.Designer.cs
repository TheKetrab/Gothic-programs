namespace UcieczkaInstaller
{



    partial class MainWindow
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }





        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.GroupBoxPage3 = new System.Windows.Forms.GroupBox();
            this.labelPage3Info = new System.Windows.Forms.Label();
            this.GroupBoxPage2 = new System.Windows.Forms.GroupBox();
            this.groupBoxPage2Info = new System.Windows.Forms.GroupBox();
            this.labelPage2Info = new System.Windows.Forms.Label();
            this.checkBoxDX11 = new System.Windows.Forms.CheckBox();
            this.checkBoxScripts = new System.Windows.Forms.CheckBox();
            this.checkBoxIcon = new System.Windows.Forms.CheckBox();
            this.checkBoxDeveloper = new System.Windows.Forms.CheckBox();
            this.checkBoxDubbing = new System.Windows.Forms.CheckBox();
            this.GroupBoxPage1 = new System.Windows.Forms.GroupBox();
            this.buttonBrowsePage1 = new System.Windows.Forms.Button();
            this.textBoxPage1 = new System.Windows.Forms.TextBox();
            this.GroupBoxPage0 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonPrev = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.Header = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBarInstallation = new System.Windows.Forms.ProgressBar();
            this.labelInstallationInfo = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.GroupBoxPage3.SuspendLayout();
            this.GroupBoxPage2.SuspendLayout();
            this.groupBoxPage2Info.SuspendLayout();
            this.GroupBoxPage1.SuspendLayout();
            this.GroupBoxPage0.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.labelInstallationInfo);
            this.MainPanel.Controls.Add(this.GroupBoxPage3);
            this.MainPanel.Controls.Add(this.GroupBoxPage2);
            this.MainPanel.Controls.Add(this.GroupBoxPage1);
            this.MainPanel.Controls.Add(this.GroupBoxPage0);
            this.MainPanel.Controls.Add(this.ButtonPrev);
            this.MainPanel.Controls.Add(this.ButtonNext);
            this.MainPanel.Controls.Add(this.Header);
            this.MainPanel.Location = new System.Drawing.Point(40, 235);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(600, 400);
            this.MainPanel.TabIndex = 0;
            // 
            // GroupBoxPage3
            // 
            this.GroupBoxPage3.Controls.Add(this.progressBarInstallation);
            this.GroupBoxPage3.Controls.Add(this.labelPage3Info);
            this.GroupBoxPage3.Location = new System.Drawing.Point(40, 100);
            this.GroupBoxPage3.Name = "GroupBoxPage3";
            this.GroupBoxPage3.Size = new System.Drawing.Size(520, 200);
            this.GroupBoxPage3.TabIndex = 5;
            this.GroupBoxPage3.TabStop = false;
            this.GroupBoxPage3.Text = "Krok 3/3";
            // 
            // labelPage3Info
            // 
            this.labelPage3Info.AutoSize = true;
            this.labelPage3Info.Location = new System.Drawing.Point(42, 40);
            this.labelPage3Info.Name = "labelPage3Info";
            this.labelPage3Info.Size = new System.Drawing.Size(46, 17);
            this.labelPage3Info.TabIndex = 0;
            this.labelPage3Info.Text = "label2";
            // 
            // GroupBoxPage2
            // 
            this.GroupBoxPage2.Controls.Add(this.groupBoxPage2Info);
            this.GroupBoxPage2.Controls.Add(this.checkBoxDX11);
            this.GroupBoxPage2.Controls.Add(this.checkBoxScripts);
            this.GroupBoxPage2.Controls.Add(this.checkBoxIcon);
            this.GroupBoxPage2.Controls.Add(this.checkBoxDeveloper);
            this.GroupBoxPage2.Controls.Add(this.checkBoxDubbing);
            this.GroupBoxPage2.Location = new System.Drawing.Point(40, 100);
            this.GroupBoxPage2.Name = "GroupBoxPage2";
            this.GroupBoxPage2.Size = new System.Drawing.Size(520, 200);
            this.GroupBoxPage2.TabIndex = 0;
            this.GroupBoxPage2.TabStop = false;
            this.GroupBoxPage2.Text = "Krok 2/3";
            // 
            // groupBoxPage2Info
            // 
            this.groupBoxPage2Info.Controls.Add(this.labelPage2Info);
            this.groupBoxPage2Info.Location = new System.Drawing.Point(192, 21);
            this.groupBoxPage2Info.Name = "groupBoxPage2Info";
            this.groupBoxPage2Info.Size = new System.Drawing.Size(306, 175);
            this.groupBoxPage2Info.TabIndex = 5;
            this.groupBoxPage2Info.TabStop = false;
            this.groupBoxPage2Info.Text = "Info";
            // 
            // labelPage2Info
            // 
            this.labelPage2Info.AutoSize = true;
            this.labelPage2Info.Location = new System.Drawing.Point(20, 28);
            this.labelPage2Info.Name = "labelPage2Info";
            this.labelPage2Info.Size = new System.Drawing.Size(0, 17);
            this.labelPage2Info.TabIndex = 0;
            // 
            // checkBoxDX11
            // 
            this.checkBoxDX11.AutoSize = true;
            this.checkBoxDX11.Location = new System.Drawing.Point(23, 143);
            this.checkBoxDX11.Name = "checkBoxDX11";
            this.checkBoxDX11.Size = new System.Drawing.Size(54, 21);
            this.checkBoxDX11.TabIndex = 4;
            this.checkBoxDX11.Text = "???";
            this.checkBoxDX11.UseVisualStyleBackColor = true;
            this.checkBoxDX11.MouseEnter += new System.EventHandler(this.checkBoxDX11_MouseEnter);
            this.checkBoxDX11.MouseLeave += new System.EventHandler(this.checkBoxDX11_MouseLeave);
            // 
            // checkBoxScripts
            // 
            this.checkBoxScripts.AutoSize = true;
            this.checkBoxScripts.Location = new System.Drawing.Point(23, 63);
            this.checkBoxScripts.Name = "checkBoxScripts";
            this.checkBoxScripts.Size = new System.Drawing.Size(77, 21);
            this.checkBoxScripts.TabIndex = 6;
            this.checkBoxScripts.Text = "Skrypty";
            this.checkBoxScripts.UseVisualStyleBackColor = true;
            this.checkBoxScripts.MouseEnter += new System.EventHandler(this.checkBoxScripts_MouseEnter);
            this.checkBoxScripts.MouseLeave += new System.EventHandler(this.checkBoxScripts_MouseLeave);
            // 
            // checkBoxIcon
            // 
            this.checkBoxIcon.AutoSize = true;
            this.checkBoxIcon.Location = new System.Drawing.Point(23, 118);
            this.checkBoxIcon.Name = "checkBoxIcon";
            this.checkBoxIcon.Size = new System.Drawing.Size(135, 21);
            this.checkBoxIcon.TabIndex = 3;
            this.checkBoxIcon.Text = "Skrót na pulpicie";
            this.checkBoxIcon.UseVisualStyleBackColor = true;
            this.checkBoxIcon.MouseEnter += new System.EventHandler(this.checkBoxIcon_MouseEnter);
            this.checkBoxIcon.MouseLeave += new System.EventHandler(this.checkBoxIcon_MouseLeave);
            // 
            // checkBoxDeveloper
            // 
            this.checkBoxDeveloper.AutoSize = true;
            this.checkBoxDeveloper.Location = new System.Drawing.Point(23, 90);
            this.checkBoxDeveloper.Name = "checkBoxDeveloper";
            this.checkBoxDeveloper.Size = new System.Drawing.Size(163, 21);
            this.checkBoxDeveloper.TabIndex = 2;
            this.checkBoxDeveloper.Text = "Wersja developerska";
            this.checkBoxDeveloper.UseVisualStyleBackColor = true;
            this.checkBoxDeveloper.MouseEnter += new System.EventHandler(this.checkBoxDeveloper_MouseEnter);
            this.checkBoxDeveloper.MouseLeave += new System.EventHandler(this.checkBoxDeveloper_MouseLeave);
            // 
            // checkBoxDubbing
            // 
            this.checkBoxDubbing.AutoSize = true;
            this.checkBoxDubbing.Location = new System.Drawing.Point(23, 36);
            this.checkBoxDubbing.Name = "checkBoxDubbing";
            this.checkBoxDubbing.Size = new System.Drawing.Size(83, 21);
            this.checkBoxDubbing.TabIndex = 1;
            this.checkBoxDubbing.Text = "Dubbing";
            this.checkBoxDubbing.UseVisualStyleBackColor = true;
            this.checkBoxDubbing.MouseEnter += new System.EventHandler(this.checkBoxDubbing_MouseEnter);
            this.checkBoxDubbing.MouseLeave += new System.EventHandler(this.checkBoxDubbing_MouseLeave);
            // 
            // GroupBoxPage1
            // 
            this.GroupBoxPage1.Controls.Add(this.buttonBrowsePage1);
            this.GroupBoxPage1.Controls.Add(this.textBoxPage1);
            this.GroupBoxPage1.Location = new System.Drawing.Point(40, 100);
            this.GroupBoxPage1.Name = "GroupBoxPage1";
            this.GroupBoxPage1.Size = new System.Drawing.Size(520, 200);
            this.GroupBoxPage1.TabIndex = 4;
            this.GroupBoxPage1.TabStop = false;
            this.GroupBoxPage1.Text = "Krok 1/3";
            // 
            // buttonBrowsePage1
            // 
            this.buttonBrowsePage1.Location = new System.Drawing.Point(378, 111);
            this.buttonBrowsePage1.Name = "buttonBrowsePage1";
            this.buttonBrowsePage1.Size = new System.Drawing.Size(109, 28);
            this.buttonBrowsePage1.TabIndex = 1;
            this.buttonBrowsePage1.Text = "Przeglądaj";
            this.buttonBrowsePage1.UseVisualStyleBackColor = true;
            this.buttonBrowsePage1.Click += new System.EventHandler(this.buttonBrowse1_Click);
            // 
            // textBoxPage1
            // 
            this.textBoxPage1.Location = new System.Drawing.Point(23, 67);
            this.textBoxPage1.Name = "textBoxPage1";
            this.textBoxPage1.Size = new System.Drawing.Size(476, 22);
            this.textBoxPage1.TabIndex = 0;
            // 
            // GroupBoxPage0
            // 
            this.GroupBoxPage0.Controls.Add(this.label1);
            this.GroupBoxPage0.Location = new System.Drawing.Point(40, 100);
            this.GroupBoxPage0.Name = "GroupBoxPage0";
            this.GroupBoxPage0.Size = new System.Drawing.Size(520, 200);
            this.GroupBoxPage0.TabIndex = 3;
            this.GroupBoxPage0.TabStop = false;
            this.GroupBoxPage0.Text = "Krok 0/3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 136);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klikając przycisk \'Dalej\' zaświadczasz,\r\nże posiadasz legalnie kupioną grę:\r\n\r\n1." +
    " Gothic II Noc Kruka\r\n2. Gothic I\r\n\r\nW modyfikacji używane są przedmioty,\r\nmuzyk" +
    "a itp. z ww. produktów.";
            // 
            // ButtonPrev
            // 
            this.ButtonPrev.Location = new System.Drawing.Point(318, 338);
            this.ButtonPrev.Name = "ButtonPrev";
            this.ButtonPrev.Size = new System.Drawing.Size(111, 46);
            this.ButtonPrev.TabIndex = 2;
            this.ButtonPrev.Text = "< Wstecz";
            this.ButtonPrev.UseVisualStyleBackColor = true;
            this.ButtonPrev.Click += new System.EventHandler(this.ButtonPrev_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(435, 338);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(130, 43);
            this.ButtonNext.TabIndex = 1;
            this.ButtonNext.Text = "Dalej >";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Modern No. 20", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.Location = new System.Drawing.Point(40, 40);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(88, 34);
            this.Header.TabIndex = 0;
            this.Header.Text = "None";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBarInstallation
            // 
            this.progressBarInstallation.Location = new System.Drawing.Point(0, 170);
            this.progressBarInstallation.Name = "progressBarInstallation";
            this.progressBarInstallation.Size = new System.Drawing.Size(520, 26);
            this.progressBarInstallation.TabIndex = 1;
            // 
            // labelInstallationInfo
            // 
            this.labelInstallationInfo.AutoSize = true;
            this.labelInstallationInfo.Location = new System.Drawing.Point(43, 299);
            this.labelInstallationInfo.Name = "labelInstallationInfo";
            this.labelInstallationInfo.Size = new System.Drawing.Size(0, 17);
            this.labelInstallationInfo.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G2 Ucieczka Installer";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.GroupBoxPage3.ResumeLayout(false);
            this.GroupBoxPage3.PerformLayout();
            this.GroupBoxPage2.ResumeLayout(false);
            this.GroupBoxPage2.PerformLayout();
            this.groupBoxPage2Info.ResumeLayout(false);
            this.groupBoxPage2Info.PerformLayout();
            this.GroupBoxPage1.ResumeLayout(false);
            this.GroupBoxPage1.PerformLayout();
            this.GroupBoxPage0.ResumeLayout(false);
            this.GroupBoxPage0.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button ButtonPrev;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.GroupBox GroupBoxPage0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GroupBoxPage3;
        private System.Windows.Forms.GroupBox GroupBoxPage2;
        private System.Windows.Forms.GroupBox GroupBoxPage1;
        private System.Windows.Forms.Button buttonBrowsePage1;
        private System.Windows.Forms.TextBox textBoxPage1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBoxPage2Info;
        private System.Windows.Forms.CheckBox checkBoxDX11;
        private System.Windows.Forms.CheckBox checkBoxIcon;
        private System.Windows.Forms.CheckBox checkBoxDeveloper;
        private System.Windows.Forms.CheckBox checkBoxDubbing;
        private System.Windows.Forms.Label labelPage2Info;
        private System.Windows.Forms.CheckBox checkBoxScripts;
        private System.Windows.Forms.Label labelPage3Info;
        private System.Windows.Forms.ProgressBar progressBarInstallation;
        private System.Windows.Forms.Label labelInstallationInfo;
    }
}

