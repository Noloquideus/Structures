using System;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

public class DoublyLinkedList
{
    private Node Head { get; set; }
    private Node Tail { get; set; }

    public bool IsEmpty()
    {
        return Head == null;
    }

    public void Append(int data)
    {
        Node newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Prev = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }
    }

    public void Prepend(int data)
    {
        Node newNode = new Node(data);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            newNode.Next = Head;
            Head.Prev = newNode;
            Head = newNode;
        }
    }

    public void Delete(int data)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Data == data)
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    Head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    Tail = current.Prev;
                }

                return;
            }
            current = current.Next;
        }
    }

    public void Display()
    {
        Node current = Head;
        while (current != null)
        {
            Console.Write($"{current.Data} <-> ");
            current = current.Next;
        }
        Console.WriteLine("None");
    }
}