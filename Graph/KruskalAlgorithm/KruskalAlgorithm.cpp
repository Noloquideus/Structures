#include <iostream>
#include <unordered_set>
#include <vector>
#include <tuple>
#include <algorithm>

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

    std::vector<std::tuple<char, char, int>> kruskal() {
        // Сортируем рёбра по весам
        std::sort(edges.begin(), edges.end(), [](const auto& a, const auto& b) {
            return std::get<2>(a) < std::get<2>(b);
        });

        // Инициализируем непересекающиеся множества
        std::unordered_map<char, char> parent;
        for (char vertex : vertices) {
            parent[vertex] = vertex;
        }

        std::vector<std::tuple<char, char, int>> minimumSpanningTree;

        // Функция для нахождения корня множества
        auto findSet = [&](char vertex) {
            if (vertex != parent[vertex]) {
                parent[vertex] = findSet(parent[vertex]);
            }
            return parent[vertex];
        };

        // Функция для объединения двух множеств
        auto unionSets = [&](char root1, char root2) {
            if (root1 != root2) {
                parent[root1] = root2;
            }
        };

        for (const auto& edge : edges) {
            char startVertex = std::get<0>(edge);
            char endVertex = std::get<1>(edge);
            int weight = std::get<2>(edge);

            char root1 = findSet(startVertex);
            char root2 = findSet(endVertex);

            // Проверяем, не образует ли добавляемое ребро цикл
            if (root1 != root2) {
                minimumSpanningTree.push_back(edge);
                unionSets(root1, root2);
            }
        }

        return minimumSpanningTree;
    }
};

int main() {
    Graph graph;
    graph.addEdge('A', 'B', 1);
    graph.addEdge('A', 'C', 4);
    graph.addEdge('B', 'C', 2);
    graph.addEdge('B', 'D', 5);
    graph.addEdge('C', 'D', 1);
    graph.addEdge('D', 'A', 7);

    std::vector<std::tuple<char, char, int>> result = graph.kruskal();

    std::cout << "Minimum Spanning Tree (Kruskal's algorithm):\n";
    for (const auto& edge : result) {
        std::cout << std::get<0>(edge) << " - " << std::get<1>(edge) << " : " << std::get<2>(edge) << "\n";
    }

    return 0;
}