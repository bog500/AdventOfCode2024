using AdventOfCode2024.Common;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day10
{

    public class Day10Part2Solver : Day10BaseSolver
    {
        Dictionary<Coord, HashSet<List<Coord>>> paths = [];

        public override string Solve(List<string> lines)
        {
            CreateMap(lines);
            Init();
            ExploreStart();
            var score = GetRating();
            return score + "";

        }

        private long GetRating()
        {
            long sum = 0;
            foreach (Coord start in starts)
            {
                int score = paths[start].Count;
                sum += score;
            }
            return sum;
        }

        protected void Init()
        {
            // init visited dictionaries
            foreach (Coord start in starts)
            {
                paths.Add(start, []);
            }
        }

        protected void ExploreStart()
        {
            foreach (Coord start in starts)
            {
                Explore(start, start,[]);
            }
        }

        protected void Explore(Coord start, Coord location, List<Coord> path)
        {
            path.Add(location);

            if(GetHeight(location) == 9)
            {
                paths[start].Add(path);
                return;
            }

            var coords = FindNextCoords(location);
            foreach (var c in coords)
            {
                Explore(start, c, new(path));
            }
        }
    }
}
