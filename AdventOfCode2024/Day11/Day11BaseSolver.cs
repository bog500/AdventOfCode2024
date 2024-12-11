
using AdventOfCode2024.Common;
using System.Collections.Generic;
using System.Numerics;

namespace AdventOfCode2024.Day11
{
    
    public abstract class Day11BaseSolver : IPartSolver
    {
        protected Stone? stone1;

        protected Dictionary<Stone, (Stone? previous, Stone? next)> stones = [];


        public abstract string Solve(List<string> lines);

        protected void CreateArrangement(string line)
        {
            Stone? previous = null;
            var values = Parser.ParseLong(line);
            foreach(var number in values)
            {
                Stone s = new(number);
                if (previous == null)
                {
                    stone1 = s;
                }
                else
                {
                    s.Previous = previous;
                    previous.Next = s;
                }
                previous = s;


            }
        }

        public int CountStones(Stone s)
        {
            if (s.Next is null)
                return 1;
            else
                return CountStones(s.Next) + 1;
        }

        public void Blink(int count)
        {
            for(int i = 0; i < count; i++)
            {
                //Console.WriteLine("=========================");
                //Print(stone1);

                if (count == 0)
                    return;
                Stone nextStone = stone1;

                while(nextStone is not null)
                {
                    nextStone = UpdateStones(nextStone);
                }
            }


        }

        public void Print(Stone? s)
        {
            if (s == null)
                Console.WriteLine("");
            else
            {
                Console.Write(s.Number + " ");
                Print(s.Next);
            }
        }

        public Stone? UpdateStones(Stone s)
        {
            Stone? nextStone = s.Next;

            if ( s.Number == 0)
            {
                s.Number = 1;
            }
            else if(int.IsEvenInteger(s.Number.NbDigits()))
            {
                Stone? previous = s.Previous;
                Stone? next = s.Next;

                (long num1, long num2) numbers = SplitNum(s.Number);

                Stone newStone1 = new(numbers.num1);
                Stone newStone2 = new(numbers.num2);

                // update links

                if (previous is null)
                    stone1 = newStone1;
                else
                    previous.Next = newStone1;

                newStone1.Previous = previous;
                newStone1.Next = newStone2;

                newStone2.Previous = newStone1;
                newStone2.Next = next;

                if (next is not null)
                    next.Previous = newStone2;

                nextStone = next;

            }
            else
            {
                s.Number = s.Number * 2024;
            }

            return nextStone;
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

        public Stone? Previous { get; set; }
        public Stone? Next { get; set; }
     
        public Stone(long num)
        {
            Number = num;
        }
    }
}
