#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <stack>
#include <vector>

class Graph {
private:
    std::unordered_map<int, std::vector<int>> graph;

public:
    void addEdge(int u, int v) {
        graph[u].push_back(v);
    }

    void topologicalSortUtil(int vertex, std::unordered_set<int>& visited, std::stack<int>& stack) {
        visited.insert(vertex);

        for (int neighbor : graph[vertex]) {
            if (visited.find(neighbor) == visited.end()) {
                topologicalSortUtil(neighbor, visited, stack);
            }
        }

        stack.push(vertex);
    }

    std::vector<int> topologicalSort() {
        std::unordered_set<int> visited;
        std::stack<int> stack;
        std::vector<int> result;

        for (const auto& entry : graph) {
            int vertex = entry.first;
            if (visited.find(vertex) == visited.end()) {
                topologicalSortUtil(vertex, visited, stack);
            }
        }

        while (!stack.empty()) {
            result.push_back(stack.top());
            stack.pop();
        }

        return result;
    }
};

int main() {
    Graph graph;
    graph.addEdge(1, 2);
    graph.addEdge(1, 3);
    graph.addEdge(2, 4);
    graph.addEdge(2, 5);
    graph.addEdge(3, 6);
    graph.addEdge(3, 7);

    std::vector<int> result = graph.topologicalSort();

    std::cout << "Topological Sort: ";
    for (int vertex : result) {
        std::cout << vertex << " ";
    }

    return 0;
}