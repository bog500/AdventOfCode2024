using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode2024.Common
{
    public static class Parser
    {
        public static List<int> ParseInt(string s, char splitChar = ' ')
        {
            List<int> ints = s
                .Split(splitChar, StringSplitOptions.RemoveEmptyEntries)
                .Where(o => !string.IsNullOrEmpty(o))
                .Select(o => int.Parse(o))
                .ToList();
            return ints;
        }

        public static List<long> ParseLong(string s, char splitChar = ' ')
        {
            List<long> ints = s
                .Split(splitChar, StringSplitOptions.RemoveEmptyEntries)
                .Where(o => !string.IsNullOrEmpty(o))
                .Select(o => long.Parse(o))
                .ToList();
            return ints;
        }

        public static int CharToInt(char c)
        {
            return (int)c - 48; 
        }

        public static char[,] GetLayout(List<string> lines)
        {
            char[,] layout;

            int rows = lines.Count;
            int cols = lines[0].Length;

            layout = new char[cols, rows];

            int y = 0;
            foreach (var line in lines)
            {
                int x = 0;
                foreach (char c in line)
                {
                    layout[x, y] = c;
                    x++;
                }
                y++;
            }

            return layout;
        }

        public static int[,] GetIntLayout(List<string> lines)
        {
            int[,] layout;

            int rows = lines.Count;
            int cols = lines[0].Length;

            layout = new int[cols, rows];

            int y = 0;
            foreach (var line in lines)
            {
                int x = 0;
                foreach (char c in line)
                {
                    layout[x, y] = c - '0';
                    x++;
                }
                y++;
            }

            return layout;
        }

    }
}
