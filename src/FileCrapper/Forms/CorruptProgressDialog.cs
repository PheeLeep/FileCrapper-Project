using FileCrapper.Classes;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class CorruptProgressDialog : Form {
        private bool isFinished = false;
        private static readonly Stopwatch stopwatch = new Stopwatch();
        public CorruptProgressDialog() {
            InitializeComponent();
        }

        protected override CreateParams CreateParams {
            get {
                // Minimize form and control flickering.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void CorruptProgressDialog_FormClosing(object sender, FormClosingEventArgs e) {
            if (!isFinished) {
                e.Cancel = true;
                return;
            }
            FileObjectsHandler.StatusChanged -= FileObjectsHandler_StatusChanged;
            FileObjectsHandler.FileCrappingProgress -= FileObjectsHandler_FileCrappingProgress;
            FileObjectsHandler.FileCrappingSucceed -= FileObjectsHandler_FileCrappingSucceed;
            FileObjectsHandler.StatusInfoOccurred -= FileObjectsHandler_StatusInfoOccurred;
        }

        private void CorruptProgressDialog_Load(object sender, EventArgs e) {
            stopwatch.Start();
            FileObjectsHandler.StatusChanged += FileObjectsHandler_StatusChanged;
            FileObjectsHandler.FileCrappingProgress += FileObjectsHandler_FileCrappingProgress;
            FileObjectsHandler.FileCrappingSucceed += FileObjectsHandler_FileCrappingSucceed;
            FileObjectsHandler.StatusInfoOccurred += FileObjectsHandler_StatusInfoOccurred;
        }

        private void FileObjectsHandler_StatusInfoOccurred(string statusInfo) {
            if (!IsHandleCreated) return;
            Invoke(new Action(() => {
                richTextBox1.AppendText(statusInfo + "\n");
                richTextBox1.ScrollToCaret();
            }));
        }

        private void FileObjectsHandler_FileCrappingSucceed(double percentage, long bytDamage) {
            if (!IsHandleCreated) return;
            Invoke(new Action(() => {
                stopwatch.Stop();
                label1.Text = "File Corruption Succeed! (Avg. Damage: "+percentage.ToString()+"%)";
                label2.Text = Miscellaneous.CalculateBytes(bytDamage) + " of all files' contents were damaged.";
                CloseButton.Enabled = true;
                Text = "File Corruption Success";
                isFinished = true;
            }));
        }

        private void FileObjectsHandler_FileCrappingProgress(int current, int total) {
            if (!IsHandleCreated) return;
            Invoke(new Action(() => {
                progressBar1.Maximum = total;
                progressBar1.Value = current;
                TimeSpan ts = Miscellaneous.GetETA(stopwatch.Elapsed, current, total);
                String timeLeft = ts.Seconds.ToString() + " second/s left.";
                if (ts.Minutes > 0 || ts.Hours > 0 || ts.Days > 0) timeLeft = "and " + timeLeft;
                if (ts.Minutes > 0) timeLeft = ts.Minutes.ToString() + " minute/s, " + timeLeft;
                if (ts.Hours > 0) timeLeft = ts.Hours.ToString() + " hour/s, " + timeLeft;
                if (ts.Days > 0) timeLeft = ts.Days.ToString() + " day/s, " + timeLeft;
                label2.Text = timeLeft;
            }));
        }

        private void FileObjectsHandler_StatusChanged() {
            if (!IsHandleCreated) return;
            Invoke(new Action(() => {
                isFinished = FileObjectsHandler.Status == FileObjectsHandler.StatusE.Ready;
                CloseButton.Enabled = isFinished;
            }));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (richTextBox1.Visible) {
                richTextBox1.Visible = false;
                Height = 203;
                linkLabel1.Text = "Show Logs";
                return;
            }
            richTextBox1.Visible = true;
            Height = 397;
            linkLabel1.Text = "Hide Logs";
        }

        private void CloseButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
