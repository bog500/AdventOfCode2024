using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day06
{

    public class Day06Part1Solver : Day06BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            CreateMap(lines);

            var visited = GetVisited();

            return visited.Count.ToString();
        }


    }
}
