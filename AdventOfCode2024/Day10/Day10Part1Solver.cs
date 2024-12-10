using AdventOfCode2024.Common;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day10
{

    public class Day10Part1Solver : Day10BaseSolver
    {
        Dictionary<Coord, HashSet<Coord>> visited = [];
        Dictionary<Coord, HashSet<Coord>> submitVisited = [];

        public override string Solve(List<string> lines)
        {
            CreateMap(lines);
            Init();
            ExploreStart();
            var score = GetScore();
            return score + "";

        }

        protected void Init()
        {
            // init visited dictionaries
            foreach (Coord start in starts)
            {
                visited.Add(start, []);
                submitVisited.Add(start, []);
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
            return sum;
        }

        protected void ExploreStart()
        {
            foreach (Coord start in starts)
            {
                Explore(start, start);
            }
        }

        protected void Explore(Coord startLocation, Coord fromLocation)
        {
            if (GetHeight(fromLocation) == 9)
                submitVisited[startLocation].Add(fromLocation);

            visited[startLocation].Add(fromLocation);

            var coords = FindNextCoords(fromLocation);
            foreach (var c in coords)
            {
                if (visited[startLocation].Contains(c))
                    continue;

                Explore(startLocation, c);
            }
        }

    }
}
