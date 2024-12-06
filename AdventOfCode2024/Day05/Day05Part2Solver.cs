using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day05
{

    public class Day05Part2Solver : Day05BaseSolver
    {
        Dictionary<Coord, char> dict = [];

        public override string Solve(List<string> lines)
        {
            int sum = 0;
            PageComparer comparer = base.GetPageComparer(lines);
            List<List<int>> updates = GetPageUpdates(lines);

            foreach (var update in updates)
            {
                List<int> list2 = new(update);
                list2.Sort(comparer);

                if (!update.SequenceEqual(list2))
                {
                    sum += GetMiddle(list2);
                }
            }

            return sum.ToString();
        }

    }
}
