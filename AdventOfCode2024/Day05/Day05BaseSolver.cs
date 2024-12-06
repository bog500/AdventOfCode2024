
using AdventOfCode2024.Common;
using System.Collections.Generic;

namespace AdventOfCode2024.Day05
{
    public abstract class Day05BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        public PageComparer GetPageComparer(List<string> lines)
        {
            PageComparer comparer = new();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Contains(","))
                    continue;

                int page1 = int.Parse(line.Split('|')[0]);
                int page2 = int.Parse(line.Split('|')[1]);

                comparer.AddPage(page1, page2);
            }

            return comparer;
        }

        public List<List<int>> GetPageUpdates(List<string> lines)
        {
            List<List<int>> pageUptates = [];
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Contains("|"))
                    continue;

                List<int> pages = line.Split(',').Select(o => int.Parse(o)).ToList();
                pageUptates.Add(pages);
            }
            return pageUptates;
        }

        public int GetMiddle(List<int> list)
        {
            int middle = (list.Count - 1) / 2;
            return list.ElementAt(middle);
        }

    }

    public class PageComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            if (rules.Contains((x, y)))
                return -1;
            return 1;
        }

        public void AddPage(int pageBefore, int pageAfter)
        {
            rules.Add((pageBefore, pageAfter));
        }

        private readonly HashSet<(int, int)> rules = [];
    }
}
