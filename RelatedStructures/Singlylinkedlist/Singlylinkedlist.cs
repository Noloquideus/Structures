using System;

class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList
{
    private Node head;
    private Node tail;

    public LinkedList()
    {
        head = null;
        tail = null;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public void Append(int data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            return;
        }
        tail.Next = newNode;
        tail = newNode;
    }

    public void Prepend(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = head;
        head = newNode;
        if (tail == null)
        {
            tail = newNode;
        }
    }

    public void Delete(int data)
    {
        if (head == null)
        {
            return;
        }

        if (head.Data == data)
        {
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Data != data)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
            if (current.Next == null)
            {
                tail = current;
            }
        }
    }

    public void Display()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("None");
    }
}