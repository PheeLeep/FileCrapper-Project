using FileCrapper.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FileCrapper.Classes.Delegates;

namespace FileCrapper.Classes {

    /// <summary>
    /// A class that facilitates the file crapping process, and other stuffs like showing dialogs.
    /// </summary>
    internal class FCrapperMotherClass {

        #region Variables
        private readonly List<FCrapperObject> _objects;
        private readonly ListView lv;
        private CancellationTokenSource CancellationTokenSource;
        private CrapProgressDialog ProgressDialog;
        private PleaseWaitDialog _dialog = null;
        private bool _isrunning = false;
        private readonly Stopwatch stopwatch = new Stopwatch();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the number of objects inside the class.
        /// </summary>
        internal int Count { get => _objects.Count; }
        #endregion

        #region Events

        /// <summary>
        /// Fires an event when the number of objects was changed.
        /// </summary>
        internal event ObjectsChangedDelegate ObjectsChanged;
        #endregion

        #region Methods (Public)

        /// <summary>
        /// Initializes a new instance of <see cref="FCrapperMotherClass"/>
        /// </summary>
        /// <param name="lv">A <see cref="ListView"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public FCrapperMotherClass(ListView lv) {
            this.lv = lv ?? throw new ArgumentNullException("lv");
            CancellationTokenSource = new CancellationTokenSource();
            _objects = new List<FCrapperObject>();

            // Run indefinitely for getting the time left.
            Task.Run(() => {
                while (true) {
                    try {
                        if (ProgressDialog != null && stopwatch.IsRunning) {
                            lv.Invoke(new Action(() => {
                                TimeSpan timeLeft = Miscellaneous.GetETA(stopwatch.Elapsed,
                                                            ProgressDialog.ObjectsCrappedProgressBar.Value,
                                                            ProgressDialog.ObjectsCrappedProgressBar.Maximum);
                                string timeLeftStr = string.Format("Time left: {0:00}:{1:00}:{2:00}",
                                                        timeLeft.TotalHours, timeLeft.Minutes, timeLeft.Seconds);
                                ProgressDialog.TimeLeftLabel.Text = timeLeftStr;
                            }));
                        }
                    } catch {
                        // Ignore this error.
                    }
                    Task.Delay(100).Wait();
                }
            });
        }

        /// <summary>
        /// Adds an item. An error message will appear, if the items was at 1,000 limit.
        /// </summary>
        /// <param name="items">An array of strings of paths.</param>
        public void AddItems(string[] items) {
            if (_objects.Count >= 1000) {
                MessageBox.Show(lv, "Items were exceeded by 1000.", "Items exceeded!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Make an asynchronous, to prevent UI blocking.
            Task.Run(() => {
                foreach (string item in items) {
                    if (_objects.Count >= 1000) break; // Break if it was exceeded to 1,000.
                    if (_objects.Count == 0 || !_objects.Exists((f) => f.Path == item)) {
                        _objects.Add(new FCrapperObject(item, CancellationTokenSource.Token));
                        Console.WriteLine(item + " added!");
                    }
                }
                UpdateListView();
                ClosePleaseWaitDialog();
            });
            ShowPleaseWaitDialog();
        }

        /// <summary>
        /// Removes checked items in <see cref="ListView"/>
        /// </summary>
        public void RemoveCheckItems() {
            List<ListViewItem> items = lv.CheckedItems.Cast<ListViewItem>().ToList();

            Task.Run(() => {
                foreach (ListViewItem lvi in items) {
                    FCrapperObject obj = _objects.Find((objF) => objF.Path == lvi.SubItems[2].Text);
                    if (obj != null) {
                        obj.Dispose();
                        _objects.Remove(obj);
                    }
                }
                items = null;
                UpdateListView();
                ClosePleaseWaitDialog();
            });
            ShowPleaseWaitDialog();
        }

        /// <summary>
        /// Initiates to run a file crapping task.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void Run() {
            if (_isrunning) throw new ArgumentException("Task is ongoing.");
            _isrunning = true;
            InitiateProgressWindow();

            Task.Run(() => {
                Task.Delay(200).Wait();
                stopwatch.Restart();

                for (int i = 0; i < _objects.Count; i++) {
                    if (CancellationTokenSource.Token.IsCancellationRequested)
                        break; // Break the for-loop when cancellation occurs.

                    ProgressDialog.DisplayObjectsIndexStatus(i, _objects.Count, i * 100 / _objects.Count);
                    FCrapperObject f = _objects[i]; // Gets the current object.
                    if (f.Exists) {
                        // Attach events first.
                        f.OnFileCrapping += ProgressDialog.F_OnFileCrapping;
                        f.OnFileCrapped += ProgressDialog.F_OnFileCrapped;
                        f.CurrentFileIndexChanged += ProgressDialog.F_CurrentFileIndexChanged;
                        f.CurrentStatusText += ProgressDialog.F_CurrentStatusText;

                        f.StartCrap(); // Start crapping.

                        // Detach events.
                        f.OnFileCrapping -= ProgressDialog.F_OnFileCrapping;
                        f.OnFileCrapped -= ProgressDialog.F_OnFileCrapped;
                        f.CurrentFileIndexChanged -= ProgressDialog.F_CurrentFileIndexChanged;
                        f.CurrentStatusText -= ProgressDialog.F_CurrentStatusText;
                    } else {
                        ProgressDialog.F_CurrentStatusText("Object '" + f.Name + "' doesn't exists! Skipping...");
                    }

                    _objects[i].Dispose();
                    ProgressDialog.DisplayObjectsIndexStatus(i + 1, _objects.Count, (i + 1) * 100 / _objects.Count);
                }

                stopwatch.Stop();

                ProgressDialog.Invoke(new Action(() => {
                    ProgressDialog.StopButton.Enabled = false;
                    if (CancellationTokenSource.Token.IsCancellationRequested) {
                        MessageBox.Show(ProgressDialog, "Heads up! Some files have been crapped before you canceled the task!",
                            "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    } else {
                        MessageBox.Show(ProgressDialog, "File crapping completed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }));

                if (CancellationTokenSource.Token.IsCancellationRequested) {
                    CancellationTokenSource.Dispose();
                    CancellationTokenSource = new CancellationTokenSource();
                }

                _objects.Clear();
                UpdateListView();
                DestroyProgressWindow();

                _isrunning = false;
            }, CancellationTokenSource.Token);
            ProgressDialog.ShowDialog(lv);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Destroys the progress window.
        /// </summary>
        private void DestroyProgressWindow() {
            lv.Invoke(new Action(() => {
                ProgressDialog.StopButton.Click -= StopButton_Click;
                ProgressDialog.Dispose();
                ProgressDialog = null;
            }));
        }

        /// <summary>
        /// Initiates to build a progress window.
        /// </summary>
        private void InitiateProgressWindow() {
            ProgressDialog = new CrapProgressDialog();
            ProgressDialog.CreateControl();
            ProgressDialog.StopButton.Click += StopButton_Click;
        }

        /// <summary>
        /// Shows the please wait dialog.
        /// </summary>
        private void ShowPleaseWaitDialog() {
            if (_dialog == null) {
                _dialog = new Forms.PleaseWaitDialog();
                _dialog.CreateControl();
            }
            Task.Run(() => lv.Invoke(new Action(() => _dialog?.ShowDialog(lv))));
        }

        /// <summary>
        /// Closes the please wait dialog.
        /// </summary>
        private void ClosePleaseWaitDialog() {
            lv.Invoke(new Action(() => {
                _dialog.Dispose();
                _dialog = null;
            }));
        }

        /// <summary>
        /// Updates the <see cref="ListView"/> inside this class. This also triggers the <see cref="ObjectsChanged"/> event.
        /// </summary>
        private void UpdateListView() {
            lv.Invoke(new Action(() => {
                lv.BeginUpdate();
                lv.Items.Clear();
            }));
            if (_objects.Count > 0) {
                List<ListViewItem> items = new List<ListViewItem>();
                foreach (FCrapperObject obj in _objects) {
                    ListViewItem lvi = new ListViewItem(obj.Name);
                    lvi.SubItems.Add(obj.Path);
                    items.Add(lvi);
                }
                lv.Invoke(new Action(() => lv.Items.AddRange(items.ToArray())));
            }
            lv.Invoke(new Action(() => {
                lv.EndUpdate();
                ObjectsChanged?.Invoke();
            }));
        }
        #endregion

        #region Private Methods (Event-related methods)

        private void StopButton_Click(object sender, EventArgs e) {
            if (!CancellationTokenSource.Token.IsCancellationRequested)
                CancellationTokenSource.Cancel();
        }
        #endregion
    }
}
