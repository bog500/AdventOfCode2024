using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day04
{

    public class Day04Part2Solver : Day04BaseSolver
    {
        Dictionary<Coord, char> dict = [];

        public override string Solve(List<string> lines)
        {

            int y = 0;
            int maxX = 0;
            foreach (var line in lines)
            {
                int x = 0;
                foreach (var c in line)
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
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (GetValue(new Coord(x, y)) != "A")
                        continue;

                    string diag1 = GetValue(new Coord(x-1, y-1)) + GetValue(new Coord(x, y)) + GetValue(new Coord(x + 1, y + 1));
                    string diag2 = GetValue(new Coord(x - 1, y + 1)) + GetValue(new Coord(x, y)) + GetValue(new Coord(x + 1, y - 1));

                    if (diag1 == "MAS" || diag1 == "SAM")
                    {
                        if (diag2 == "MAS" || diag2 == "SAM")
                        {
                            sum++;
                        }
                    }
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
