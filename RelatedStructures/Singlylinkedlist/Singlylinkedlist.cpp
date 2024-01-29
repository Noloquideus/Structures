#include <iostream>

class Node
{
public:
    int data;
    Node* next;

    Node(int data)
    {
        this->data = data;
        this->next = nullptr;
    }

    ~Node()
    {
        delete next;
    }
};

class LinkedList
{
private:
    Node* head;
    Node* tail;

public:
    LinkedList()
    {
        head = nullptr;
        tail = nullptr;
    }

    ~LinkedList()
    {
        delete head;
    }

    bool IsEmpty()
    {
        return head == nullptr;
    }

    void Append(int data)
    {
        Node* newNode = new Node(data);
        if (head == nullptr)
        {
            head = newNode;
            tail = newNode;
            return;
        }
        tail->next = newNode;
        tail = newNode;
    }

    void Prepend(int data)
    {
        Node* newNode = new Node(data);
        newNode->next = head;
        head = newNode;
        if (tail == nullptr)
        {
            tail = newNode;
        }
    }

    void Delete(int data)
    {
        if (head == nullptr)
        {
            return;
        }

        if (head->data == data)
        {
            Node* temp = head;
            head = head->next;
            temp->next = nullptr;
            delete temp;
            if (head == nullptr)
            {
                tail = nullptr;
            }
            return;
        }

        Node* current = head;
        while (current->next != nullptr && current->next->data != data)
        {
            current = current->next;
        }

        if (current->next != nullptr)
        {
            Node* temp = current->next;
            current->next = current->next->next;
            temp->next = nullptr;
            delete temp;
            if (current->next == nullptr)
            {
                tail = current;
            }
        }
    }

    void Display()
    {
        Node* current = head;
        while (current != nullptr)
        {
            std::cout << current->data << " -> ";
            current = current->next;
        }
        std::cout << "None" << std::endl;
    }
};