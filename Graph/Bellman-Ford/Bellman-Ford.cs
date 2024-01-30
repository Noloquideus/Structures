using System;
using System.Collections.Generic;

class Graph
{
    private HashSet<char> vertices = new HashSet<char>();
    private List<Tuple<char, char, int>> edges = new List<Tuple<char, char, int>>();

    public void AddEdge(char start, char end, int weight)
    {
        vertices.Add(start);
        vertices.Add(end);
        edges.Add(Tuple.Create(start, end, weight));
    }

    public Dictionary<char, int> BellmanFord(char start)
    {
        Dictionary<char, int> distances = new Dictionary<char, int>();
        foreach (char vertex in vertices)
        {
            distances[vertex] = int.MaxValue;
        }
        distances[start] = 0;

        for (int i = 0; i < vertices.Count - 1; ++i)
        {
            foreach (var edge in edges)
            {
                char startVertex = edge.Item1;
                char endVertex = edge.Item2;
                int weight = edge.Item3;

                if (distances[startVertex] + weight < distances[endVertex])
                {
                    distances[endVertex] = distances[startVertex] + weight;
                }
            }
        }

        // Проверка наличия отрицательных циклов
        foreach (var edge in edges)
        {
            char startVertex = edge.Item1;
            char endVertex = edge.Item2;
            int weight = edge.Item3;

            if (distances[startVertex] + weight < distances[endVertex])
            {
                throw new InvalidOperationException("Граф содержит отрицательный цикл");
            }
        }

        return distances;
    }
}

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        graph.AddEdge('A', 'B', 1);
        graph.AddEdge('A', 'C', 4);
        graph.AddEdge('B', 'C', 2);
        graph.AddEdge('B', 'D', 5);
        graph.AddEdge('C', 'D', 1);
        graph.AddEdge('D', 'A', -7);

        char startVertex = 'A';
        Dictionary<char, int> result = graph.BellmanFord(startVertex);

        Console.WriteLine($"Shortest distances from vertex {startVertex}:");
        foreach (var entry in result)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}