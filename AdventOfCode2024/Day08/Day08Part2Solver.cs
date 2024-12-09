using AdventOfCode2024.Common;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day08
{

    public class Day08Part2Solver : Day08BaseSolver
    {
        protected override int MaxCheck => Math.Max(mapMaxX, mapMaxY);

        protected override int MinCheck => -Math.Max(mapMaxX, mapMaxY);

        public override string Solve(List<string> lines)
        {
            base.CreateMap(lines);
            base.CalculateAntinodes();
            return base.antinodes.Count + "";
        }

    }
}
