
using AdventOfCode2024.Common;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace AdventOfCode2024.Day08
{
    public abstract class Day08BaseSolver : IPartSolver
    {
        public abstract string Solve(List<string> lines);

        protected Dictionary<Coord, char> map = [];

        protected abstract int MaxCheck { get; }
        protected abstract int MinCheck { get; }

        protected Dictionary<char, HashSet<Coord>> antennas = [];
        protected HashSet<Coord> antinodes = [];

        protected int mapMaxY = 0;
        protected int mapMaxX = 0;

        protected void CreateMap(List<string> lines)
        {
            int y = 0;
            foreach (string line in lines)
            {
                int x = 0;
                foreach (char freq in line)
                {
                    Coord c = new Coord(x, y);

                    //general map
                    map.Add(c, freq);

                    if (freq != '.')
                        AddToAntennas(freq, c);
                    x++;
                }
                y++;
                mapMaxX = x;
                mapMaxY = y;
            }
        }



        protected void CalculateAntinodes()
        {
            foreach(var pair in antennas)
            {
                char freq = pair.Key;
                foreach(Coord c1 in pair.Value)
                {
                    foreach (Coord c2 in pair.Value)
                    {
                        if (c1 == c2)
                            continue;


                        for (int i = MinCheck; i < MaxCheck; i++)
                        {
                            int distX = Math.Abs(c2.X - c1.X) * i;
                            int distY = Math.Abs(c2.Y - c1.Y) * i;


                            Coord antinode = (c1.X < c2.X, c1.Y < c2.Y) switch
                            {
                                (true, true) => new(c1.X - distX, c1.Y - distY),
                                (false, false) => new(c1.X + distX, c1.Y + distY),

                                (true, false) => new(c1.X - distX, c1.Y + distY),
                                (false, true) => new(c1.X + distX, c1.Y - distY),
                            };

                            if (map.ContainsKey(antinode))
                                antinodes.Add(antinode);
                        }


                    }
                }
            }
        }

        protected void Print()
        {
            Console.WriteLine("=================");

            for (int y = 0; y < mapMaxY; y++)
            {
                for (int x = 0; x < mapMaxX; x++)
                {
                    Coord c = new(x, y);
                    if (antinodes.Contains(c))
                        Console.Write("#");
                    else
                        Console.Write(map[c]);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("=================");
        }

        private void AddToAntennas(char frequency, Coord c)
        {
            if (antennas.ContainsKey(frequency))
                antennas[frequency].Add(c);
            else
                antennas.Add(frequency, [c]);
        }

    }
}
