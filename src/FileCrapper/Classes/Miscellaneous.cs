using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class containing miscellaneous things.
    /// </summary>
    internal static class Miscellaneous {

        /// <summary>
        /// Shows the disclaimer message.
        /// </summary>
        /// <param name="userPermission">Create an interaction to the user, to get its reply.</param>
        /// <returns>Returns a <see cref="DialogResult"/> value.</returns>
        internal static DialogResult ShowDisclaimer(bool userPermission) {
            string text = Properties.Resources.DisclaimerText;
            text += userPermission ? "\n\n" + Properties.Resources.DisclaimerAcknowledge : "";
            MessageBoxButtons buttons = userPermission ? MessageBoxButtons.YesNo : MessageBoxButtons.OK;
            return MessageBox.Show(null, text, "Fair Warning.", buttons, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Checks if the existing process of the same name, is running.
        /// </summary>
        /// <returns>'true' if the process of the same name, exists.</returns>
        internal static bool IsOneInstance() {
            return Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length == 1;
        }

        /// <summary>
        /// Get files from the directory.
        /// </summary>
        /// <param name="DirectoryPath">The directory path.</param>
        /// <param name="recursion">'true' to get files from its subdirectories.</param>
        /// <param name="_token">A current <see cref="CancellationToken"/> object.</param>
        /// <returns>Returns an array of <see cref="FileInfo"/>.</returns>
        internal static FileInfo[] GetFilesFromDirectories(string DirectoryPath, bool recursion, CancellationToken _token) {
            DirectoryInfo dir = new DirectoryInfo(DirectoryPath);
            List<FileInfo> f = new List<FileInfo>();
            try {
                FileInfo[] enumF = dir.EnumerateFiles().ToArray();
                for (int i = 0; i < enumF.Length; i++) {
                    if (_token.IsCancellationRequested)
                        break;
                    f.Add(enumF[i]);
                }
            } catch {
                // Ignore this error.
            }

            if (recursion) {
                try {
                    foreach (DirectoryInfo d in dir.EnumerateDirectories()) {
                        if (_token.IsCancellationRequested)
                            break;
                        f.AddRange(GetFilesFromDirectories(d.FullName, recursion, _token));
                    }
                } catch {
                    // Ignore this error.
                }
            }
            return f.ToArray();
        }

        /// <summary>
        /// Calculate the estimated time of arrival (ETA).
        /// </summary>
        /// <param name="srTimeSpan">A TimeSpan to be use for conversion.</param>
        /// <param name="current">The current value of the current progress.</param>
        /// <param name="total">The total value of the current progress.</param>
        /// <returns>Returns an ETA, in TimeSpan. TimeSpan.Zero if the 'current' is greater than 'total'.</returns>
        internal static TimeSpan GetETA(TimeSpan srTimeSpan, long current, long total) {
            if (current == 0)
                return TimeSpan.Zero;

            if (current > total)
                return TimeSpan.Zero;

            try {
                double elapsedMin = srTimeSpan.TotalMilliseconds / 1000 / 60;
                double minLeft = elapsedMin / current * (total - current);
                TimeSpan ret = TimeSpan.FromMinutes(minLeft);
                return ret;
            } catch {
                return TimeSpan.Zero;
            } // Throw TimeSpan.Zero instead of error

        }
    }
}
