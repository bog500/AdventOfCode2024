using AdventOfCode2024.Common;
using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day13
{

    public class Day13Part1Solver : Day13BaseSolver
    {

        public override string Solve(List<string> lines)
        {

            var games = CreateGames(lines);

            var sum = GetSum(games);
            
            return sum + "";
        }
    }
}
