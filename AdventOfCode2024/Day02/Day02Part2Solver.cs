
using AdventOfCode2024.Common;

namespace AdventOfCode2024.Day02
{
    public class Day02Part2Solver : Day02BaseSolver
    {
        public override string Solve(List<string> lines)
        {
            int good = 0;
            foreach (var line in lines)
            {
                var report = Parser.ParseInt(line);
                bool goodFound = false;
                for(int i = -1; i < report.Count && !goodFound; i++)
                {
                    var report2 = ModifyReport(report, i);
                    if (IsValid(report2))
                    {
                        good++;
                        goodFound = true;
                    }
                }

                    
            }
            return "Good:" + good;
        }

        private List<int> ModifyReport(List<int> report, int indexToRemove)
        {
            if (indexToRemove == -1)
                return report;

            List<int> newReport = new(report);
            newReport.RemoveAt(indexToRemove);
            return newReport;
        }
    }
}
