class Graph:
    def __init__(self):
        self.vertices = set()
        self.edges = []

    def add_edge(self, start, end, weight):
        self.vertices.add(start)
        self.vertices.add(end)
        self.edges.append((start, end, weight))

    def kruskal(self):
        # Сортируем рёбра по весам
        sorted_edges = sorted(self.edges, key=lambda x: x[2])

        # Инициализируем непересекающиеся множества
        parent = {vertex: vertex for vertex in self.vertices}
        minimum_spanning_tree = []

        # Функция для нахождения корня множества
        def find_set(vertex):
            if vertex != parent[vertex]:
                parent[vertex] = find_set(parent[vertex])
            return parent[vertex]

        # Функция для объединения двух множеств
        def union_sets(root1, root2):
            if root1 != root2:
                parent[root1] = root2

        for edge in sorted_edges:
            start_vertex, end_vertex, weight = edge
            root1 = find_set(start_vertex)
            root2 = find_set(end_vertex)

            # Проверяем, не образует ли добавляемое ребро цикл
            if root1 != root2:
                minimum_spanning_tree.append(edge)
                union_sets(root1, root2)

        return minimum_spanning_tree


# Пример использования
graph = Graph()
graph.add_edge("A", "B", 1)
graph.add_edge("A", "C", 4)
graph.add_edge("B", "C", 2)
graph.add_edge("B", "D", 5)
graph.add_edge("C", "D", 1)
graph.add_edge("D", "A", 7)

result = graph.kruskal()
print("Minimum Spanning Tree (Kruskal's algorithm):", result)