using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace FileCrapper.Classes {
    /// <summary>
    /// A static class containing settings values and methods on loading/saving.
    /// </summary>
    internal static class SettingsClass {
        /// <summary>
        /// A delegate method invokes when the settings values has changed.
        /// </summary>
        internal delegate void SettingsValueChangedDelegate();

        private static bool isInit = false;
        private static int intensity = 0;
        private static bool swapped = false;
        private static bool generate = true;
        private static bool nullify = false;
        private static int r = 200;
        private static int dmg = 65;
        private static bool exclu = false;
        private static bool recursion = false;
        private static int passes = 1;
        private static bool highThreadPriority = false;

#if IsPortable
        private static string AppPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
        private static readonly FileInfo ini = new FileInfo(AppPath + "\\Settings.ini");
#endif
        /// <summary>
        /// Occurs when the settings values has changed.
        /// </summary>
        internal static event SettingsValueChangedDelegate SettingsChanged;

        /// <summary>
        /// Determines if the version is a portable mode.
        /// </summary>
        internal static bool IsPortable {
            get {
#if IsPortable
                return true;
#else
                return false;
#endif
            }
        }

        /// <summary>
        /// Initialize and load the settings.
        /// </summary>
        internal static void Initialize() {
            /*
             * To make FileCrapper a portable version, go to Solution Explorer > FileCrapper > (right-click) Properties > Build
             * 
             * In Conditional Compilation Symbols, add a keyword "IsPortable" (without quotes) to make a portable version.
             * Else, remove the said keyword when you want to put FileCrapper on installer setup.
             */
            if (isInit) return;
#if IsPortable
            ReadFromIniFile();
#else
            ReadFromRegistry();
#endif
            isInit = true;
            DebugProps.Print(DebugProps.PrintType.Debug, "Settings initialized.");
        }

#if IsPortable

        /// <summary>
        /// Reads all settings values from an .ini file.
        /// </summary>
        private static void ReadFromIniFile() {
            DebugProps.Print(DebugProps.PrintType.Debug, "Attempting to read from .ini file...");
            if (!ini.Exists ) {
                DebugProps.Print(DebugProps.PrintType.Warning, ".ini file doesn't exists. Creating a new one.");
                ResetDefaults();
                Save();
                return;
            }


            IniFile iFile = new IniFile(ini.FullName);
            if (!int.TryParse(iFile.Read("Intensity"), out intensity) || intensity < 0 || intensity > 3) {
                DebugProps.Print(DebugProps.PrintType.Warning, "Invalid value detected. Resetting to default...");
                ResetDefaults();
                Save();
                return;
            }

            Intensity = intensity;
            if (Intensity == 0) {
                ByteSwapped = !bool.TryParse(iFile.Read("ByteSwapped"), out swapped) || swapped;
                ByteGenerate = bool.TryParse(iFile.Read("ByteGenerate"), out generate) && generate;
                ByteNullify = bool.TryParse(iFile.Read("ByteNullify"), out nullify) && nullify;
                if (!ByteSwapped && !ByteGenerate && !ByteNullify) generate = true;

                Rounds = int.TryParse(iFile.Read("Rounds"), out r) && r >= 100 && r < 10000 ? r : 200;
                DamageChance = int.TryParse(iFile.Read("DamageChance"), out dmg) && dmg >= 10 && dmg < 101 ? dmg : 65;
                HeaderExclusion = bool.TryParse(iFile.Read("HeaderExclusion"), out exclu) && exclu;
               
                Pass = int.TryParse(iFile.Read("Pass"), out passes) && passes >= 1 && passes < 20 ? passes : 1;
            }
            SubfolderRecursion = !bool.TryParse(iFile.Read("SubfolderRecursion"), out recursion) || recursion;
            ThreadHighPriority = bool.TryParse(iFile.Read("HighPriorityThread"), out highThreadPriority) && highThreadPriority;
        }
#else

        /// <summary>
        ///  Reads all settings values from a registry.
        /// </summary>
        private static void ReadFromRegistry() {
            // Read FileCrapper's settings in registry.
            DebugProps.Print(DebugProps.PrintType.Debug, "Attempting to read from the user's registry...");
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\FileCrapper");
            if (key == null) {
                key?.Close();
                ResetDefaults();
                Save();
                return;
            }
            if (!int.TryParse(key.GetValue("Intensity").ToString(), out intensity) || intensity < 0 || intensity > 3) {
                DebugProps.Print(DebugProps.PrintType.Warning, "Invalid value detected. Resetting to default...");
                ResetDefaults();
                Save();
                return;
            }

            Intensity = intensity;
            if (Intensity == 0) {
                ByteSwapped = !bool.TryParse(key.GetValue("ByteSwapped").ToString(), out swapped) || swapped;
                ByteGenerate = bool.TryParse(key.GetValue("ByteGenerate").ToString(), out generate) && generate;
                ByteNullify = bool.TryParse(key.GetValue("ByteNullify").ToString(), out nullify) && nullify;
                if (!ByteSwapped && !ByteGenerate && !ByteNullify) generate = true;

                Rounds = int.TryParse(key.GetValue("Rounds").ToString(), out r) && r >= 100 && r < 10000 ? r : 200;
                DamageChance = int.TryParse(key.GetValue("DamageChance").ToString(), out dmg) && dmg >= 10 && dmg < 101 ? dmg : 65;
                HeaderExclusion = bool.TryParse(key.GetValue("HeaderExclusion").ToString(), out exclu) && exclu;

                Pass = int.TryParse(key.GetValue("Pass").ToString(), out passes) && passes >= 1 && passes < 20 ? passes : 1;
            }
            SubfolderRecursion = !bool.TryParse(key.GetValue("SubfolderRecursion").ToString(), out recursion) || recursion;
            ThreadHighPriority = bool.TryParse(key.GetValue("HighPriorityThread").ToString(), out highThreadPriority) && highThreadPriority;
        }
#endif

        /// <summary>
        /// Reset all settings values to default.
        /// </summary>
        internal static void ResetDefaults() {
            Intensity = 2;
            SubfolderRecursion = false;
        }

        /// <summary>
        /// Save the current settings values.
        /// </summary>
        internal static void Save() {
            try {
#if IsPortable
            if (ini.Exists) ini.Delete();
            IniFile iFile = new IniFile(ini.FullName);
            iFile.Write("Intensity", Intensity.ToString());
            iFile.Write("ByteSwapped", ByteSwapped.ToString());
            iFile.Write("ByteGenerate", ByteGenerate.ToString());
            iFile.Write("ByteNullify", ByteNullify.ToString());
            iFile.Write("Rounds", Rounds.ToString());
            iFile.Write("DamageChance", DamageChance.ToString());
            iFile.Write("HeaderExclusion", HeaderExclusion.ToString());
            iFile.Write("SubfolderRecursion", SubfolderRecursion.ToString());
            iFile.Write("Pass", Pass.ToString());
            iFile.Write("HighPriorityThread", ThreadHighPriority.ToString());
#else
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\FileCrapper", true);
                if (key == null) key = Registry.CurrentUser.CreateSubKey("Software\\FileCrapper", true);
                key.SetValue("Intensity", Intensity.ToString());
                key.SetValue("ByteSwapped", ByteSwapped.ToString());
                key.SetValue("ByteGenerate", ByteGenerate.ToString());
                key.SetValue("ByteNullify", ByteNullify.ToString());
                key.SetValue("Rounds", Rounds.ToString());
                key.SetValue("DamageChance", DamageChance.ToString());
                key.SetValue("HeaderExclusion", HeaderExclusion.ToString());
                key.SetValue("SubfolderRecursion", SubfolderRecursion.ToString());
                key.SetValue("Pass", Pass.ToString());
                key.SetValue("HighPriorityThread", ThreadHighPriority.ToString());
                key.Close();

#endif
                DebugProps.Print(DebugProps.PrintType.Debug, "Settings values was saved.");

            } catch (Exception ex) {
                MessageBox.Show(null, "Failed to save settings values.\n\nCause: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

#region Registry Additions 

        /// <summary>
        /// Checks if the context menu exists in the current computer.
        /// </summary>
        /// <param name="isContextExists">Use as a negation that the method will return, works in portable version.</param>
        /// <returns></returns>
        internal static bool CheckContextMenuShortcut(bool isContextExists) {
#if IsPortable
            return isContextExists;
#endif
            RegistryKey folderCmx = null;
            RegistryKey fileCmx = null;
            try {
                fileCmx = Registry.ClassesRoot.OpenSubKey("*\\shell\\FileCrapper");
                folderCmx = Registry.ClassesRoot.OpenSubKey("Folder\\shell\\FileCrapper");

                return folderCmx != null && fileCmx != null;
            } catch (Exception ex) {
                Console.WriteLine("[x]: Couldn't read a registry. E: " + ex.Message);
                return false;
            } finally {
                folderCmx?.Close();
                fileCmx?.Close();
            }
        }

        /// <summary>
        /// Inserts the context menu scripts and other artifacts to the registry.
        /// </summary>
        /// <returns>Returns true if it's succeed. Otherwise, false.</returns>
        internal static bool InsertRegistryContextMenu() {
#if IsPortable
            return false;
#endif
            RegistryKey folderCmx = null;
            RegistryKey fileCmx = null;
            string exec = "\"" + Assembly.GetExecutingAssembly().Location + "\"";
            try {
                folderCmx = Registry.ClassesRoot.OpenSubKey("Folder\\shell", true);
                fileCmx = Registry.ClassesRoot.OpenSubKey("*\\shell", true);
                if (folderCmx == null || fileCmx == null) {
                    Console.WriteLine("[x]: Failed to open a registry.");
                    return false;
                }
                folderCmx.CreateSubKey("FileCrapper");
                fileCmx.CreateSubKey("FileCrapper");

                folderCmx = folderCmx.OpenSubKey("FileCrapper", true);
                fileCmx = fileCmx.OpenSubKey("FileCrapper", true);

                if (folderCmx == null || fileCmx == null) {
                    Console.WriteLine("[x]: Failed to open a newly created registry.");
                    return false;
                }

                folderCmx.SetValue("Icon", exec);
                folderCmx.SetValue("", "Corrupt this Folder's contents.");
                folderCmx.SetValue("NoWorkingDirectory", "");
                folderCmx.SetValue("MultiSelectModel", "Folders");

                folderCmx.CreateSubKey("command");
                folderCmx = folderCmx.OpenSubKey("command", true);
                if (folderCmx == null) {
                    Console.WriteLine("[x]: Failed to open a sub registry.");
                    return false;
                }
                folderCmx.SetValue("", exec + "/obj \"%1\"");

                fileCmx.SetValue("Icon", exec);
                fileCmx.SetValue("", "Corrupt this File.");
                fileCmx.SetValue("NoWorkingDirectory", "");
                fileCmx.SetValue("MultiSelectModel", "Files");

                fileCmx.CreateSubKey("command");
                fileCmx = fileCmx.OpenSubKey("command", true);
                if (fileCmx == null) {
                    Console.WriteLine("[x]: Failed to open a sub registry.");
                    return false;
                }
                fileCmx.SetValue("", exec + "/obj \"%1\"");
                folderCmx.Flush();
                fileCmx.Flush();
                return true;
            } catch (Exception ex) {
                Console.WriteLine("[x]: Couldn't read a registry. E: " + ex.Message);
                return false;
            } finally {
                folderCmx?.Close();
                fileCmx?.Close();
            }
        }

        /// <summary>
        /// Removes the context menu related to the program.
        /// </summary>
        /// <returns>Returns true if it's succeed. Otherwise, false.</returns>
        internal static bool RemoveRegistryContextMenu() {
#if IsPortable
            return false;
#endif
            RegistryKey folderCmx = null;
            RegistryKey fileCmx = null;
            try {
                folderCmx = Registry.ClassesRoot.OpenSubKey("Folder\\shell", true);
                fileCmx = Registry.ClassesRoot.OpenSubKey("*\\shell", true);
                if (folderCmx == null || fileCmx == null) {
                    Console.WriteLine("[x]: Failed to open a registry.");
                    return false;
                }
                folderCmx.DeleteSubKeyTree("FileCrapper");
                fileCmx.DeleteSubKeyTree("FileCrapper");
                folderCmx.Flush();
                fileCmx.Flush();
                return true;
            } catch (Exception ex) {
                Console.WriteLine("[x]: Couldn't read a registry. E: " + ex.Message);
                return false;
            } finally {
                folderCmx?.Close();
                fileCmx?.Close();
            }
        }
#endregion

#region Settings

        /// <summary>
        /// Determines if a program is able to swap bytes of a file's content.
        /// </summary>
        internal static bool ByteSwapped {
            get => swapped;
            set {
                if (swapped != value) {
                    swapped = value;
                    if (!ByteSwapped && !ByteGenerate && !ByteNullify) generate = true;
                    if (isInit) SettingsChanged?.Invoke();
                }
            }
        }

        /// <summary>
        /// Determines if a program is able to generate a byte then replace to the file's content.
        /// </summary>
        internal static bool ByteGenerate {
            get => generate;
            set {
                if (generate != value) {
                    generate = value;
                    if (!ByteSwapped && !ByteGenerate && !ByteNullify) generate = true;
                    if (isInit) SettingsChanged?.Invoke();
                }
            }
        }

        /// <summary>
        /// Determines if a program is able to nullify a file's byte.
        /// </summary>
        internal static bool ByteNullify {
            get => nullify;
            set {
                if (nullify != value) {
                    nullify = value;
                    if (!ByteSwapped && !ByteGenerate && !ByteNullify) generate = true;
                    if (isInit) SettingsChanged?.Invoke();
                }
            }
        }

        /// <summary>
        /// Gets or sets a number of rounds per <see cref="Pass"/>.
        /// </summary>
        internal static int Rounds {
            get => r;
            set {
                if (value < 100 || value > 10000 || r == value) return;
                r = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        /// <summary>
        /// Gets or sets a percentage of chance of a file's byte to be corrupted per round.
        /// </summary>
        internal static int DamageChance {
            get => dmg;
            set {
                if (value < 10 || value > 100 || dmg == value) return;
                dmg = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        /// <summary>
        /// Gets or sets the exclusion of a header.
        /// </summary>
        internal static bool HeaderExclusion {
            get => exclu;
            set {
                if (value == exclu) return;
                exclu = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        /// <summary>
        /// Gets or sets the program to be able to search files in subfolders.
        /// </summary>
        internal static bool SubfolderRecursion {
            get => recursion;
            set {
                if (value == recursion) return;
                recursion = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        /// <summary>
        /// Gets or sets a number of passes per file.
        /// </summary>
        internal static int Pass {
            get => passes;
            set {
                if (value < 1 || value > 20 || passes == value) return;
                passes = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        /// <summary>
        /// Enables/Disables a program to run its threads as high priority.
        /// </summary>
        internal static bool ThreadHighPriority {
            get => highThreadPriority;
            set {
                if (highThreadPriority == value) return;
                highThreadPriority = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        /// <summary>
        /// Gets or sets an intensity. If the value is nonzero, it will set the values based on specified number.
        /// </summary>
        internal static int Intensity {
            get => intensity;
            set {
                if (value < 0 || value > 3) return;
                intensity = value;
                if (intensity == 0) return;
                switch (intensity) {
                    case 1:
                        swapped = false;
                        generate = true;
                        nullify = false;
                        r = 1000;
                        dmg = 50;
                        exclu = true;
                        passes = 1;
                        break;
                    case 2:
                        swapped = true;
                        generate = true;
                        nullify = true;
                        r = 2500;
                        dmg = 65;
                        exclu = true;
                        passes = 1;
                        break;
                    case 3:
                        swapped = true;
                        generate = true;
                        nullify = true;
                        r = 6500;
                        dmg = 80;
                        exclu = false;
                        passes = 10;
                        break;
                }
                if (isInit) SettingsChanged?.Invoke();
            }
        }
#endregion
    }
}
