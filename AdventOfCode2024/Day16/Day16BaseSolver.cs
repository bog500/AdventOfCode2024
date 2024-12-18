
using AdventOfCode2024.Common;
using System.Collections.Generic;
using System.Diagnostics;
using static AdventOfCode2024.Common.Enums;

namespace AdventOfCode2024.Day16
{
    public abstract class Day16BaseSolver : IPartSolver
    {
        protected HashSet<Coord> BestTiles = [];
        Stack<(Coord location, Direction dir, int score, HashSet<Coord> path)> ToExplore = [];
        public Dictionary<(Coord Location, Direction Direction), int> Scores = [];
        public Dictionary<Coord, bool> Maze = []; // true = wall
        public int BestScore = int.MaxValue;

        public Coord End;
        public Coord Start;

        public abstract string Solve(List<string> lines);

        public void CreateMaze(List<string> lines)
        {
            //reset
            BestTiles = [];
            Maze = [];
            Scores = [];
            BestScore = int.MaxValue;
            ToExplore = [];

            int y = 0;
            foreach(var line in lines)
            {
                int x = 0;
                foreach(char c in line)
                {
                    Coord coo = new(x, y);
                    if (c == '#')
                        Maze.Add(coo, true);
                    else if (c == '.')
                        Maze.Add(coo, false);
                    else if (c == 'S')
                    {
                        Maze.Add(coo, false);
                        Start = coo;
                    }
                    else if (c == 'E')
                    {
                        Maze.Add(coo, false);
                        End = coo;
                    }
                    else
                        throw new UnreachableException();

                    x++;
                }
                y++;
            }

            ToExplore.Push((Start, Direction.Right, 0, [Start]));
        }

        

        public void ExploreStack()
        {
            while(ToExplore.Count > 0)
            {
                var top = ToExplore.Pop();
                Coord location = top.location;
                Direction direction = top.dir;
                int score = top.score;
                HashSet<Coord> path = top.path;

                var ld = (location, direction);

                if (!Scores.ContainsKey(ld))
                    Scores.Add(ld, score);
                else if (Scores[ld] > score)
                    Scores[ld] = score; // new best score

                if (location == End)
                {
                    if (score < BestScore)
                    {
                        BestTiles = new(path);

                        BestScore = score;
                        Console.WriteLine($"Best score: {score}");
                    }
                    else if (score == BestScore)
                    {
                        foreach (var t in path)
                            BestTiles.Add(t);
                    }

                    continue; // end exploration
                }

                if (score > BestScore)
                    continue; // cancel exploration

                Coord nextLocation = direction switch
                {
                    Direction.Up => location.MoveUp(),
                    Direction.Down => location.MoveDown(),
                    Direction.Left => location.MoveLeft(),
                    Direction.Right => location.MoveRight(),
                    _ => throw new NotImplementedException()
                };

                if (CanVisit(nextLocation) && IsCheaper(nextLocation, direction, score + 1))
                {
                    HashSet<Coord> newPath = new(path);
                    newPath.Add(nextLocation);

                    var nextNode = (nextLocation, direction, score + 1, newPath);
                    ToExplore.Push(nextNode);
                }
                    

                var otherDirs = GetOtherDirections(location, direction);
                if (otherDirs is null)
                    continue;

                foreach (var otherDir in otherDirs)
                {
                    if (IsCheaper(location, otherDir, score + 1000))
                    {
                        var nextNode = (location, otherDir, score + 1000, path);
                        ToExplore.Push(nextNode);
                    }
                }

            }
        }

        protected bool IsCheaper(Coord location, Direction direction, int score)
        {
            if (!Scores.ContainsKey((location, direction)))
                return true; // never visited

            int previousScore = Scores[(location, direction)];
            if (previousScore > score-1)
                return true;

            return false;
        }

        protected IEnumerable<Direction> GetOtherDirections(Coord location, Direction direction)
        {
            switch(direction)
            {
                case Direction.Up:
                case Direction.Down:
                    if(CanVisit(location.MoveLeft()))
                        yield return Direction.Left;
                    if (CanVisit(location.MoveRight()))
                        yield return Direction.Right;
                    break;


                case Direction.Left:
                case Direction.Right:
                    if (CanVisit(location.MoveUp()))
                        yield return Direction.Up;
                    if (CanVisit(location.MoveDown()))
                        yield return Direction.Down;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        protected bool CanVisit(Coord location)
        {
            if (!Maze.ContainsKey(location)) // outside
                return false;

            if (Maze[location]) // wall
                return false;

            return true;
        }
    }
}
