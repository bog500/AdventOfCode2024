using AdventOfCode2024.Common;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Tests
{
    public class Day02Tests
    {
        [Fact]
        public void Part1_Clue()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day02, PartEnum.Part1, FileEnum.Clue);
            var result = runner2.Run();
            Assert.Equal("Good:282", result);
        }

        [Fact]
        public void Part1_Demo1()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day02, PartEnum.Part1, FileEnum.Demo1);
            var result = runner2.Run();
            Assert.Equal("Good:2", result);
        }
    }
}
