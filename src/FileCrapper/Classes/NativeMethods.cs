using System;
using System.Runtime.InteropServices;
using System.Text;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class containing the native methods.
    /// </summary>
    internal static class NativeMethods {

        /// <summary>
        /// Attaches the calling process to the console of the specified process as a client application.
        /// </summary>
        /// <param name="dwProcessId">Use the console of the parent of the current process.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        internal static extern bool AttachConsole(int dwProcessId);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="hWnd">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="Msg">The message to be sent.</param>
        /// <param name="wParam">Additional message-specific information.</param>
        /// <param name="lParam">Additional message-specific information.</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// Copies a string into the specified section of an initialization file.
        /// </summary>
        /// <param name="Section">The name of the section to which the string will be copied. If the section does not exist, it is created.</param>
        /// <param name="Key">The name of the key to be associated with a string. If the key does not exist in the specified section, it is created.</param>
        /// <param name="Value">A null-terminated string to be written to the file. If this parameter is NULL, the key pointed to by the lpKeyName parameter is deleted.</param>
        /// <param name="FilePath">The name of the initialization file.</param>
        /// <returns>If the function successfully copies the string to the initialization file, the return value is nonzero.</returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        /// <summary>
        /// Retrieves a string from the specified section in an initialization file.
        /// </summary>
        /// <param name="Section">The name of the section containing the key name. </param>
        /// <param name="Key">The name of the key whose associated string is to be retrieved. </param>
        /// <param name="Default">A default string.</param>
        /// <param name="RetVal">A pointer to the buffer that receives the retrieved string.</param>
        /// <param name="Size">The size of the buffer pointed to by the lpReturnedString parameter, in characters.</param>
        /// <param name="FilePath">The name of the initialization file.</param>
        /// <returns>The return value is the number of characters copied to the buffer, not including the terminating null character.</returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
    }
}
