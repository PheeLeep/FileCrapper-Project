using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class PleaseWaitDialog : Form {
        public PleaseWaitDialog() {
            InitializeComponent();
        }

        private void PleaseWaitDialog_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
        }
    }
}
