using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FileCrapper.Controls {

    /// <summary>
    /// A control that shows information of an object from <see cref="FileCrapper.Classes.FileObject"/>.
    /// </summary>
    public partial class FileTab : UserControl {
        public FileTab() {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        internal bool IsSelected {
            get { return SelectedCBox.Checked; }
            set { SelectedCBox.Checked = value; }
        }

        private void revealInFileExplorerToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Process.Start("explorer.exe", "/select, \"" + FilePathLabel.Text + "\"");
            } catch (Exception ex) {
                MessageBox.Show(this, "Failed to open a file.\n\nError: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
