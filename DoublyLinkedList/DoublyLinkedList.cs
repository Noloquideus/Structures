namespace Struct.DoublyLinkedList;


public class DoublyLinkedList
{
    private Node? _head;
    // Check if the linked list is empty.
    public bool IsEmpty()
    {
        return _head == null;
    }

    public void Append(int data)
    {
        Node? newNode = new Node(data);

        if (IsEmpty())
        {
            _head = newNode;
        }
        else
        {
            var current = _head;
            while (current?.Next != null)
            {
                current = current.Next;
            }

            if (current == null) return;
            current.Next = newNode;
            newNode.Prev = current;
        }
    }

    public void Prepend(int data)
    {
        var newNode = new Node(data);

        if (IsEmpty())
        {
            _head = newNode;
        }
        else
        {
            newNode.Next = _head;
            if (_head != null) _head.Prev = newNode;
            _head = newNode;
        }
    }
    /*
      Deletes the first occurrence of the specified data from the linked list. 
     Parameters:
       data:
         The data to be deleted. 
     Returns:
         None.
     */

    public void Delete(int data)
    {
        if (IsEmpty())
        {
            return;
        }

        var current = _head;

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
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }

                return;
            }

            current = current.Next;
        }
    }
    // Displays the elements of the doubly linked list.

    public void Display()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Doubly linked list is empty");
            return;
        }

        var current = _head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}