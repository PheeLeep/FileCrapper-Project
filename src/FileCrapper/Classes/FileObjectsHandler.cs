using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileCrapper.Classes {
    internal static class FileObjectsHandler {
        internal delegate void StatusChangedDelegate();
        internal delegate void ItemsChangedDelegate();
        internal delegate void StatusInfoOccurredDelegate(string statusInfo);
        internal delegate void FileCrappingProgressDelegate(int current, int total);
        internal delegate void FileCrappingSucceedDelegate(double percentage, long bytDamage);

        internal enum StatusE {
            Ready,
            Adding,
            Removing,
            Crapping,
        }

        private static StatusE _status = StatusE.Ready;
        private static List<FileObject> objects = new List<FileObject>();

        #region Properties

        /// <summary>
        /// Gets the number of objects inside the class.
        /// </summary>
        internal static int Count { get => objects.Count; }
        internal static StatusE Status {
            get => _status;
            set {
                if (_status == value) return;
                _status = value;
                StatusChanged?.Invoke();
            }
        }
        #endregion

        #region Events
        internal static event StatusChangedDelegate StatusChanged;
        internal static event ItemsChangedDelegate ItemsChanged;
        internal static event StatusInfoOccurredDelegate StatusInfoOccurred;
        internal static event FileCrappingProgressDelegate FileCrappingProgress;
        internal static event FileCrappingSucceedDelegate FileCrappingSucceed;
        #endregion

        #region Methods

        internal static FileObject[] GetItems(int min, int max) {
            List<FileObject> items = new List<FileObject>();
            if (min < 0 || min >= objects.Count || min >= max) return items.ToArray();
            if (max >= objects.Count) max = objects.Count - 1;
            for (int i = min; i < max + 1; i++)
                items.Add(objects[i]);
            return items.ToArray();
        }

        internal static void AddItems(string[] items) {
            if (_status != StatusE.Ready) return;
            Status = StatusE.Adding;
            Thread t = new Thread(() => ThreadAddItems(items)) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        private static void ThreadAddItems(string[] items) {
            List<FileObject> addedItems = InternalAddItems(items);
            if (addedItems.Count > 0) ItemsChanged.Invoke();
            Status = StatusE.Ready;
        }

        private static List<FileObject> InternalAddItems(string[] items) {
            List<FileObject> fInfos = new List<FileObject>();
            foreach (string item in items) {
                if (string.IsNullOrEmpty(item)) continue;
                if (objects.Any(obj => obj.FileInfo.FullName.Equals(item))) continue;
                FileInfo fInfo = new FileInfo(item);
                if (!fInfo.Exists) continue;
                FileObject t = new FileObject(GenerateGuid(), fInfo);
                objects.Add(t);
                fInfos.Add(t);
                StatusInfoOccurred?.Invoke("File '" + fInfo.Name + "' was added.");
            }
            return fInfos;
        }

        internal static void AddItemsFromDirectory(string path, bool recursive) {
            if (_status != StatusE.Ready) return;
            Status = StatusE.Adding;
            Thread t = new Thread(() => ThreadAddItemsFromDirectory(path, recursive)) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        private static void ThreadAddItemsFromDirectory(string path, bool recursive) {
            FindFiles(path, recursive);
            ItemsChanged.Invoke();
            Status = StatusE.Ready;
        }

        private static void FindFiles(string path, bool recursive) {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists) return; // Premature.
            StatusInfoOccurred?.Invoke("Searching files on: " + path);
            try {
                foreach (FileInfo fInfos in dir.EnumerateFiles()) {
                    if (!fInfos.Exists || objects.Any(obj => obj.FileInfo.FullName.Equals(fInfos.FullName))) continue;
                    FileObject t = new FileObject(GenerateGuid(), fInfos);
                    objects.Add(t);
                    StatusInfoOccurred?.Invoke("File '" + fInfos.Name + "' was added.");
                }
            } catch (Exception ex) {
                StatusInfoOccurred?.Invoke("Couldn't retrieve files. (E: " + ex.Message + ")");
            }
            if (recursive) {
                try {
                    foreach (DirectoryInfo subdirs in dir.EnumerateDirectories())
                        FindFiles(subdirs.FullName, recursive);
                } catch (Exception ex) {
                    StatusInfoOccurred?.Invoke("Couldn't recursive search a directory. (E: " + ex.Message + ")");
                }
            }
        }

        internal static void RemoveItems(Guid[] items) {
            if (_status != StatusE.Ready) return;
            Status = StatusE.Removing;
            Thread t = new Thread(() => ThreadRemoveItems(items)) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        private static void ThreadRemoveItems(Guid[] items) {
            foreach (Guid item in items) {
                FileObject t = objects.Find(obj => obj.Guid.Equals(item));
                if (t != null) objects.Remove(t);
            }
            ItemsChanged.Invoke();
            Status = StatusE.Ready;
        }

        internal static void RemoveAllItems() {
            if (_status != StatusE.Ready) return;
            Status = StatusE.Removing;
            Thread tx = new Thread(() => {
                List<Guid> guids = new List<Guid>();
                foreach (FileObject t in objects)
                    guids.Add(t.Guid);
                ThreadRemoveItems(guids.ToArray());
            }) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            tx.Start();
        }

        internal static bool SystemFilesObjectsExists() {
            if (objects.Count == 0) return false;
            return objects.Any(o => o.IsASystem);
        }

        internal static void StartFileCrapping() {
            if (_status != StatusE.Ready || objects.Count == 0) return;
            Status = StatusE.Crapping;
            Thread t = new Thread(() => ThreadStartFileCrapping()) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        private static void ThreadStartFileCrapping() {
            Thread.Sleep(500);
            StatusInfoOccurred?.Invoke("[i]: Start file crapping (" + objects.Count.ToString() + " objects found.)");
            double avg = 0;
            long damageBytes = 0;
            List<Guid> guids = new List<Guid>();
            for (int i = 0; i < objects.Count; i++) {
                FileCrappingProgress?.Invoke(i, objects.Count);
                FileObject t = objects[i];
                guids.Add(t.Guid);

                if (!t.FileInfo.Exists) {
                    StatusInfoOccurred?.Invoke("[!]: File '" + t.FileInfo.Name + "' skipped. File not found.");
                    FileCrappingProgress?.Invoke(i + 1, objects.Count);
                    continue;
                }
                t.CalculatePercentage(CrapFileMethod(t.FileInfo, out long byt));
                avg += t.Percentage;
                damageBytes += byt;
                StatusInfoOccurred?.Invoke("[i]: File '" + t.FileInfo.Name + "' destruction completed. Damage: " + t.Percentage.ToString() + 
                                           "% (" + Miscellaneous.CalculateBytes(byt) + " were affected)");
                FileCrappingProgress?.Invoke(i + 1, objects.Count);
            }
            avg /= objects.Count;
            FileCrappingSucceed?.Invoke(Math.Round(avg, 2), damageBytes);
            ThreadRemoveItems(guids.ToArray());
        }

        private static long CrapFileMethod(FileInfo f, out long bytesAffected) {
            try {
                long roundHits = 0;
                using (FileStream fs = f.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
                    byte[] firstBytes = new byte[fs.Length > 4096 ? 4096 : fs.Length];
                    fs.Read(firstBytes, 0, firstBytes.Length);
                    fs.Position = 0;
                    long startingPoint = FileSystemExtrasClass.IsBinary(firstBytes) ? 128 : 0;
                    long destroyedBytes = 0;
                    for (int j = 0; j < SettingsClass.Pass; j++) {
                        for (int i = 0; i < SettingsClass.Rounds; i++) {
                            if (Program.Random.Next(1, 100) >= SettingsClass.DamageChance) {
                                CrapMethods.ChangeStreamPosition(fs, startingPoint);
                                switch (Program.Random.Next(0, 3)) {
                                    case 0:
                                        if (!SettingsClass.ByteGenerate) continue;
                                        destroyedBytes += CrapMethods.OverwriteNewByte(fs);
                                        break;
                                    case 1:
                                        if (!SettingsClass.ByteSwapped) continue;
                                        destroyedBytes += CrapMethods.SwapBytes(fs, startingPoint);
                                        break;
                                    case 2:
                                        if (!SettingsClass.ByteNullify) continue;
                                        destroyedBytes += CrapMethods.NullifyByte(fs);
                                        break;
                                }
                                roundHits++;
                            }
                        }
                    }
                    bytesAffected = destroyedBytes;
                    return roundHits;
                }
            } catch (Exception ex) {
                StatusInfoOccurred?.Invoke("[!]: Failed to corrupt a file! E: " + ex.Message);
                bytesAffected = 0;
                return 0;
            }
        }
        private static Guid GenerateGuid() {
            Guid newId = Guid.NewGuid();
            while (true) {
                if (!objects.Any(obj => obj.Guid.Equals(newId))) return newId;
                newId = Guid.NewGuid();
            }
        }
        #endregion
    }
}
