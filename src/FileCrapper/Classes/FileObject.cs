using System;
using System.IO;

namespace FileCrapper.Classes {
    internal class FileObject {

        // Assume this was a Windows directory.
        private static readonly string winDirString = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.System)).Parent.FullName.ToLower();

        internal FileObject(Guid id, FileInfo info) {
            Guid = id;
            FileInfo = info;
            IsASystem = FileInfo.Directory.FullName.ToLower().StartsWith(winDirString);
        }

        internal Guid Guid { get; private set; }
        internal FileInfo FileInfo { get; private set; }
        internal double Percentage { get; private set; }
        internal bool IsASystem { get; private set; }
        internal long BytesAffected { get; set; }

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
