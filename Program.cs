namespace LongestCycleGraph
{
    internal class Program
    {
        public class LongestCycleGraph
        {
            private int longestCycle = -1;

            private void DFS(Dictionary<int, int> pathMap, bool[] visited, int[] edges, int node)
            {
                visited[node] = true;
                int neighbor = edges[node];
                if (neighbor != -1 && !visited[neighbor])
                {
                    pathMap[neighbor] = pathMap.GetValueOrDefault(node) + 1;
                    DFS(pathMap, visited, edges, neighbor);
                }
                else if (neighbor != -1 && pathMap.ContainsKey(neighbor))
                {
                    longestCycle = Math.Max(longestCycle, pathMap[node] - pathMap[neighbor] + 1);
                }
            }

            public int LongestCycle(int[] edges)
            {
                bool[] visited = new bool[edges.Length];
                for(int edge = 0; edge < edges.Length; ++edge)
                {
                    if (!visited[edge])
                    {
                        Dictionary<int, int> pathMap = new()
                        {
                            { edge, 1 }
                        };
                        DFS(pathMap, visited, edges, edge);
                    }
                }
                return longestCycle;
            }
        }

        static void Main(string[] args)
        {
            LongestCycleGraph longestCycleGraph1 = new();
            Console.WriteLine(longestCycleGraph1.LongestCycle(new int[] { 3, 3, 4, 2, 3 }));
            LongestCycleGraph longestCycleGraph2 = new();
            Console.WriteLine(longestCycleGraph2.LongestCycle(new int[] { 2, -1, 3, 1 }));
        }
    }
}