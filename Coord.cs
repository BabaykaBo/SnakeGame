namespace SnakeGame;

public class Coord(int x, int y)
{
    private int x = x;
    private int y = y;

     public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

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

    public void ApplyMovementDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                y--;
                break;
            case Direction.Down:
                y++;
                break;
            case Direction.Left:
                x--;
                break;
            case Direction.Right:
                x++;
                break;
        }
    }
}
