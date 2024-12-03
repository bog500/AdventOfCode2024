using AdventOfCode2024.Common;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03
{
    record AnalizerData
    {
        public string mul { get; set; } = "";
        public string numA { get; set; } = "";
        public string numB { get; set; } = "";

        public bool commaFound = false;
    }

    public class Day03Part1Solver : Day03BaseSolver
    {

        public override string Solve(List<string> lines)
        {

            long sum = 0;

            Regex r = new Regex(@"mul\([0-9]+,[0-9]+\)");

            foreach (var line in lines)
            {
                AnalizerData data = new();

                foreach (Match m in r.Matches(line))
                {
                    string s = m.Value.Replace("mul(", "").Replace(")", "");
                    int i1 = int.Parse(s.Split(',')[0]);
                    int i2 = int.Parse(s.Split(',')[1]);
                    sum += i1 * i2;
                }
            }

            return sum.ToString();
        }

    }
}
