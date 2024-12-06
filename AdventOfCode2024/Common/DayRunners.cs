using AdventOfCode2024.Day02;
using AdventOfCode2024.Day03;
using AdventOfCode2024.Day04;
using AdventOfCode2024.Day05;
using AdventOfCode2024.Day06;
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
            };
        }
    }
}
