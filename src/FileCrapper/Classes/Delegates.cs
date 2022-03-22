using System;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class for containing delegates.
    /// </summary>
    internal static class Delegates {

        /// <summary>
        /// A method represents sending status text, to the event.
        /// </summary>
        /// <param name="text">A string containing status text.</param>
        public delegate void CurrentStatusTextDelegate(string text);

        /// <summary>
        /// A method represents the current file index and its filename, from the object.
        /// </summary>
        /// <param name="index">The current index of the file.</param>
        /// <param name="total">The total number of files inside the object.</param>
        /// <param name="fileName">A filename of the current file index.</param>
        /// <param name="filesPerce">The current percentage of the files been crapped, inside the object.</param>
        public delegate void CurrentDirectoryFileIndexDelegate(int index, int total, string fileName, int filesPerce);

        /// <summary>
        /// A method represents the current object index. (not to be confused with <see cref="CurrentDirectoryFileIndexDelegate"/>)
        /// </summary>
        /// <param name="index">The current index of the object.</param>
        /// <param name="total">The total number of objects.</param>
        /// <param name="filesPerce">The current percentage of the objects been crapped.</param>
        public delegate void CurrentObjectsIndexDelegate(int index, int total, int filesPerce);

        /// <summary>
        /// A method represents the current number of rounds, during file crapping.
        /// </summary>
        /// <param name="roundsCurrent">A current number of rounds.</param>
        /// <param name="roundsTotal">A total number of rounds.</param>
        public delegate void OnFileCrappingDelegate(int roundsCurrent, int roundsTotal);

        /// <summary>
        /// A method represents the completion of the file crapping process.
        /// </summary>
        /// <param name="isCancelled">Returns true if the process was cancelled.</param>
        /// <param name="e">Returns an <see cref="Exception"/> if there is a problem; null if it was manually-canceled.</param>
        public delegate void OnFileCrappedDelegate(bool isCancelled, Exception e);

        /// <summary>
        /// A method represents on invoking when the objects inside <see cref="FCrapperMotherClass"/> was changed.
        /// </summary>
        public delegate void ObjectsChangedDelegate();
    }
}
