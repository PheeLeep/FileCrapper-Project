using System.Runtime.InteropServices;

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
    }
}
