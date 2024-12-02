
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day02
{
    public class Day02Part1Solver : Day02BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            int good = 0;
            foreach(var line in lines)
            {
                var report = Parser.ParseInt(line);
                if (IsValid(report))
                    good++;
            }
            return "Good:" + good;
        }

    }
}
