using System;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class contains extra functions on file system (like binary-like file check).
    /// </summary>
    internal static class FileSystemExtrasClass {

        /// <summary>
        /// Checks if the file is binary or text-based.
        /// </summary>
        /// <param name="bytes">An array of bytes snipped from the file. Parameter value's length must have at least 4096 bytes.</param>
        /// <returns>Returns true if the byte array is a binary; false if isn't or <see cref="Properties.Settings.Default.ExcludeHeaderBytes"/> value is set as false.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsBinary(byte[] bytes) {
            if (!SettingsClass.HeaderExclusion) return false;
            if (bytes == null) throw new ArgumentNullException("bytes");
            if (bytes.Length > 4096) throw new ArgumentException("Byte length must be at least 4096 bytes (4 KB).");

            if (bytes.Length == 0) return false;
            int ctrlCharCounts = 0;
            for (int i = 0; i < bytes.Length; i++) {
                if (IsCtrlChar(bytes[i]))
                    ctrlCharCounts++;
            }
            int perce = ctrlCharCounts * 100 / bytes.Length;
            return perce > 10;
        }

        /// <summary>
        /// Checks if the given parameter from the byte array is a control character.
        /// </summary>
        /// <param name="chr">A value from the byte.</param>
        /// <returns>Returns true if it's a control character; false if not.</returns>
        private static bool IsCtrlChar(int chr) {
            return (chr > 0 && chr < 8) || (chr > 13 && chr < 26);
        }
    }
}
