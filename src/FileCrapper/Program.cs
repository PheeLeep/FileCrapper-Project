using FileCrapper.Classes;
using System;
using System.Windows.Forms;
using static FileCrapper.Classes.Miscellaneous;
using static FileCrapper.Classes.NativeMethods;

namespace FileCrapper {
    internal static class Program {

        /// <summary>
        /// A pre-initialized <see cref="Random"/> variable. 
        /// </summary>
        internal static readonly Random Random = new Random();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            // Exit the program if there is more instance running, or the user aborts the disclaimer.
            if (!IsOneInstance() || ShowDisclaimer(true) != DialogResult.Yes) {
                return;
            }
            AttachConsole(-1);
            SettingsClass.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainForm());
        }
    }
}
