#include <iostream>
#include <unordered_set>
#include <vector>
#include <queue>
#include <tuple>

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

    std::vector<std::tuple<char, char, int>> prim() {
        char startVertex = *vertices.begin();
        std::unordered_set<char> visited = {startVertex};
        std::priority_queue<std::tuple<int, char, char>, std::vector<std::tuple<int, char, char>>, std::greater<std::tuple<int, char, char>>> minHeap;

        for (const auto& edge : edges) {
            if (std::get<0>(edge) == startVertex) {
                minHeap.push(edge);
            }
        }

        std::vector<std::tuple<char, char, int>> minimumSpanningTree;

        while (!minHeap.empty()) {
            int weight = std::get<0>(minHeap.top());
            char currentVertex = std::get<1>(minHeap.top());
            char nextVertex = std::get<2>(minHeap.top());
            minHeap.pop();

            if (visited.find(nextVertex) == visited.end()) {
                visited.insert(nextVertex);
                minimumSpanningTree.emplace_back(currentVertex, nextVertex, weight);

                for (const auto& edge : edges) {
                    if (std::get<0>(edge) == nextVertex && visited.find(std::get<1>(edge)) == visited.end()) {
                        minHeap.push(edge);
                    }

                    if (std::get<1>(edge) == nextVertex && visited.find(std::get<0>(edge)) == visited.end()) {
                        minHeap.push(edge);
                    }
                }
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

    std::vector<std::tuple<char, char, int>> result = graph.prim();

    std::cout << "Minimum Spanning Tree (Prim's algorithm):\n";
    for (const auto& edge : result) {
        std::cout << std::get<0>(edge) << " - " << std::get<1>(edge) << " : " << std::get<2>(edge) << "\n";
    }

    return 0;
}