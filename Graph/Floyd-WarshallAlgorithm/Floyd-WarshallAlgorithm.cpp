#include <iostream>
#include <vector>
#include <limits>

const int INF = std::numeric_limits<int>::max();

std::vector<std::vector<int>> floydWarshall(const std::vector<std::vector<int>>& graph) {
    int V = graph.size();
    std::vector<std::vector<int>> dist(V, std::vector<int>(V, INF));

    for (int i = 0; i < V; ++i) {
        for (int j = 0; j < V; ++j) {
            if (i == j) {
                dist[i][j] = 0;
            } else if (graph[i][j] != INF) {
                dist[i][j] = graph[i][j];
            }
        }
    }

    for (int k = 0; k < V; ++k) {
        for (int i = 0; i < V; ++i) {
            for (int j = 0; j < V; ++j) {
                if (dist[i][k] != INF && dist[k][j] != INF && dist[i][k] + dist[k][j] < dist[i][j]) {
                    dist[i][j] = dist[i][k] + dist[k][j];
                }
            }
        }
    }

    return dist;
}

int main() {
    std::vector<std::vector<int>> graph = {
        {0, 3, INF, 7},
        {8, 0, 2, INF},
        {5, INF, 0, 1},
        {2, INF, INF, 0}
    };

    std::vector<std::vector<int>> result = floydWarshall(graph);

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

    return 0;
}