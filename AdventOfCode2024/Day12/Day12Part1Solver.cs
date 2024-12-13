using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day12
{

    public class Day12Part1Solver : Day12BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            CreateMap(lines);
            CreateRegions();
            int price = GetTotalPriceWithPerimeter();
            return price + "";
        }


    }
}
