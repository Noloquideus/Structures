from collections import deque


class Graph:
    def __init__(self):
        self.vertices = {}

    def add_vertex(self, vertex):
        if vertex not in self.vertices:
            self.vertices[vertex] = []

    def add_edge(self, vertex1, vertex2):
        self.vertices[vertex1].append(vertex2)
        self.vertices[vertex2].append(vertex1)

    def bfs(self, start):
        visited = set()
        queue = deque([start])

        while queue:
            current_vertex = queue.popleft()
            if current_vertex not in visited:
                print(current_vertex, end=" ")
                visited.add(current_vertex)
                queue.extend(neighbor for neighbor in self.vertices[current_vertex] if neighbor not in visited)


# Пример использования
graph = Graph()
for vertex in range(1, 8):
    graph.add_vertex(vertex)

edges = [(1, 2), (1, 3), (2, 4), (2, 5), (3, 6), (3, 7)]
for edge in edges:
    graph.add_edge(*edge)

print("BFS starting from vertex 1:")
graph.bfs(1)
