namespace FileCrapper.Controls {
    partial class FileTab {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.SelectedCBox = new System.Windows.Forms.CheckBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.IsSystemPartPBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.revealInFileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.IsSystemPartPBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectedCBox
            // 
            this.SelectedCBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SelectedCBox.AutoSize = true;
            this.SelectedCBox.Location = new System.Drawing.Point(12, 21);
            this.SelectedCBox.Name = "SelectedCBox";
            this.SelectedCBox.Size = new System.Drawing.Size(18, 17);
            this.SelectedCBox.TabIndex = 0;
            this.SelectedCBox.UseVisualStyleBackColor = true;
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileNameLabel.AutoEllipsis = true;
            this.FileNameLabel.ContextMenuStrip = this.contextMenuStrip1;
            this.FileNameLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(44, 8);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(514, 23);
            this.FileNameLabel.TabIndex = 1;
            this.FileNameLabel.Text = "Filename";
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilePathLabel.AutoEllipsis = true;
            this.FilePathLabel.ContextMenuStrip = this.contextMenuStrip1;
            this.FilePathLabel.Location = new System.Drawing.Point(45, 33);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(540, 20);
            this.FilePathLabel.TabIndex = 2;
            this.FilePathLabel.Text = "C:";
            // 
            // IsSystemPartPBox
            // 
            this.IsSystemPartPBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsSystemPartPBox.Image = global::FileCrapper.Properties.Resources.IsSystemIcon;
            this.IsSystemPartPBox.Location = new System.Drawing.Point(584, 3);
            this.IsSystemPartPBox.Name = "IsSystemPartPBox";
            this.IsSystemPartPBox.Size = new System.Drawing.Size(32, 32);
            this.IsSystemPartPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IsSystemPartPBox.TabIndex = 3;
            this.IsSystemPartPBox.TabStop = false;
            this.toolTip1.SetToolTip(this.IsSystemPartPBox, "This is a part of a Windows\' system directory. Crapping this file will lead to un" +
        "usual behavior to a computer.");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.revealInFileExplorerToolStripMenuItem,
            this.toolStripSeparator1,
            this.propertiesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 58);
            // 
            // revealInFileExplorerToolStripMenuItem
            // 
            this.revealInFileExplorerToolStripMenuItem.Name = "revealInFileExplorerToolStripMenuItem";
            this.revealInFileExplorerToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.revealInFileExplorerToolStripMenuItem.Text = "Reveal in File Explorer";
            this.revealInFileExplorerToolStripMenuItem.Click += new System.EventHandler(this.revealInFileExplorerToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // FileTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.IsSystemPartPBox);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.SelectedCBox);
            this.DoubleBuffered = true;
            this.Name = "FileTab";
            this.Size = new System.Drawing.Size(625, 59);
            ((System.ComponentModel.ISupportInitialize)(this.IsSystemPartPBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox SelectedCBox;
        internal System.Windows.Forms.Label FileNameLabel;
        internal System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.PictureBox IsSystemPartPBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem revealInFileExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
    }
}
