using FileCrapper.Classes;
using System;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class MainForm : Form {
        private FCrapperMotherClass motherClass;
        public MainForm() {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            motherClass = new FCrapperMotherClass(lvFiles);
            motherClass.ObjectsChanged += MotherClass_ObjectsChanged;
            if (Miscellaneous.IsInAdminMode()) {
                AdminModeWarnToolStripButton.Visible = true;
                AdminModeWarnToolStripLabel.Visible = true;
                MessageBox.Show(this, "You're in admin mode! Please use this program with caution, as this will destroy your computer " +
                                "if you crap some critical components, making your computer unbootable or having unexpected behavior.", "Admin Mode",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void MotherClass_ObjectsChanged() {
            ObjectsStatusLabel.Text = motherClass.Count.ToString() + " object/s";
            NoFilesLabel.Visible = motherClass.Count == 0; // Shows if the count is zero.
        }

        private void AddFilesToolStripButton_Click(object sender, EventArgs e) {
            if (AddFilesDialog.ShowDialog() == DialogResult.OK)
                motherClass.AddItems(AddFilesDialog.FileNames);
        }

        private void AddFolderToolStripButton_Click(object sender, EventArgs e) {
            if (AddFolderDialog.ShowDialog() == DialogResult.OK)
                motherClass.AddItems(new string[] { AddFolderDialog.SelectedPath });
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e) {
            new Forms.AboutDialog().ShowDialog();
        }

        private void DisclaimerToolStripMenuItem_Click(object sender, EventArgs e) {
            Miscellaneous.ShowDisclaimer(false);
        }

        private void SettingsToolStripButton_Click(object sender, EventArgs e) {
            new Forms.OptionsDialog().ShowDialog();
        }

        private void CheckAllToolStripMenuItem_Click(object sender, EventArgs e) {
            if (motherClass.Count == 0) return;
            lvFiles.BeginUpdate();
            foreach (ListViewItem item in lvFiles.Items)
                item.Checked = true;
            lvFiles.EndUpdate();
        }

        private void UncheckAllToolStripMenuItem_Click(object sender, EventArgs e) {
            if (motherClass.Count == 0) return;
            lvFiles.BeginUpdate();
            foreach (ListViewItem item in lvFiles.Items)
                item.Checked = false;
            lvFiles.EndUpdate();
        }

        private void RemoveCheckedItemsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (motherClass.Count == 0) return;
            motherClass.RemoveCheckItems();
        }

        private void RemoveAllItemsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (motherClass.Count == 0) return;
            checkAllToolStripMenuItem.PerformClick();
            motherClass.RemoveCheckItems();
        }

        private void StartCrapToolStripButton_Click(object sender, EventArgs e) {
            if (motherClass.Count == 0) {
                MessageBox.Show(this, "No files to crap. Please add files first.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (new Forms.ConfirmationDialog().ShowDialog() == DialogResult.Yes)
                motherClass.Run();
        }

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e) {
            MessageBox.Show(this, Properties.Resources.HelpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lvFiles_DragEnter(object sender, DragEventArgs e) {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void lvFiles_DragDrop(object sender, DragEventArgs e) {
            string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
            motherClass.AddItems(objects);
        }

        private void AdminModeWarnToolStripButton_Click(object sender, EventArgs e) {
            MessageBox.Show(this, Properties.Resources.AdminModeDisclaimer, "Admin Mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
