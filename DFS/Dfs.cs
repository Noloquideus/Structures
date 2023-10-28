using Struct.BFS;

namespace Struct.DFS;

public class Dfs
{
    private static void DfsAlgorithm(Graph graph, int startVertex)
    {
        int verticesCount = graph.GetVerticesCount();
        bool[] visited = new bool[verticesCount];

        Struct.Stack.Stack stack = new Struct.Stack.Stack(verticesCount);
        stack.Push(startVertex);

        while (!stack.IsEmpty())
        {
            int currentVertex = stack.Pop();

            if (!visited[currentVertex])
            {
                Console.Write(currentVertex + " ");
                visited[currentVertex] = true;
            }

            List<int> adjacencyList = graph.GetAdjacencyList(currentVertex);
            foreach (int neighbor in adjacencyList)
            {
                if (!visited[neighbor])
                {
                    stack.Push(neighbor);
                }
            }
        }
    }
}