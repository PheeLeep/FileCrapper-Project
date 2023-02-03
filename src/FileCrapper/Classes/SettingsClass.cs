using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileCrapper.Classes {
    internal static class SettingsClass {
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
        private static FileInfo ini = new FileInfo(AppPath + "\\Settings.ini");
#else

#endif
        internal static event SettingsValueChangedDelegate SettingsChanged;

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
        }

        private static void ReadFromIniFile() {
            if (!ini.Exists ) {
                ResetDefaults();
                Save();
                return;
            }
            IniFile iFile = new IniFile(ini.FullName);
            if (!int.TryParse(iFile.Read("Intensity"), out intensity) || intensity < 0 || intensity > 3) {
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

        private static void ReadFromRegistry() {
            // Read FileCrapper's settings in registry.
        }

        internal static void ResetDefaults() {
            Intensity = 2;
            SubfolderRecursion = false;
        }

        internal static void Save() {
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
            // Registry
#endif
        }
        #region Settings
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

        internal static int Rounds {
            get => r;
            set {
                if (value < 100 || value > 10000 || r == value) return;
                r = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }
        internal static int DamageChance {
            get => dmg;
            set {
                if (value < 10 || value > 100 || dmg == value) return;
                dmg = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        internal static bool HeaderExclusion {
            get => exclu;
            set {
                if (value == exclu) return;
                exclu = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        internal static bool SubfolderRecursion {
            get => recursion;
            set {
                if (value == recursion) return;
                recursion = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

        internal static int Pass {
            get => passes;
            set {
                if (value < 1 || value > 20 || passes == value) return;
                passes = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }
        internal static bool ThreadHighPriority {
            get => highThreadPriority;
            set {
                if (highThreadPriority == value) return;
                highThreadPriority = value;
                if (isInit) SettingsChanged?.Invoke();
            }
        }

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
