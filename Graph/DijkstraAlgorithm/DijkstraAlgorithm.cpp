#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <queue>
#include <vector>
#include <climits>

class Graph {
private:
    std::unordered_set<char> vertices;
    std::unordered_map<char, std::vector<std::pair<char, int>>> edges;

public:
    void addEdge(char start, char end, int weight) {
        vertices.insert(start);
        vertices.insert(end);
        edges[start].emplace_back(end, weight);
    }

    std::unordered_map<char, int> dijkstra(char start) {
        std::unordered_map<char, int> distances;
        for (char vertex : vertices) {
            distances[vertex] = INT_MAX;
        }
        distances[start] = 0;

        std::priority_queue<std::pair<int, char>, std::vector<std::pair<int, char>>, std::greater<std::pair<int, char>>> pq;
        pq.push({0, start});

        while (!pq.empty()) {
            int currentDistance = pq.top().first;
            char currentVertex = pq.top().second;
            pq.pop();

            if (currentDistance > distances[currentVertex]) {
                continue;
            }

            for (const auto& neighbor : edges[currentVertex]) {
                int distance = currentDistance + neighbor.second;
                if (distance < distances[neighbor.first]) {
                    distances[neighbor.first] = distance;
                    pq.push({distance, neighbor.first});
                }
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
    graph.addEdge('D', 'A', 7);

    char startVertex = 'A';
    std::unordered_map<char, int> result = graph.dijkstra(startVertex);

    std::cout << "Shortest distances from vertex " << startVertex << ":\n";
    for (const auto& entry : result) {
        std::cout << entry.first << ": " << entry.second << "\n";
    }

    return 0;
}