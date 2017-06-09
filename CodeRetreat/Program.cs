namespace CodeRetreat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var maze = Api.GetMaze("09a655dd-6cbd-4793-89cf-604d2b0a8330").Result;

            var quickestPath = PathFinder.FindQuickestPath(maze);
            var x = Api.PostSolution(quickestPath).Result;
        }
    }
}