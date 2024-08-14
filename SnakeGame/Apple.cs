using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Apple
    {
        public Coord Position { get; private set; }
        private readonly Random rand = new();

        public Apple(Coord gridDimensions)
        {
            Reposition(gridDimensions);
        }

        public void Reposition(Coord gridDimensions)
        {
            Position = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
        }
    }
}