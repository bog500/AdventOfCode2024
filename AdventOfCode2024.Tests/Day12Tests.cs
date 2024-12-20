﻿using AdventOfCode2024.Common;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Tests
{
    public class Day12Tests
    {
        [Fact]
        public void Part1_Clue()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day12, PartEnum.Part1, FileEnum.Clue);
            var result = runner2.Run();
            Assert.Equal("1550156", result);
        }

        [Fact]
        public void Part1_Demo1()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day12, PartEnum.Part1, FileEnum.Demo1);
            var result = runner2.Run();
            Assert.Equal("772", result);
        }

        [Fact]
        public void Part1_Demo2()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day12, PartEnum.Part1, FileEnum.Demo2);
            var result = runner2.Run();
            Assert.Equal("1930", result);
        }

        
        [Fact]
        public void Part2_Clue()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day12, PartEnum.Part2, FileEnum.Clue);
            var result = runner2.Run();
            // bad 709490 (too low)

            // bad 7094900 (too high)
            Assert.Equal("71668682", result);
        }

        [Fact]
        public void Part2_Demo3()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day12, PartEnum.Part2, FileEnum.Demo3);
            var result = runner2.Run();
            Assert.Equal("80", result);
        }

        [Fact]
        public void Part2_Demo4()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day12, PartEnum.Part2, FileEnum.Demo4);
            var result = runner2.Run();
            Assert.Equal("236", result);
        }

        [Fact]
        public void Part2_Demo5()
        {
            IDayRunner runner2 = DayRunners.Get(DayEnum.Day12, PartEnum.Part2, FileEnum.Demo5);
            var result = runner2.Run();
            Assert.Equal("368", result);
        }
    }
}
