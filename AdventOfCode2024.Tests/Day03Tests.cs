using AdventOfCode2024.Common;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Tests
{
    public class Day03Tests
    {
        [Fact]
        public void Part1_Clue()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day03, PartEnum.Part1, FileEnum.Clue);
            var result = runner2.Run();
            Assert.Equal("175700056", result);
        }

        [Fact]
        public void Part1_Demo()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day03, PartEnum.Part1, FileEnum.Demo1);
            var result = runner2.Run();
            Assert.Equal("161", result);
        }

        [Fact]
        public void Part2_Clue()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day03, PartEnum.Part2, FileEnum.Clue);
            var result = runner2.Run();
            Assert.Equal("71668682", result);
        }

        [Fact]
        public void Part2_Demo()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day03, PartEnum.Part2, FileEnum.Demo2);
            var result = runner2.Run();
            Assert.Equal("48", result);
        }
    }
}
