import heapq

class Graph:
    def __init__(self):
        self.vertices = set()
        self.edges = []

    def add_edge(self, start, end, weight):
        self.vertices.add(start)
        self.vertices.add(end)
        self.edges.append((start, end, weight))

    def prim(self):
        # Выбираем произвольную начальную вершину
        start_vertex = next(iter(self.vertices))
        visited = {start_vertex}
        min_heap = [(weight, start_vertex, end_vertex) for start_vertex, end_vertex, weight in self.edges if start_vertex == start_vertex]

        heapq.heapify(min_heap)
        minimum_spanning_tree = []

        while min_heap:
            weight, current_vertex, next_vertex = heapq.heappop(min_heap)

            if next_vertex not in visited:
                visited.add(next_vertex)
                minimum_spanning_tree.append((current_vertex, next_vertex, weight))

                for edge in self.edges:
                    if edge[0] == next_vertex and edge[1] not in visited:
                        heapq.heappush(min_heap, (edge[2], next_vertex, edge[1]))

                    if edge[1] == next_vertex and edge[0] not in visited:
                        heapq.heappush(min_heap, (edge[2], next_vertex, edge[0]))

        return minimum_spanning_tree


# Пример использования
graph = Graph()
graph.add_edge("A", "B", 1)
graph.add_edge("A", "C", 4)
graph.add_edge("B", "C", 2)
graph.add_edge("B", "D", 5)
graph.add_edge("C", "D", 1)
graph.add_edge("D", "A", 7)

result = graph.prim()
print("Minimum Spanning Tree (Prim's algorithm):", result)