namespace Struct.Stack;

class Stack
{
    private readonly int _maxSize;
    private int _top;
    private readonly int[] _stackArray;
    
    /*
     Initializes a new instance of the Stack class with the specified size.
    Parameters:
    size:
    The maximum size of the stack.
    */ 

    public Stack(int size)
    {
        _maxSize = size;
        _top = -1;
        _stackArray = new int[_maxSize];
    }

    // Pushes an integer value onto the stack.
    public void Push(int value)
    {
        if (_top == _maxSize - 1)
        {
            Console.WriteLine("Стек полон. Невозможно добавить элемент.");
            return;
        }

        _stackArray[++_top] = value;
    }
    /*
    Pop function pops the top element from the stack and returns it.
    If the stack is empty, it prints an error message and returns -1.
    Returns:
         The top element of the stack if the stack is not empty.
         -1 if the stack is empty.
    */
    public int Pop()
    {
        if (_top == -1)
        {
            Console.WriteLine("Стек пуст. Невозможно извлечь элемент.");
            return -1;
        }

        return _stackArray[_top--];
    }
    /*
    Retrieves the top element from the stack without removing it.
    Returns:
          The top element of the stack.
          If the stack is empty, returns -1 and prints an error message.
     */
    public int Peek()
    {
        if (_top == -1)
        {
            Console.WriteLine("Стек пуст. Невозможно получить элемент.");
            return -1;
        }

        return _stackArray[_top];
    }

    public bool IsEmpty()
    {
        return (_top == -1);
    }

    public bool IsFull()
    {
        return (_top == _maxSize - 1);
    }
}