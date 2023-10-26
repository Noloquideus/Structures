namespace Struct.Queue;

using System;

class Queue
{
    private int _maxSize;
    private int _front;
    private int _rear;
    private int[] _queueArray;

    /**
     Initializes a new instance of the Queue class with the specified size.
    Parameters:
          size: The maximum number of elements that the queue can hold.
    Remarks:
         This constructor sets the initial state of the queue. The size parameter
         determines the maximum number of elements that the queue can hold.
         The queue is initially empty, with both the front and rear pointers
         set to -1. The _queueArray is also initialized with the specified size.
     */
    public Queue(int size)
    {
        _maxSize = size;
        _front = -1;
        _rear = -1;
        _queueArray = new int[_maxSize];
    }
    // Enqueues an integer value into the queue.

    public void Enqueue(int value)
    {
        if (_rear == _maxSize - 1)
        {
            Console.WriteLine("Очередь полна. Невозможно добавить элемент.");
            return;
        }

        _queueArray[++_rear] = value;

        if (_front == -1)
        {
            _front = 0;
        }
    }
    // Dequeues an element from the queue and returns it.
    // If the queue is empty, a message is displayed and -1 is returned.

    public int Dequeue()
    {
        if (_front == -1 || _front > _rear)
        {
            Console.WriteLine("Очередь пуста. Невозможно извлечь элемент.");
            return -1;
        }

        int value = _queueArray[_front++];

        if (_front > _rear)
        {
            _front = -1;
            _rear = -1;
        }

        return value;
    }
    // Retrieves the element at the front of the queue without removing it.

    public int Peek()
    {
        if (_front == -1 || _front > _rear)
        {
            Console.WriteLine("Очередь пуста. Невозможно получить элемент.");
            return -1;
        }

        return _queueArray[_front];
    }

    public bool IsEmpty()
    {
        return (_front == -1 || _front > _rear);
    }

    public bool IsFull()
    {
        return (_rear == _maxSize - 1);
    }
}