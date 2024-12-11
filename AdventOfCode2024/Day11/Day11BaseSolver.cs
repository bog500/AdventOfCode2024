
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
                stones.Add(s, (null, null));

                if (previous == null)
                {
                    stone1 = s;
                }
                else
                {
                    SetPrevious(s, previous);
                    SetNext(previous, s);
                }
                previous = s;
            }
        }



        public void SetPrevious(Stone s, Stone? previous)
        {
            if (!stones.ContainsKey(s))
                stones.Add(s, (previous, null));
            else
                stones[s] = (previous, stones[s].next);
        }

        public void SetNext(Stone s, Stone? next)
        {
            if (!stones.ContainsKey(s))
                stones.Add(s, (null, next));
            else
                stones[s] = (stones[s].previous, next);
        }

        public int CountStones(Stone s)
        {
            if (stones[s].next is null)
                return 1;
            else
                return CountStones(stones[s].next) + 1;
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

        public Stone? UpdateStones(Stone s)
        {
            Stone? nextStone = stones[s].next;

            if ( s.Number == 0)
            {
                s.Number = 1;
            }
            else if(int.IsEvenInteger(s.Number.NbDigits()))
            {
                Stone? previous = stones[s].previous;
                Stone? next = stones[s].next;

                (long num1, long num2) numbers = SplitNum(s.Number);

                Stone newStone1 = new(numbers.num1);
                Stone newStone2 = new(numbers.num2);

                // update links

                if (previous is null)
                {
                    stones.Remove(stone1);
                    stone1 = newStone1;
                }
                else
                {
                    SetNext(previous, newStone1);
                }
                    

                SetPrevious(newStone1, previous);
                SetNext(newStone1, newStone2);

                SetPrevious(newStone2, newStone1);
                SetNext(newStone2, next);

                if (next is not null)
                    SetPrevious(next, newStone2);

                nextStone = next;

                stones.Remove(s);

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
     
        public Stone(long num)
        {
            Number = num;
        }
    }
}
