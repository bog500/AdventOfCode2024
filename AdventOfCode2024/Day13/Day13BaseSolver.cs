
using AdventOfCode2024.Common;
using System.Collections.Generic;

namespace AdventOfCode2024.Day13
{
    public abstract class Day13BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        public List<Game> CreateGames(List<string> lines)
        {
            List<Game> games = [];

            for(int i = 0; i < (lines.Count+1) / 4; i ++)
            {
                Game g = Game.CreateGame(lines.Skip(i*4).Take(3).ToArray());
                games.Add(g);
            }

            return games;
        }

        public (long PressA, long PressB)? PlayBruteForce(Game g)
        {
            for(long pressA = 0; pressA <= 100; pressA++)
            {
                for (long pressB = 0; pressB <= 100; pressB++)
                {
                    if(pressA * g.ButtonA.X + pressB * g.ButtonB.X == g.Price.X)
                    {
                        if (pressA * g.ButtonA.Y + pressB * g.ButtonB.Y == g.Price.Y)
                        {
                            return (pressA, pressB);
                        }
                    }
                }
            }
            return null;
        }


        public (long PressA, long PressB)? PlayMath(Game g)
        {
            
            double b = ((double)g.Price.Y * (double)g.ButtonA.X - (double)g.Price.X * (double)g.ButtonA.Y)
                    / ((double)g.ButtonB.Y * (double)g.ButtonA.X - (double)g.ButtonB.X * (double)g.ButtonA.Y);

            if (b % 1 != 0)
                return null;

            double a = ((double)g.Price.X - b * (double)g.ButtonB.X) / (double)g.ButtonA.X;
            
            if (a % 1 != 0)
                return null;

            return new((long)a, (long)b);
        }

        public double GetSum(List<Game> games)
        {
            double sum = 0;
            int winningGames = 0;

            foreach (var g in games)
            {
                var result = PlayMath(g);
                if (result is null)
                    continue;
                double partial = (double)result.Value.PressA * 3 + (double)result.Value.PressB;
                sum += partial;
                winningGames++;
            }

            return sum;
        }
    }



    public class Game
    {
        public static Game CreateGame(string[] lines)
        {
            Game g = new();

            var l1 = lines[0].Replace("Button A: X+", "").Replace(" Y+", "").Split(',');
            var l2 = lines[1].Replace("Button B: X+", "").Replace(" Y+", "").Split(',');
            var l3 = lines[2].Replace("Prize: X=", "").Replace("Y=", "").Split(',');

            g.ButtonA = new(int.Parse(l1[0]), int.Parse(l1[1]));
            g.ButtonB = new(int.Parse(l2[0]), int.Parse(l2[1]));
            g.Price = new(int.Parse(l3[0]), int.Parse(l3[1]));

            return g;
        }

        internal void AddToPrice(long v)
        {
            Price = new(Price.X + v, Price.Y + v);
        }

        public CoordL ButtonA { get; private set; }

        public CoordL ButtonB { get; private set; }

        public CoordL Price { get; private set; }
    }
}
