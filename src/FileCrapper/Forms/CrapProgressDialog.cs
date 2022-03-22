using System;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class CrapProgressDialog : Form {
        public CrapProgressDialog() {
            InitializeComponent();
        }

        private void CrapProgressDialog_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
        }

        public void F_OnFileCrapping(int roundsCurrent, int roundsTotal) {
            Invoke(new Action(() => {
                RoundsProgressBar.Maximum = roundsTotal;
                RoundsProgressBar.Value = roundsCurrent;
            }));
        }

        public void F_OnFileCrapped(bool isCancelled, Exception e) {
            if (isCancelled) {
                Invoke(new Action(() => {
                    if (e != null) {
                        errorListRTB.ForeColor = System.Drawing.Color.Red;
                        errorListRTB.AppendText("E: " + e.Message + "\n");
                        errorListRTB.ForeColor = System.Drawing.Color.Black;
                    }
                }));
            }
        }

        public void F_CurrentStatusText(string text) {
            Invoke(new Action(() => {
                errorListRTB.AppendText(text + "\n");
            }));
        }

        public void F_CurrentFileIndexChanged(int index, int total, string fileName, int filesPerce) {
            Invoke(new Action(() => {
                CrapOnoingProgressBar.Value = filesPerce;
                CrapOnoingLabel.Text = "Crapping: " + fileName + "(" + index.ToString() + "/" + total.ToString() + ")";
            }));
        }

        public void DisplayObjectsIndexStatus(int current, int total, int perce) {
            Invoke(new Action(() => {
                ObjectsCrappedProgressBar.Value = perce;
                ObjectsCrappedLabel.Text = "File/s crapped: (x/y)".Replace("x", current.ToString()).Replace("y", total.ToString());
            }));
        }
    }
}
