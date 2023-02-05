namespace FileCrapper.Forms {
    partial class OptionsDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.IncludeSubfolderFilesCheckbox = new System.Windows.Forms.CheckBox();
            this.RNGByteGenCBox = new System.Windows.Forms.CheckBox();
            this.ByteNullCBox = new System.Windows.Forms.CheckBox();
            this.ByteSwapCBox = new System.Windows.Forms.CheckBox();
            this.RoundsTrackbar = new System.Windows.Forms.TrackBar();
            this.DamageTrackbar = new System.Windows.Forms.TrackBar();
            this.PassesTrackBar = new System.Windows.Forms.TrackBar();
            this.IgnoreHeaderBytes = new System.Windows.Forms.CheckBox();
            this.HighPrioThreadCBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.IntensityIcon = new System.Windows.Forms.PictureBox();
            this.IntensityLabel = new System.Windows.Forms.Label();
            this.IntensityTrackBar = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PanelPreferedDamage = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PassesLabel = new System.Windows.Forms.Label();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.RoundsLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddRemoveContextMenuBtn = new System.Windows.Forms.Button();
            this.PanelPortableWarning = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.LicenseLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IconPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RoundsTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassesTrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntensityIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntensityTrackBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.PanelPreferedDamage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PanelPortableWarning.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // IncludeSubfolderFilesCheckbox
            // 
            this.IncludeSubfolderFilesCheckbox.AutoSize = true;
            this.IncludeSubfolderFilesCheckbox.Location = new System.Drawing.Point(64, 234);
            this.IncludeSubfolderFilesCheckbox.Name = "IncludeSubfolderFilesCheckbox";
            this.IncludeSubfolderFilesCheckbox.Size = new System.Drawing.Size(247, 24);
            this.IncludeSubfolderFilesCheckbox.TabIndex = 1;
            this.IncludeSubfolderFilesCheckbox.Text = "Include files from the subfolders.";
            this.toolTip1.SetToolTip(this.IncludeSubfolderFilesCheckbox, "Includes files from the the selected directories\' subfolders.");
            this.IncludeSubfolderFilesCheckbox.UseVisualStyleBackColor = true;
            this.IncludeSubfolderFilesCheckbox.CheckedChanged += new System.EventHandler(this.IncludeSubfolderFilesCheckbox_CheckedChanged);
            // 
            // RNGByteGenCBox
            // 
            this.RNGByteGenCBox.AutoSize = true;
            this.RNGByteGenCBox.Location = new System.Drawing.Point(23, 84);
            this.RNGByteGenCBox.Name = "RNGByteGenCBox";
            this.RNGByteGenCBox.Size = new System.Drawing.Size(199, 24);
            this.RNGByteGenCBox.TabIndex = 7;
            this.RNGByteGenCBox.Text = "Random byte generation.";
            this.toolTip1.SetToolTip(this.RNGByteGenCBox, "Randomly generate a byte, and overwrites on the selected position.");
            this.RNGByteGenCBox.UseVisualStyleBackColor = true;
            this.RNGByteGenCBox.CheckedChanged += new System.EventHandler(this.RNGByteGenCBox_CheckedChanged);
            this.RNGByteGenCBox.Click += new System.EventHandler(this.CBoxClick);
            // 
            // ByteNullCBox
            // 
            this.ByteNullCBox.AutoSize = true;
            this.ByteNullCBox.Location = new System.Drawing.Point(23, 58);
            this.ByteNullCBox.Name = "ByteNullCBox";
            this.ByteNullCBox.Size = new System.Drawing.Size(107, 24);
            this.ByteNullCBox.TabIndex = 6;
            this.ByteNullCBox.Text = "Byte Nullify";
            this.toolTip1.SetToolTip(this.ByteNullCBox, "Nullifies the selected byte of the file.");
            this.ByteNullCBox.UseVisualStyleBackColor = true;
            this.ByteNullCBox.CheckedChanged += new System.EventHandler(this.ByteNullCBox_CheckedChanged);
            this.ByteNullCBox.Click += new System.EventHandler(this.CBoxClick);
            // 
            // ByteSwapCBox
            // 
            this.ByteSwapCBox.AutoSize = true;
            this.ByteSwapCBox.Location = new System.Drawing.Point(23, 32);
            this.ByteSwapCBox.Name = "ByteSwapCBox";
            this.ByteSwapCBox.Size = new System.Drawing.Size(130, 24);
            this.ByteSwapCBox.TabIndex = 5;
            this.ByteSwapCBox.Text = "Byte Swapping";
            this.toolTip1.SetToolTip(this.ByteSwapCBox, "Swaps two different bytes\' positions.");
            this.ByteSwapCBox.UseVisualStyleBackColor = true;
            this.ByteSwapCBox.CheckedChanged += new System.EventHandler(this.ByteSwapCBox_CheckedChanged);
            this.ByteSwapCBox.Click += new System.EventHandler(this.CBoxClick);
            // 
            // RoundsTrackbar
            // 
            this.RoundsTrackbar.Location = new System.Drawing.Point(300, 48);
            this.RoundsTrackbar.Maximum = 10000;
            this.RoundsTrackbar.Minimum = 100;
            this.RoundsTrackbar.Name = "RoundsTrackbar";
            this.RoundsTrackbar.Size = new System.Drawing.Size(355, 56);
            this.RoundsTrackbar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.RoundsTrackbar, "Adds on how many rounds to occur during crapping progress.");
            this.RoundsTrackbar.Value = 100;
            this.RoundsTrackbar.Scroll += new System.EventHandler(this.RoundsTrackbar_Scroll);
            // 
            // DamageTrackbar
            // 
            this.DamageTrackbar.Location = new System.Drawing.Point(300, 109);
            this.DamageTrackbar.Maximum = 100;
            this.DamageTrackbar.Minimum = 10;
            this.DamageTrackbar.Name = "DamageTrackbar";
            this.DamageTrackbar.Size = new System.Drawing.Size(355, 56);
            this.DamageTrackbar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.DamageTrackbar, "Adds on how much the chance will occur a damage per round.");
            this.DamageTrackbar.Value = 10;
            this.DamageTrackbar.Scroll += new System.EventHandler(this.DamageTrackbar_Scroll);
            // 
            // PassesTrackBar
            // 
            this.PassesTrackBar.Location = new System.Drawing.Point(301, 171);
            this.PassesTrackBar.Maximum = 20;
            this.PassesTrackBar.Minimum = 1;
            this.PassesTrackBar.Name = "PassesTrackBar";
            this.PassesTrackBar.Size = new System.Drawing.Size(355, 56);
            this.PassesTrackBar.TabIndex = 11;
            this.toolTip1.SetToolTip(this.PassesTrackBar, "Adds on how much the chance will occur a damage per round.");
            this.PassesTrackBar.Value = 1;
            this.PassesTrackBar.Scroll += new System.EventHandler(this.PassesTrackBar_Scroll);
            // 
            // IgnoreHeaderBytes
            // 
            this.IgnoreHeaderBytes.AutoSize = true;
            this.IgnoreHeaderBytes.Location = new System.Drawing.Point(27, 184);
            this.IgnoreHeaderBytes.Name = "IgnoreHeaderBytes";
            this.IgnoreHeaderBytes.Size = new System.Drawing.Size(243, 24);
            this.IgnoreHeaderBytes.TabIndex = 13;
            this.IgnoreHeaderBytes.Text = "Ignore Header Bytes (128 bytes)";
            this.toolTip1.SetToolTip(this.IgnoreHeaderBytes, "Ignores the common first 128 bytes on every file, except the text-based files.");
            this.IgnoreHeaderBytes.UseVisualStyleBackColor = true;
            // 
            // HighPrioThreadCBox
            // 
            this.HighPrioThreadCBox.AutoSize = true;
            this.HighPrioThreadCBox.Location = new System.Drawing.Point(51, 173);
            this.HighPrioThreadCBox.Name = "HighPrioThreadCBox";
            this.HighPrioThreadCBox.Size = new System.Drawing.Size(213, 24);
            this.HighPrioThreadCBox.TabIndex = 4;
            this.HighPrioThreadCBox.Text = "Run threads in high priority.";
            this.toolTip1.SetToolTip(this.HighPrioThreadCBox, "Includes files from the the selected directories\' subfolders.");
            this.HighPrioThreadCBox.UseVisualStyleBackColor = true;
            this.HighPrioThreadCBox.CheckedChanged += new System.EventHandler(this.HighPrioThreadCBox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 379);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.IncludeSubfolderFilesCheckbox);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.IntensityIcon);
            this.groupBox4.Controls.Add(this.IntensityLabel);
            this.groupBox4.Controls.Add(this.IntensityTrackBar);
            this.groupBox4.Location = new System.Drawing.Point(20, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(637, 213);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Intensity";
            // 
            // IntensityIcon
            // 
            this.IntensityIcon.Image = global::FileCrapper.Properties.Resources.SettingsAdjust;
            this.IntensityIcon.Location = new System.Drawing.Point(64, 117);
            this.IntensityIcon.Name = "IntensityIcon";
            this.IntensityIcon.Size = new System.Drawing.Size(64, 64);
            this.IntensityIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IntensityIcon.TabIndex = 2;
            this.IntensityIcon.TabStop = false;
            // 
            // IntensityLabel
            // 
            this.IntensityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntensityLabel.Location = new System.Drawing.Point(148, 99);
            this.IntensityLabel.Name = "IntensityLabel";
            this.IntensityLabel.Size = new System.Drawing.Size(451, 98);
            this.IntensityLabel.TabIndex = 1;
            this.IntensityLabel.Text = "Custom:\r\n\r\nCustomize the damage chance, passes, etc.";
            // 
            // IntensityTrackBar
            // 
            this.IntensityTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IntensityTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.IntensityTrackBar.Location = new System.Drawing.Point(44, 40);
            this.IntensityTrackBar.Maximum = 3;
            this.IntensityTrackBar.Name = "IntensityTrackBar";
            this.IntensityTrackBar.Size = new System.Drawing.Size(555, 56);
            this.IntensityTrackBar.TabIndex = 0;
            this.IntensityTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.IntensityTrackBar.Scroll += new System.EventHandler(this.IntensityTrackBar_Scroll);
            this.IntensityTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IntensityTrackBar_MouseDown);
            this.IntensityTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.IntensityTrackBar_MouseUp);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.tabPage2.Controls.Add(this.PanelPreferedDamage);
            this.tabPage2.Controls.Add(this.IgnoreHeaderBytes);
            this.tabPage2.Controls.Add(this.PassesLabel);
            this.tabPage2.Controls.Add(this.PassesTrackBar);
            this.tabPage2.Controls.Add(this.DamageLabel);
            this.tabPage2.Controls.Add(this.DamageTrackbar);
            this.tabPage2.Controls.Add(this.RoundsTrackbar);
            this.tabPage2.Controls.Add(this.RoundsLabel);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Damage";
            // 
            // PanelPreferedDamage
            // 
            this.PanelPreferedDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PanelPreferedDamage.Controls.Add(this.label1);
            this.PanelPreferedDamage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelPreferedDamage.ForeColor = System.Drawing.Color.White;
            this.PanelPreferedDamage.Location = new System.Drawing.Point(3, 301);
            this.PanelPreferedDamage.Name = "PanelPreferedDamage";
            this.PanelPreferedDamage.Size = new System.Drawing.Size(673, 42);
            this.PanelPreferedDamage.TabIndex = 14;
            this.PanelPreferedDamage.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "This option is not available in when not setting the Intensity as Custom.";
            // 
            // PassesLabel
            // 
            this.PassesLabel.AutoSize = true;
            this.PassesLabel.Location = new System.Drawing.Point(296, 148);
            this.PassesLabel.Name = "PassesLabel";
            this.PassesLabel.Size = new System.Drawing.Size(71, 20);
            this.PassesLabel.TabIndex = 12;
            this.PassesLabel.Text = "Pass/es: 1";
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Location = new System.Drawing.Point(295, 86);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(214, 20);
            this.DamageLabel.TabIndex = 10;
            this.DamageLabel.Text = "Damage Rate per round: (10%)";
            // 
            // RoundsLabel
            // 
            this.RoundsLabel.AutoSize = true;
            this.RoundsLabel.Location = new System.Drawing.Point(296, 22);
            this.RoundsLabel.Name = "RoundsLabel";
            this.RoundsLabel.Size = new System.Drawing.Size(99, 20);
            this.RoundsLabel.TabIndex = 7;
            this.RoundsLabel.Text = "Rounds: (100)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RNGByteGenCBox);
            this.groupBox3.Controls.Add(this.ByteNullCBox);
            this.groupBox3.Controls.Add(this.ByteSwapCBox);
            this.groupBox3.Location = new System.Drawing.Point(27, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 146);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Damage Methods";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.HighPrioThreadCBox);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(679, 346);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Miscellaneous";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddRemoveContextMenuBtn);
            this.groupBox1.Controls.Add(this.PanelPortableWarning);
            this.groupBox1.Location = new System.Drawing.Point(20, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Integration";
            // 
            // AddRemoveContextMenuBtn
            // 
            this.AddRemoveContextMenuBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddRemoveContextMenuBtn.Location = new System.Drawing.Point(31, 36);
            this.AddRemoveContextMenuBtn.Name = "AddRemoveContextMenuBtn";
            this.AddRemoveContextMenuBtn.Size = new System.Drawing.Size(295, 32);
            this.AddRemoveContextMenuBtn.TabIndex = 3;
            this.AddRemoveContextMenuBtn.Text = "Add to Explorer\'s Context Menu";
            this.AddRemoveContextMenuBtn.UseVisualStyleBackColor = true;
            this.AddRemoveContextMenuBtn.Click += new System.EventHandler(this.AddRemoveContextMenuBtn_Click);
            // 
            // PanelPortableWarning
            // 
            this.PanelPortableWarning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PanelPortableWarning.Controls.Add(this.label2);
            this.PanelPortableWarning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelPortableWarning.ForeColor = System.Drawing.Color.White;
            this.PanelPortableWarning.Location = new System.Drawing.Point(3, 83);
            this.PanelPortableWarning.Name = "PanelPortableWarning";
            this.PanelPortableWarning.Size = new System.Drawing.Size(631, 42);
            this.PanelPortableWarning.TabIndex = 2;
            this.PanelPortableWarning.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(310, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "This option is not available in portable mode.";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.linkLabel2);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.linkLabel1);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.LicenseLinkLabel);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.IconPictureBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(679, 346);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(125, 224);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(109, 20);
            this.linkLabel2.TabIndex = 17;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Icons by Icons8";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel2_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Icons: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Credit/s:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Author: PheeLeep";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(115, 134);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 20);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub Repo";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Website: ";
            // 
            // LicenseLinkLabel
            // 
            this.LicenseLinkLabel.AutoSize = true;
            this.LicenseLinkLabel.Location = new System.Drawing.Point(115, 156);
            this.LicenseLinkLabel.Name = "LicenseLinkLabel";
            this.LicenseLinkLabel.Size = new System.Drawing.Size(86, 20);
            this.LicenseLinkLabel.TabIndex = 11;
            this.LicenseLinkLabel.TabStop = true;
            this.LicenseLinkLabel.Text = "MIT License";
            this.LicenseLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "License:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(124, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "A Program that Corrupts in an Easy and Worry-free.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(119, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "FileCrapper";
            // 
            // IconPictureBox
            // 
            this.IconPictureBox.Image = global::FileCrapper.Properties.Resources.fcrapper;
            this.IconPictureBox.Location = new System.Drawing.Point(49, 27);
            this.IconPictureBox.Name = "IconPictureBox";
            this.IconPictureBox.Size = new System.Drawing.Size(64, 64);
            this.IconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.IconPictureBox.TabIndex = 7;
            this.IconPictureBox.TabStop = false;
            // 
            // OptionsDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(687, 379);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsDialog_FormClosing);
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RoundsTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassesTrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IntensityIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntensityTrackBar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.PanelPreferedDamage.ResumeLayout(false);
            this.PanelPreferedDamage.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.PanelPortableWarning.ResumeLayout(false);
            this.PanelPortableWarning.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox IncludeSubfolderFilesCheckbox;
        private System.Windows.Forms.TrackBar IntensityTrackBar;
        private System.Windows.Forms.PictureBox IntensityIcon;
        private System.Windows.Forms.Label IntensityLabel;
        private System.Windows.Forms.TrackBar RoundsTrackbar;
        private System.Windows.Forms.Label RoundsLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox RNGByteGenCBox;
        private System.Windows.Forms.CheckBox ByteNullCBox;
        private System.Windows.Forms.CheckBox ByteSwapCBox;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.TrackBar DamageTrackbar;
        private System.Windows.Forms.Label PassesLabel;
        private System.Windows.Forms.TrackBar PassesTrackBar;
        private System.Windows.Forms.CheckBox IgnoreHeaderBytes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel PanelPortableWarning;
        private System.Windows.Forms.Button AddRemoveContextMenuBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelPreferedDamage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel LicenseLinkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox IconPictureBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox HighPrioThreadCBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}