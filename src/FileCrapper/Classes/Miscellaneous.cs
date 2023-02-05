using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class containing miscellaneous methods.
    /// </summary>
    internal static class Miscellaneous {

        /// <summary>
        /// Checks if the running instance of the program, has an administrative privilege.
        /// </summary>
        /// <returns>Returns true,\ if it has an admin privilege; otherwise false.</returns>
        internal static bool IsInAdminMode() {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

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

        /// <summary>
        /// Calculate the bytes of a file and convert into human-readable bytes.
        /// </summary>
        /// <param name="byt">The length size of a file.</param>
        /// <returns>Returns the human-readable size format.</returns>
        internal static string CalculateBytes(long byt) {
            double DoubleBytes;
            try {
                switch (byt) {
                    case long n when byt >= 1099511627776: {
                        DoubleBytes = Convert.ToDouble(byt / (double)1099511627776);
                        return Math.Round(DoubleBytes, 2).ToString() + " TB";
                    }

                    case long n when 1073741824 <= byt && byt <= 1099511627775: {
                        DoubleBytes = Convert.ToDouble(byt / (double)1073741824);
                        return Math.Round(DoubleBytes, 2).ToString() + " GB";
                    }

                    case long n when 1048576 <= byt && byt <= 1073741823: {
                        DoubleBytes = Convert.ToDouble(byt / (double)1048576);
                        return Math.Round(DoubleBytes, 2).ToString() + " MB";
                    }

                    case long n when 1024 <= byt && byt <= 1048575: {
                        DoubleBytes = Convert.ToDouble(byt / (double)1024);
                        return Math.Round(DoubleBytes, 2).ToString() + " KB";
                    }

                    case long n when 0 <= byt && byt <= 1023: {
                        DoubleBytes = byt;
                        return Math.Round(DoubleBytes, 2).ToString() + " bytes";
                    }

                    default: {
                        return "0 KB";
                    }
                }
            } catch {
                return "0 KB";
            }
        }
    }
}
