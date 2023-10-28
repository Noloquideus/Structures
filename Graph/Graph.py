class Graph:
    def __init__(self, vertices):
        self.vertices = vertices
        self.adjacency_list = [[] for _ in range(vertices)]

    def add_edge(self, source, destination):
        self.adjacency_list[source].append(destination)
        self.adjacency_list[destination].append(source)

    def bfs(self, start_vertex):
        visited = [False] * self.vertices
        queue = Queue()

        visited[start_vertex] = True
        queue.enqueue(start_vertex)

        while not queue.is_empty():
            current_vertex = queue.dequeue()
            print(current_vertex, end=" ")

            for neighbor in self.adjacency_list[current_vertex]:
                if not visited[neighbor]:
                    visited[neighbor] = True
                    queue.enqueue(neighbor)

    def dfs(self, start_vertex):
        visited = [False] * self.vertices
        stack = Stack()

        stack.push(start_vertex)

        while not stack.is_empty():
            current_vertex = stack.pop()

            if not visited[current_vertex]:
                visited[current_vertex] = True
                print(current_vertex, end=" ")

                for neighbor in self.adjacency_list[current_vertex]:
                    stack.push(neighbor)