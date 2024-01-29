#include <iostream>

template <typename T>
class Queue {
private:
    struct Node {
        T data;
        Node* next;
        Node(T item) : data(item), next(nullptr) {}
    };

    Node* front;
    Node* rear;

public:
    Queue() : front(nullptr), rear(nullptr) {}

    bool IsEmpty() {
        return front == nullptr;
    }

    void Enqueue(T item) {
        Node* newNode = new Node(item);
        if (IsEmpty()) {
            front = rear = newNode;
        } else {
            rear->next = newNode;
            rear = newNode;
        }
    }

    T Dequeue() {
        if (IsEmpty()) {
            std::cout << "Queue is empty" << std::endl;
            return T();
        } else {
            T dequeuedItem = front->data;
            Node* temp = front;
            front = front->next;
            delete temp;
            return dequeuedItem;
        }
    }

    int Size() {
        int count = 0;
        Node* temp = front;
        while (temp != nullptr) {
            count++;
            temp = temp->next;
        }
        return count;
    }
};