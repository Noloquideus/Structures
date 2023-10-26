namespace Struct.HeapOnArray;

public class Heap
{
    private int[] _heap;
    private int _size;
    private int _capacity;
    /*
     Initializes a new instance of the Heap class with the specified capacity. 
     Parameters:
       capacity: The maximum number of elements that the heap can contain.
     Returns:
       None.
     */

    public Heap(int capacity)
    {
        _capacity = capacity;
        _heap = new int[capacity];
        _size = 0;
    }
    /*
     Returns the parent index of the given index in a binary heap.
     Parameters:
       index: The index of the element to find the parent of.
     Returns:
       The index of the parent of the given index.
    */

    private static int GetParentIndex(int index)
    {
        return (index - 1) / 2;
    }
    /*
    Get the index of the left child of the given index.
    Parameters:
       index: The index of the parent node.
    Returns:
       The index of the left child node.
     */

    private int GetLeftChildIndex(int index)
    {
        return 2 * index + 1;
    }
    /*
     Returns the index of the right child node in a binary tree given the index of the parent node. 
    Parameters:
       index: The index of the parent node.
    Returns:
       The index of the right child node.
     */

    private int GetRightChildIndex(int index)
    {
        return 2 * index + 2;
    }
    /*
    Swaps the elements at the specified indices in the heap.
    Parameters:
       index1 - The index of the first element to be swapped.
       index2 - The index of the second element to be swapped.
     Returns:
       None.
    */
    private void Swap(int index1, int index2)
    {
        (_heap[index1], _heap[index2]) = (_heap[index2], _heap[index1]);
    }
    /*
     HeapifyUp is a private void function that performs the operation of moving an element up the heap to its correct position.
    It takes an integer parameter called index, which represents the index of the element to be heapified.
    The function first calculates the parent index of the current element using the GetParentIndex method.
    If the parent index is less than 0 or the value of the current element is greater than or equal to the value of the parent element, the function returns without performing any further operations.
    Otherwise, the function swaps the current element with its parent element using the Swap method and recursively calls itself with the parent index as the parameter.
     */

    private void HeapifyUp(int index)
    {
        var parentIndex = GetParentIndex(index);
        if (parentIndex < 0 || _heap[index] >= _heap[parentIndex]) return;
        Swap(index, parentIndex);
        HeapifyUp(parentIndex);
    }
    /*
    HeapifyDown is a private function that performs the heapify down operation on the binary heap.
    It takes an index parameter, which represents the index of the element to be heapified down.
    This function is used to maintain the heap property of the binary heap after removing an element.
    private void HeapifyDown(int index)
     */

    private void HeapifyDown(int index)
    {
        var smallestIndex = index;
        while (true)
        {
            var leftChildIndex = GetLeftChildIndex(index: index);
            var rightChildIndex = GetRightChildIndex(index: index);

            if (leftChildIndex < _size && (smallestIndex >= 0 && smallestIndex < _heap.Length && _heap[leftChildIndex] < _heap[smallestIndex]))
            {
                smallestIndex = leftChildIndex;
            }

            if (rightChildIndex < _size && _heap[rightChildIndex] < _heap[smallestIndex])
            {
                smallestIndex = rightChildIndex;
            }

            if (smallestIndex != index)
            {
                Swap(index, smallestIndex);
                index = smallestIndex;
                continue;
            }

            break;
        }
    }
    /*
    Inserts a value into the heap. 
    Parameters:
       value - The value to be inserted into the heap. 
    Returns:
       None.
     */

    public void Insert(int value)
    {
        if (_size >= _capacity)
        {
            throw new OverflowException("Heap capacity exceeded.");
        }

        _heap[_size] = value;
        HeapifyUp(_size);
        _size++;
    }

    public int ExtractMin()
    {
        if (_size <= 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        int min = _heap[0];
        _heap[0] = _heap[_size - 1];
        _size--;
        HeapifyDown(0);
        return min;
    }
    // Returns the minimum value in the heap without removing it.
    public int PeekMin()
    {
        if (_size <= 0)
        {
            throw new InvalidOperationException("Heap is empty.");
        }

        return _heap[0];
    }
}