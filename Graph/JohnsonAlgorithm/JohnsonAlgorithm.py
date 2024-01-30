import heapq

INF = float('inf')

def johnson(graph):
    V = len(graph)

    # Шаг 1: Добавляем вершину s и соединяем её со всеми оригинальными вершинами
    graph.append([(V, 0) for _ in range(V)])

    # Шаг 2: Применяем алгоритм Беллмана-Форда для нахождения кратчайших путей от вершины s
    dist_s = [INF] * (V + 1)
    dist_s[V] = 0

    for _ in range(V):
        for u in range(V + 1):
            for v, weight in graph[u]:
                if dist_s[u] != INF and dist_s[u] + weight < dist_s[v]:
                    dist_s[v] = dist_s[u] + weight

    # Проверка наличия отрицательных циклов
    for u in range(V):
        for v, weight in graph[u]:
            if dist_s[u] != INF and dist_s[u] + weight < dist_s[v]:
                raise ValueError("Граф содержит отрицательный цикл")

    # Шаг 3: Удаляем добавленную вершину s и корректируем веса рёбер графа
    graph.pop()
    for u in range(V):
        for i in range(len(graph[u])):
            v, weight = graph[u][i]
            graph[u][i] = (v, weight + dist_s[u] - dist_s[v])

    # Шаг 4: Применяем алгоритм Дейкстры для каждой вершины графа
    all_shortest_paths = []
    for u in range(V):
        dist_u = dijkstra(graph, u)
        all_shortest_paths.append(dist_u)

    return all_shortest_paths

def dijkstra(graph, start):
    V = len(graph)
    dist = [INF] * V
    dist[start] = 0
    heap = [(0, start)]

    while heap:
        current_dist, u = heapq.heappop(heap)

        if current_dist > dist[u]:
            continue

        for v, weight in graph[u]:
            if dist[u] + weight < dist[v]:
                dist[v] = dist[u] + weight
                heapq.heappush(heap, (dist[v], v))

    return dist

# Пример использования
graph = [
    [(1, -2), (2, 4)],
    [(2, 3), (3, 2)],
    [(0, -1)],
    []
]

result = johnson(graph)
print("Матрица кратчайших путей:")
for row in result:
    print(row)