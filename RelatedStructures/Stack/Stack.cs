using System;
using System.Collections.Generic;

class Stack<T>
{
    private List<T> items = new List<T>();

    public bool IsEmpty()
    {
        return items.Count == 0;
    }

    public void Push(T item)
    {
        items.Add(item);
    }

    public T Pop()
    {
        if (!IsEmpty())
        {
            int lastIndex = items.Count - 1;
            T poppedItem = items[lastIndex];
            items.RemoveAt(lastIndex);
            return poppedItem;
        }
        else
        {
            return default(T);
        }
    }

    public T Peek()
    {
        if (!IsEmpty())
        {
            return items[items.Count - 1];
        }
        else
        {
            return default(T);
        }
    }

    public int Size()
    {
        return items.Count;
    }
}