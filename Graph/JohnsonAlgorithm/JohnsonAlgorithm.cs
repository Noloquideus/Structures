using System;
using System.Collections.Generic;
using System.Linq;

class JohnsonAlgorithm
{
    private const int INF = int.MaxValue;

    private List<(int, int, int)> GetEdgesWithModifiedWeights(List<(int, int, int)> edges, int vertexCount)
    {
        var modifiedEdges = new List<(int, int, int)>(edges);

        for (int i = 1; i <= vertexCount; i++)
        {
            modifiedEdges.Add((0, i, 0));
        }

        return modifiedEdges;
    }

    private int[] BellmanFord(List<(int, int, int)> edges, int vertexCount, int source)
    {
        int[] distance = new int[vertexCount + 1];
        Array.Fill(distance, INF);
        distance[source] = 0;

        for (int i = 1; i < vertexCount; i++)
        {
            foreach (var (u, v, w) in edges)
            {
                if (distance[u] != INF && distance[u] + w < distance[v])
                {
                    distance[v] = distance[u] + w;
                }
            }
        }

        return distance;
    }

    private int[,] Dijkstra(List<(int, int, int)> edges, int vertexCount, int source)
    {
        int[,] result = new int[vertexCount, vertexCount];
        int[] distance = new int[vertexCount];
        Array.Fill(distance, INF);
        distance[source] = 0;

        var priorityQueue = new SortedSet<(int, int)>(Comparer<(int, int)>.Create((a, b) => a.Item2.CompareTo(b.Item2)));
        for (int i = 0; i < vertexCount; i++)
        {
            priorityQueue.Add((i, distance[i]));
        }

        while (priorityQueue.Count > 0)
        {
            int u = priorityQueue.Min.Item1;
            priorityQueue.Remove(priorityQueue.Min);

            foreach (var (v, w) in edges.Where(e => e.Item1 == u))
            {
                if (distance[u] != INF && distance[u] + w < distance[v])
                {
                    priorityQueue.Remove((v, distance[v]));
                    distance[v] = distance[u] + w;
                    priorityQueue.Add((v, distance[v]));
                }
            }
        }

        for (int i = 0; i < vertexCount; i++)
        {
            result[source - 1, i] = distance[i];
        }

        return result;
    }

    public int[,] Johnson(List<(int, int, int)> edges, int vertexCount)
    {
        var modifiedEdges = GetEdgesWithModifiedWeights(edges, vertexCount);
        int[] h = BellmanFord(modifiedEdges, vertexCount, 0);

        var newEdges = edges.Select(e => (e.Item1, e.Item2, e.Item3 + h[e.Item1 - 1] - h[e.Item2 - 1])).ToList();

        int[,] result = new int[vertexCount, vertexCount];

        for (int i = 1; i <= vertexCount; i++)
        {
            int[] dijkstraResult = Dijkstra(newEdges, vertexCount, i);
            for (int j = 0; j < vertexCount; j++)
            {
                result[i - 1, j] = dijkstraResult[0, j] - h[i - 1] + h[j];
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        var edges = new List<(int, int, int)>
        {
            (1, 2, 3),
            (2, 3, -2),
            (3, 1, 1),
            (1, 4, 2),
            (4, 3, -3)
        };

        int vertexCount = 4;

        JohnsonAlgorithm johnsonAlgorithm = new JohnsonAlgorithm();
        int[,] result = johnsonAlgorithm.Johnson(edges, vertexCount);

        Console.WriteLine("Shortest paths matrix after Johnson's algorithm:");
        for (int i = 0; i < vertexCount; i++)
        {
            for (int j = 0; j < vertexCount; j++)
            {
                Console.Write($"{result[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}