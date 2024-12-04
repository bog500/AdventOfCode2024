using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day04
{

    public class Day04Part1Solver : Day04BaseSolver
    {
        Dictionary<Coord, char> dict = [];

        public override string Solve(List<string> lines)
        {

            int y = 0;
            int maxX = 0;
            foreach(var line in lines)
            {
                int x = 0;
                foreach(var c in line)
                {
                    Coord coord = new(x, y);
                    dict.Add(coord, c);
                    x++;
                }
                y++;
                maxX = x;
            }
            int sum = Find(maxX, y);
            return sum.ToString();
        }

        private int Find(int maxX, int maxY)
        {
            int sum = 0;
            for(int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {

                    string horizontal1 = GetValue(new Coord(x, y)) + GetValue(new Coord(x + 1, y)) + GetValue(new Coord(x + 2, y)) + GetValue(new Coord(x + 3, y));
                    string horizontal2 = GetValue(new Coord(x, y)) + GetValue(new Coord(x - 1, y)) + GetValue(new Coord(x - 2, y)) + GetValue(new Coord(x - 3, y));

                    string vertical1 = GetValue(new Coord(x, y)) + GetValue(new Coord(x, y + 1)) + GetValue(new Coord(x, y + 2)) + GetValue(new Coord(x, y + 3));
                    string vertical2 = GetValue(new Coord(x, y)) + GetValue(new Coord(x, y - 1)) + GetValue(new Coord(x, y - 2)) + GetValue(new Coord(x, y - 3));

                    string diag1 = GetValue(new Coord(x, y)) + GetValue(new Coord(x + 1, y + 1)) + GetValue(new Coord(x + 2, y + 2)) + GetValue(new Coord(x + 3, y + 3));
                    string diag2 = GetValue(new Coord(x, y)) + GetValue(new Coord(x - 1, y - 1)) + GetValue(new Coord(x - 2, y - 2)) + GetValue(new Coord(x - 3, y - 3));

                    string diag3 = GetValue(new Coord(x, y)) + GetValue(new Coord(x + 1, y - 1)) + GetValue(new Coord(x + 2, y - 2)) + GetValue(new Coord(x + 3, y - 3));
                    string diag4 = GetValue(new Coord(x, y)) + GetValue(new Coord(x - 1, y + 1)) + GetValue(new Coord(x - 2, y + 2)) + GetValue(new Coord(x - 3, y + 3));

                    if (horizontal1 == "XMAS")
                        sum++;

                    if (horizontal2 == "XMAS")
                        sum++;

                    if (vertical1 == "XMAS")
                        sum++;

                    if (vertical2 == "XMAS")
                        sum++;

                    if (diag1 == "XMAS")
                        sum++;

                    if (diag2 == "XMAS")
                        sum++;

                    if (diag3 == "XMAS")
                        sum++;

                    if (diag4 == "XMAS")
                        sum++;
                }
            }

            return sum;
        }

        private string GetValue(Coord c)
        {
            if (dict.ContainsKey(c))
            {
                return dict[c].ToString();
            }
            return "";
        }


    }
}
