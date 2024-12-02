
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day02
{
    public abstract class Day02BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> line);

        protected bool IsValid(List<int> report)
        {
            int last = report[0];
            bool increasing = report[1] > last;

            foreach (int i in report.Skip(1))
            {
                int diff = i - last;

                if (diff == 0 || diff < -3 || diff > 3)
                    return false;

                if (increasing && diff <= 0)
                    return false;

                if (!increasing && diff >= 0)
                    return false;

                last = i;
            }
            return true;
        }
    }
}
