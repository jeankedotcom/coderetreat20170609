namespace CodeRetreat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var maze = Api.GetMaze("51b8269c-00e2-4486-ac05-f4490942c0c9").Result;

            var quickestPath = PathFinder.FindQuickestPath(maze);
            var x = Api.PostSolution(quickestPath).Result;
        }
    }
}