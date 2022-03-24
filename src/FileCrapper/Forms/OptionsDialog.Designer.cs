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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IncludeSubfolderFilesCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RNGByteGenCBox = new System.Windows.Forms.CheckBox();
            this.ByteNullCBox = new System.Windows.Forms.CheckBox();
            this.ByteSwapCBox = new System.Windows.Forms.CheckBox();
            this.IgnoreHeaderBytes = new System.Windows.Forms.CheckBox();
            this.RoundsTrackbar = new System.Windows.Forms.TrackBar();
            this.RoundsLabel = new System.Windows.Forms.Label();
            this.DamageTrackbar = new System.Windows.Forms.TrackBar();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundsTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageTrackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IncludeSubfolderFilesCheckbox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files and Folders";
            // 
            // IncludeSubfolderFilesCheckbox
            // 
            this.IncludeSubfolderFilesCheckbox.AutoSize = true;
            this.IncludeSubfolderFilesCheckbox.Location = new System.Drawing.Point(26, 36);
            this.IncludeSubfolderFilesCheckbox.Name = "IncludeSubfolderFilesCheckbox";
            this.IncludeSubfolderFilesCheckbox.Size = new System.Drawing.Size(218, 20);
            this.IncludeSubfolderFilesCheckbox.TabIndex = 0;
            this.IncludeSubfolderFilesCheckbox.Text = "Include files from the subfolders.";
            this.toolTip1.SetToolTip(this.IncludeSubfolderFilesCheckbox, "Includes files from the the selected directories\' subfolders.");
            this.IncludeSubfolderFilesCheckbox.UseVisualStyleBackColor = true;
            this.IncludeSubfolderFilesCheckbox.CheckedChanged += new System.EventHandler(this.IncludeSubfolderFilesCheckbox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.IgnoreHeaderBytes);
            this.groupBox2.Controls.Add(this.RoundsTrackbar);
            this.groupBox2.Controls.Add(this.RoundsLabel);
            this.groupBox2.Controls.Add(this.DamageTrackbar);
            this.groupBox2.Controls.Add(this.DamageLabel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 330);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crapping Options";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RNGByteGenCBox);
            this.groupBox3.Controls.Add(this.ByteNullCBox);
            this.groupBox3.Controls.Add(this.ByteSwapCBox);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 124);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Crapping Methods";
            // 
            // RNGByteGenCBox
            // 
            this.RNGByteGenCBox.AutoSize = true;
            this.RNGByteGenCBox.Location = new System.Drawing.Point(23, 84);
            this.RNGByteGenCBox.Name = "RNGByteGenCBox";
            this.RNGByteGenCBox.Size = new System.Drawing.Size(180, 20);
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
            this.ByteNullCBox.Size = new System.Drawing.Size(95, 20);
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
            this.ByteSwapCBox.Size = new System.Drawing.Size(119, 20);
            this.ByteSwapCBox.TabIndex = 5;
            this.ByteSwapCBox.Text = "Byte Swapping";
            this.toolTip1.SetToolTip(this.ByteSwapCBox, "Swaps two different bytes\' positions.");
            this.ByteSwapCBox.UseVisualStyleBackColor = true;
            this.ByteSwapCBox.CheckedChanged += new System.EventHandler(this.ByteSwapCBox_CheckedChanged);
            this.ByteSwapCBox.Click += new System.EventHandler(this.CBoxClick);
            // 
            // IgnoreHeaderBytes
            // 
            this.IgnoreHeaderBytes.AutoSize = true;
            this.IgnoreHeaderBytes.Location = new System.Drawing.Point(26, 177);
            this.IgnoreHeaderBytes.Name = "IgnoreHeaderBytes";
            this.IgnoreHeaderBytes.Size = new System.Drawing.Size(255, 20);
            this.IgnoreHeaderBytes.TabIndex = 4;
            this.IgnoreHeaderBytes.Text = "Ignore first 128 bytes. (Except text files)";
            this.toolTip1.SetToolTip(this.IgnoreHeaderBytes, "Ignores the common first 128 bytes on every file, except the text-based files.");
            this.IgnoreHeaderBytes.UseVisualStyleBackColor = true;
            this.IgnoreHeaderBytes.CheckedChanged += new System.EventHandler(this.IgnoreHeaderBytes_CheckedChanged);
            // 
            // RoundsTrackbar
            // 
            this.RoundsTrackbar.Location = new System.Drawing.Point(12, 130);
            this.RoundsTrackbar.Maximum = 1000;
            this.RoundsTrackbar.Minimum = 10;
            this.RoundsTrackbar.Name = "RoundsTrackbar";
            this.RoundsTrackbar.Size = new System.Drawing.Size(307, 56);
            this.RoundsTrackbar.TabIndex = 3;
            this.toolTip1.SetToolTip(this.RoundsTrackbar, "Adds on how many rounds to occur during crapping progress.");
            this.RoundsTrackbar.Value = 10;
            this.RoundsTrackbar.Scroll += new System.EventHandler(this.RoundsTrackbar_Scroll);
            // 
            // RoundsLabel
            // 
            this.RoundsLabel.AutoSize = true;
            this.RoundsLabel.Location = new System.Drawing.Point(9, 111);
            this.RoundsLabel.Name = "RoundsLabel";
            this.RoundsLabel.Size = new System.Drawing.Size(82, 16);
            this.RoundsLabel.TabIndex = 2;
            this.RoundsLabel.Text = "Rounds: (10)";
            // 
            // DamageTrackbar
            // 
            this.DamageTrackbar.Location = new System.Drawing.Point(12, 52);
            this.DamageTrackbar.Maximum = 100;
            this.DamageTrackbar.Minimum = 1;
            this.DamageTrackbar.Name = "DamageTrackbar";
            this.DamageTrackbar.Size = new System.Drawing.Size(307, 56);
            this.DamageTrackbar.TabIndex = 1;
            this.toolTip1.SetToolTip(this.DamageTrackbar, "Adds on how much the chance will occur a damage per round.");
            this.DamageTrackbar.Value = 1;
            this.DamageTrackbar.Scroll += new System.EventHandler(this.DamageTrackbar_Scroll);
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Location = new System.Drawing.Point(9, 33);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(153, 16);
            this.DamageLabel.TabIndex = 0;
            this.DamageLabel.Text = "Damage per round: (1%)";
            // 
            // OptionsDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(331, 409);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoundsTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DamageTrackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox IncludeSubfolderFilesCheckbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar DamageTrackbar;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.TrackBar RoundsTrackbar;
        private System.Windows.Forms.Label RoundsLabel;
        private System.Windows.Forms.CheckBox IgnoreHeaderBytes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ByteSwapCBox;
        private System.Windows.Forms.CheckBox RNGByteGenCBox;
        private System.Windows.Forms.CheckBox ByteNullCBox;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}