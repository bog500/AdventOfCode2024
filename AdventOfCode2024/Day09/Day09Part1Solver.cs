﻿using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day09
{

    public class Day09Part1Solver : Day09BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            string str = base.Expand(lines[0]);
            string str2 = base.Compact(str);


            long checksum = base.CheckSum(str2);


            string f = checksum.ToString();

            return f;
        }

    }
}
