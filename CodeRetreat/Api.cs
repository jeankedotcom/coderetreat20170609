using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CodeRetreat.Models;
using Newtonsoft.Json;

namespace CodeRetreat
{
    public static class Api
    {
        private const string BaseUri = @"http://mazeretreat.azurewebsites.net/mazes/";
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<Maze> GetMaze(string mazeId)
        {
            var url = BaseUri + mazeId;
            var response = await GetAsync(url);
            var maze = ParseApiResponse(response);

            return maze;
        }

        public static async Task<bool> PostSolution(List<Tile> quickestPath)
        {
            var solution = new ResponseModel
            {
                TeamName = "Wouter en Ivan",
                MazeId = "51b8269c-00e2-4486-ac05-f4490942c0c9",
                Solution = string.Join(";", quickestPath.Select(tile => tile.X + "," + tile.Y))
            };

            return await PostJsonContentAsync(JsonConvert.SerializeObject(solution), "http://mazeretreat.azurewebsites.net/solutions/51b8269c-00e2-4486-ac05-f4490942c0c9");
        }

        private static Maze ParseApiResponse(string apiResponse)
        {
            var maze = new Maze();

            var rows = apiResponse.Replace("\\r\\n", "|").Replace("\"", "").Split('|');

            for (int rowNumber = 0; rowNumber < rows.Length; rowNumber++)
            {
                var row = rows[rowNumber];
                var columns = row.ToCharArray();

                var tilesForRow = new List<Tile>();

                for (int columnNumber = 0; columnNumber < columns.Length; columnNumber++)
                {
                    var column = columns[columnNumber];

                    if (column == '\n')
                    {
                        continue;
                    }

                    var tileType = ParseTileType(column);
                    
                    var tile = new Tile
                    {
                        Type = tileType,
                        X = columnNumber,
                        Y = rowNumber
                    };
                    
                    tilesForRow.Add(tile);
                }

                maze.Tiles.Add(tilesForRow);
            }

            return maze;
        }

        private static TileType ParseTileType(char tile)
        {
            switch (tile)
            {
                case '#':
                    return TileType.Wall;
                case '.':
                    return TileType.Grass;
                case 'S':
                    return TileType.Start;
                case 'F':
                    return TileType.Finish;
                case '1':
                    return TileType.Teleport;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static async Task<string> GetAsync(string url)
        {
            try
            {
                using (var response = await HttpClient.GetAsync(url))
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch
            {
                return null;
            }
        }

        private static async Task<bool> PostJsonContentAsync(string content, string url)
        {
            try
            {
                var postcontent = new StringContent(content, Encoding.UTF8, "application/json");
                using (var response = await HttpClient.PostAsync(url, postcontent))
                {
                    return response.IsSuccessStatusCode;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public class ResponseModel
        {
            public string TeamName { get; set; }
            public string MazeId { get; set; }
            public string Solution { get; set; }
        }
    }
}