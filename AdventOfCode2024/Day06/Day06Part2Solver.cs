using AdventOfCode2024.Common;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day06
{

    public class Day06Part2Solver : Day06BaseSolver
    {

        public override string Solve(List<string> lines)
        {
            CreateMap(lines);

            Coord startPosition = guardPosition;

            var routePosition = GetVisited();
            routePosition.Remove(startPosition);

            int loopCount = 0;

            foreach (Coord c in routePosition)
            {
                guardPosition = startPosition;
                guardDirection = Enums.Direction.Up;

                // place obstacle
                map[c] = true;

                if (IsLoop())
                    loopCount++;

                // reset
                map[c] = false;

            }
            return loopCount.ToString();
        }

        private bool IsLoop()
        {
            HashSet<(Coord coord, Enums.Direction dir)> visited = [];

            while (IsInMap(guardPosition) && !visited.Contains((guardPosition, guardDirection)))
            {
                visited.Add((guardPosition, guardDirection));


                var nextStep = NextStep(guardPosition, guardDirection);

                guardPosition = nextStep.position;
                guardDirection = nextStep.direction;
            }

            return IsInMap(guardPosition);
        }
    }
}
