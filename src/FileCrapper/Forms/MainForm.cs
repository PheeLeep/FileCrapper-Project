using FileCrapper.Classes;
using FileCrapper.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class MainForm : Form {

        private bool isKeyDown = false;
        private int currentPage = 1;
        private int maxPage = 1;
        private readonly object locker = new object();
        private Thread t = null;
        /// <summary>
        /// 
        /// </summary>
        private static List<string> queueStrings = new List<string>();
        private bool listInUse = false;
        public MainForm() {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        internal void LoadPathToQueue(string cmdline) {
            lock (locker) {
                while (listInUse) {/**/ }
                listInUse = true;
                if (!queueStrings.Contains(cmdline)) queueStrings.Add(cmdline);
                listInUse = false;
            }
            if (t == null) {
                t = new Thread(() => {
                    bool isInit = false;
                    while (!isInit) {
                        if (IsHandleCreated) isInit = true;
                        Thread.Sleep(100);
                    }
                    while (queueStrings.Count > 0) {
                        while (FileObjectsHandler.Status != FileObjectsHandler.StatusE.Ready || listInUse) {
                            Thread.Sleep(100);
                        }

                        listInUse = true;
                        string path = queueStrings[0];
                        queueStrings.RemoveAt(0);
                        listInUse = false;
                        if (File.Exists(path)) {
                            FileObjectsHandler.AddItems(new string[] { path });
                        } else if (Directory.Exists(path)) {
                            FileObjectsHandler.AddItemsFromDirectory(path);
                        }
                    }
                    t = null;
                });
                t.Start();
            }
        }
        protected override CreateParams CreateParams {
            get {
                // Minimize form and control flickering.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void MainForm_Load(object sender, EventArgs e) {
            FileObjectsHandler.StatusChanged += ObjectsHandlerClass_StatusChanged;
            FileObjectsHandler.ItemsChanged += ObjectsHandlerClass_ItemsChanged;
            FileObjectsHandler.StatusInfoOccurred += ObjectsHandlerClass_StatusInfoOccurred; ;
            if (Miscellaneous.IsInAdminMode()) {
                MessageBox.Show(this, "You're in admin mode! Please use this program with caution, as this will destroy your computer " +
                                "if you crap some critical components, making your computer unbootable or having unexpected behavior.", "Admin Mode",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            NoFilesLabel.Text = Properties.Resources.NoFilesAddedText;
        }

        private void ObjectsHandlerClass_StatusInfoOccurred(string statusInfo) {
            Invoke(new Action(() => {
                if (FileObjectsHandler.Status == FileObjectsHandler.StatusE.Ready || FileObjectsHandler.Status == FileObjectsHandler.StatusE.Crapping)
                    return;
                NoFilesLabel.Text = statusInfo;
                NoFilesLabel.Update();
            }));
        }

        private void ObjectsHandlerClass_ItemsChanged() {
            Invoke(new Action(() => {
                if (FileObjectsHandler.Count > 50) {
                    int max = FileObjectsHandler.Count;
                    maxPage = 0;
                    while (max > 0) {
                        max -= 50;
                        maxPage++;
                    }
                    if (currentPage >= maxPage) currentPage = maxPage;
                }
                PageManagementPanel.Visible = FileObjectsHandler.Count > 50;
                MovePage();
            }));
        }

        private void MovePage() {
            int minIndex = 50 * (currentPage - 1);
            int maxIndex = minIndex + 49;
            if (maxIndex >= FileObjectsHandler.Count) maxIndex = FileObjectsHandler.Count;
            PageCountLabel.Text = "/" + maxPage.ToString();
            PageTextBox.Text = currentPage.ToString();
            ModifyFileTab(FileObjectsHandler.GetItems(minIndex, maxIndex));
        }

        private void ModifyFileTab(FileObject[] objects) {
            ItemsManPanel.Visible = false;

            for (int i = 0; i < ListsPanel.Controls.Count; i++) {
                FileTab ftb = (FileTab)ListsPanel.Controls[i];
                ftb.IsSelected = false;
                if (i >= objects.Length) {
                    ftb.Visible = false;
                    ftb.Tag = null;
                    continue;
                }
                ftb.Visible = true;
                ftb.FileNameLabel.Text = objects[i].FileInfo.Name;
                ftb.FilePathLabel.Text = objects[i].FileInfo.FullName;
                ftb.IsSystemPartPBox.Visible = objects[i].IsASystem;
                ftb.Tag = objects[i].Guid;
            }
            ItemsManPanel.Visible = true;
        }

        private void ObjectsHandlerClass_StatusChanged() {
            Invoke(new Action(() => {
                SwitchButtons(FileObjectsHandler.Status == FileObjectsHandler.StatusE.Ready);
                iconBox.Image = Properties.Resources.Processing;
                switch (FileObjectsHandler.Status) {
                    case FileObjectsHandler.StatusE.Ready:
                        ObjectsCountLabel.Text = FileObjectsHandler.Count.ToString();
                        if (FileObjectsHandler.Count == 0) {
                            if (StagePanel.Controls.GetChildIndex(EmptyItemsPanel) != 0) EmptyItemsPanel.BringToFront();
                            iconBox.Image = Properties.Resources.CrumpledPaper;
                            NoFilesLabel.Text = Properties.Resources.NoFilesAddedText;
                            return;
                        }
                        ItemsManPanel.BringToFront();
                        break;
                    case FileObjectsHandler.StatusE.Adding:
                        if (StagePanel.Controls.GetChildIndex(EmptyItemsPanel) != 0) EmptyItemsPanel.BringToFront();
                        NoFilesLabel.Text = "Adding... Please wait.";
                        break;
                    case FileObjectsHandler.StatusE.Removing:
                        if (StagePanel.Controls.GetChildIndex(EmptyItemsPanel) != 0) EmptyItemsPanel.BringToFront();
                        NoFilesLabel.Text = "Removing... Please wait.";
                        break;
                    case FileObjectsHandler.StatusE.Crapping:
                        if (StagePanel.Controls.GetChildIndex(EmptyItemsPanel) != 0) EmptyItemsPanel.BringToFront();
                        iconBox.Image = Properties.Resources.CrumpledPaper;
                        NoFilesLabel.Text = "Crapping objects... Please wait.";
                        break;
                }

            }));
        }

        private void SwitchButtons(bool isEnable) {
            AddObjectsButton.Enabled = isEnable;
            TickAllButton.Enabled = isEnable;
            RemoveSelectedButton.Enabled = isEnable;
            RemoveAllItemsBtn.Enabled = isEnable;
            CrapAllFilesButton.Enabled = isEnable;
            SettingsButton.Enabled = isEnable;
        }

        private void AdminModeWarnToolStripButton_Click(object sender, EventArgs e) {
            MessageBox.Show(this, Properties.Resources.AdminModeDisclaimer, "Admin Mode", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void AddObjectsButton_MouseClick(object sender, MouseEventArgs e) {
            AddObjectsCMS.Show(AddObjectsButton, e.Location);
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e) {
            if (AddFilesDialog.ShowDialog() == DialogResult.OK)
                FileObjectsHandler.AddItems(AddFilesDialog.FileNames);
        }

        private void addFromFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            if (AddFolderDialog.ShowDialog() == DialogResult.OK)
                FileObjectsHandler.AddItemsFromDirectory(AddFolderDialog.SelectedPath);
        }

        private void TickAllButton_Click(object sender, EventArgs e) {
            if (ListsPanel.Controls.Count == 0) return;
            foreach (FileTab ftb in ListsPanel.Controls)
                ftb.IsSelected = true;
        }

        private void RemoveSelectedButton_Click(object sender, EventArgs e) {
            if (FileObjectsHandler.Count == 0) return;
            List<Guid> selectedGuids = new List<Guid>();
            foreach (FileTab ftb in ListsPanel.Controls)
                if (ftb.Visible && ftb.IsSelected)
                    selectedGuids.Add((Guid)ftb.Tag);
            if (selectedGuids.Count == 0) return;
            if (MessageBox.Show(this, "Do you want to remove selected item/s?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            FileObjectsHandler.RemoveItems(selectedGuids.ToArray());
        }

        private void PageTextBox_KeyDown(object sender, KeyEventArgs e) {
            if (!isKeyDown && e.KeyCode == Keys.Return) {
                isKeyDown = true;
                if (!int.TryParse(PageTextBox.Text, out int x) || x < 1 || x > maxPage) {
                    PageTextBox.BackColor = System.Drawing.Color.Red;
                    return;
                }
                PageTextBox.BackColor = System.Drawing.Color.White;
                currentPage = x;
                MovePage();
            }
        }

        private void PageTextBox_KeyUp(object sender, KeyEventArgs e) {
            if (isKeyDown) isKeyDown = false;
        }

        private void MovePreviousPageButton_Click(object sender, EventArgs e) {
            if (currentPage > 1) currentPage--;
            MovePage();
        }

        private void MoveNextPageButton_Click(object sender, EventArgs e) {
            if (currentPage < maxPage) currentPage++;
            MovePage();
        }

        private void MoveFirstPageButton_Click(object sender, EventArgs e) {
            currentPage = 1;
            MovePage();
        }

        private void MoveLastPageButton_Click(object sender, EventArgs e) {
            currentPage = maxPage;
            MovePage();
        }

        private void RemoveAllItemsBtn_Click(object sender, EventArgs e) {
            if (FileObjectsHandler.Count == 0) return;
            if (MessageBox.Show(this, "Do you want to remove all item/s?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            FileObjectsHandler.RemoveAllItems();
        }

        private void SettingsButton_Click(object sender, EventArgs e) {
            new OptionsDialog().ShowDialog(this);
        }

        private void CrapAllFilesButton_Click(object sender, EventArgs e) {
            if (FileObjectsHandler.Count == 0) {
                MessageBox.Show(this, "No files to destroy.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (new ConfirmationDialog().ShowDialog() != DialogResult.Yes) return;
            CorruptProgressDialog c = new CorruptProgressDialog();
            c.CreateControl(); // Force to create form.
            FileObjectsHandler.StartFileCrapping();
            c.ShowDialog(this);
        }

        private void FormDragEnter(object sender, DragEventArgs e) {
            e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop) && FileObjectsHandler.Status == FileObjectsHandler.StatusE.Ready) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void FormDragDrop(object sender, DragEventArgs e) {
            try {
                foreach (string s in (string[])e.Data.GetData(DataFormats.FileDrop))
                    LoadPathToQueue(s);
            } catch {
                // Ignore.
            }
        }
    }
}
