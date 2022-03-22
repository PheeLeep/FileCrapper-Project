using System;
using System.Windows.Forms;

namespace FileCrapper.Forms {
    public partial class OptionsDialog : Form {
        bool _initialized = false;
        public OptionsDialog() {
            InitializeComponent();
        }

        private void OptionsDialog_Load(object sender, EventArgs e) {
            IncludeSubfolderFilesCheckbox.Checked = Properties.Settings.Default.FileInSubfolderIncluded;
            DamageTrackbar.Value = Properties.Settings.Default.DamageChance;
            RoundsTrackbar.Value = Properties.Settings.Default.Rounds;
            IgnoreHeaderBytes.Checked = Properties.Settings.Default.ExcludeHeaderBytes;

            ByteNullCBox.Checked = Properties.Settings.Default.ByteNullify;
            ByteSwapCBox.Checked = Properties.Settings.Default.ByteSwapped;
            RNGByteGenCBox.Checked = Properties.Settings.Default.ByteGenerate;

            DamageLabel.Text = "Damage: (x%)".Replace("x", DamageTrackbar.Value.ToString());
            RoundsLabel.Text = "Rounds: x".Replace("x", RoundsTrackbar.Value.ToString());
            _initialized = true;
        }

        private void IncludeSubfolderFilesCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (_initialized) {
                Properties.Settings.Default.FileInSubfolderIncluded = IncludeSubfolderFilesCheckbox.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void DamageTrackbar_Scroll(object sender, EventArgs e) {
            if (_initialized) {
                Properties.Settings.Default.DamageChance = DamageTrackbar.Value;
                Properties.Settings.Default.Save();
                DamageLabel.Text = "Damage: (x%)".Replace("x", DamageTrackbar.Value.ToString());
            }
        }

        private void RoundsTrackbar_Scroll(object sender, EventArgs e) {
            if (_initialized) {
                Properties.Settings.Default.Rounds = RoundsTrackbar.Value;
                Properties.Settings.Default.Save();
                RoundsLabel.Text = "Rounds: x".Replace("x", RoundsTrackbar.Value.ToString());
            }
        }

        private void IgnoreHeaderBytes_CheckedChanged(object sender, EventArgs e) {
            if (_initialized) {
                Properties.Settings.Default.ExcludeHeaderBytes = IgnoreHeaderBytes.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void ByteSwapCBox_CheckedChanged(object sender, EventArgs e) {
            if (_initialized) {
                Properties.Settings.Default.ByteSwapped = ByteSwapCBox.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void ByteNullCBox_CheckedChanged(object sender, EventArgs e) {
            if (_initialized) {
                Properties.Settings.Default.ByteNullify = ByteNullCBox.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void RNGByteGenCBox_CheckedChanged(object sender, EventArgs e) {
            if (_initialized) {
                Properties.Settings.Default.ByteGenerate = RNGByteGenCBox.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void CBoxClick(object sender, EventArgs e) {
            if (!ByteSwapCBox.Checked && !ByteNullCBox.Checked) {
                RNGByteGenCBox.Checked = true;
                RNGByteGenCBox.Enabled = false;
            } else {
                RNGByteGenCBox.Enabled = true;
            }
        }
    }
}
