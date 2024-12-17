using AdventOfCode2024.Common;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day14
{

    public class Day14Part2Solver : Day14BaseSolver
    {
        int minDist = int.MaxValue;
        int bestSeconds = 0;
        public override string Solve(List<string> lines)
        {
            var robots = GetRobots(lines);

            int seconds = 0;
            while(seconds < 10_000)
            {
                if (MiddleFinder(robots, seconds))
                    break;

                foreach (var r in robots)
                {
                    r.Move();
                }
                seconds++;
            }

            return seconds + "";
        }

        private bool MiddleFinder(List<Robot> robots, int seconds)
        {
            int dist = 0;
            foreach(var r1 in robots)
            {
                foreach (var r2 in robots)
                {
                    dist += Math.Abs(r2.Location.X - r1.Location.X);
                    dist += Math.Abs(r2.Location.Y - r1.Location.Y);
                }
            }

            if(dist < minDist)
            {
                minDist = dist;
                bestSeconds = seconds;
            }

            return false;
        }
    }
}
