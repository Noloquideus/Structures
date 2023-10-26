namespace Struct.Queue;

using System;

class Queue
{
    private int _maxSize;
    private int _front;
    private int _rear;
    private int[] _queueArray;

    public Queue(int size)
    {
        _maxSize = size;
        _front = -1;
        _rear = -1;
        _queueArray = new int[_maxSize];
    }

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