class Node:
    """
    Initializes a new instance of the class.
    Parameters:
        data (type): The data to be assigned to the 'data' attribute.
    Returns:
        None
    """
    def __init__(self, data):
        self.data = data
        self.prev = None
        self.next = None


class DoublyLinkedList:
    """
    Initializes a new instance of the class.
    This function does not take any parameters.
    Parameters:
        None
    Returns:
        None
    """
    def __init__(self):
        self.head = None
    """
    Check if the linked list is empty.
    Returns:
        bool: True if the linked list is empty, False otherwise.
    """
    def is_empty(self):
        return self.head is None
    """
    Insert a new node at the beginning of the linked list.
    Parameters:
        data (any): The data to be inserted into the new node.
    Returns:
        None
    """
    def insert_at_beginning(self, data):
        new_node = Node(data)
        if self.is_empty():
            self.head = new_node
        else:
            new_node.next = self.head
            self.head.prev = new_node
            self.head = new_node
    """
    Inserts a new node with the given data at the end of the doubly linked list.
    Parameters:
        data (any): The data to be stored in the new node.
    Returns:
        None
    """
    def insert_at_end(self, data):
        new_node = Node(data)
        if self.is_empty():
            self.head = new_node
        else:
            current = self.head
            while current.next:
                current = current.next
            current.next = new_node
            new_node.prev = current
    """
    Delete the node at the beginning of the linked list.
    Returns:
        The data of the deleted node.
    Raises:
        None.
    """
    def delete_at_beginning(self):
        if self.is_empty():
            return None
        else:
            temp = self.head
            self.head = self.head.next
            self.head.prev = None
            temp.next = None
            return temp.data
    """
    Deletes the last element in the doubly linked list.
    Returns:
        The data of the deleted element.
    Raises:
        None.
    """
    def delete_at_end(self):
        if self.is_empty():
            return None
        else:
            current = self.head
            while current.next:
                current = current.next
            temp = current
            current.prev.next = None
            current.prev = None
            return temp.data
    """
    Prints the elements of the Doubly Linked List.
    Parameters:
        None
    Returns:
        None
    """
    def display(self):
        if self.is_empty():
            print("Doubly Linked List is empty.")
        else:
            current = self.head
            while current:
                print(current.data, end=" ")
                current = current.next
            print()