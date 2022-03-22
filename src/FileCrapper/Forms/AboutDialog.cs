using System.Diagnostics;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class AboutDialog : Form {
        public AboutDialog() {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string repoLink = "https://github.com/PheeLeep/FileCrapper-Project";
            Process.Start(repoLink);
        }
    }
}
