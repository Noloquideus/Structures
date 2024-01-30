class Graph:
    def __init__(self):
        self.vertices = set()
        self.edges = []

    def add_edge(self, start, end, weight):
        self.vertices.add(start)
        self.vertices.add(end)
        self.edges.append((start, end, weight))

    def bellman_ford(self, start):
        distances = {vertex: float('infinity') for vertex in self.vertices}
        distances[start] = 0

        for _ in range(len(self.vertices) - 1):
            for start_vertex, end_vertex, weight in self.edges:
                if distances[start_vertex] + weight < distances[end_vertex]:
                    distances[end_vertex] = distances[start_vertex] + weight

        # Проверка наличия отрицательных циклов
        for start_vertex, end_vertex, weight in self.edges:
            if distances[start_vertex] + weight < distances[end_vertex]:
                raise ValueError("Граф содержит отрицательный цикл")

        return distances


# Пример использования
graph = Graph()
graph.add_edge("A", "B", 1)
graph.add_edge("A", "C", 4)
graph.add_edge("B", "C", 2)
graph.add_edge("B", "D", 5)
graph.add_edge("C", "D", 1)
graph.add_edge("D", "A", -7)

start_vertex = "A"
result = graph.bellman_ford(start_vertex)
print(f"Shortest distances from vertex {start_vertex}: {result}")