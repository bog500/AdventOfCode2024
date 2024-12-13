
using AdventOfCode2024.Common;
using System.Collections.Generic;

namespace AdventOfCode2024.Day06
{
    public abstract class Day06BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected void CreateMap(List<string> lines)
        {
            int y = 0;
            foreach(string line in lines)
            {
                int x = 0;
                foreach(char c in line)
                {
                    Coord coo = new Coord(x, y);
                    map.Add(coo, c == '#');
                    if (c == '^')
                        guardPosition = coo;
                    x++;
                }
                y++;
                mapMaxX = x;
                mapMaxY = y;
            }
        }

        protected (Coord position, Enums.Direction direction) NextStep(Coord position, Enums.Direction dir)
        {
            return dir switch
            {
                Enums.Direction.Down => IsObstacle(position.MoveDown()) ? NextStep(position, Enums.Direction.Left) : (position.MoveDown(), Enums.Direction.Down),
                Enums.Direction.Left => IsObstacle(position.MoveLeft()) ? NextStep(position, Enums.Direction.Up) : (position.MoveLeft(), Enums.Direction.Left),
                Enums.Direction.Up => IsObstacle(position.MoveUp()) ? NextStep(position, Enums.Direction.Right) : (position.MoveUp(), Enums.Direction.Up),
                Enums.Direction.Right => IsObstacle(position.MoveRight()) ? NextStep(position, Enums.Direction.Down) : (position.MoveRight(), Enums.Direction.Right),
            };
        }

        protected void Print()
        {
            Console.WriteLine("=== MAP ===");
            for (int y = 0; y < mapMaxY; y++)
            {
                for (int x = 0; x < mapMaxX; x++)
                {
                    Coord c = new(x, y);
                    if(guardPosition == c)
                    {
                        char g = guardDirection switch
                        {
                            Enums.Direction.Up => '^',
                            Enums.Direction.Down => 'v',
                            Enums.Direction.Right => '>',
                            Enums.Direction.Left => '<',
                        };
                        Console.Write(g);
                    }
                    else if(IsObstacle(c))
                    {
                        Console.Write('#');
                    }
                    else
                    {
                        Console.Write('.');
                    }
                }
                Console.Write('\n');
            }
            Console.WriteLine("==========");
        }

        protected bool IsInMap(Coord c)
        {
            return map.ContainsKey(c);
        }

        protected bool IsObstacle(Coord c)
        {
            if (!IsInMap(c))
                return false;
            return map[c];
        }

        protected int mapMaxY = 0;
        protected int mapMaxX = 0;

        protected Enums.Direction guardDirection = Enums.Direction.Up;

        protected Coord guardPosition = new();

        //true = obstacle
        protected Dictionary<Coord, bool> map = [];

        protected HashSet<Coord> GetVisited()
        {
            HashSet<Coord> visited = [];

            while (IsInMap(guardPosition))
            {
                visited.Add(guardPosition);

                var nextStep = NextStep(guardPosition, guardDirection);

                guardPosition = nextStep.position;
                guardDirection = nextStep.direction;
            }

            return visited;
        }
    }
}
