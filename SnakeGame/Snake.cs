using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake(Coord startPos)
    {
        public Coord Head => Positions.First();
        private List<Coord> Positions { get; set; } = [startPos];
        private Direction MovementDirection { get; set; } = Direction.Down;
        private int TailLength { get; set; } = 1;

        public void Move(Coord gridDimensions)
        {
            var newHead = Head.ApplyMovementDirection(MovementDirection);

            // Wrap around the grid
            if (newHead.X < 0) newHead.X = gridDimensions.X - 2;
            if (newHead.X >= gridDimensions.X - 1) newHead.X = 1;
            if (newHead.Y < 0) newHead.Y = gridDimensions.Y - 2;
            if (newHead.Y >= gridDimensions.Y - 1) newHead.Y = 1;

            Positions.Insert(0, newHead);

            if (Positions.Count > TailLength)
            {
                Positions.RemoveAt(Positions.Count - 1);
            }
        }

        public void ChangeDirection(Direction newDirection)
        {
            // Prevent the snake from reversing direction
            if ((MovementDirection == Direction.Up && newDirection != Direction.Down) ||
                (MovementDirection == Direction.Down && newDirection != Direction.Up) ||
                (MovementDirection == Direction.Left && newDirection != Direction.Right) ||
                (MovementDirection == Direction.Right && newDirection != Direction.Left))
            {
                MovementDirection = newDirection;
            }
        }

        public void Grow()
        {
            TailLength++;
        }

        public bool IsOccupying(Coord coord)
        {
            return Positions.Contains(coord);
        }

        public bool HasCollidedWithSelf()
        {
            return Positions.Skip(1).Contains(Head);
        }
    }
}