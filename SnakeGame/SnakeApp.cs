using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakeApp
    {
        public Coord GridDimensions { get; set; }
        public Snake Snake { get; set; }
        public Apple Apple { get; set; }
        public int Score { get; private set; }
        public int FrameDelayMilSec { get; set; } = 200;

        private bool runGame = true;

        public SnakeApp(int width, int height)
        {
            GridDimensions = new Coord(width, height);
            Snake = new Snake(new Coord(10, 2));
            Apple = new Apple(GridDimensions);
        }

        public void Run()
        {
            Console.CursorVisible = false;

            while (runGame)
            {
                Draw();
                HandleInput();
                Update();
                System.Threading.Thread.Sleep(FrameDelayMilSec);
            }

            Console.WriteLine("\nGame over...");
            Console.CursorVisible = true;
        }

        private void Draw()
        {
            Console.Clear();
            Console.WriteLine($"Score: {Score}");

            for (int y = 0; y < GridDimensions.Y; y++)
            {
                for (int x = 0; x < GridDimensions.X; x++)
                {
                    Coord currentCoord = new(x, y);

                    if (Snake.IsOccupying(currentCoord))
                    {
                        Console.Write("■");
                    }
                    else if (Apple.Position.Equals(currentCoord))
                    {
                        Console.Write("●");
                    }
                    else if (x == 0 || y == 0 || x == GridDimensions.X - 1 || y == GridDimensions.Y - 1)
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
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        Snake.ChangeDirection(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Snake.ChangeDirection(Direction.Down);
                        break;
                    case ConsoleKey.LeftArrow:
                        Snake.ChangeDirection(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        Snake.ChangeDirection(Direction.Right);
                        break;
                }
            }
        }

        private void Update()
        {
            Snake.Move(GridDimensions);

            if (Snake.Head.Equals(Apple.Position))
            {
                Snake.Grow();
                Score++;
                Apple.Reposition(GridDimensions);
            }

            if (Snake.HasCollidedWithSelf())
            {
                runGame = false;
            }
        }
    }
}