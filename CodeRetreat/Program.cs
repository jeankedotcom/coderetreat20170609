namespace CodeRetreat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var maze = Api.GetMaze("9fbd4bd6-e677-43d6-b2f7-e993b634ada2").Result;

            //var quickestPath = PathFinder.FindQuickestPath(maze);
            //var x = Api.PostSolution(quickestPath).Result;
        }
    }
}