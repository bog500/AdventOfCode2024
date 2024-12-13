
using AdventOfCode2024.Common;
using System.Collections.Generic;

namespace AdventOfCode2024.Day12
{
    public abstract class Day12BaseSolver : IPartSolver
    {
        Dictionary<Coord, (char Code, bool InRegion)> map = [];
        protected int mapMaxX = 0;
        protected int mapMaxY = 0;

        List<Region> regions = [];

        public abstract string Solve(List<string> lines);

        protected void CreateMap(List<string> lines)
        {
            int y = 0;
            foreach (string line in lines)
            {
                int x = 0;
                foreach (char c in line)
                {
                    Coord coo = new Coord(x, y);
                    map.Add(coo, (Code: c, InRegion: false));
                    x++;
                }
                y++;
                mapMaxX = x;
                mapMaxY = y;
            }
        }

        protected void CreateRegions()
        {
            foreach(var mapPosition in map)
            {
                if (mapPosition.Value.InRegion)
                    continue;

                Region region = new(mapPosition.Value.Code);
                regions.Add(region);
                AddTileToRegion(region, mapPosition.Key);

                CreateRegion(mapPosition.Key, region);

            }
        }

        protected void CreateRegion(Coord fromCoord, Region region)
        {
            foreach(var newCoord in fromCoord.MoveAll4())
            {
                if (!map.ContainsKey(newCoord))
                    continue; // not in the map!

                if (map[newCoord].InRegion)
                    continue; // already in a region

                if (map[newCoord].Code != region.Code)
                    continue; // not the same code

                AddTileToRegion(region, newCoord);
                CreateRegion(newCoord, region);
            }
        }

        public int GetTotalPriceWithPerimeter()
        {
            int sum = 0;
            foreach(var r in regions)
            {
                sum += r.PerimeterPrice;
            }
            return sum;
        }

        public int GetTotalPriceWithSides()
        {
            int sum = 0;
            foreach (var r in regions)
            {
                sum += r.SidePrice;
            }
            return sum;
        }

        public bool AddTileToRegion(Region r, Coord c)
        {
            if (r.Tiles.Contains(c))
                return false;

            map[c] = (map[c].Code, true); // set InRegion = true
            r.Tiles.Add(c);

            //adjust perimeter
            if (r.Tiles.Count == 1)
            {
                r.Perimeter = 4;
            }
            else
            {
                int nbNeighbors = 0;
                foreach (var neighborCoord in c.MoveAll4())
                {
                    if(r.Tiles.Contains(neighborCoord))
                    {
                        nbNeighbors++;
                    }
                }
                r.Perimeter = nbNeighbors switch
                {
                    1 => r.Perimeter + 2,
                    2 => r.Perimeter,
                    3 => r.Perimeter - 2,
                    4 => r.Perimeter - 4,
                };
            }
            return true;
        }
    }

    public class Region
    {
        public Region(char c)
        {
            this.Code = c;
        }

        public char Code { get; set; }
        public HashSet<Coord> Tiles { get; set; } = [];

        public int Perimeter { get; set; } = 0;

        public int Sides { get; set; } = 0;

        public int Area => this.Tiles.Count;

        public int PerimeterPrice => Perimeter * Area;
        public int SidePrice => Sides * Area;
    }
}
