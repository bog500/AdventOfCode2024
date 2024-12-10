
using AdventOfCode2024.Common;
using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode2024.Day10
{
    public abstract class Day10BaseSolver : IPartSolver
    {
        HashSet<Coord> starts = [];
        Dictionary<Coord, int> map = [];

        Dictionary<Coord, HashSet<Coord>> visited = [];
        Dictionary<Coord, HashSet<Coord>> submitVisited = [];

        int mapMaxX = 0;
        int mapMaxY = 0;

        public abstract string Solve(List<string> lines);

        protected void CreateMap(List<string> lines)
        {
            
            // create map
            int y = 0;
            foreach (string line in lines)
            {
                int x = 0;
                foreach (char c in line)
                {
                    Coord coo = new Coord(x, y);

                    if (c == '0')
                        starts.Add(coo);

                    map.Add(coo, Parser.CharToInt(c));
                    x++;
                }
                y++;
                mapMaxX = x;
                mapMaxY = y;
            }

            // init visited dictionaries
            foreach(Coord start in starts)
            {
                visited.Add(start, []);
                submitVisited.Add(start, []);
            }
        }

        protected void ExploreStart()
        {
            foreach (Coord start in starts)
            {
                Explore(start, start);
            }
        }

        protected long GetScore()
        {
            long sum = 0;
            foreach (Coord start in starts)
            {
                int score = submitVisited[start].Count;
                sum += score;
            }

            //bad : 6395800119709

            return sum;
        }

        protected void Explore(Coord startLocation, Coord fromLocation)
        {
            if (GetHeight(fromLocation) == 9)
                submitVisited[startLocation].Add(fromLocation);

            visited[startLocation].Add(fromLocation);

            var coords = FindNextCoords(fromLocation);
            foreach(var c in coords)
            {
                if (visited[startLocation].Contains(c))
                    continue;

                Explore(startLocation, c);
            }
        }

        protected int GetHeight(Coord c)
        {
            if (map.TryGetValue(c, out int height))
                return height;
            return -1;
        }

        protected IEnumerable<Coord> FindNextCoords(Coord fromLocation)
        {
            int currentHeight = GetHeight(fromLocation);

            int left = GetHeight(fromLocation.MoveLeft());
            int right = GetHeight(fromLocation.MoveRight());
            int up = GetHeight(fromLocation.MoveTop());
            int down = GetHeight(fromLocation.MoveBottom());

            if (left - currentHeight == 1)
                yield return fromLocation.MoveLeft();

            if (right - currentHeight == 1)
                yield return fromLocation.MoveRight();

            if (up - currentHeight == 1)
                yield return fromLocation.MoveTop();

            if (down - currentHeight == 1)
                yield return fromLocation.MoveBottom();

        }
    }
}
