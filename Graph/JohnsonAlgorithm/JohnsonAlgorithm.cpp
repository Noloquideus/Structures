#include <iostream>
#include <vector>
#include <limits>
#include <queue>
#include <functional>

const int INF = std::numeric_limits<int>::max();

std::vector<int> bellmanFord(const std::vector<std::vector<std::pair<int, int>>>& graph, int source) {
    int V = graph.size();
    std::vector<int> distance(V, INF);
    distance[source] = 0;

    for (int _ = 0; _ < V - 1; ++_) {
        for (int u = 0; u < V; ++u) {
            for (const auto& neighbor : graph[u]) {
                int v = neighbor.first;
                int weight = neighbor.second;
                if (distance[u] != INF && distance[u] + weight < distance[v]) {
                    distance[v] = distance[u] + weight;
                }
            }
        }
    }

    return distance;
}

std::vector<std::vector<int>> johnson(const std::vector<std::vector<std::pair<int, int>>>& graph) {
    int V = graph.size();

    // Модификация графа
    std::vector<std::vector<std::pair<int, int>>> modifiedGraph = {{{0, 0}}};
    modifiedGraph.insert(modifiedGraph.end(), graph.begin(), graph.end());

    std::vector<int> h = bellmanFord(modifiedGraph, 0);

    // Проверка наличия отрицательного цикла
    if (std::find(h.begin(), h.end(), INF) != h.end()) {
        std::cout << "Граф содержит отрицательный цикл\n";
        return {};
    }

    // Модификация весов рёбер
    for (int u = 0; u < V; ++u) {
        for (auto& neighbor : graph[u]) {
            int v = neighbor.first;
            int weight = neighbor.second;
            graph[u][v] = weight + h[u] - h[v];
        }
    }

    // Запуск алгоритма Дейкстры для каждой вершины
    std::vector<std::vector<int>> allShortestPaths;
    for (int u = 0; u < V; ++u) {
        std::vector<int> distance(V, INF);
        distance[u] = 0;
        std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<>> minHeap;
        minHeap.push({0, u});

        while (!minHeap.empty()) {
            int currentDistance = minHeap.top().first;
            int currentVertex = minHeap.top().second;
            minHeap.pop();

            if (currentDistance > distance[currentVertex]) {
                continue;
            }

            for (const auto& neighbor : graph[currentVertex]) {
                int v = neighbor.first;
                int weight = neighbor.second;
                if (distance[currentVertex] + weight < distance[v]) {
                    distance[v] = distance[currentVertex] + weight;
                    minHeap.push({distance[v], v});
                }
            }
        }

        // Восстановление исходных весов
        for (int v = 0; v < V; ++v) {
            if (distance[v] != INF) {
                distance[v] -= h[u] - h[v];
            }
        }

        allShortestPaths.push_back(distance);
    }

    return allShortestPaths;
}

int main() {
    std::vector<std::vector<std::pair<int, int>>> graph = {
        {{1, 3}, {3, 7}},
        {{2, 2}},
        {{0, 5}, {3, 1}},
        {}
    };

    std::vector<std::vector<int>> result = johnson(graph);

    if (!result.empty()) {
        std::cout << "Matrix of shortest paths:\n";
        for (const auto& row : result) {
            for (int value : row) {
                if (value == INF) {
                    std::cout << "INF ";
                } else {
                    std::cout << value << " ";
                }
            }
            std::cout << "\n";
        }
    }

    return 0;
}