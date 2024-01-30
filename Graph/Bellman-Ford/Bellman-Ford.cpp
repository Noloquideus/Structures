#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <vector>
#include <climits>

class Graph {
private:
    std::unordered_set<char> vertices;
    std::vector<std::tuple<char, char, int>> edges;

public:
    void addEdge(char start, char end, int weight) {
        vertices.insert(start);
        vertices.insert(end);
        edges.emplace_back(start, end, weight);
    }

    std::unordered_map<char, int> bellmanFord(char start) {
        std::unordered_map<char, int> distances;
        for (char vertex : vertices) {
            distances[vertex] = INT_MAX;
        }
        distances[start] = 0;

        for (size_t i = 0; i < vertices.size() - 1; ++i) {
            for (const auto& edge : edges) {
                char startVertex = std::get<0>(edge);
                char endVertex = std::get<1>(edge);
                int weight = std::get<2>(edge);

                if (distances[startVertex] + weight < distances[endVertex]) {
                    distances[endVertex] = distances[startVertex] + weight;
                }
            }
        }

        // Проверка наличия отрицательных циклов
        for (const auto& edge : edges) {
            char startVertex = std::get<0>(edge);
            char endVertex = std::get<1>(edge);
            int weight = std::get<2>(edge);

            if (distances[startVertex] + weight < distances[endVertex]) {
                throw std::runtime_error("Граф содержит отрицательный цикл");
            }
        }

        return distances;
    }
};

int main() {
    Graph graph;
    graph.addEdge('A', 'B', 1);
    graph.addEdge('A', 'C', 4);
    graph.addEdge('B', 'C', 2);
    graph.addEdge('B', 'D', 5);
    graph.addEdge('C', 'D', 1);
    graph.addEdge('D', 'A', -7);

    char startVertex = 'A';
    std::unordered_map<char, int> result = graph.bellmanFord(startVertex);

    std::cout << "Shortest distances from vertex " << startVertex << ":\n";
    for (const auto& entry : result) {
        std::cout << entry.first << ": " << entry.second << "\n";
    }

    return 0;
}