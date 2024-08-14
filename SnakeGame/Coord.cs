namespace SnakeGame;

public struct Coord(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public readonly Coord ApplyMovementDirection(Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Coord(X, Y - 1),
            Direction.Down => new Coord(X, Y + 1),
            Direction.Left => new Coord(X - 1, Y),
            Direction.Right => new Coord(X + 1, Y),
            _ => this
        };
    }

    public override readonly bool Equals(object? obj)
    {
        if (obj is Coord other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

    public override readonly int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator == (Coord left, Coord right)
    {
        return left.Equals(right);
    }

    public static bool operator != (Coord left, Coord right)
    {
        return !(left == right);
    }
}