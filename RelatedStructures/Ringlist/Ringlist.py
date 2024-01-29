class Node:
    def __init__(self, data):
        self.data = data
        self.next = None

class CircularLinkedList:
    def __init__(self):
        self.head = None

    def is_empty(self):
        return self.head is None

    def append(self, data):
        new_node = Node(data)
        if self.is_empty():
            self.head = new_node
            new_node.next = self.head
        else:
            temp = self.head
            while temp.next != self.head:
                temp = temp.next
            temp.next = new_node
            new_node.next = self.head

    def prepend(self, data):
        new_node = Node(data)
        new_node.next = self.head
        temp = self.head
        while temp.next != self.head:
            temp = temp.next
        temp.next = new_node
        self.head = new_node

    def delete(self, data):
        if self.is_empty():
            return

        if self.head.data == data:
            if self.head.next == self.head:
                self.head = None
            else:
                temp = self.head
                while temp.next != self.head:
                    temp = temp.next
                temp.next = self.head.next
                self.head = self.head.next
            return

        current = self.head
        prev = None
        while current.next != self.head:
            if current.data == data:
                prev.next = current.next
                return
            prev = current
            current = current.next

        if current.data == data:
            prev.next = self.head

    def search(self, data):
        if self.is_empty():
            return False

        temp = self.head
        while temp.next != self.head:
            if temp.data == data:
                return True
            temp = temp.next

        return temp.data == data

    def count(self):
        if self.is_empty():
            return 0

        count = 0
        temp = self.head
        while temp.next != self.head:
            count += 1
            temp = temp.next

        return count + 1

    def insert_at_index(self, index, data):
        if index < 0:
            raise ValueError("Index must be non-negative")

        new_node = Node(data)

        if index == 0:
            self.prepend(data)
            return
        elif index == self.count():
            self.append(data)
            return

        current = self.head
        for _ in range(index - 1):
            if current.next == self.head:
                raise IndexError("Index out of range")
            current = current.next

        new_node.next = current.next
        current.next = new_node

    def remove_at_index(self, index):
        if index < 0:
            raise ValueError("Index must be non-negative")

        if index == 0:
            if self.head is None:
                raise IndexError("Index out of range")
            self.head = self.head.next
            return

        current = self.head
        prev = None
        for _ in range(index):
            if current.next == self.head:
                raise IndexError("Index out of range")
            prev = current
            current = current.next

        prev.next = current.next

    def display(self):
        if self.is_empty():
            print("Circular Linked List is empty.")
            return
        temp = self.head
        while True:
            print(temp.data, end=" -> ")
            temp = temp.next
            if temp == self.head:
                break
        print(" (head)")