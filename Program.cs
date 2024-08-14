using SnakeGame;

Coord gridDimensions = new(50, 20);
Coord snakePos = new(10,0);

for (int y = 0; y < gridDimensions.Y; y++)
{
    for (int x = 0; x < gridDimensions.X; x++)
    {
        Coord currentCoord = new(x, y);
        
        if (snakePos.Equals(currentCoord))
        {
            Console.Write("■");
        }
        else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
        {
            Console.Write("#");
        }
        else
        {
            Console.Write(" ");
        }
    }
    Console.WriteLine();
}