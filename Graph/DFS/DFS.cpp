#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <vector>

class Graph {
private:
    std::unordered_map<int, std::vector<int>> vertices;

public:
    void addVertex(int vertex) {
        if (vertices.find(vertex) == vertices.end()) {
            vertices[vertex] = std::vector<int>();
        }
    }

    void addEdge(int vertex1, int vertex2) {
        vertices[vertex1].push_back(vertex2);
        vertices[vertex2].push_back(vertex1);
    }

    void dfs(int start, std::unordered_set<int>& visited) {
        visited.insert(start);
        std::cout << start << " ";

        for (int neighbor : vertices[start]) {
            if (visited.find(neighbor) == visited.end()) {
                dfs(neighbor, visited);
            }
        }
    }
};

int main() {
    Graph graph;
    for (int vertex = 1; vertex <= 7; ++vertex) {
        graph.addVertex(vertex);
    }

    std::vector<std::pair<int, int>> edges = {{1, 2}, {1, 3}, {2, 4}, {2, 5}, {3, 6}, {3, 7}};
    for (const auto& edge : edges) {
        graph.addEdge(edge.first, edge.second);
    }

    std::unordered_set<int> visited;
    std::cout << "DFS starting from vertex 1:\n";
    graph.dfs(1, visited);

    return 0;
}