using System;
using System.Collections.Generic;

class Graph
{
    private HashSet<char> vertices = new HashSet<char>();
    private Dictionary<char, List<Tuple<char, int>>> edges = new Dictionary<char, List<Tuple<char, int>>>();

    public void AddEdge(char start, char end, int weight)
    {
        vertices.Add(start);
        vertices.Add(end);

        if (!edges.ContainsKey(start))
        {
            edges[start] = new List<Tuple<char, int>>();
        }

        edges[start].Add(Tuple.Create(end, weight));
    }

    public Dictionary<char, int> Dijkstra(char start)
    {
        Dictionary<char, int> distances = new Dictionary<char, int>();
        foreach (char vertex in vertices)
        {
            distances[vertex] = int.MaxValue;
        }
        distances[start] = 0;

        PriorityQueue<Tuple<int, char>> priorityQueue = new PriorityQueue<Tuple<int, char>>();
        priorityQueue.Enqueue(Tuple.Create(0, start));

        while (priorityQueue.Count > 0)
        {
            int currentDistance = priorityQueue.Peek().Item1;
            char currentVertex = priorityQueue.Peek().Item2;
            priorityQueue.Dequeue();

            if (currentDistance > distances[currentVertex])
            {
                continue;
            }

            foreach (Tuple<char, int> neighbor in edges[currentVertex])
            {
                int distance = currentDistance + neighbor.Item2;
                if (distance < distances[neighbor.Item1])
                {
                    distances[neighbor.Item1] = distance;
                    priorityQueue.Enqueue(Tuple.Create(distance, neighbor.Item1));
                }
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
        graph.AddEdge('D', 'A', 7);

        char startVertex = 'A';
        Dictionary<char, int> result = graph.Dijkstra(startVertex);

        Console.WriteLine($"Shortest distances from vertex {startVertex}:");
        foreach (var entry in result)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
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