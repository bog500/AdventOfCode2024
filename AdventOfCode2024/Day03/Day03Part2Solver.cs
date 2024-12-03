
using AdventOfCode2024.Common;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03
{
    public class Day03Part2Solver : Day03BaseSolver
    {
        private int GetIndex(MatchCollection match, int maxIndex)
        {
            int index = int.MinValue;

            var matches = match.Where(o => o.Index < maxIndex);
            if (matches.Any())
            {
                index = matches.Select(o => o.Index).Max();
            }
            return index;
        }

        public override string Solve(List<string> lines)
        {

            string line = string.Join('\n', lines);

            long sum = 0;

            Regex regNumber = new Regex(@"mul\([0-9]+,[0-9]+\)");

            Regex regDo = new Regex(@"do\(\)");
            Regex regDont = new Regex(@"don't\(\)");

            var mRegDo = regDo.Matches(line);
            var mRegDont = regDont.Matches(line);

            AnalizerData data = new();

            foreach (Match m in regNumber.Matches(line))
            {
                int doIndex = GetIndex(mRegDo, m.Index);
                int dontIndex = GetIndex(mRegDont, m.Index);

                if (doIndex < dontIndex)
                    continue;

                string s = m.Value.Replace("mul(", "").Replace(")", "");
                int i1 = int.Parse(s.Split(',')[0]);
                int i2 = int.Parse(s.Split(',')[1]);

                sum += i1 * i2;
            }

            return sum.ToString();
        }

    }
}
