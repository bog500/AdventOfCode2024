using AdventOfCode2024.Common;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Tests
{
    public class Day13Tests
    {
        [Fact]
        public void Part1_Clue()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day13, PartEnum.Part1, FileEnum.Clue);
            var result = runner2.Run();
            Assert.Equal("27105", result);
        }

        [Fact]
        public void Part1_Demo1()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day13, PartEnum.Part1, FileEnum.Demo1);
            var result = runner2.Run();
            Assert.Equal("480", result);
        }

        
        [Fact]
        public void Part2_Clue()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day13, PartEnum.Part2, FileEnum.Clue);
            var result = runner2.Run();
            Assert.Equal("101726882250942", result);
        }
        

    }
}
