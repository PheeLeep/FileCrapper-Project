using FileCrapper.Classes;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using static FileCrapper.Classes.NativeMethods;

namespace FileCrapper.Forms {

    /// <summary>
    /// A <see cref="Form"/> containing options and about section.
    /// </summary>
    public partial class OptionsDialog : Form {

        private bool isInitialized = false;
        private bool isMouseDown = false;
        private const int BCM_SETSHIELD = 0x160C;
        private readonly object locker = new object();

        public OptionsDialog() {
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

        private void OptionsDialog_Load(object sender, EventArgs e) {
            AddRemoveContextMenuBtn.FlatStyle = FlatStyle.System;
            SendMessage(AddRemoveContextMenuBtn.Handle, BCM_SETSHIELD, 0, 1); // Request to acquire UAC shield.

            // Disable Context Menu Panel if the Program is in portable version.
#if IsPortable
            AddRemoveContextMenuBtn.Enabled = false;
            PanelPortableWarning.Show();
#endif
            CheckCMXButton();
            ReloadItems();
            ChangeIntensityDesc();
        }

        private void CheckCMXButton() {
#if IsPortable
            return;
#endif
            AddRemoveContextMenuBtn.Text = (SettingsClass.CheckContextMenuShortcut(true) ? "Remove" : "Add") + " to Explorer's Context Menu";
        }

        private void IncludeSubfolderFilesCheckbox_CheckedChanged(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.SubfolderRecursion = IncludeSubfolderFilesCheckbox.Checked;

        }

        private void DamageTrackbar_Scroll(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.DamageChance = DamageTrackbar.Value;
            DamageLabel.Text = "Damage Rate per round: (x%)".Replace("x", DamageTrackbar.Value.ToString());

        }

        private void RoundsTrackbar_Scroll(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.Rounds = RoundsTrackbar.Value;
            RoundsLabel.Text = "Rounds: x".Replace("x", RoundsTrackbar.Value.ToString());

        }

        private void IgnoreHeaderBytes_CheckedChanged(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.HeaderExclusion = IgnoreHeaderBytes.Checked;

        }

        private void ByteSwapCBox_CheckedChanged(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.ByteSwapped = ByteSwapCBox.Checked;

        }

        private void ByteNullCBox_CheckedChanged(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.ByteNullify = ByteNullCBox.Checked;

        }

        private void RNGByteGenCBox_CheckedChanged(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.ByteGenerate = RNGByteGenCBox.Checked;

        }

        private void CBoxClick(object sender, EventArgs e) {
            if (!isInitialized) return;
            if (!ByteSwapCBox.Checked && !ByteNullCBox.Checked) {
                RNGByteGenCBox.Checked = true;
                RNGByteGenCBox.Enabled = false;
            } else {
                RNGByteGenCBox.Enabled = true;
            }
        }

        private void IntensityTrackBar_Scroll(object sender, EventArgs e) {
            ChangeIntensityDesc();
            IntensityLabel.Update();
            IntensityIcon.Update();
        }

        private void ChangeIntensityDesc() {
            switch (IntensityTrackBar.Value) {
                case 0:
                    IntensityLabel.Text = "Custom:\r\n\r\nCustomize the damage chance, passes, etc.";
                    IntensityIcon.Image = Properties.Resources.SettingsAdjust;
                    break;
                case 1:
                    IntensityLabel.Text = "Quick:\r\n\r\nQuickly crapping a file with less performance hits. File corruption efficacy are possibly less.";
                    IntensityIcon.Image = Properties.Resources.SettingsQuickMode;
                    break;
                case 2:
                    IntensityLabel.Text = "Balance:\r\n\r\nBalances the succession speed and efficacy of crapping files.";
                    IntensityIcon.Image = Properties.Resources.SettingsBalanceIntense;
                    break;
                case 3:
                    IntensityLabel.Text = "Sanity-wise:\r\n\r\nSignificantly increase the file corruption efficacy," +
                                          " in exchange of performance penalty and drive's wear and tear.";
                    IntensityIcon.Image = Properties.Resources.SettingsSaneMode;
                    break;
            }
        }
        private void ReloadItems() {
            lock (locker) {
                isInitialized = false;
                IncludeSubfolderFilesCheckbox.Checked = SettingsClass.SubfolderRecursion;
                DamageTrackbar.Value = SettingsClass.DamageChance;
                RoundsTrackbar.Value = SettingsClass.Rounds;
                IgnoreHeaderBytes.Checked = SettingsClass.HeaderExclusion;
                IntensityTrackBar.Value = SettingsClass.Intensity;

                ByteNullCBox.Checked = SettingsClass.ByteNullify;
                ByteSwapCBox.Checked = SettingsClass.ByteSwapped;
                RNGByteGenCBox.Checked = SettingsClass.ByteGenerate;
                PassesTrackBar.Value = SettingsClass.Pass;
                DamageLabel.Text = "Damage Rate per round: (x%)".Replace("x", DamageTrackbar.Value.ToString());
                RoundsLabel.Text = "Rounds: x".Replace("x", RoundsTrackbar.Value.ToString());
                PassesLabel.Text = "Pass" + (PassesTrackBar.Value != 1 ? "es" : "") + ": " + PassesTrackBar.Value.ToString();
                HighPrioThreadCBox.Checked = SettingsClass.ThreadHighPriority;
                SetOptions(SettingsClass.Intensity == 0);
                isInitialized = true;
            }
        }

        private void PassesTrackBar_Scroll(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.Pass = PassesTrackBar.Value;
            PassesLabel.Text = "Pass" + (PassesTrackBar.Value != 1 ? "es" : "") + ": " + PassesTrackBar.Value.ToString();

        }

        private void OptionsDialog_FormClosing(object sender, FormClosingEventArgs e) {
            SettingsClass.Save();
        }

        private void SetOptions(bool isAccessible) {
            DamageTrackbar.Enabled = isAccessible;
            RoundsTrackbar.Enabled = isAccessible;
            IgnoreHeaderBytes.Enabled = isAccessible;
            ByteNullCBox.Enabled = isAccessible;
            ByteSwapCBox.Enabled = isAccessible;
            RNGByteGenCBox.Enabled = isAccessible;
            PassesTrackBar.Enabled = isAccessible;

            PanelPreferedDamage.Visible = !isAccessible;
        }

        private void IntensityTrackBar_MouseDown(object sender, MouseEventArgs e) {
            if (!isMouseDown && e.Button == MouseButtons.Left) isMouseDown = true;
        }

        private void IntensityTrackBar_MouseUp(object sender, MouseEventArgs e) {
            if (isMouseDown && isInitialized) {
                isMouseDown = false;
                SettingsClass.Intensity = IntensityTrackBar.Value;
                ReloadItems();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string repoLink = "https://github.com/PheeLeep/FileCrapper-Project";
            Process.Start(repoLink);
        }

        private void LicenseLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string licenseLink = "https://github.com/PheeLeep/FileCrapper-Project/blob/master/LICENSE";
            Process.Start(licenseLink);
        }

        private void HighPrioThreadCBox_CheckedChanged(object sender, EventArgs e) {
            if (!isInitialized) return;
            SettingsClass.ThreadHighPriority = HighPrioThreadCBox.Checked;
        }

        private void AddRemoveContextMenuBtn_Click(object sender, EventArgs e) {
            if (!AddRemoveContextMenuBtn.Enabled) return;
            lock (locker) {
                AddRemoveContextMenuBtn.Enabled = false;
                try {
                    ProcessStartInfo psi = new ProcessStartInfo() {
                        FileName = Assembly.GetExecutingAssembly().Location,
                        Arguments = SettingsClass.CheckContextMenuShortcut(true) ? "/regremove" : "/regadd",
                        Verb = "runas"
                    };
                    Process p = Process.Start(psi);
                    p.WaitForExit();
                    BringToFront();
                } catch {
                    // Ignore this if the user denies it.
                }
                CheckCMXButton();

                AddRemoveContextMenuBtn.Enabled = true;
            }
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                // No choice lods, disable warning sa URI Hardcode.
#pragma warning disable S1075 // URIs should not be hardcoded
                Process.Start("https://icons8.com");
#pragma warning restore S1075 // URIs should not be hardcoded
            } catch {
                // Ignore.
            }
        }
    }
}
