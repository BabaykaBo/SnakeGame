using SnakeGame;

Console.CursorVisible = false;

Coord gridDimensions = new(50, 20);
Coord snakePos = new(10, 2);

Random rand = new();
Coord applePos = new(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));

int frameDelayMilSec = 200;
Direction movementDirection = Direction.Down;

int score = 0;

List<Coord> snakePosHistory = [];
int tailLength = 1;

bool runGame = true;

while (runGame)
{
    Console.Clear();
    Console.WriteLine($"Score: {score}");

    snakePos.ApplyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {
        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new(x, y);

            if (snakePos.Equals(currentCoord) || snakePosHistory.Contains(currentCoord))
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

    if (snakePos.Equals(applePos))
    {
        tailLength++;
        score++;
        applePos = new(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
    }
    else if (snakePosHistory.Contains(snakePos))
    {
        runGame = false;
    }
    
    if (snakePos.X == 0)
    {
        snakePos.X = gridDimensions.X - 2;
        movementDirection = Direction.Left;
    }
    else if (snakePos.X == gridDimensions.X - 1)
    {
        snakePos.X = 1;
        movementDirection = Direction.Right;
    }
    else if (snakePos.Y == 0)
    {
        snakePos.Y = gridDimensions.Y - 2;
        movementDirection = Direction.Up;
    }
    else if (snakePos.Y == gridDimensions.Y - 1)
    {
        snakePos.Y = 1;
        movementDirection = Direction.Down;
    }

    snakePosHistory.Add(new Coord(snakePos.X, snakePos.Y));

    if (snakePosHistory.Count > tailLength)
    {
        snakePosHistory.RemoveAt(0);
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
                    if (movementDirection != Direction.Down) movementDirection = Direction.Up;  
                    break;
                case ConsoleKey.DownArrow:
                    if (movementDirection != Direction.Up) movementDirection = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    if (movementDirection != Direction.Right) movementDirection = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    if (movementDirection != Direction.Left) movementDirection = Direction.Right;
                    break;
            }
        }
    }
}

Console.WriteLine("");
Console.WriteLine("Game over...");
Console.CursorVisible = true;
