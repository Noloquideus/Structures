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

    public List<Tuple<char, char, int>> Prim()
    {
        char startVertex = vertices.First();
        HashSet<char> visited = new HashSet<char> {startVertex};
        PriorityQueue<Tuple<int, char, char>> minHeap = new PriorityQueue<Tuple<int, char, char>>((x, y) => x.Item1.CompareTo(y.Item1));

        foreach (var edge in edges)
        {
            if (edge.Item1 == startVertex)
            {
                minHeap.Enqueue(edge);
            }
        }

        List<Tuple<char, char, int>> minimumSpanningTree = new List<Tuple<char, char, int>>();

        while (minHeap.Count > 0)
        {
            int weight = minHeap.Peek().Item1;
            char currentVertex = minHeap.Peek().Item2;
            char nextVertex = minHeap.Peek().Item3;
            minHeap.Dequeue();

            if (!visited.Contains(nextVertex))
            {
                visited.Add(nextVertex);
                minimumSpanningTree.Add(Tuple.Create(currentVertex, nextVertex, weight));

                foreach (var edge in edges)
                {
                    if (edge.Item1 == nextVertex && !visited.Contains(edge.Item2))
                    {
                        minHeap.Enqueue(edge);
                    }

                    if (edge.Item2 == nextVertex && !visited.Contains(edge.Item1))
                    {
                        minHeap.Enqueue(edge);
                    }
                }
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

        List<Tuple<char, char, int>> result = graph.Prim();

        Console.WriteLine("Minimum Spanning Tree (Prim's algorithm):");
        foreach (var edge in result)
        {
            Console.WriteLine($"{edge.Item1} - {edge.Item2} : {edge.Item3}");
        }
    }
}

// Вспомогательный класс для реализации очереди с приоритетом
public class PriorityQueue<T>
{
    private List<T> heap;
    private Comparison<T> comparison;

    public int Count => heap.Count;

    public PriorityQueue(Comparison<T> comparison)
    {
        this.heap = new List<T>();
        this.comparison = comparison;
    }

    public void Enqueue(T item)
    {
        heap.Add(item);
        int i = heap.Count - 1;
        while (i > 0)
        {
            int parent = (i - 1) / 2;
            if (comparison(heap[parent], item) <= 0)
            {
                break;
            }

            heap[i] = heap[parent];
            i = parent;
        }

        heap[i] = item;
    }

    public T Dequeue()
    {
        T item = heap[0];
        int lastIndex = heap.Count - 1;
        T lastItem = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        if (lastIndex > 0)
        {
            int i = 0;
            while (true)
            {
                int leftChild = 2 * i + 1;
                if (leftChild >= lastIndex)
                {
                    break;
                }

                int rightChild = leftChild + 1;
                int smallerChild = (rightChild < lastIndex && comparison(heap[rightChild], heap[leftChild]) < 0) ? rightChild : leftChild;

                if (comparison(heap[smallerChild], lastItem) >= 0)
                {
                    break;
                }

                heap[i] = heap[smallerChild];
                i = smallerChild;
            }

            heap[i] = lastItem;
        }

        return item;
    }

    public T Peek()
    {
        if (heap.Count == 0)
        {
            throw new InvalidOperationException("PriorityQueue is empty");
        }

        return heap[0];
    }
}