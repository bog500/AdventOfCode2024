﻿using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day16
{

    public class Day16Part1Solver : Day16BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            base.CreateMaze(lines);
            //base.Explore(Start, Enums.Direction.Right, 0, 0);
            base.ExploreStack();
            return base.BestScore + "";
        }


    }
}
