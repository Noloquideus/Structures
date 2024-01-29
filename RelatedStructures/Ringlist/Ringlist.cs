using System;

public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

public class CircularLinkedList
{
    private Node Head { get; set; }

    public bool IsEmpty()
    {
        return Head == null;
    }

    public void Append(int data)
    {
        Node newNode = new Node(data);
        if (IsEmpty())
        {
            Head = newNode;
            newNode.Next = Head;
        }
        else
        {
            Node temp = Head;
            while (temp.Next != Head)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Next = Head;
        }
    }

    public void Prepend(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = Head;
        Node temp = Head;
        while (temp.Next != Head)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
        Head = newNode;
    }

    public void Delete(int data)
    {
        if (IsEmpty())
        {
            return;
        }

        if (Head.Data == data)
        {
            if (Head.Next == Head)
            {
                Head = null;
            }
            else
            {
                Node temp = Head;
                while (temp.Next != Head)
                {
                    temp = temp.Next;
                }
                temp.Next = Head.Next;
                Head = Head.Next;
            }
            return;
        }

        Node current = Head;
        Node prev = null;
        while (current.Next != Head)
        {
            if (current.Data == data)
            {
                prev.Next = current.Next;
                return;
            }
            prev = current;
            current = current.Next;
        }

        if (current.Data == data)
        {
            prev.Next = Head;
        }
    }

    public bool Search(int data)
    {
        if (IsEmpty())
        {
            return false;
        }

        Node temp = Head;
        while (temp.Next != Head)
        {
            if (temp.Data == data)
            {
                return true;
            }
            temp = temp.Next;
        }

        return temp.Data == data;
    }

    public int Count()
    {
        if (IsEmpty())
        {
            return 0;
        }

        int count = 0;
        Node temp = Head;
        while (temp.Next != Head)
        {
            count++;
            temp = temp.Next;
        }

        return count + 1;
    }

    public void InsertAtIndex(int index, int data)
    {
        if (index < 0)
        {
            throw new ArgumentException("Index must be non-negative");
        }

        Node newNode = new Node(data);

        if (index == 0)
        {
            Prepend(data);
            return;
        }
        else if (index == Count())
        {
            Append(data);
            return;
        }

        Node current = Head;
        for (int i = 0; i < index - 1; i++)
        {
            if (current.Next == Head)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            current = current.Next;
        }

        newNode.Next = current.Next;
        current.Next = newNode;
    }

    public void RemoveAtIndex(int index)
    {
        if (index < 0)
        {
            throw new ArgumentException("Index must be non-negative");
        }

        if (index == 0)
        {
            if (Head == null)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            Head = Head.Next;
            return;
        }

        Node current = Head;
        Node prev = null;
        for (int i = 0; i < index; i++)
        {
            if (current.Next == Head)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            prev = current;
            current = current.Next;
        }

        prev.Next = current.Next;
    }

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Circular Linked List is empty.");
            return;
        }
        Node temp = Head;
        do
        {
            Console.Write($"{temp.Data} -> ");
            temp = temp.Next;
        } while (temp != Head);
        Console.WriteLine("(head)");
    }
}