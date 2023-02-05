using System;
using System.Diagnostics;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class containing methods for extra debugging props.
    /// </summary>
    internal static class DebugProps {

        /// <summary>
        /// A boolean to determine that the debug prop session is initialized.
        /// </summary>
        private static bool isInitialzed = false;

        /// <summary>
        /// A readonly <see cref="Stopwatch"/> used on time elapsed.
        /// </summary>
        private static readonly Stopwatch sw = new Stopwatch();

        /// <summary>
        /// An object used for synchronization.
        /// </summary>
        private static readonly object locker = new object();

        /// <summary>
        /// An enumeration of a status type.
        /// </summary>
        internal enum PrintType {
            /// <summary>
            /// An error status.
            /// </summary>
            Error,

            /// <summary>
            /// A warning status.
            /// </summary>
            Warning,

            /// <summary>
            /// An info status.
            /// </summary>
            Info,

            /// <summary>
            /// A debug status.
            /// </summary>
            Debug
        }

        /// <summary>
        /// Initialize the debugging props session.
        /// </summary>
        internal static void Initialize() {
#if DEBUG
            if (isInitialzed) return;
            Debug.AutoFlush = true;
            Debug.Print("== FileCrapper Debugger Props ==");
            isInitialzed = true;
            Print(PrintType.Info, "Debug session started at " + DateTime.Now.ToString("dd/MM/yy hh:mm:ss"));
#endif
        }

        /// <summary>
        /// Closes the current debugging props session.
        /// </summary>
        internal static void Close() {
            if (!isInitialzed) return;
            Print(PrintType.Info, "Debug session ended at " + DateTime.Now.ToString("dd/MM/yy hh:mm:ss"));
            isInitialzed = false;
        }

        /// <summary>
        /// Starts the stopwatch.
        /// </summary>
        internal static void StartStopwatch() {
            if (!isInitialzed || sw.IsRunning) return;
            sw.Restart();
        }

        /// <summary>
        /// Stops the stopwatch and print the time elapsed.
        /// </summary>
        internal static void StopStopwatch() {
            if (!isInitialzed || !sw.IsRunning) return;
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Print(PrintType.Debug, "Time Elapsed: " + string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds));
        }

        /// <summary>
        /// Prints the message with date/time and icon indicating the status.
        /// </summary>
        /// <param name="type">The status type of a message.</param>
        /// <param name="message">The message to be print.</param>
        internal static void Print(PrintType type, string message) {
            if (!isInitialzed) return;
            lock (locker) {
                switch (type) {
                    case PrintType.Error:
                        message = "[x]: " + message;
                        break;
                    case PrintType.Warning:
                        message = "[!]: " + message;
                        break;
                    case PrintType.Info:
                        message = "[i]: " + message;
                        break;
                    case PrintType.Debug:
                        message = "[~]: " + message;
                        break;
                }
                message = "[" + DateTime.Now.ToString("dd/MM/yy hh:mm:ss") + "]" + message;
                Debug.Print(message);
            }
        }
    }
}
