using AdventOfCode2024.Common;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day15
{

    public class Day15Part1Solver : Day15BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            CreateMap(lines);

            foreach(var c in Instructions)
            {
                switch(c)
                {
                    case '<':
                        Robot.MoveLeft();
                        break;
                    case '>':
                        Robot.MoveRight();
                        break;
                    case '^':
                        Robot.MoveUp();
                        break;
                    case 'v':
                        Robot.MoveDown();
                        break;
                }
            }

            long sum = 0;

            foreach(var b in Boxes)
            {
                sum += b.GpsScore();
            }

            return sum + "";
        }


    }
}
