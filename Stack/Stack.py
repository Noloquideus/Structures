class Stack:
    """
    Initializes a new instance of the class.
    Parameters:
            self: The object itself.
    Returns:
            None
    """
    def __init__(self):
        self.stack = []
    """
    Check if the stack is empty.
    Returns:
            bool: True if the stack is empty, False otherwise.
    """
    def is_empty(self):
        return len(self.stack) == 0
    """
    Pushes an item onto the stack.
    Parameters:
            item (any): The item to be pushed onto the stack.
    Returns:
            None
    """

    def push(self, item):
        self.stack.append(item)
    """
    Removes and returns the top element of the stack.
    Parameters:
            None
    Returns:
            The top element of the stack, or None if the stack is empty.
    """
    def pop(self):
        if self.is_empty():
            return None
        return self.stack.pop()
    """
    Returns the top element of the stack without removing it.
    Returns:
            The top element of the stack, or None if the stack is empty.
    """

    def peek(self):
        if self.is_empty():
            return None
        return self.stack[-1]
    """
    Returns the size of the stack.
    Returns:
            int: The size of the stack.
    """
    def size(self):
        return len(self.stack)