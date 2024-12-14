using AdventOfCode2024.Common;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day13
{

    public class Day13Part2Solver : Day13BaseSolver
    {

        public override string Solve(List<string> lines)
        {

            var games = CreateGames(lines);

            foreach(var g in games)
            {
                g.AddToPrice(10000000000000);
            }

            var sum = GetSum(games);

            return sum + "";
        }

    }
}
