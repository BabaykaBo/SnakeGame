namespace SnakeGame;

public class Coord(int x, int y)
{
    private int x = x;
    private int y = y;

    public int X { get => x;  }
    public int Y { get => y;  }

    public override bool Equals(object? obj)
    {
        if (obj == null || !GetType().Equals(obj.GetType()))
        {
            return false;
        }

        Coord coord = (Coord)obj;
        return coord.X == x && coord.Y == y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}
