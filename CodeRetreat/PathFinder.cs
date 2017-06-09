using System.Collections.Generic;
using System.Linq;
using CodeRetreat.Models;

namespace CodeRetreat
{
    public static class PathFinder
    {
        private static Tile GetCorrespondingTeleport(Tile currentTile, Maze maze) {
            Tile correspondingTeleport = maze.Tiles[currentTile.Y].Single(t => t.Type == TileType.Teleport && t.X != currentTile.X);
            return correspondingTeleport;
        }

        //public static List<Tile> FindQuickestPath(Maze maze)
        //{
        //    var quickestPath = new List<Tile>();

        //    var currentTile = maze.Tiles.SelectMany(row => row).Single(tile => tile.Type == TileType.Start);

        //    while (true)
        //    {
        //        quickestPath.Add(currentTile);

        //        if (currentTile.Type == TileType.Finish)
        //        {
        //            break;
        //        }

        //        if (currentTile.Type == TileType.Teleport)
        //        {
        //            //var adjacentTiles = GetAdjacentTiles(maze, currentTile);
        //            currentTile = GetCorrespondingTeleport(currentTile, maze);
        //            currentTile.IsAccessedTeleport = true;
        //        }

        //        currentTile = GetNextMove(maze, currentTile, quickestPath);
        //    }

        //    return quickestPath;
        //}

        //private static Tile GetNextMove(Maze maze, Tile currentTile, List<Tile> crossedPath)
        //{
        //    var adjacentTiles = GetAdjacentTiles(maze, currentTile);
        //    var accessibleTiles = adjacentTiles.Where(tile => tile.Accessible && !tile.IsAccessedTeleport).OrderByDescending(t => t.Y);
        //    var canMoveTo = accessibleTiles.Where(currentTile.CanMoveTo);

        //    return canMoveTo.First(tile => crossedPath.Contains(tile) == false);
        //}

        //private static IEnumerable<Tile> GetAdjacentTiles(Maze maze, Tile currentPosition)
        //{
        //    return maze.Tiles.SelectMany(row => row).Where(tile => tile.IsAdjacentTo(currentPosition));
        //}
    }
}