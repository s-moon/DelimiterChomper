using System;

namespace DelimiterChomper
{
    class Program
    {
        /// <summary>
        /// Main program. We're going to check all the parameters
        /// and then perform the magic on the input file.
        /// 
        /// A successful run will result in an exit code of 0.
        /// 
        /// Exit Code
        /// ---------
        /// 0 = Success
        /// 1 = Direction not one of Left or Right
        /// 2 = Allowed parameter not a number or not greater than zero
        /// 3 = Can't open input file
        /// 4 = Can't write output file
        /// 5 = Delimiter too long
        /// </summary>
        static void Main(string[] args)
        {
            // Validating arguments supplied
            if (args.Length != 5)
            {
                CommandLine.Usage();
                System.Environment.Exit(1);
            }


            string delimiter = CommandLine.CheckDelimiter(args[0]);
            Direction direction = CommandLine.CheckDirection(args[1]);
            int allowed = CommandLine.CheckAllowed(args[2]);
            string inPath = CommandLine.CheckInPath(args[3]);
            string outPath = CommandLine.CheckOutPath(args[4]);

            DelimiterChomper.RemoveExcessDelimiters(delimiter, direction, allowed, inPath, outPath);
            Environment.Exit(0);
        }
    }
}
