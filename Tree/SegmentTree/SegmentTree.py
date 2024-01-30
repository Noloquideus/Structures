class SegmentTree:
    def __init__(self, arr):
        self.n = len(arr)
        self.tree = [0] * (2 * self.n)
        self.construct_tree(arr, 0, self.n - 1, 0)

    def construct_tree(self, arr, low, high, pos):
        if low == high:
            self.tree[pos] = arr[low]
            return

        mid = (low + high) // 2
        self.construct_tree(arr, low, mid, 2 * pos + 1)
        self.construct_tree(arr, mid + 1, high, 2 * pos + 2)
        self.tree[pos] = self.tree[2 * pos + 1] + self.tree[2 * pos + 2]

    def query(self, qlow, qhigh):
        return self._query(qlow, qhigh, 0, self.n - 1, 0)

    def _query(self, qlow, qhigh, low, high, pos):
        # Total overlap
        if qlow <= low and qhigh >= high:
            return self.tree[pos]

        # No overlap
        if qlow > high or qhigh < low:
            return 0

        # Partial overlap
        mid = (low + high) // 2
        return self._query(qlow, qhigh, low, mid, 2 * pos + 1) + self._query(qlow, qhigh, mid + 1, high, 2 * pos + 2)

    def update(self, index, value):
        diff = value - self.tree[index]
        self.tree[index] = value
        self._update(index, diff, 0, self.n - 1, 0)

    def _update(self, index, diff, low, high, pos):
        if index < low or index > high:
            return

        self.tree[pos] += diff

        if low != high:
            mid = (low + high) // 2
            self._update(index, diff, low, mid, 2 * pos + 1)
            self._update(index, diff, mid + 1, high, 2 * pos + 2)


# Пример использования
arr = [1, 3, 5, 7, 9, 11]
seg_tree = SegmentTree(arr)

# Вывод суммы на отрезке [1, 3] (ожидаем 3 + 5 + 7 = 15)
print("Сумма на отрезке [1, 3]:", seg_tree.query(1, 3))

# Обновление значения в индексе 2 на 10
seg_tree.update(2, 10)

# Вывод суммы на отрезке [1, 3] после обновления (ожидаем 3 + 10 + 7 = 20)
print("Сумма на отрезке [1, 3] после обновления:", seg_tree.query(1, 3))
