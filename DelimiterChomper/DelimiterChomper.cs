using System;
using System.Text;
using System.IO;

namespace DelimiterChomper
{
    public static class DelimiterChomper
    {
        /// <summary>
        /// Opens and writes the files, whilst removing any excess delimiters
        /// </summary>
        public static void RemoveExcessDelimiters(string delimiter, Direction direction, int allowed, string inPath, string outPath)
        {
            using (StreamReader sr = new StreamReader(inPath))
            {
                using (StreamWriter sw = new StreamWriter(outPath))
                {
                    string line = string.Empty;
                    while (null != (line = sr.ReadLine()))
                    {
                        line = CleanLineOfDelimiters(delimiter, direction, allowed, line);
                        sw.WriteLine(line);
                    }
                }
            }
        }

        /// <summary>
        /// Given a line of text (from a file), remove the excess delimiters
        /// </summary>
        public static string CleanLineOfDelimiters(string delimiter, Direction direction, int allowed, string line)
        {
            var result = new StringBuilder();

            if (string.IsNullOrEmpty(line))
                return string.Empty;

            if (direction == Direction.RIGHT)
            {
                line = Reverse(line);
            }

            for (int i = 0; i < line.Length; i++)
            {
                // Add character to result only if it's not a delimiter, or within the bounds of
                // allowed delimiters.
                if ((line[i] == delimiter[0] && allowed-- > 0) || line[i] != delimiter[0])
                {
                    if (direction == Direction.RIGHT)
                    {
                        result.Insert(0, line[i]);
                    }
                    else
                    {
                        result.Append(line[i]);
                    }
                }
            }

            return result.ToString();
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
