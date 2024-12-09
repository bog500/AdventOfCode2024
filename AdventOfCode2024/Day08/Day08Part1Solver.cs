using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day08
{

    public class Day08Part1Solver : Day08BaseSolver
    {
        protected override int MaxCheck => 2;

        protected override int MinCheck => 1;

        public override string Solve(List<string> lines)
        {
            base.CreateMap(lines);
            base.CalculateAntinodes();
            return base.antinodes.Count + "";
        }


    }
}
