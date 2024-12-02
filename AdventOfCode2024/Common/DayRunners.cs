using AdventOfCode2024.Day02;
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
            };
        }
    }
}
