def bucket_sort(arr):
    buckets = []
    for i in range(len(arr)):
        buckets.append([])

    # Распределение элементов по корзинам
    for num in arr:
        index = int(num * 10)  # Пример критерия распределения
        buckets[index].append(num)

    sorted_array = []
    # Сортировка внутри каждой корзины (можно использовать другой алгоритм сортировки)
    for bucket in buckets:
        sorted_array.extend(sorted(bucket))

    return sorted_array