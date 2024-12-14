namespace AdventOfCode2024.Common
{
    public struct CoordL(long x, long y)
    {
        public long X => x;
        public long Y => y;
    }

    public struct Coord(int x, int y) : IComparable, IEquatable<Coord>
    {
        public int X => x;
        public int Y => y;

        public int CompareTo(object? obj)
        {
            if (obj is not Coord)
                return -1;

            Coord coord2 = (Coord)obj;

            if (this.X != coord2.X)
                return this.X.CompareTo(coord2.X);

            if (this.Y != coord2.Y)
                return this.Y.CompareTo(coord2.Y);

            return 0;
        }

        public bool Equals(Coord other)
        {
            return this == other;
        }

        public static bool operator == (Coord a, Coord b) => a.X == b.X && a.Y == b.Y;
        public static bool operator != (Coord a, Coord b) => !(a == b);

        // move in straight lines
        public Coord MoveRight() => new Coord(this.X + 1, this.Y);
        public Coord MoveDown() => new Coord(this.X, this.Y + 1);
        public Coord MoveLeft() => new Coord(this.X - 1, this.Y);
        public Coord MoveUp() => new Coord(this.X, this.Y - 1);

        // move in diagonal
        public Coord MoveUpLeft() => this.MoveUp().MoveLeft();
        public Coord MoveUpRight() => this.MoveUp().MoveRight();
        public Coord MoveDownLeft() => this.MoveDown().MoveLeft();
        public Coord MoveDownRight() => this.MoveDown().MoveRight();

        // enumerables of moves
        public IEnumerable<Coord> MoveAll4() => [MoveRight(), MoveDown(), MoveLeft(), MoveUp()];
        public IEnumerable<Coord> MoveAll4Diag() => [MoveUpLeft(), MoveUpRight(), MoveDownLeft(), MoveDownRight()];
        public IEnumerable<Coord> MoveAll8() => [.. MoveAll4(), .. MoveAll4Diag()];
    }

    public struct Coord3D(int x, int y, int z)
    {
        public int X => x;
        public int Y => y;
        public int Z => z;

        public static bool operator ==(Coord3D a, Coord3D b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        public static bool operator !=(Coord3D a, Coord3D b) => !(a == b);
    }

    
}
