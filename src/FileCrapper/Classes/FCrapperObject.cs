using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using static FileCrapper.Classes.CrapMethods;
using static FileCrapper.Classes.Delegates;

namespace FileCrapper.Classes {

    /// <summary>
    /// A class that holds file or directory, responsible for file crapping.
    /// </summary>
    internal class FCrapperObject : IDisposable {

        #region Private 

        private FileSystemInfo _fileInfo;
        private bool disposedValue;
        private List<FileInfo> files;
        private CancellationToken _token;
        private bool _onCorrupted;
        #endregion

        #region Settings Values

        private bool byteSwapped;
        private bool byteGenerate;
        private bool byteNullify;
        private int rounds;
        private int chance;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the object.
        /// </summary>
        public string Name {
            get => !disposedValue ? _fileInfo.Name : throw new ObjectDisposedException(GetType().Name);
        }

        /// <summary>
        /// Gets the full path of the object.
        /// </summary>
        public string Path {
            get => !disposedValue ? _fileInfo.FullName : throw new ObjectDisposedException(GetType().Name);
        }

        /// <summary>
        /// Gets if the object exists.
        /// </summary>
        public bool Exists {
            get => !disposedValue ? (File.Exists(_fileInfo.FullName) || Directory.Exists(_fileInfo.FullName)) : throw new ObjectDisposedException(GetType().Name);
        }

        /// <summary>
        /// Gets if the object is a directory.
        /// </summary>
        public bool IsDirectory {
            get => !disposedValue ? Directory.Exists(_fileInfo.FullName) : throw new ObjectDisposedException(GetType().Name);
        }

        #endregion

        #region Events
        /// <summary>
        /// Fires an event during the file crapping progress.
        /// </summary>
        internal event OnFileCrappingDelegate OnFileCrapping;

        /// <summary>
        /// Fires an event once the file crapping progress is completed.
        /// </summary>
        internal event OnFileCrappedDelegate OnFileCrapped;

        /// <summary>
        /// Fires an event when changing the current file index.
        /// </summary>
        internal event CurrentDirectoryFileIndexDelegate CurrentFileIndexChanged;

        /// <summary>
        /// Fires an event during firing a current status text.
        /// </summary>
        internal event CurrentStatusTextDelegate CurrentStatusText;
        #endregion

        /// <summary>
        /// Initializes a new instance of <see cref="FCrapperObject"/>
        /// </summary>
        /// <param name="filePath">A string of a file path.</param>
        /// <param name="token">A current <see cref="CancellationToken"/> object.</param>
        /// <exception cref="FileNotFoundException"></exception>
        public FCrapperObject(string filePath, CancellationToken token) {
            _token = token;

            if (File.Exists(filePath)) {
                _fileInfo = new FileInfo(filePath);
            } else if (Directory.Exists(filePath)) {
                _fileInfo = new DirectoryInfo(filePath);
            } else {
                throw new FileNotFoundException(filePath);
            }

            files = new List<FileInfo>();
            _onCorrupted = false;
        }

        /// <summary>
        /// Initiates to start crapping an object.
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void StartCrap() {
            if (disposedValue) throw new ObjectDisposedException(GetType().Name);
            if (_onCorrupted)
                throw new ArgumentException("This object is already corrupted! Please dispose it.");

            // Get the current settings values.
            byteSwapped = Properties.Settings.Default.ByteSwapped;
            byteGenerate = Properties.Settings.Default.ByteGenerate;
            byteNullify = Properties.Settings.Default.ByteNullify;
            rounds = Properties.Settings.Default.Rounds;
            chance = 100 - Properties.Settings.Default.DamageChance;

            try {
                CurrentStatusText?.Invoke("Enumerating objects...");

                if (IsDirectory) {
                    // Add range on getting files from the directory.
                    files.AddRange(Miscellaneous.GetFilesFromDirectories(_fileInfo.FullName,
                                    Properties.Settings.Default.FileInSubfolderIncluded, _token));
                } else {
                    files.Add((FileInfo)_fileInfo);
                }

                CurrentFileIndexChanged?.Invoke(0, files.Count, _fileInfo.Name, 0);
                for (int i = 0; i < files.Count; i++) {
                    if (_token.IsCancellationRequested) {
                        CurrentStatusText?.Invoke("Task was cancelled!");
                        OnFileCrapped?.Invoke(true, null);
                        return;
                    }
                    CrapFileMethod(files[i].FullName);
                    CurrentFileIndexChanged?.Invoke(i + 1, files.Count, files[i].Name, (i + 1) * 100 / files.Count);
                }

            } catch (Exception ex) {
                CurrentStatusText?.Invoke("Task was cancelled due to an error!");
                OnFileCrapped?.Invoke(true, ex);
                Console.WriteLine(ex.Message);
                return;
            }
            CurrentStatusText?.Invoke(_fileInfo.Name + " has been crapped!");
            OnFileCrapped?.Invoke(false, null);
        }

        /// <summary>
        /// Initiates to crap
        /// </summary>
        /// <param name="filepath">A string path of the targeted file.</param>
        private void CrapFileMethod(string filepath) {
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None)) {
                byte[] firstBytes = new byte[fs.Length > 4096 ? 4096 : fs.Length];
                fs.Read(firstBytes, 0, firstBytes.Length);
                fs.Position = 0;
                long startingPoint = FileSystemExtrasClass.IsBinary(firstBytes) ? 128 : 0;
                for (int i = 0; i < rounds; i++) {
                    OnFileCrapping?.Invoke(i, rounds);
                    if (_token.IsCancellationRequested)
                        return;

                    if (Program.Random.Next(1, 100) >= chance) {
                        _onCorrupted = true;
                        ChangeStreamPosition(fs, startingPoint);
                        switch (Program.Random.Next(0, 3)) {
                            case 0:
                                if (!byteGenerate) continue;
                                OverwriteNewByte(fs);
                                break;
                            case 1:
                                if (!byteSwapped) continue;
                                SwapBytes(fs, startingPoint);
                                break;
                            case 2:
                                if (!byteNullify) continue;
                                NullifyByte(fs);
                                break;
                        }
                    }
                    OnFileCrapping?.Invoke(i + 1, rounds);
                }
            }
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    _fileInfo = null;
                    files = null;
                }
                disposedValue = true;
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
