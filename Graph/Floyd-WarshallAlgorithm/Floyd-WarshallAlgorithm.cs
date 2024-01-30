using System;

class FloydWarshall
{
    private const int INF = int.MaxValue;

    public int[,] FindShortestPaths(int[,] graph)
    {
        int V = graph.GetLength(0);
        int[,] dist = new int[V, V];

        for (int i = 0; i < V; ++i)
        {
            for (int j = 0; j < V; ++j)
            {
                if (i == j)
                {
                    dist[i, j] = 0;
                }
                else if (graph[i, j] != INF)
                {
                    dist[i, j] = graph[i, j];
                }
            }
        }

        for (int k = 0; k < V; ++k)
        {
            for (int i = 0; i < V; ++i)
            {
                for (int j = 0; j < V; ++j)
                {
                    if (dist[i, k] != INF && dist[k, j] != INF && dist[i, k] + dist[k, j] < dist[i, j])
                    {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }

        return dist;
    }
}

class Program
{
    static void Main()
    {
        int[,] graph = {
            {0, 3, INF, 7},
            {8, 0, 2, INF},
            {5, INF, 0, 1},
            {2, INF, INF, 0}
        };

        FloydWarshall floydWarshall = new FloydWarshall();
        int[,] result = floydWarshall.FindShortestPaths(graph);

        Console.WriteLine("Matrix of shortest paths:");
        for (int i = 0; i < result.GetLength(0); ++i)
        {
            for (int j = 0; j < result.GetLength(1); ++j)
            {
                if (result[i, j] == INF)
                {
                    Console.Write("INF ");
                }
                else
                {
                    Console.Write($"{result[i, j]} ");
                }
            }
            Console.WriteLine();
        }
    }
}