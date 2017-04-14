using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day1
    {
        private readonly List<string> _moves;
        private Coordinate[] _relocations;

        public Day1(List<string> moves)
        {
            _moves = moves;
            _relocations = new[] { new Coordinate(0, 1), new Coordinate(1, 0), new Coordinate(0, -1), new Coordinate(-1, 0) };
        }

        public int GetDistance()
        {
            var currentDirection = 0;
            var currentPosition = new Coordinate();

            foreach (var move in _moves)
            {
                currentDirection = ((move.Substring(0, 1) == "L" ? --currentDirection : ++currentDirection) + 4) % 4;
                var relocation = _relocations[currentDirection];
                var distance = int.Parse(move.Substring(1));
                currentPosition.Move(relocation, distance);
            }

            return Math.Abs(currentPosition.X) + Math.Abs(currentPosition.Y);
        }
    }

    internal struct Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x, int y) { X = x; Y = y; }

        public void Move(Coordinate relocation, int distance)
        {
            X += relocation.X * distance;
            Y += relocation.Y * distance;
        }
    }
}
