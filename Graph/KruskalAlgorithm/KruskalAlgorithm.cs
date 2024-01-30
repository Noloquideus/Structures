using System;
using System.Collections.Generic;
using System.Linq;

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

    public List<Tuple<char, char, int>> Kruskal()
    {
        // Сортируем рёбра по весам
        edges = edges.OrderBy(edge => edge.Item3).ToList();

        // Инициализируем непересекающиеся множества
        Dictionary<char, char> parent = new Dictionary<char, char>();
        foreach (char vertex in vertices)
        {
            parent[vertex] = vertex;
        }

        List<Tuple<char, char, int>> minimumSpanningTree = new List<Tuple<char, char, int>>();

        // Функция для нахождения корня множества
        char FindSet(char vertex)
        {
            if (vertex != parent[vertex])
            {
                parent[vertex] = FindSet(parent[vertex]);
            }
            return parent[vertex];
        }

        // Функция для объединения двух множеств
        void UnionSets(char root1, char root2)
        {
            if (root1 != root2)
            {
                parent[root1] = root2;
            }
        }

        foreach (var edge in edges)
        {
            char startVertex = edge.Item1;
            char endVertex = edge.Item2;
            int weight = edge.Item3;

            char root1 = FindSet(startVertex);
            char root2 = FindSet(endVertex);

            // Проверяем, не образует ли добавляемое ребро цикл
            if (root1 != root2)
            {
                minimumSpanningTree.Add(edge);
                UnionSets(root1, root2);
            }
        }

        return minimumSpanningTree;
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
        graph.AddEdge('D', 'A', 7);

        List<Tuple<char, char, int>> result = graph.Kruskal();

        Console.WriteLine("Minimum Spanning Tree (Kruskal's algorithm):");
        foreach (var edge in result)
        {
            Console.WriteLine($"{edge.Item1} - {edge.Item2} : {edge.Item3}");
        }
    }
}