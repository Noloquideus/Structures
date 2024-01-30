class Graph:
    def __init__(self):
        self.vertices = {}

    def add_vertex(self, vertex):
        if vertex not in self.vertices:
            self.vertices[vertex] = []

    def add_edge(self, vertex1, vertex2):
        self.vertices[vertex1].append(vertex2)
        self.vertices[vertex2].append(vertex1)

    def dfs(self, start, visited=None):
        if visited is None:
            visited = set()

        visited.add(start)
        print(start, end=" ")

        for neighbor in self.vertices[start]:
            if neighbor not in visited:
                self.dfs(neighbor, visited)

# Пример использования
graph = Graph()
for vertex in range(1, 8):
    graph.add_vertex(vertex)

edges = [(1, 2), (1, 3), (2, 4), (2, 5), (3, 6), (3, 7)]
for edge in edges:
    graph.add_edge(*edge)

print("DFS starting from vertex 1:")
graph.dfs(1)