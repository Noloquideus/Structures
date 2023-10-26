class Queue:
    """
    Initializes the object by creating an empty queue.
    Parameters:
        self: The object itself.
    Return:
        None
    """
    def __init__(self):
        self.queue = []
    """
    Adds an item to the end of the queue.
    Parameters:
        item: The item to be added to the queue.
     Returns:
        None
    """
    def enqueue(self, item):
        self.queue.append(item)
    """
    Remove and return the first element in the queue.
    Parameters:
            None
    Returns:
            The first element in the queue if the queue is not empty, otherwise None.
    """
    def dequeue(self):
        if not self.is_empty():
            return self.queue.pop(0)
    """
    Check if the queue is empty.
    Returns:
        bool: True if the queue is empty, False otherwise.
    """
    def is_empty(self):
        return len(self.queue) == 0
    """
    Returns the size of the queue.
    :return: An integer representing the number of elements in the queue.
    """

    def size(self):
        return len(self.queue)