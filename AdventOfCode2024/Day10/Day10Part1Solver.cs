using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day10
{

    public class Day10Part1Solver : Day10BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            base.CreateMap(lines);
            base.ExploreStart();
            var score = GetScore();
            return score + "";

        }


    }
}
