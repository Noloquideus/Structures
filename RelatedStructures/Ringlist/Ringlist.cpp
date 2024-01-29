#include <iostream>

class Node {
public:
    int data;
    Node* next;

    Node(int val) : data(val), next(nullptr) {}
};

class CircularLinkedList {
private:
    Node* head;

public:
    CircularLinkedList() : head(nullptr) {}

    bool isEmpty() {
        return head == nullptr;
    }

    void append(int data) {
        Node* newNode = new Node(data);
        if (isEmpty()) {
            head = newNode;
            newNode->next = head;
        } else {
            Node* temp = head;
            while (temp->next != head) {
                temp = temp->next;
            }
            temp->next = newNode;
            newNode->next = head;
        }
    }

    void prepend(int data) {
        Node* newNode = new Node(data);
        newNode->next = head;
        Node* temp = head;
        while (temp->next != head) {
            temp = temp->next;
        }
        temp->next = newNode;
        head = newNode;
    }

    void deleteNode(int data) {
        if (isEmpty()) {
            return;
        }

        if (head->data == data) {
            if (head->next == head) {
                delete head;
                head = nullptr;
            } else {
                Node* temp = head;
                while (temp->next != head) {
                    temp = temp->next;
                }
                temp->next = head->next;
                delete head;
                head = head->next;
            }
            return;
        }

        Node* current = head;
        Node* prev = nullptr;
        while (current->next != head) {
            if (current->data == data) {
                prev->next = current->next;
                delete current;
                return;
            }
            prev = current;
            current = current->next;
        }

        if (current->data == data) {
            prev->next = head;
            delete current;
        }
    }

    bool search(int data) {
        if (isEmpty()) {
            return false;
        }

        Node* temp = head;
        do {
            if (temp->data == data) {
                return true;
            }
            temp = temp->next;
        } while (temp != head);

        return false;
    }

    int count() {
        if (isEmpty()) {
            return 0;
        }

        int count = 0;
        Node* temp = head;
        do {
            count++;
            temp = temp->next;
        } while (temp != head);

        return count;
    }

    void insertAtIndex(int index, int data) {
        if (index < 0) {
            throw std::invalid_argument("Index must be non-negative");
        }

        Node* newNode = new Node(data);

        if (index == 0) {
            prepend(data);
            return;
        } else if (index == count()) {
            append(data);
            return;
        }

        Node* current = head;
        for (int i = 0; i < index - 1; i++) {
            if (current->next == head) {
                throw std::out_of_range("Index out of range");
            }
            current = current->next;
        }

        newNode->next = current->next;
        current->next = newNode;
    }

    void removeAtIndex(int index) {
        if (index < 0) {
            throw std::invalid_argument("Index must be non-negative");
        }

        if (index == 0) {
            if (head == nullptr) {
                throw std::out_of_range("Index out of range");
            }
            Node* temp = head;
            head = head->next;
            delete temp;
            return;
        }

        Node* current = head;
        Node* prev = nullptr;
        for (int i = 0; i < index; i++) {
            if (current->next == head) {
                throw std::out_of_range("Index out of range");
            }
            prev = current;
            current = current->next;
        }

        prev->next = current->next;
        delete current;
    }

    void display() {
        if (isEmpty()) {
            std::cout << "Circular Linked List is empty." << std::endl;
            return;
        }
        Node* temp = head;
        do {
            std::cout << temp->data << " -> ";
            temp = temp->next;
        } while (temp != head);
        std::cout << "(head)" << std::endl;
    }

    ~CircularLinkedList() {
        while (head != nullptr) {
            Node* temp = head;
            if (head->next == head) {
                delete head;
                head = nullptr;
            } else {
                Node* temp = head;
                while (temp->next != head) {
                    temp = temp->next;
                }
                temp->next = head->next;
                delete head;
                head = head->next;
            }
        }
    }
};