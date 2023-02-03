using FileCrapper.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class ConfirmationDialog : Form {

        private bool _onHold = false;
        private Point lastPosition;
        public ConfirmationDialog() {
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
        private void SliderPanel_MouseDown(object sender, MouseEventArgs e) {
            _onHold = true;
            lastPosition = e.Location;
        }

        private void SliderPanel_MouseMove(object sender, MouseEventArgs e) {
            if (_onHold) {
                SliderPanel.Location = new Point(SliderPanel.Location.X - lastPosition.X + e.X, 0);
                int sliderX = SliderPanel.Location.X;
                if (sliderX < 0) {
                    SliderPanel.Location = new Point(0, 0);
                } else if (sliderX > (SliderHolderPanel.Width - SliderPanel.Width)) {
                    SliderPanel.Location = new Point(SliderHolderPanel.Width - SliderPanel.Width, 0);
                }
                Update();
            }
        }

        private void SliderPanel_MouseUp(object sender, MouseEventArgs e) {
            _onHold = false;
            int sliderX = SliderPanel.Location.X;
            if (sliderX < 0 || (sliderX >= 0 && sliderX < (SliderHolderPanel.Width - SliderPanel.Width))) {
                SliderPanel.Location = new Point(0, 0);
            } else {
                DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void ConfirmationDialog_Load(object sender, System.EventArgs e) {
            if (FileObjectsHandler.SystemFilesObjectsExists()) {
                Height = 293;
                AcknowledgeRiskCBox.Show();
                label1.Text = "You've selected files that are part of the operating system. Corrupting those said files " +
                              "could lead your computer at risk to an unstable state.\n\n" +
                              "By ticking the checkbox and sliding the bar to the right, you're responsible to possible damage " +
                              "to your computer after you corrupt selected system files.";
                SliderHolderPanel.Enabled = false;
                pictureBox1.Image = Properties.Resources.ConfirmSystemFileWarn;
            }
        }

        private void AcknowledgeRiskCBox_CheckedChanged(object sender, System.EventArgs e) {
            SliderHolderPanel.Enabled = AcknowledgeRiskCBox.Checked;
        }
    }
}
