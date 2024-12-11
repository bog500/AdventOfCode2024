using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day11
{

    public class Day11Part1Solver : Day11BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            CreateArrangement(lines[0]);
            Blink(25);
            return stones.Count + "";
        }


    }
}
