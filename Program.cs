using SnakeGame;

Coord gridDimensions = new(50, 20);
Coord snakePos = new(10, 2);

Random rand = new();
Coord applePos = new(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));

int frameDelayMilSec = 100;

Console.CursorVisible = false;

Direction movementDirection = Direction.Down;

while (true)
{
    Console.Clear();
    snakePos.ApplyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new(x, y);

            if (snakePos.Equals(currentCoord))
            {
                Console.Write("■");
            }
            else if (applePos.Equals(currentCoord))
            {
                Console.Write("●");
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

    DateTime time = DateTime.Now;

    while((DateTime.Now - time).Milliseconds < frameDelayMilSec)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
            }
        }
    }
}

// Console.CursorVisible = true;
