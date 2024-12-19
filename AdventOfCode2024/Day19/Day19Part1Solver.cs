using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day19
{

    public class Day19Part1Solver : Day19BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            base.Init(lines);
            var c = base.CountPossibles();
            return c + "";
        }


    }
}
