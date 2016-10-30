using System;
using System.IO;

namespace DelimiterChomper
{
    public enum Direction
    {
        LEFT,
        RIGHT
    }

    public static class CommandLine
    {
        /// <summary>
        /// Direction must be either Left or Right. We do allow mixed 
        /// case to be more flexible though
        /// </summary>
        public static Direction CheckDirection(string v)
        {
            Direction direction;
            if (Enum.TryParse(v.ToUpper(), out direction) == false)
            {
                Console.WriteLine("Invalid direction. Use: Left or Right");
                Usage();
                System.Environment.Exit(1);
            }

            return direction;
        }

        /// <summary>
        /// Ensure a number is supplied for the amount of delimiters
        /// that can exist and that it is greater than zero
        /// </summary>
        public static int CheckAllowed(string v)
        {
            int allowed;
            if (Int32.TryParse(v, out allowed) == false || allowed < 1)
            {
                Console.WriteLine("Invalid number for Allowed: {0}", v);
                Usage();
                System.Environment.Exit(2);
            }

            return allowed;
        }

        /// <summary>
        /// Ensure we can open the file specified
        /// </summary>
        public static string CheckInPath(string v)
        {
            if (!File.Exists(v))
            {
                Console.WriteLine("File: {0} does not exist", v);
                Usage();
                System.Environment.Exit(3);
            }

            return v;
        }

        /// <summary>
        /// Ensure we can write to the file and location specified
        /// </summary>
        public static string CheckOutPath(string v)
        {
            try
            {
                using (FileStream fs = File.Create(v))
                {
                    // Do nothing here. Want it to close.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("File: {0} cannot be written to", v);
                Console.WriteLine(e);
                Usage();
                System.Environment.Exit(4);
            }

            return v;
        }

        /// <summary>
        /// A delimiter should be one character
        /// </summary>
        public static string CheckDelimiter(string v)
        {
            if (v.Length != 1)
            {
                Console.WriteLine("Delimiter is too long. Expecting 1 character");
                Usage();
                System.Environment.Exit(5);
            }

            return v;
        }

        /// <summary>
        /// How to use the program
        /// </summary>
        public static void Usage()
        {
            Console.WriteLine("Usage: DelimiterChomper Delimiter Direction Allowed FilenameIn FilenameOut");
            Console.WriteLine("       Delimiter: E.g. \",\" or \"|\"");
            Console.WriteLine("       Direction: E.g. Left or Right");
            Console.WriteLine("       Allowed: Number of delimiters to allow before removing remainder");
            Console.WriteLine("       FilenameIn: Path to the file to process");
            Console.WriteLine("       FilenameOut: Path of file to write output to");
            Console.WriteLine();
            Console.WriteLine("E.g.   DelimiterChomper \",\" Left 5 C:\\foo.csv C:\\foo-out.csv");
            Console.WriteLine("       This will remove all commas after the fifth one found, starting from the left, in file foo.csv");
        }
    }
}
