namespace FileCrapper.Forms {
    partial class MainForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lvFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncheckAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeCheckedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NoFilesLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ObjectsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.AdminModeWarnToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.startCrappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.disclaimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddFilesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddFolderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.CheckAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveCheckedItemsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveAllItemsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.StartCrapToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AdminModeWarnToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.listViewContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvFiles
            // 
            this.lvFiles.AllowDrop = true;
            this.lvFiles.CheckBoxes = true;
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lvFiles.ContextMenuStrip = this.listViewContextMenu;
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.HideSelection = false;
            this.lvFiles.Location = new System.Drawing.Point(3, 18);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(433, 302);
            this.lvFiles.TabIndex = 0;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragDrop);
            this.lvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 113;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Path";
            this.columnHeader3.Width = 232;
            // 
            // listViewContextMenu
            // 
            this.listViewContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.listViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkAllToolStripMenuItem,
            this.uncheckAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeCheckedItemsToolStripMenuItem,
            this.removeAllItemsToolStripMenuItem});
            this.listViewContextMenu.Name = "listViewContextMenu";
            this.listViewContextMenu.Size = new System.Drawing.Size(233, 106);
            // 
            // checkAllToolStripMenuItem
            // 
            this.checkAllToolStripMenuItem.Name = "checkAllToolStripMenuItem";
            this.checkAllToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.checkAllToolStripMenuItem.Text = "Check All";
            this.checkAllToolStripMenuItem.Click += new System.EventHandler(this.CheckAllToolStripMenuItem_Click);
            // 
            // uncheckAllToolStripMenuItem
            // 
            this.uncheckAllToolStripMenuItem.Name = "uncheckAllToolStripMenuItem";
            this.uncheckAllToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.uncheckAllToolStripMenuItem.Text = "Uncheck All";
            this.uncheckAllToolStripMenuItem.Click += new System.EventHandler(this.UncheckAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // removeCheckedItemsToolStripMenuItem
            // 
            this.removeCheckedItemsToolStripMenuItem.Name = "removeCheckedItemsToolStripMenuItem";
            this.removeCheckedItemsToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.removeCheckedItemsToolStripMenuItem.Text = "Remove Checked Items";
            this.removeCheckedItemsToolStripMenuItem.Click += new System.EventHandler(this.RemoveCheckedItemsToolStripMenuItem_Click);
            // 
            // removeAllItemsToolStripMenuItem
            // 
            this.removeAllItemsToolStripMenuItem.Name = "removeAllItemsToolStripMenuItem";
            this.removeAllItemsToolStripMenuItem.Size = new System.Drawing.Size(232, 24);
            this.removeAllItemsToolStripMenuItem.Text = "Remove All Items";
            this.removeAllItemsToolStripMenuItem.Click += new System.EventHandler(this.RemoveAllItemsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NoFilesLabel);
            this.groupBox1.Controls.Add(this.lvFiles);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 323);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files and Folders";
            // 
            // NoFilesLabel
            // 
            this.NoFilesLabel.AllowDrop = true;
            this.NoFilesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NoFilesLabel.BackColor = System.Drawing.Color.White;
            this.NoFilesLabel.Location = new System.Drawing.Point(68, 104);
            this.NoFilesLabel.Name = "NoFilesLabel";
            this.NoFilesLabel.Size = new System.Drawing.Size(303, 129);
            this.NoFilesLabel.TabIndex = 1;
            this.NoFilesLabel.Text = resources.GetString("NoFilesLabel.Text");
            this.NoFilesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoFilesLabel.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragDrop);
            this.NoFilesLabel.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ObjectsStatusLabel,
            this.toolStripSeparator7,
            this.AdminModeWarnToolStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(439, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ObjectsStatusLabel
            // 
            this.ObjectsStatusLabel.Name = "ObjectsStatusLabel";
            this.ObjectsStatusLabel.Size = new System.Drawing.Size(78, 20);
            this.ObjectsStatusLabel.Text = "0 object/s.";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
            // 
            // AdminModeWarnToolStripLabel
            // 
            this.AdminModeWarnToolStripLabel.Name = "AdminModeWarnToolStripLabel";
            this.AdminModeWarnToolStripLabel.Size = new System.Drawing.Size(249, 20);
            this.AdminModeWarnToolStripLabel.Text = "Admin Mode! Proceed with Caution!";
            this.AdminModeWarnToolStripLabel.Visible = false;
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(439, 28);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.toolStripSeparator2,
            this.startCrappingToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.addFilesToolStripMenuItem.Text = "Add file/s";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.AddFilesToolStripButton_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.addFolderToolStripMenuItem.Text = "Add folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.AddFolderToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(254, 6);
            // 
            // startCrappingToolStripMenuItem
            // 
            this.startCrappingToolStripMenuItem.Name = "startCrappingToolStripMenuItem";
            this.startCrappingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.startCrappingToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.startCrappingToolStripMenuItem.Text = "Start Crapping";
            this.startCrappingToolStripMenuItem.Click += new System.EventHandler(this.StartCrapToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(254, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(257, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator4,
            this.disclaimerToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 26);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(255, 26);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(252, 6);
            // 
            // disclaimerToolStripMenuItem
            // 
            this.disclaimerToolStripMenuItem.Name = "disclaimerToolStripMenuItem";
            this.disclaimerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.disclaimerToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.disclaimerToolStripMenuItem.Text = "Disclaimer";
            this.disclaimerToolStripMenuItem.Click += new System.EventHandler(this.DisclaimerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(255, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFilesToolStripButton,
            this.AddFolderToolStripButton,
            this.toolStripSeparator8,
            this.CheckAllToolStripButton,
            this.RemoveCheckedItemsToolStripButton,
            this.RemoveAllItemsToolStripButton,
            this.toolStripSeparator5,
            this.StartCrapToolStripButton,
            this.toolStripSeparator6,
            this.OptionsToolStripButton,
            this.AdminModeWarnToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(439, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddFilesToolStripButton
            // 
            this.AddFilesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFilesToolStripButton.Image = global::FileCrapper.Properties.Resources.AddFile;
            this.AddFilesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFilesToolStripButton.Name = "AddFilesToolStripButton";
            this.AddFilesToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.AddFilesToolStripButton.Text = "Add File/s";
            this.AddFilesToolStripButton.Click += new System.EventHandler(this.AddFilesToolStripButton_Click);
            // 
            // AddFolderToolStripButton
            // 
            this.AddFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddFolderToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddFolderToolStripButton.Image")));
            this.AddFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddFolderToolStripButton.Name = "AddFolderToolStripButton";
            this.AddFolderToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.AddFolderToolStripButton.Text = "Add Folder";
            this.AddFolderToolStripButton.Click += new System.EventHandler(this.AddFolderToolStripButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
            // 
            // CheckAllToolStripButton
            // 
            this.CheckAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CheckAllToolStripButton.Image = global::FileCrapper.Properties.Resources.SelectAll;
            this.CheckAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CheckAllToolStripButton.Name = "CheckAllToolStripButton";
            this.CheckAllToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.CheckAllToolStripButton.Text = "Check All";
            this.CheckAllToolStripButton.Click += new System.EventHandler(this.CheckAllToolStripMenuItem_Click);
            // 
            // RemoveCheckedItemsToolStripButton
            // 
            this.RemoveCheckedItemsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveCheckedItemsToolStripButton.Image = global::FileCrapper.Properties.Resources.DeleteSelected;
            this.RemoveCheckedItemsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveCheckedItemsToolStripButton.Name = "RemoveCheckedItemsToolStripButton";
            this.RemoveCheckedItemsToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.RemoveCheckedItemsToolStripButton.Text = "Remove Checked Item/s.";
            this.RemoveCheckedItemsToolStripButton.Click += new System.EventHandler(this.RemoveCheckedItemsToolStripMenuItem_Click);
            // 
            // RemoveAllItemsToolStripButton
            // 
            this.RemoveAllItemsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveAllItemsToolStripButton.Image = global::FileCrapper.Properties.Resources.DeleteAll;
            this.RemoveAllItemsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveAllItemsToolStripButton.Name = "RemoveAllItemsToolStripButton";
            this.RemoveAllItemsToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.RemoveAllItemsToolStripButton.Text = "Remove All Item/s";
            this.RemoveAllItemsToolStripButton.Click += new System.EventHandler(this.RemoveAllItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // StartCrapToolStripButton
            // 
            this.StartCrapToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StartCrapToolStripButton.Image = global::FileCrapper.Properties.Resources.CrapItems;
            this.StartCrapToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartCrapToolStripButton.Name = "StartCrapToolStripButton";
            this.StartCrapToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.StartCrapToolStripButton.Text = "Start Crapping";
            this.StartCrapToolStripButton.Click += new System.EventHandler(this.StartCrapToolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
            // 
            // OptionsToolStripButton
            // 
            this.OptionsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OptionsToolStripButton.Image = global::FileCrapper.Properties.Resources.SettingsImage;
            this.OptionsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptionsToolStripButton.Name = "OptionsToolStripButton";
            this.OptionsToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.OptionsToolStripButton.Text = "Options";
            this.OptionsToolStripButton.Click += new System.EventHandler(this.SettingsToolStripButton_Click);
            // 
            // AdminModeWarnToolStripButton
            // 
            this.AdminModeWarnToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AdminModeWarnToolStripButton.Image = global::FileCrapper.Properties.Resources.InAdminModeWarn;
            this.AdminModeWarnToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AdminModeWarnToolStripButton.Name = "AdminModeWarnToolStripButton";
            this.AdminModeWarnToolStripButton.Size = new System.Drawing.Size(29, 28);
            this.AdminModeWarnToolStripButton.Text = "Admin Mode Warning";
            this.AdminModeWarnToolStripButton.Visible = false;
            this.AdminModeWarnToolStripButton.Click += new System.EventHandler(this.AdminModeWarnToolStripButton_Click);
            // 
            // AddFilesDialog
            // 
            this.AddFilesDialog.FileName = "openFileDialog1";
            this.AddFilesDialog.Multiselect = true;
            this.AddFilesDialog.Title = "Add File/s";
            // 
            // AddFolderDialog
            // 
            this.AddFolderDialog.ShowNewFolderButton = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(439, 404);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainMenuStrip);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileCrapper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.listViewContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip listViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem checkAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncheckAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem removeCheckedItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeAllItemsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem startCrappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddFilesToolStripButton;
        private System.Windows.Forms.ToolStripButton AddFolderToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton StartCrapToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton OptionsToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disclaimerToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog AddFilesDialog;
        private System.Windows.Forms.FolderBrowserDialog AddFolderDialog;
        private System.Windows.Forms.ToolStripStatusLabel ObjectsStatusLabel;
        private System.Windows.Forms.ToolStripButton AdminModeWarnToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripStatusLabel AdminModeWarnToolStripLabel;
        private System.Windows.Forms.Label NoFilesLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton CheckAllToolStripButton;
        private System.Windows.Forms.ToolStripButton RemoveCheckedItemsToolStripButton;
        private System.Windows.Forms.ToolStripButton RemoveAllItemsToolStripButton;
    }
}

