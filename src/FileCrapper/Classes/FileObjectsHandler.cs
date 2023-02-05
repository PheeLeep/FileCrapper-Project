using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class that is a core operation of listing and file corruption methods.
    /// </summary>
    internal static class FileObjectsHandler {

        /// <summary>
        /// A delegate method that invokes when changing status occurs.
        /// </summary>
        internal delegate void StatusChangedDelegate();

        /// <summary>
        /// A delegate method invokes when the items was changed.
        /// </summary>
        internal delegate void ItemsChangedDelegate();

        /// <summary>
        /// A delegate method passes a status info about the current occurrence of <see cref="FileObjectsHandler"/>.
        /// </summary>
        /// <param name="statusInfo">A string of message.</param>
        internal delegate void StatusInfoOccurredDelegate(string statusInfo);

        /// <summary>
        /// A delegate method passes a current and total number of files.
        /// </summary>
        /// <param name="current">A current number of files that was damaged or skipped.</param>
        /// <param name="total">A total number of files.</param>
        internal delegate void FileCrappingProgressDelegate(int current, int total);

        /// <summary>
        /// A delegate method invokes when the file corruption succeed.
        /// </summary>
        /// <param name="percentage">A total average percentage of files that was damaged.</param>
        /// <param name="bytDamage">A total average of files' bytes that was damaged.</param>
        internal delegate void FileCrappingSucceedDelegate(double percentage, long bytDamage);

        /// <summary>
        /// An enumeration of status.
        /// </summary>
        internal enum StatusE {
            /// <summary>
            /// A ready status.
            /// </summary>
            Ready,

            /// <summary>
            /// An adding status, used when the objects are adding.
            /// </summary>
            Adding,

            /// <summary>
            /// A removing status, used when the objects are removing.
            /// </summary>
            Removing,

            /// <summary>
            /// A file crapping status, used when the objects are corrupting (or crapping) in the process.
            /// </summary>
            Crapping,
        }

        /// <summary>
        /// A private variable for <see cref="Status"/>.
        /// </summary>
        private static StatusE _status = StatusE.Ready;

        /// <summary>
        /// A readonly <see cref="List{T}"/> objects that stores <see cref="FileObject"/>.
        /// </summary>
        private static readonly List<FileObject> objects = new List<FileObject>();

        #region Properties

        /// <summary>
        /// Gets the number of <see cref="FileObject"/> contained in this class.
        /// </summary>
        internal static int Count { get => objects.Count; }

        /// <summary>
        /// Gets the current status of the class.
        /// </summary>
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

        /// <summary>
        /// Occurs when a <see cref="Status"/> value changed.
        /// </summary>
        internal static event StatusChangedDelegate StatusChanged;

        /// <summary>
        /// Occurs when the number of items changed.
        /// </summary>
        internal static event ItemsChangedDelegate ItemsChanged;

        /// <summary>
        /// Occurs when the status message of the class was passed.
        /// </summary>
        internal static event StatusInfoOccurredDelegate StatusInfoOccurred;

        /// <summary>
        /// Occurs when the current file crapping process is ongoing.
        /// </summary>
        internal static event FileCrappingProgressDelegate FileCrappingProgress;

        /// <summary>
        /// Occurs when the current file crapping process succeed.
        /// </summary>
        internal static event FileCrappingSucceedDelegate FileCrappingSucceed;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the number of <see cref="FileObject"/> items.
        /// </summary>
        /// <param name="min">A starting point of a list.</param>
        /// <param name="max">
        /// A point where <see cref="FileObject"/> item enumeration should end. If this value is equal or greater, automatically a value of <see cref="Count"/> will be passed.
        /// </param>
        /// <returns>Returns the number of <see cref="FileObject"/> items.</returns>
        internal static FileObject[] GetItems(int min, int max) {
            List<FileObject> items = new List<FileObject>();
            if (min < 0 || min >= objects.Count || min >= max) return items.ToArray();
            if (max >= objects.Count) max = objects.Count - 1;
            for (int i = min; i < max + 1; i++)
                items.Add(objects[i]);
            return items.ToArray();
        }

        /// <summary>
        /// Adds the file names to the list.
        /// </summary>
        /// <param name="items">An array of string containing file paths.</param>
        internal static void AddItems(string[] items) {
            if (_status != StatusE.Ready) return;
            Status = StatusE.Adding;
            Thread t = new Thread(() => ThreadAddItems(items)) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        /// <summary>
        /// Adds the file names to the list in thread mode.
        /// </summary>
        /// <param name="items">An array of string containing file paths.</param>
        private static void ThreadAddItems(string[] items) {
            if (InternalAddItems(items) > 0) ItemsChanged.Invoke();
            Status = StatusE.Ready;
        }

        /// <summary>
        /// Adds the file objects to the list.
        /// </summary>
        /// <param name="items">An array of string containing file paths.</param>
        /// <returns></returns>
        private static int InternalAddItems(string[] items) {
            int counts = 0;
            foreach (string item in items) {
                if (string.IsNullOrEmpty(item)) continue;
                if (objects.Any(obj => obj.FileInfo.FullName.Equals(item))) {
                    StatusInfoOccurred?.Invoke("File '" + item + "' skipped.");
                    continue;
                }
                FileInfo fInfo = new FileInfo(item);
                if (!fInfo.Exists) continue;
                FileObject t = new FileObject(GenerateGuid(), fInfo);
                objects.Add(t);
                counts++;
                StatusInfoOccurred?.Invoke("File '" + fInfo.Name + "' was added.");
            }
            DebugProps.Print(DebugProps.PrintType.Info, counts.ToString() + " object/s were added.");
            return counts;
        }

        /// <summary>
        /// Enumerates all files from the directory.
        /// </summary>
        /// <param name="path">A directory path.</param>
        internal static void AddItemsFromDirectory(string path) {
            if (_status != StatusE.Ready) return;
            Status = StatusE.Adding;
            Thread t = new Thread(() => ThreadAddItemsFromDirectory(path, SettingsClass.SubfolderRecursion)) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        /// <summary>
        /// Enumerates all files from the directory in thread mode.
        /// </summary>
        /// <param name="path">A directory path.</param>
        /// <param name="recursive">Determines if the subdirectory recursion is allowed.</param>
        private static void ThreadAddItemsFromDirectory(string path, bool recursive) {
            DebugProps.StartStopwatch();
            FindFiles(path, recursive);
            DebugProps.StopStopwatch();
            ItemsChanged.Invoke();
            Status = StatusE.Ready;
        }

        /// <summary>
        /// Finds the file inside the specified directory.
        /// </summary>
        /// <param name="path">A directory path.</param>
        /// <param name="recursive">Determines if the subdirectory recursion is allowed.</param>
        private static void FindFiles(string path, bool recursive) {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists) return; // Premature.
            StatusInfoOccurred?.Invoke("Searching files on: " + path);
            int filesFound = 0;
            try {
                foreach (FileInfo fInfos in dir.EnumerateFiles()) {
                    if (!fInfos.Exists || objects.Any(obj => obj.FileInfo.FullName.Equals(fInfos.FullName))) {
                        StatusInfoOccurred?.Invoke("File '" + fInfos.FullName + "' skipped.");
                        continue;
                    }
                    FileObject t = new FileObject(GenerateGuid(), fInfos);
                    objects.Add(t);
                    StatusInfoOccurred?.Invoke("File '" + fInfos.Name + "' was added.");
                    filesFound++;
                }
            } catch (Exception ex) {
                DebugProps.Print(DebugProps.PrintType.Warning, "Couldn't retrieve files. (E: " + ex.Message + ")");
                StatusInfoOccurred?.Invoke("Couldn't retrieve files. (E: " + ex.Message + ")");
            }
            if (recursive) {
                try {
                    foreach (DirectoryInfo subdirs in dir.EnumerateDirectories())
                        FindFiles(subdirs.FullName, recursive);
                } catch (Exception ex) {
                    DebugProps.Print(DebugProps.PrintType.Warning, "Couldn't recursive search a directory. (E: " + ex.Message + ")");
                    StatusInfoOccurred?.Invoke("Couldn't recursive search a directory. (E: " + ex.Message + ")");
                }
            }
            DebugProps.Print(DebugProps.PrintType.Info, filesFound.ToString() + " object/s were added from directory '" + path + "'.");
        }

        /// <summary>
        /// Removes a specified files.
        /// </summary>
        /// <param name="items">An array of <see cref="Guid"/> specifying the files.</param>
        internal static void RemoveItems(Guid[] items) {
            if (_status != StatusE.Ready) return;
            Status = StatusE.Removing;
            Thread t = new Thread(() => ThreadRemoveItems(items)) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        /// <summary>
        /// Removes a specified files in thread mode.
        /// </summary>
        /// <param name="items">An array of <see cref="Guid"/> specifying the files.</param>
        private static void ThreadRemoveItems(Guid[] items) {
            foreach (Guid item in items) {
                FileObject t = objects.Find(obj => obj.Guid.Equals(item));
                if (t != null) objects.Remove(t);
            }
            DebugProps.Print(DebugProps.PrintType.Info, items.Length.ToString() + " object/s were removed.");
            ItemsChanged.Invoke();
            Status = StatusE.Ready;
        }

        /// <summary>
        /// Removes all items.
        /// </summary>
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

        /// <summary>
        /// Checks if the <see cref="FileObject"/> items are part of the system.
        /// </summary>
        /// <returns>Returns true if the files are part of the system. Otherwise, false.</returns>
        internal static bool SystemFilesObjectsExists() {
            if (objects.Count == 0) return false;
            return objects.Any(o => o.IsASystem);
        }

        /// <summary>
        /// Starts the file crapping procedure.
        /// </summary>
        internal static void StartFileCrapping() {
            if (_status != StatusE.Ready || objects.Count == 0) return;
            Status = StatusE.Crapping;
            Thread t = new Thread(() => ThreadStartFileCrapping()) {
                Priority = SettingsClass.ThreadHighPriority ? ThreadPriority.Highest : ThreadPriority.Normal
            };
            t.Start();
        }

        /// <summary>
        /// Starts the file crapping procedure in thread mode.
        /// </summary>
        private static void ThreadStartFileCrapping() {
            Thread.Sleep(500); // This gives a time for CorruptProgressDialog to complete on initialization.

            DebugProps.Print(DebugProps.PrintType.Debug, "Start file crapping.(" + objects.Count.ToString() + " objects found. | Started at " + DateTime.Now.ToString("dd/MM/yy hh:mm:ss") + ")");
            DebugProps.StartStopwatch();
            StatusInfoOccurred?.Invoke("[i]: Start file crapping (" + objects.Count.ToString() + " objects found.)");
            double avg = 0;
            long damageBytes = 0;
            List<Guid> guids = new List<Guid>();

            for (int i = 0; i < objects.Count; i++) {
                FileCrappingProgress?.Invoke(i, objects.Count);
                FileObject t = objects[i];
                guids.Add(t.Guid);

                if (!t.FileInfo.Exists) {
                    DebugProps.Print(DebugProps.PrintType.Warning, "File '" + t.FileInfo.FullName + "' not found. Skipping...");
                    StatusInfoOccurred?.Invoke("[!]: File '" + t.FileInfo.Name + "' skipped. File not found.");
                    FileCrappingProgress?.Invoke(i + 1, objects.Count);
                    continue;
                }

                t.CalculatePercentage(CrapFileMethod(t.FileInfo, out long byt));
                DebugProps.Print(DebugProps.PrintType.Warning, "File '" + t.FileInfo.FullName + "' was destroyed. Damage: " + t.Percentage.ToString() +
                                           "% (" + Miscellaneous.CalculateBytes(byt) + " obliterated.)");
                avg += t.Percentage;
                damageBytes += byt;
                StatusInfoOccurred?.Invoke("[i]: File '" + t.FileInfo.Name + "' destruction completed. Damage: " + t.Percentage.ToString() +
                                           "% (" + Miscellaneous.CalculateBytes(byt) + " were affected)");
                FileCrappingProgress?.Invoke(i + 1, objects.Count);
            }

            DebugProps.Print(DebugProps.PrintType.Debug, "Cleaning up...");
            ThreadRemoveItems(guids.ToArray());

            avg /= objects.Count;
            FileCrappingSucceed?.Invoke(Math.Round(avg, 2), damageBytes);
            DebugProps.Print(DebugProps.PrintType.Info, "File crapping was finished. Ended at " + DateTime.Now.ToString("dd/MM/yy hh:mm:ss")
                             + " (Avg Damage Rate: " + Math.Round(avg, 2).ToString() + "% | Avg Bytes Damage: " + Miscellaneous.CalculateBytes(damageBytes) + ")");

            DebugProps.StopStopwatch();
        }

        /// <summary>
        /// Initialize the file crapping procedure.
        /// </summary>
        /// <param name="f">A <see cref="FileInfo"/> referencing a file to destroy.</param>
        /// <param name="bytesAffected">Returns a length of bytes that was damaged.</param>
        /// <returns>Returns a number of rounds that file corruption occurs.</returns>
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
                DebugProps.Print(DebugProps.PrintType.Error, "Failed to corrupt a file '" + f.FullName + "'! E: " + ex.Message);
                StatusInfoOccurred?.Invoke("[!]: Failed to corrupt a file! E: " + ex.Message);
                bytesAffected = 0;
                return 0;
            }
        }

        /// <summary>
        /// Generates a new <see cref="Guid"/> value.
        /// </summary>
        /// <returns>Returns a new <see cref="Guid"/> value.</returns>
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
