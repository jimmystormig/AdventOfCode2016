using System;
using System.Collections.Generic;

namespace Solutions
{
    public class Day1
    {
        public void Main()
        {
            var moves = new List<string> { "R5", "L2", "L1", "R1", "R3", "R3", "L3", "R3", "R4", "L2", "R4", "L4", "R4", "R3", "L2", "L1", "L1", "R2", "R4", "R4", "L4", "R3", "L2", "R1", "L4", "R1", "R3", "L5", "L4", "L5", "R3", "L3", "L1", "L1", "R4", "R2", "R2", "L1", "L4", "R191", "R5", "L2", "R46", "R3", "L1", "R74", "L2", "R2", "R187", "R3", "R4", "R1", "L4", "L4", "L2", "R4", "L5", "R4", "R3", "L2", "L1", "R3", "R3", "R3", "R1", "R1", "L4", "R4", "R1", "R5", "R2", "R1", "R3", "L4", "L2", "L2", "R1", "L3", "R1", "R3", "L5", "L3", "R5", "R3", "R4", "L1", "R3", "R2", "R1", "R2", "L4", "L1", "L1", "R3", "L3", "R4", "L2", "L4", "L5", "L5", "L4", "R2", "R5", "L4", "R4", "L2", "R3", "L4", "L3", "L5", "R5", "L4", "L2", "R3", "R5", "R5", "L1", "L4", "R3", "L1", "R2", "L5", "L1", "R4", "L1", "R5", "R1", "L4", "L4", "L4", "R4", "R3", "L5", "R1", "L3", "R4", "R3", "L2", "L1", "R1", "R2", "R2", "R2", "L1", "L1", "L2", "L5", "L3", "L1" };
            var distance = GetDistance(moves);
            Console.WriteLine(distance);
            Console.ReadLine();
        }

        public static int GetDistance(List<string> moves)
        {
            var relocations = new[] { new Coordinate(0, 1), new Coordinate(1, 0), new Coordinate(0, -1), new Coordinate(-1, 0) };
            var currentDirection = 0;
            var currentPosition = new Coordinate();

            foreach (var move in moves)
            {
                currentDirection = ((move.Substring(0, 1) == "L" ? --currentDirection : ++currentDirection) + 4) % 4;
                var relocation = relocations[currentDirection];
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
