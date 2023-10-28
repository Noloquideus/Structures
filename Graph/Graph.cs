using System.Collections.Generic;

namespace Struct.BFS
{
    class Graph
    {
        private List<int>[] _adjacencyList;
        private readonly int _v;

        public Graph(int v)
        {
            _v = v;
            _adjacencyList = new List<int>[_v];
            for (int i = 0; i < _v; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            _adjacencyList[v].Add(w);
        }

        public List<int> GetAdjacencyList(int v)
        {
            return _adjacencyList[v];
        }

        public int GetVerticesCount()
        {
            return _v;
        }
    }
}