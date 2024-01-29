using System;
using System.Collections.Generic;

class Queue<T>
{
    private List<T> items = new List<T>();

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void Enqueue(T item)
    {
        items.Add(item);
    }

    public T Dequeue()
    {
        if (!IsEmpty())
        {
            T dequeuedItem = items[0];
            items.RemoveAt(0);
            return dequeuedItem;
        }
        else
        {
            Console.WriteLine("Queue is empty");
            return default(T);
        }
    }

    public int Size()
    {
        return items.Count;
    }
}