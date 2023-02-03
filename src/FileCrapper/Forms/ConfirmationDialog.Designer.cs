namespace FileCrapper.Forms {
    partial class ConfirmationDialog {
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
            this.SliderHolderPanel = new System.Windows.Forms.Panel();
            this.SliderPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AcknowledgeRiskCBox = new System.Windows.Forms.CheckBox();
            this.SliderHolderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SliderHolderPanel
            // 
            this.SliderHolderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SliderHolderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.SliderHolderPanel.Controls.Add(this.SliderPanel);
            this.SliderHolderPanel.Controls.Add(this.label2);
            this.SliderHolderPanel.Location = new System.Drawing.Point(26, 163);
            this.SliderHolderPanel.Name = "SliderHolderPanel";
            this.SliderHolderPanel.Size = new System.Drawing.Size(533, 25);
            this.SliderHolderPanel.TabIndex = 0;
            // 
            // SliderPanel
            // 
            this.SliderPanel.BackColor = System.Drawing.Color.Red;
            this.SliderPanel.Location = new System.Drawing.Point(0, 0);
            this.SliderPanel.Name = "SliderPanel";
            this.SliderPanel.Size = new System.Drawing.Size(69, 25);
            this.SliderPanel.TabIndex = 0;
            this.SliderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SliderPanel_MouseDown);
            this.SliderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SliderPanel_MouseMove);
            this.SliderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SliderPanel_MouseUp);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(161, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Swipe the red bar, to the right. >>>";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 131);
            this.label1.TabIndex = 1;
            this.label1.Text = "This operation will destroy your selected files, and it is irreversible once it i" +
    "s done!\r\n\r\nIf you acknowledged this consequences, click and hold the slider belo" +
    "w, and swipe it to the right to accept.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FileCrapper.Properties.Resources.ConfirmWarning;
            this.pictureBox1.Location = new System.Drawing.Point(26, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // AcknowledgeRiskCBox
            // 
            this.AcknowledgeRiskCBox.AutoSize = true;
            this.AcknowledgeRiskCBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcknowledgeRiskCBox.Location = new System.Drawing.Point(115, 167);
            this.AcknowledgeRiskCBox.Name = "AcknowledgeRiskCBox";
            this.AcknowledgeRiskCBox.Size = new System.Drawing.Size(269, 24);
            this.AcknowledgeRiskCBox.TabIndex = 3;
            this.AcknowledgeRiskCBox.Text = "I acknowledge the risk and proceed.";
            this.AcknowledgeRiskCBox.UseVisualStyleBackColor = true;
            this.AcknowledgeRiskCBox.Visible = false;
            this.AcknowledgeRiskCBox.CheckedChanged += new System.EventHandler(this.AcknowledgeRiskCBox_CheckedChanged);
            // 
            // ConfirmationDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(583, 205);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SliderHolderPanel);
            this.Controls.Add(this.AcknowledgeRiskCBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmationDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Final Warning";
            this.Load += new System.EventHandler(this.ConfirmationDialog_Load);
            this.SliderHolderPanel.ResumeLayout(false);
            this.SliderHolderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel SliderHolderPanel;
        private System.Windows.Forms.Panel SliderPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox AcknowledgeRiskCBox;
    }
}