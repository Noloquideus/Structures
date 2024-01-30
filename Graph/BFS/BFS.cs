using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> vertices = new Dictionary<int, List<int>>();

    public void AddVertex(int vertex)
    {
        if (!vertices.ContainsKey(vertex))
        {
            vertices[vertex] = new List<int>();
        }
    }

    public void AddEdge(int vertex1, int vertex2)
    {
        vertices[vertex1].Add(vertex2);
        vertices[vertex2].Add(vertex1);
    }

    public void BFS(int start)
    {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int currentVertex = queue.Dequeue();

            if (!visited.Contains(currentVertex))
            {
                Console.Write($"{currentVertex} ");
                visited.Add(currentVertex);

                foreach (int neighbor in vertices[currentVertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        for (int vertex = 1; vertex <= 7; ++vertex)
        {
            graph.AddVertex(vertex);
        }

        List<Tuple<int, int>> edges = new List<Tuple<int, int>> {
            Tuple.Create(1, 2), Tuple.Create(1, 3), Tuple.Create(2, 4),
            Tuple.Create(2, 5), Tuple.Create(3, 6), Tuple.Create(3, 7)
        };
        foreach (var edge in edges)
        {
            graph.AddEdge(edge.Item1, edge.Item2);
        }

        Console.Write("BFS starting from vertex 1:\n");
        graph.BFS(1);
    }
}