using System;
using System.Collections.Generic;

namespace CodeRetreat.Models
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileType Type { get; set; }

        public bool Accessible => Type == TileType.Grass || Type == TileType.Finish;

        public bool CanMoveTo(Tile other)
        {
            return Math.Abs(X - other.X) == 1 && Math.Abs(Y - other.Y) == 0 ||
                   Math.Abs(Y - other.Y) == 1 && Math.Abs(X - other.X) == 0;
        }

        public bool IsAdjacentTo(Tile other)
        {
            return !(X == other.X && Y == other.Y) &&
                   Math.Abs(X - other.X) <= 1 &&
                   Math.Abs(Y - other.Y) <= 1;
        }

        public override string ToString()
        {
            return $"Tile at: {X}, {Y} - of Type: {Type}";
        }
    }

    public enum TileType
    {
        Wall,
        Grass,
        Finish,
        Start
    }

    public class Maze
    {
        public List<List<Tile>> Tiles { get; set; } = new List<List<Tile>>();
    }
}