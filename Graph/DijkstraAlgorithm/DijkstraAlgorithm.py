import heapq


class Graph:
    def __init__(self):
        self.vertices = set()
        self.edges = defaultdict(list)

    def add_edge(self, start, end, weight):
        self.vertices.add(start)
        self.vertices.add(end)
        self.edges[start].append((end, weight))

    def dijkstra(self, start):
        distances = {vertex: float('infinity') for vertex in self.vertices}
        distances[start] = 0
        priority_queue = [(0, start)]

        while priority_queue:
            current_distance, current_vertex = heapq.heappop(priority_queue)

            if current_distance > distances[current_vertex]:
                continue

            for neighbor, weight in self.edges[current_vertex]:
                distance = current_distance + weight

                if distance < distances[neighbor]:
                    distances[neighbor] = distance
                    heapq.heappush(priority_queue, (distance, neighbor))

        return distances


# Пример использования
graph = Graph()
graph.add_edge("A", "B", 1)
graph.add_edge("A", "C", 4)
graph.add_edge("B", "C", 2)
graph.add_edge("B", "D", 5)
graph.add_edge("C", "D", 1)
graph.add_edge("D", "A", 7)

start_vertex = "A"
result = graph.dijkstra(start_vertex)
print(f"Shortest distances from vertex {start_vertex}: {result}")
