using System;

namespace Struct.BFS
{
    class Bfs
    {
        private Graph _graph;
        private Queue.Queue _queue;
        
        // Initializes a new instance of the Bfs class with the specified number of vertices.
        public Bfs(int v)
        {
            _graph = new Graph(v);
            _queue = new Queue.Queue(v);
        }
        /*
        Adds an edge to the graph.
        Parameters:
           v:
             The starting vertex of the edge.
           w:
             The ending vertex of the edge.
        Returns:
             None.
        */
        public void AddEdge(int v, int w)
        {
            _graph.AddEdge(v, w);
        }
        /*
        Performs a breadth-first search starting from vertex s in the graph.
        Parameters:
           s: The starting vertex for the breadth-first search.
        Returns:
           None.
         */
        public void BfsAlgorithm(int s)
        {
            bool[] visited = new bool[_graph.GetVerticesCount()];
            for (int i = 0; i < _graph.GetVerticesCount(); ++i)
            {
                visited[i] = false;
            }

            visited[s] = true;
            _queue.Enqueue(s);

            while (!_queue.IsEmpty())
            {
                s = _queue.Dequeue();
                Console.Write(s + " ");

                foreach (int i in _graph.GetAdjacencyList(s))
                {
                    if (!visited[i])
                    {
                        visited[i] = true;
                        _queue.Enqueue(i);
                    }
                }
            }
        }
    }
}