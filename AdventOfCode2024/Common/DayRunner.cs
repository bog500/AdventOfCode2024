using AdventOfCode2024.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024
{
    public class DayRunner<T> : IDayRunner
        where T : IPartSolver, new()
    {
        
        private readonly ClueReader cr;

        private readonly T solver;

        protected readonly List<string> demoLines;
        protected readonly List<string> clueLines;

        private DayEnum Day;
        private PartEnum Part;

        private void SetEnums()
        {
            Day = Enum.Parse<DayEnum>(typeof(T).Name
                .Replace("Part1","")
                .Replace("Part2", "")
                .Replace("Solver",""));

            Part = typeof(T).Name.Contains("Part1") ? PartEnum.Part1 : PartEnum.Part2;
        }

        public DayRunner(): this(FileEnum.Default)
        {

        }

        public DayRunner(FileEnum file = FileEnum.Default)
        {
            SetEnums();

            ConsoleWritter.WriteLine("=====================");
            ConsoleWritter.Write("   " + Day.ToString(), ConsoleColor.Yellow);
            ConsoleWritter.WriteLine("   " + Part.ToString(), ConsoleColor.White);
            ConsoleWritter.WriteLine("=====================");

            cr = new ClueReader(Day);

            solver = new();

            demoLines = cr.Read(GetFile(file, DemoEnum.Demo, Part));
            clueLines = cr.Read(GetFile(file, DemoEnum.Real, Part));
        }

        private FileEnum GetFile(FileEnum file, DemoEnum demoreal, PartEnum part)
        {
            return (file, demoreal, part) switch
            {
                (FileEnum.Default, DemoEnum.Demo, PartEnum.Part1) => FileEnum.Demo1,
                (FileEnum.Default, DemoEnum.Demo, PartEnum.Part2) => FileEnum.Demo2,
                (FileEnum.Default, DemoEnum.Real, _) => FileEnum.Clue,
                (_,_, _) => file,
            };
        }

        public string Run()
        {
            using (new CodeTimer())
            {
                var ans = solver.Solve(demoLines);
                ConsoleWritter.Answer(DemoEnum.Demo, ans);
                return ans;
            }
        }

        public IPartSolver GetSolver() => solver;
    }
}
