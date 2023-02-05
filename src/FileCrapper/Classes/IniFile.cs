using System.IO;
using System.Reflection;
using System.Text;
using static FileCrapper.Classes.NativeMethods;

namespace FileCrapper.Classes {

    /// <summary>
    /// A class that manipulates the INI file's content.
    /// </summary>
    /// <remarks>
    /// Code taken from https://stackoverflow.com/a/14906422 | Author: Danny Beckett | Date Published: 16/2/2013 | Latest Date Edited: 20/8/2022
    /// </remarks>
    internal class IniFile {

        private string Path;
        private static readonly string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Initializes a new <see cref="IniFile"/> object.
        /// </summary>
        /// <param name="IniPath">A file path of the .ini file.</param>
        public IniFile(string IniPath = null) {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        /// <summary>
        /// Reads the value from the .ini file.
        /// </summary>
        /// <param name="Key">A key to read a value.</param>
        /// <param name="Section">A section that contains the key.</param>
        /// <returns>Returns a value of associates key.</returns>
        public string Read(string Key, string Section = null) {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        /// <summary>
        /// Writes a value to the .ini file.
        /// </summary>
        /// <param name="Key">A key where to store a value.</param>
        /// <param name="Value">A value to be written in the .ini file.</param>
        /// <param name="Section">A section that associates the key.</param>
        public void Write(string Key, string Value, string Section = null) {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        /// <summary>
        /// Deletes a key and its value.
        /// </summary>
        /// <param name="Key">A key to be deleted from a .ini file.</param>
        /// <param name="Section">A section that associates the key.</param>
        public void DeleteKey(string Key, string Section = null) {
            Write(Key, null, Section ?? EXE);
        }

        /// <summary>
        /// Deletes a specified section from the .ini file.
        /// </summary>
        /// <param name="Section">A section to be remove.</param>
        public void DeleteSection(string Section = null) {
            Write(null, null, Section ?? EXE);
        }

        /// <summary>
        /// Checks if the specified key exists in the .ini file.
        /// </summary>
        /// <param name="Key">A key to find inside the .ini file.</param>
        /// <param name="Section">A section that associates the key.</param>
        /// <returns>Returns true if the specified key exists, otherwise false.</returns>
        public bool KeyExists(string Key, string Section = null) {
            return Read(Key, Section).Length > 0;
        }

    }
}
