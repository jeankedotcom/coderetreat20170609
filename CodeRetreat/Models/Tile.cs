using System;
using System.Collections.Generic;

namespace CodeRetreat.Models
{
    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public TileType Type { get; set; }
        public int? TeleportId { get; set; }

        public List<Tile> Children { get; set; }

        public bool Accessible => Type == TileType.Grass || Type == TileType.Finish || Type == TileType.Teleport;

        public int CanMoveTo(Tile other)
        {
            if (this.Type == TileType.Teleport && other.Type == TileType.Teleport && other.TeleportId == this.TeleportId)
                return 0;

            if (Math.Abs(X - other.X) == 1 && Math.Abs(Y - other.Y) == 0 || Math.Abs(Y - other.Y) == 1 && Math.Abs(X - other.X) == 0)
                return 1;

            return int.MaxValue;          
        }

        //public bool IsAdjacentTo(Tile other)
        //{
        //    return !(X == other.X && Y == other.Y) &&
        //           Math.Abs(X - other.X) <= 1 &&
        //           Math.Abs(Y - other.Y) <= 1;
        //}

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
        Start,
        Teleport
    }

    public class Maze
    {
        public List<List<Tile>> Tiles { get; set; } = new List<List<Tile>>();
    }
}