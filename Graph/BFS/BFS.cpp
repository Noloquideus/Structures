#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <queue>

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

    void bfs(int start) {
        std::unordered_set<int> visited;
        std::queue<int> queue;

        queue.push(start);

        while (!queue.empty()) {
            int currentVertex = queue.front();
            queue.pop();

            if (visited.find(currentVertex) == visited.end()) {
                std::cout << currentVertex << " ";
                visited.insert(currentVertex);

                for (int neighbor : vertices[currentVertex]) {
                    if (visited.find(neighbor) == visited.end()) {
                        queue.push(neighbor);
                    }
                }
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

    std::cout << "BFS starting from vertex 1:\n";
    graph.bfs(1);

    return 0;
}