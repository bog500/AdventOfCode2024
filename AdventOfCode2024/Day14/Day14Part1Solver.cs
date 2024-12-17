using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day14
{

    public class Day14Part1Solver : Day14BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            var robots = GetRobots(lines);

            for(int i = 0; i < 100; i++)
            {
                foreach(var r in robots)
                {
                    r.Move();
                }
            }

            int sum = GetSafertyFactor(robots);

            return sum + "";
        }


    }
}
