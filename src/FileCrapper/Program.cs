using FileCrapper.Classes;
using FileCrapper.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Windows.Forms;
using static FileCrapper.Classes.Miscellaneous;

namespace FileCrapper {

    internal class Program : WindowsFormsApplicationBase {

        /// <summary>
        /// A pre-initialized <see cref="System.Random"/> variable. 
        /// </summary>
        internal static readonly Random Random = new Random();

        /// <summary>
        /// Used as a blocker to prevent other instances while the main instance is not loaded yet.
        /// (especially if the <see cref="Miscellaneous.ShowDisclaimer(bool)"/> is still ongoing.)
        /// </summary>
        private bool onInit = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// A parameter containing command-line arguments that was passed.
        /// </param>
        [STAThread]
        static int Main(string[] args) {
            DebugProps.Initialize();

            if (args.Length > 0) {
                switch (args[0]) {
                    /*
                        Registry related arguments will exit (whether if the operation succeed or not.)
                     */
                    case "/regadd":
                        if (!CheckForRegistryAccess()) return -1;
                        if (SettingsClass.CheckContextMenuShortcut(true)) {
                            Console.WriteLine("[i]: This program is running in portable mode, or the registry was already added.");
                            return 0;
                        }
                        if (!SettingsClass.InsertRegistryContextMenu()) {
                            Console.WriteLine("Failed to set a registry!");
                            return -1;
                        }
                        Console.WriteLine("Registry set!");
                        return 0;
                    case "/regremove":
                        if (!CheckForRegistryAccess()) return -1;
                        if (!SettingsClass.CheckContextMenuShortcut(false)) {
                            Console.WriteLine("[i]: This program is running in portable mode, or the registry was not added yet.");
                            return 0;
                        }
                        if (!SettingsClass.RemoveRegistryContextMenu()) {
                            Console.WriteLine("Failed to remove a registry!");
                            return -1;
                        }
                        return 0;
                    case "/obj":
                        // Check if the other arguments required and valid path.
                        try {
                            if (args.Length != 2) return 0;
                            string absPath = Path.GetFullPath(args[1]);
                            if (!File.Exists(absPath) && !Directory.Exists(absPath)) return 0;
                        } catch {
                            return 0;
                        }
                        break;
                    default:
                        return 0;
                }
            }
            try {
                // Initialize the settings and start a program.
                SettingsClass.Initialize();
                Program p = new Program(args);
                p.Run(args);
            } catch (UnauthorizedAccessException) {
                // Ignore this as there is some cases that FileCrapper was running in a different user
                // and attempt to open a program/send an argument.
            } catch (Exception ex) {
                MessageBox.Show(null, "General Error occurred.\n\nCause: " + ex.Message, "General Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            DebugProps.Close();
            return 0;
        }

        /// <summary>
        /// Instantiate a new class of <see cref="Program"/>.
        /// </summary>
        public Program(string[] args) {
            IsSingleInstance = true;
            EnableVisualStyles = true;
            MainForm = new Forms.MainForm();
            if (IsOneInstance() && args.Length == 2 && args[0].Equals("/obj"))
                ((MainForm)MainForm).LoadPathToQueue(args[1]);
            DebugProps.Print(DebugProps.PrintType.Debug, "Visual Styles Rendering completed. Opening the Main Form...");
        }


        protected override void OnRun() {
            // Exit a program if FileCrapper has only one instance and declines the disclaimer.
            if (IsOneInstance() && ShowDisclaimer(true) != DialogResult.Yes) {
                DebugProps.Print(DebugProps.PrintType.Info, "User aborted. Premature exit.");
                DebugProps.Close();
                Environment.Exit(0);
                return;
            }
            onInit = true; // Set onInit to true so that a single instance will accept arguments.
            base.OnRun();
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs) {
            if (!onInit || FileObjectsHandler.Status == FileObjectsHandler.StatusE.Crapping) return;
            if (eventArgs.CommandLine.Count != 2 || !eventArgs.CommandLine[0].Equals("/obj")) return;
            ((MainForm)MainForm).LoadPathToQueue(eventArgs.CommandLine[1]);
            if (MainForm.WindowState == FormWindowState.Minimized) MainForm.WindowState = FormWindowState.Normal;
            MainForm.Activate();
        }

        /// <summary>
        /// Checks if the program is able to modify system registry, by checking if it's running as installable and admin mode.
        /// </summary>
        /// <returns>Returns true if the program is running as admin and installable version. Otherwise false, and printing a reason to the terminal that was listened.</returns>
        private static bool CheckForRegistryAccess() {
            if (!IsInAdminMode() || SettingsClass.IsPortable) {
                Console.WriteLine("[!]: Access denied or the program is in Portable mode.");
                return false;
            }
            return true;
        }
    }
}
