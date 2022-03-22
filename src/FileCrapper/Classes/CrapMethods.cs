﻿using System;
using System.IO;

namespace FileCrapper.Classes {

    /// <summary>
    /// A static class containing functions for crapping file/s.
    /// </summary>
    internal static class CrapMethods {

        /// <summary>
        /// A null byte character.
        /// </summary>
        static readonly byte[] nullByte = new byte[] { 0 };

        /// <summary>
        /// Overwrites the targeted byte with a new, generated byte.
        /// </summary>
        /// <param name="fs">An existing <see cref="FileStream"/> object.</param>
        internal static void OverwriteNewByte(FileStream fs) {
            byte[] newByt = new byte[] { (byte)Program.Random.Next(1, 255) };
            fs.Write(newByt, 0, newByt.Length);
            fs.Flush();
            Console.WriteLine("Position %a has been modified.".Replace("%a", fs.Position.ToString()));
        }

        /// <summary>
        /// Nullifies the targeted byte.
        /// </summary>
        /// <param name="fs">An existing <see cref="FileStream"/> object.</param>
        internal static void NullifyByte(FileStream fs) {
            fs.Write(nullByte, 0, nullByte.Length);
            fs.Flush();
            Console.WriteLine("Position %a has been nullified.".Replace("%a", fs.Position.ToString()));
        }

        /// <summary>
        /// Swaps two bytes from its own different positions.
        /// </summary>
        /// <param name="fs">An existing <see cref="FileStream"/> object.</param>
        /// <param name="startingPoint">The starting point where it should begin, for randomization.</param>
        internal static void SwapBytes(FileStream fs, long startingPoint) {
            long lastKnownPos1, lastKnownPos2;
            int len = 1;
            if (fs.Length > 32)
                len = Program.Random.Next(1, 32);

            byte[] firstByte = new byte[len];
            byte[] secByte = new byte[len];

            ChangeStreamPosition(fs, startingPoint); // Randomize the first position.

            lastKnownPos1 = fs.Position;
            fs.Read(firstByte, 0, firstByte.Length);

            ChangeStreamPosition(fs, startingPoint); // Randomize the second position.

            lastKnownPos2 = fs.Position;
            fs.Read(secByte, 0, secByte.Length);

            // Begin the swapping phase.
            fs.Position = lastKnownPos1;
            fs.Write(secByte, 0, secByte.Length);
            fs.Position = lastKnownPos2;
            fs.Write(firstByte, 0, firstByte.Length);

            fs.Flush();

            Array.Clear(firstByte, 0, firstByte.Length);
            Array.Clear(secByte, 0, secByte.Length);

            Console.WriteLine("Positions has been swapped.");
        }

        /// <summary>
        /// Randomize changing the stream's position.
        /// </summary>
        /// <param name="f">An existing <see cref="FileStream"/> object.</param>
        /// <param name="startingpoint">The starting point where it should begin, for randomization.</param>
        internal static void ChangeStreamPosition(FileStream f, long startingpoint) {
            long len = f.Length;
            f.Position = startingpoint;
            long nextPos;
            try {
                nextPos = Program.Random.NextLong(startingpoint, len);
            } catch {
                nextPos = startingpoint;
            }
            f.Seek(nextPos, SeekOrigin.Begin);
            Console.WriteLine("Position has been set to byte %a".Replace("%a", f.Position.ToString()));
        }
    }
}
