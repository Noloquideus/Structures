from collections import defaultdict

class Graph:
    def __init__(self):
        self.graph = defaultdict(list)

    def add_edge(self, u, v):
        self.graph[u].append(v)

    def topological_sort_util(self, vertex, visited, stack):
        visited.add(vertex)

        for neighbor in self.graph[vertex]:
            if neighbor not in visited:
                self.topological_sort_util(neighbor, visited, stack)

        stack.append(vertex)

    def topological_sort(self):
        visited = set()
        stack = []

        for vertex in self.graph:
            if vertex not in visited:
                self.topological_sort_util(vertex, visited, stack)

        return stack[::-1]


# Пример использования
graph = Graph()
graph.add_edge(1, 2)
graph.add_edge(1, 3)
graph.add_edge(2, 4)
graph.add_edge(2, 5)
graph.add_edge(3, 6)
graph.add_edge(3, 7)

result = graph.topological_sort()
print("Topological Sort:", result)