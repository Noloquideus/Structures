INF = float('inf')

def floyd_warshall(graph):
    V = len(graph)
    dist = [[INF] * V for _ in range(V)]

    for i in range(V):
        for j in range(V):
            if i == j:
                dist[i][j] = 0
            elif graph[i][j] is not None:
                dist[i][j] = graph[i][j]

    for k in range(V):
        for i in range(V):
            for j in range(V):
                if dist[i][k] != INF and dist[k][j] != INF and dist[i][k] + dist[k][j] < dist[i][j]:
                    dist[i][j] = dist[i][k] + dist[k][j]

    return dist


# Пример использования
graph = [
    [0, 3, None, 7],
    [8, 0, 2, None],
    [5, None, 0, 1],
    [2, None, None, 0]
]

result = floyd_warshall(graph)
print("Матрица кратчайших путей:")
for row in result:
    print(row)