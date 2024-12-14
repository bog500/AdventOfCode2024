using AdventOfCode2024.Day02;
using AdventOfCode2024.Day03;
using AdventOfCode2024.Day04;
using AdventOfCode2024.Day05;
using AdventOfCode2024.Day06;
using AdventOfCode2024.Day07;
using AdventOfCode2024.Day08;
using AdventOfCode2024.Day09;
using AdventOfCode2024.Day10;
using AdventOfCode2024.Day11;
using AdventOfCode2024.Day12;
using AdventOfCode2024.Day13;
using AdventOfCode2024.Day14;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Common
{
    public static class DayRunners
    {
        public static IEnumerable<IDayRunner> GetAll()
        {
            foreach(var day in Enum.GetValues<DayEnum>())
            {
                yield return Get(day, PartEnum.Part1);
                yield return Get(day, PartEnum.Part2);
            }
        }

        public static IDayRunner Get(DayEnum day, PartEnum part, FileEnum file = FileEnum.Default)
        {
            return (day, part) switch
            {
                (DayEnum.Day02, PartEnum.Part1) => new DayRunner<Day02Part1Solver>(file),
                (DayEnum.Day02, PartEnum.Part2) => new DayRunner<Day02Part2Solver>(file),
                (DayEnum.Day03, PartEnum.Part1) => new DayRunner<Day03Part1Solver>(file),
                (DayEnum.Day03, PartEnum.Part2) => new DayRunner<Day03Part2Solver>(file),
                (DayEnum.Day04, PartEnum.Part1) => new DayRunner<Day04Part1Solver>(file),
                (DayEnum.Day04, PartEnum.Part2) => new DayRunner<Day04Part2Solver>(file),
                (DayEnum.Day05, PartEnum.Part1) => new DayRunner<Day05Part1Solver>(file),
                (DayEnum.Day05, PartEnum.Part2) => new DayRunner<Day05Part2Solver>(file),
                (DayEnum.Day06, PartEnum.Part1) => new DayRunner<Day06Part1Solver>(file),
                (DayEnum.Day06, PartEnum.Part2) => new DayRunner<Day06Part2Solver>(file),
                (DayEnum.Day07, PartEnum.Part1) => new DayRunner<Day07Part1Solver>(file),
                (DayEnum.Day07, PartEnum.Part2) => new DayRunner<Day07Part2Solver>(file),
                (DayEnum.Day08, PartEnum.Part1) => new DayRunner<Day08Part1Solver>(file),
                (DayEnum.Day08, PartEnum.Part2) => new DayRunner<Day08Part2Solver>(file),
                (DayEnum.Day09, PartEnum.Part1) => new DayRunner<Day09Part1Solver>(file),
                (DayEnum.Day09, PartEnum.Part2) => new DayRunner<Day09Part2Solver>(file),
                (DayEnum.Day10, PartEnum.Part1) => new DayRunner<Day10Part1Solver>(file),
                (DayEnum.Day10, PartEnum.Part2) => new DayRunner<Day10Part2Solver>(file),
                (DayEnum.Day11, PartEnum.Part1) => new DayRunner<Day11Part1Solver>(file),
                (DayEnum.Day11, PartEnum.Part2) => new DayRunner<Day11Part2Solver>(file),
                (DayEnum.Day12, PartEnum.Part1) => new DayRunner<Day12Part1Solver>(file),
                (DayEnum.Day12, PartEnum.Part2) => new DayRunner<Day12Part2Solver>(file),
                (DayEnum.Day13, PartEnum.Part1) => new DayRunner<Day13Part1Solver>(file),
                (DayEnum.Day13, PartEnum.Part2) => new DayRunner<Day13Part2Solver>(file),
                (DayEnum.Day14, PartEnum.Part1) => new DayRunner<Day14Part1Solver>(file),
                (DayEnum.Day14, PartEnum.Part2) => new DayRunner<Day14Part2Solver>(file),
            };
        }
    }
}
