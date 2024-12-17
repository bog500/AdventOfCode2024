
using AdventOfCode2024.Common;
using System.Collections.Generic;

namespace AdventOfCode2024.Day15
{
    public abstract class Day15BaseSolver : IPartSolver
    {

        Dictionary<Coord, MazeObject> map = [];
        public List<Box> Boxes = [];
        public List<char> Instructions = [];
        public Robot Robot;


        public abstract string Solve(List<string> lines);

        public void CreateMap(List<string> lines)
        {
            int y = 0;
            foreach (var line in lines)
            {
                if (line.Contains('#'))
                {
                    // create map
                    int x = 0;
                    foreach (var c in line)
                    {
                        Coord coo = new(x, y);
                        switch (c)
                        {
                            case '#':
                                Wall w = new(map, coo);
                                map[coo] = w;
                                break;
                            case 'O':
                                Box b = new(map, coo);
                                map[coo] = b;
                                Boxes.Add(b);
                                break;
                            case '@':
                                Robot r = new(map, coo);
                                map[coo] = r;
                                this.Robot = r;
                                break;
                            default:
                                break;
                        }
                        x++;
                    }
                }
                else
                {

                    // create instructions
                    foreach (var c in line)
                    {
                        if (c == '<' || c == '>' || c == '^' || c == 'v')
                            Instructions.Add(c);
                    }
                }
                y++;
            }
        }
    }

    public abstract class MazeObject
    {
        protected Coord location;
        protected Dictionary<Coord, MazeObject> map;

        public MazeObject(Dictionary<Coord, MazeObject> map, Coord location)
        {
            this.map = map;
            this.location = location;
        }

        public abstract bool CanMoveLeft();
        public abstract bool CanMoveRight();
        public abstract bool CanMoveUp();
        public abstract bool CanMoveDown();

        public long GpsScore()
        {
            return 100 * this.location.Y + this.location.X;
        }

    }

    public abstract class MovableMazeObject : MazeObject
    {
        protected MovableMazeObject(Dictionary<Coord, MazeObject> map, Coord location) : base(map, location)
        {
        }

        public void MoveLeft()
        {
            if(!map.ContainsKey(this.location.MoveLeft()))
            {
                // space is empty, just move
                map.Remove(this.location);
                map.Add(this.location.MoveLeft(), this);
                this.location = this.location.MoveLeft();
                return;
            }
            
            if(CanMoveLeft())
            {
                var dest = map[this.location.MoveLeft()] as MovableMazeObject;
                if (dest is null)
                    return;

                dest.MoveLeft();
                map.Remove(this.location);
                map.Add(this.location.MoveLeft(), this);
                this.location = this.location.MoveLeft();
            }
        }

        public void MoveRight()
        {
            if (!map.ContainsKey(this.location.MoveRight()))
            {
                // space is empty, just move
                map.Remove(this.location);
                map.Add(this.location.MoveRight(), this);
                this.location = this.location.MoveRight();
                return;
            }

            if (CanMoveRight())
            {
                var dest = map[this.location.MoveRight()] as MovableMazeObject;
                if (dest is null)
                    return;

                dest.MoveRight();
                map.Remove(this.location);
                map.Add(this.location.MoveRight(), this);
                this.location = this.location.MoveRight();
            }
        }

        public void MoveUp()
        {
            if (!map.ContainsKey(this.location.MoveUp()))
            {
                // space is empty, just move
                map.Remove(this.location);
                map.Add(this.location.MoveUp(), this);
                this.location = this.location.MoveUp();
                return;
            }

            if (CanMoveUp())
            {
                var dest = map[this.location.MoveUp()] as MovableMazeObject;
                if (dest is null)
                    return;

                dest.MoveUp();
                map.Remove(this.location);
                map.Add(this.location.MoveUp(), this);
                this.location = this.location.MoveUp();
            }
        }

        public void MoveDown()
        {
            if (!map.ContainsKey(this.location.MoveDown()))
            {
                // space is empty, just move
                map.Remove(this.location);
                map.Add(this.location.MoveDown(), this);
                this.location = this.location.MoveDown();
                return;
            }

            if (CanMoveDown())
            {
                var dest = map[this.location.MoveDown()] as MovableMazeObject;
                if (dest is null)
                    return;

                dest.MoveDown();
                map.Remove(this.location);
                map.Add(this.location.MoveDown(), this);
                this.location = this.location.MoveDown();
            }
        }


        public override bool CanMoveDown()
        {
            if (!map.ContainsKey(this.location.MoveDown()))
                return true;
            return map[this.location.MoveDown()].CanMoveDown();
        }

        public override bool CanMoveLeft()
        {
            if (!map.ContainsKey(this.location.MoveLeft()))
                return true;
            return map[this.location.MoveLeft()].CanMoveLeft();
        }

        public override bool CanMoveRight()
        {
            if (!map.ContainsKey(this.location.MoveRight()))
                return true;
            return map[this.location.MoveRight()].CanMoveRight();
        }

        public override bool CanMoveUp()
        {
            if (!map.ContainsKey(this.location.MoveUp()))
                return true;
            return map[this.location.MoveUp()].CanMoveUp();
        }
    }

    public class Robot : MovableMazeObject
    {
        public Robot(Dictionary<Coord, MazeObject> map, Coord location) : base(map, location)
        {
        }
    }

    public class Box : MovableMazeObject
    {
        public Box(Dictionary<Coord, MazeObject> map, Coord location) : base(map, location)
        {
        }
    }

    public class Wall : MazeObject
    {
        public Wall(Dictionary<Coord, MazeObject> map, Coord location) : base(map, location)
        {
        }

        public override bool CanMoveDown() => false;

        public override bool CanMoveLeft() => false;

        public override bool CanMoveRight() => false;

        public override bool CanMoveUp() => false;
    }

}