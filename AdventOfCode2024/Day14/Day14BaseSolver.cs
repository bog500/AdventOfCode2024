
using AdventOfCode2024.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AdventOfCode2024.Day14
{
    public abstract class Day14BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected (int maxX, int maxY) maximums;

        public List<Robot> GetRobots(List<string> lines)
        {
            maximums = ParseSize(lines[0]);

            List<Robot> robots = [];

            foreach(var line in lines.Skip(1))
            {
                Robot r = Robot.Create(line, maximums.maxX, maximums.maxY);
                robots.Add(r);
            }
            return robots;
        }

        public (int maxX, int maxY) ParseSize(string s)
        {
            var values = Parser.ParseInt(s, 'x');

            var result = (values[0] - 1, values[1] - 1);

            return result;
        }

        public int GetSafertyFactor(List<Robot> robots)
        {
            var cadrans = new Dictionary<int, int>()
            {
                [-1] = 0,
                [0] = 0,
                [1] = 0,
                [2] = 0,
                [3] = 0,
            };

            foreach(var r in robots)
            {
                int cadran = r.GetCadran();
                cadrans[cadran] = cadrans[cadran] + 1;
            }

            int sum = cadrans[0] * cadrans[1] * cadrans[2] * cadrans[3];

            return sum;
        }
    }

    public class Robot
    {
        private readonly int maxX;
        private readonly int maxY;

        private Robot(int maxX, int maxY, int locationX, int locationY, int velocityX, int velocityY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.Location = new(locationX, locationY);
            this.Velocity = new(velocityX, velocityY);
        }

        public static Robot Create(string s, int maxX, int maxY)
        {
            var values = Parser.ParseInt(s.Replace("p=", "").Replace(" v=", ","), ',');
            Robot r = new(maxX, maxY, values[0], values[1], values[2], values[3]);
            return r;
        }

        public Coord Location { get; private set; }
        public Coord Velocity { get; private set; }

        /// <summary>
        /// Get cadran number 0,1,2,3 (or -1 on the edge)
        /// </summary>
        /// <returns></returns>
        public int GetCadran()
        {
            //  #############   #############
            //  #           #   #           #
            //  #     0     #   #     1     #
            //  #           #   #           #
            //  #############   #############
            //
            //  #############   #############
            //  #           #   #           #
            //  #     2     #   #     3     #
            //  #           #   #           #
            //  #############   #############

            int middleX = maxX / 2;
            int middleY = maxY / 2;

            if (this.Location.X == middleX || this.Location.Y == middleY)
                return -1;

            if (this.Location.X < middleX && this.Location.Y < middleY)
                return 0;

            if (this.Location.X > middleX && this.Location.Y < middleY)
                return 1;

            if (this.Location.X < middleX && this.Location.Y > middleY)
                return 2;

            if (this.Location.X > middleX && this.Location.Y > middleY)
                return 3;

            throw new UnreachableException();
        }

        public void Move()
        {
            int newLocationX = this.Location.X + this.Velocity.X;
            int newLocationY = this.Location.Y + this.Velocity.Y;

            if (newLocationX >= maxX)
                newLocationX = newLocationX - 1 - maxX;

            if (newLocationY >= maxY)
                newLocationY = newLocationY - 1 - maxY;

            if (newLocationX < 0)
                newLocationX = newLocationX + 1 + maxX;

            if (newLocationY < 0)
                newLocationY = newLocationY + 1 + maxY;

            this.Location = new(newLocationX, newLocationY);
        }
    }
}
