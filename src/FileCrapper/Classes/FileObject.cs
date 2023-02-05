using System;
using System.IO;

namespace FileCrapper.Classes {

    /// <summary>
    /// A class that holds the information of a file and the statistics of damage.
    /// </summary>
    internal class FileObject {

        // Assume this was a Windows directory. C:\Windows
        private static readonly string winDirString = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.System)).Parent.FullName.ToLower();

        /// <summary>
        /// Initializes a new object of <see cref="FileObject"/>.
        /// </summary>
        /// <param name="id">The <see cref="System.Guid"/> for a new class.</param>
        /// <param name="info">The current <see cref="System.IO.FileInfo"/> object.</param>
        internal FileObject(Guid id, FileInfo info) {
            Guid = id;
            FileInfo = info;
            IsASystem = FileInfo.Directory.FullName.ToLower().StartsWith(winDirString);
        }

        /// <summary>
        /// A current <see cref="System.Guid"/> ID value.
        /// </summary>
        internal Guid Guid { get; private set; }

        /// <summary>
        /// A current <see cref="System.IO.FileInfo"/> object.
        /// </summary>
        internal FileInfo FileInfo { get; private set; }

        /// <summary>
        /// A percentage of damage of a file after it was corrupted.
        /// </summary>
        internal double Percentage { get; private set; }

        /// <summary>
        /// Determines if the current file belongs to the Windows' system files.
        /// </summary>
        internal bool IsASystem { get; private set; }

        /// <summary>
        /// Gets the length of bytes that was damaged.
        /// </summary>
        internal long BytesAffected { get; set; }

        /// <summary>
        /// Performs a damage calculation.
        /// </summary>
        /// <param name="roundsHit">A number of rounds that file corruption occurs.</param>
        internal void CalculatePercentage(double roundsHit) {
            double totalRounds = SettingsClass.Rounds * SettingsClass.Pass;
            if (roundsHit > totalRounds) {
                Percentage = 100;
                return;
            }
            double perceRaw = ((roundsHit / totalRounds) * 100d);
            Percentage = Math.Round(100d - perceRaw, 2);
        }
    }
}
