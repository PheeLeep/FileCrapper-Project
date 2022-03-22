namespace FileCrapper.Forms {
    partial class CrapProgressDialog {
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
            this.ObjectsCrappedLabel = new System.Windows.Forms.Label();
            this.ObjectsCrappedProgressBar = new System.Windows.Forms.ProgressBar();
            this.CrapOnoingProgressBar = new System.Windows.Forms.ProgressBar();
            this.CrapOnoingLabel = new System.Windows.Forms.Label();
            this.TimeLeftLabel = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorListRTB = new System.Windows.Forms.RichTextBox();
            this.RoundsProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectsCrappedLabel
            // 
            this.ObjectsCrappedLabel.AutoEllipsis = true;
            this.ObjectsCrappedLabel.Location = new System.Drawing.Point(15, 21);
            this.ObjectsCrappedLabel.Name = "ObjectsCrappedLabel";
            this.ObjectsCrappedLabel.Size = new System.Drawing.Size(310, 17);
            this.ObjectsCrappedLabel.TabIndex = 0;
            this.ObjectsCrappedLabel.Text = "Object/s crapped: --/--";
            // 
            // ObjectsCrappedProgressBar
            // 
            this.ObjectsCrappedProgressBar.Location = new System.Drawing.Point(18, 41);
            this.ObjectsCrappedProgressBar.Name = "ObjectsCrappedProgressBar";
            this.ObjectsCrappedProgressBar.Size = new System.Drawing.Size(307, 17);
            this.ObjectsCrappedProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ObjectsCrappedProgressBar.TabIndex = 1;
            // 
            // CrapOnoingProgressBar
            // 
            this.CrapOnoingProgressBar.Location = new System.Drawing.Point(18, 93);
            this.CrapOnoingProgressBar.Name = "CrapOnoingProgressBar";
            this.CrapOnoingProgressBar.Size = new System.Drawing.Size(307, 17);
            this.CrapOnoingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.CrapOnoingProgressBar.TabIndex = 3;
            // 
            // CrapOnoingLabel
            // 
            this.CrapOnoingLabel.AutoEllipsis = true;
            this.CrapOnoingLabel.Location = new System.Drawing.Point(15, 73);
            this.CrapOnoingLabel.Name = "CrapOnoingLabel";
            this.CrapOnoingLabel.Size = new System.Drawing.Size(311, 16);
            this.CrapOnoingLabel.TabIndex = 2;
            this.CrapOnoingLabel.Text = "Crapping:";
            // 
            // TimeLeftLabel
            // 
            this.TimeLeftLabel.AutoSize = true;
            this.TimeLeftLabel.Location = new System.Drawing.Point(15, 155);
            this.TimeLeftLabel.Name = "TimeLeftLabel";
            this.TimeLeftLabel.Size = new System.Drawing.Size(98, 16);
            this.TimeLeftLabel.TabIndex = 4;
            this.TimeLeftLabel.Text = "Time Left: --:--:--";
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(250, 152);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 5;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorListRTB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 182);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log/s:";
            // 
            // errorListRTB
            // 
            this.errorListRTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorListRTB.ForeColor = System.Drawing.Color.Black;
            this.errorListRTB.Location = new System.Drawing.Point(3, 18);
            this.errorListRTB.Name = "errorListRTB";
            this.errorListRTB.ReadOnly = true;
            this.errorListRTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.errorListRTB.Size = new System.Drawing.Size(332, 161);
            this.errorListRTB.TabIndex = 0;
            this.errorListRTB.Text = "";
            // 
            // RoundsProgressBar
            // 
            this.RoundsProgressBar.Location = new System.Drawing.Point(18, 116);
            this.RoundsProgressBar.Name = "RoundsProgressBar";
            this.RoundsProgressBar.Size = new System.Drawing.Size(307, 17);
            this.RoundsProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.RoundsProgressBar.TabIndex = 8;
            // 
            // CrapProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 364);
            this.ControlBox = false;
            this.Controls.Add(this.RoundsProgressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.TimeLeftLabel);
            this.Controls.Add(this.CrapOnoingProgressBar);
            this.Controls.Add(this.CrapOnoingLabel);
            this.Controls.Add(this.ObjectsCrappedProgressBar);
            this.Controls.Add(this.ObjectsCrappedLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrapProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Progress";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CrapProgressDialog_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button StopButton;
        internal System.Windows.Forms.Label ObjectsCrappedLabel;
        internal System.Windows.Forms.ProgressBar ObjectsCrappedProgressBar;
        internal System.Windows.Forms.ProgressBar CrapOnoingProgressBar;
        internal System.Windows.Forms.Label CrapOnoingLabel;
        internal System.Windows.Forms.Label TimeLeftLabel;
        internal System.Windows.Forms.RichTextBox errorListRTB;
        internal System.Windows.Forms.ProgressBar RoundsProgressBar;
    }
}