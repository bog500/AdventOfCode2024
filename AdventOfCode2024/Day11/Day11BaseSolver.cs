
using AdventOfCode2024.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace AdventOfCode2024.Day11
{
    
    public abstract class Day11BaseSolver : IPartSolver
    {


        protected HashSet<Stone> stones = [];


        public abstract string Solve(List<string> lines);

        protected void CreateArrangement(string line)
        {
            var values = Parser.ParseLong(line);
            foreach(var number in values)
            {
                Stone s = new(number);
                stones.Add(s);
            }
        }

        public void Blink(int count)
        {
            Stopwatch sw = new();
            sw.Start();

            for(int i = 0; i < count; i++)
            {
                
                ConsoleWritter.WriteLine(sw.Elapsed.TotalSeconds + " seconds", ConsoleColor.DarkRed);
                ConsoleWritter.WriteLine("Blink: " + i);
                ConsoleWritter.WriteLine("Stones: " + stones.Count, ConsoleColor.Green);
                Console.WriteLine("=========================");
                

                if (count == 0)
                    return;

                var stoneList = new HashSet<Stone>(stones);

                foreach(var stone in stoneList)
                {
                    UpdateStones(stone);
                }
            }


        }
        /*
        public void Print(Stone? s)
        {
            if (s == null)
                Console.WriteLine("");
            else
            {
                Console.Write(s.Number + " ");
                Print(s.Next);
            }
        }*/

        public void UpdateStones(Stone s)
        {

            if (s.Number == 0)
            {
                s.Number = 1;
            }
            else if(int.IsEvenInteger(s.Number.NbDigits()))
            {

                (long num1, long num2) numbers = SplitNum(s.Number);

                Stone newStone1 = new(numbers.num1);
                Stone newStone2 = new(numbers.num2);

                stones.Add(newStone1);
                stones.Add(newStone2);
                stones.Remove(s);

            }
            else
            {
                s.Number = s.Number * 2024;
            }
        }

        public (long num1, long num2) SplitNum(long n)
        {
            string s = n.ToString();

            int center = s.Length / 2;

            string s1 = s[..center];
            string s2 = s[center..];

            return (long.Parse(s1), long.Parse(s2));

        }
    }

    public class Stone
    {
        public long Number { get; set; }
     
        public Stone(long num)
        {
            Number = num;
        }
    }
}
