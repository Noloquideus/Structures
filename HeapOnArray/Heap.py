class Heap:
    """
    Initializes a new instance of the class.
    Parameters:
        None
    Returns:
            None
    """
    def __init__(self):
        self.heap = []
    """
    Insert an item into the heap.
    Parameters:
        item (Any): The item to be inserted into the heap.
    Returns:
        None
    """
    def insert(self, item):
        self.heap.append(item)
        self._percolate_up(len(self.heap) - 1)
    """
    Delete the root element from the heap and return it.
    Returns:
        object: The root element of the heap.
    Raises:
        IndexError: If the heap is empty.
    """
    def delete(self):
        if not self.is_empty():
            root = self.heap[0]
            self.heap[0] = self.heap[-1]
            self.heap.pop()
            self._percolate_down(0)
            return
    """
    Check if the heap is empty.
    Returns:
        bool: True if the heap is empty, False otherwise.
    """
    def is_empty(self):
        return len(self.heap) == 0
    """
    Returns the size of the heap.
    :return: The number of elements in the heap.
    """
    def size(self):
        return len(self.heap)
    """
    Percolates the element at the given index up the heap until the heap property is satisfied.
    Parameters:
        index (int): The index of the element to percolate up.
    Returns:
        None
    """
    def _percolate_up(self, index):
        parent = (index - 1) // 2
        if index <= 0:
            return
        elif self.heap[index] < self.heap[parent]:
            self.heap[index], self.heap[parent] = self.heap[parent], self.heap[index]
            self._percolate_up(parent)
    """
    Percolates down the element at the given index in the heap.
    Parameters:
        index (int): The index of the element to be percolated down.
    Returns:
        None
    """
    def _percolate_down(self, index):
        left_child = 2 * index + 1
        right_child = 2 * index + 2
        smallest = index

        if left_child < len(self.heap) and self.heap[left_child] < self.heap[smallest]:
            smallest = left_child

        if right_child < len(self.heap) and self.heap[right_child] < self.heap[smallest]:
            smallest = right_child

        if smallest != index:
            self.heap[index], self.heap[smallest] = self.heap[smallest], self.heap[index]
            self._percolate_down(smallest)