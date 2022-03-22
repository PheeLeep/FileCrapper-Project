using System.Drawing;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class ConfirmationDialog : Form {

        private bool _onHold = false;
        private Point lastPosition;
        public ConfirmationDialog() {
            InitializeComponent();
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
    }
}
