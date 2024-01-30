using System;
using System.Collections.Generic;
using System.Linq;

class Graph
{
    private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

    public void AddEdge(int u, int v)
    {
        if (!graph.ContainsKey(u))
        {
            graph[u] = new List<int>();
        }

        graph[u].Add(v);
    }

    private void TopologicalSortUtil(int vertex, HashSet<int> visited, Stack<int> stack)
    {
        visited.Add(vertex);

        foreach (int neighbor in graph[vertex])
        {
            if (!visited.Contains(neighbor))
            {
                TopologicalSortUtil(neighbor, visited, stack);
            }
        }

        stack.Push(vertex);
    }

    public List<int> TopologicalSort()
    {
        HashSet<int> visited = new HashSet<int>();
        Stack<int> stack = new Stack<int>();
        List<int> result = new List<int>();

        foreach (var entry in graph)
        {
            int vertex = entry.Key;
            if (!visited.Contains(vertex))
            {
                TopologicalSortUtil(vertex, visited, stack);
            }
        }

        while (stack.Count > 0)
        {
            result.Add(stack.Pop());
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(3, 6);
        graph.AddEdge(3, 7);

        List<int> result = graph.TopologicalSort();

        Console.Write("Topological Sort: ");
        foreach (int vertex in result)
        {
            Console.Write($"{vertex} ");
        }
    }
}