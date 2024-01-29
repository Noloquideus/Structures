using System;

class FibonacciSearch
{
    static int FibonacciSearchAlgorithm(int[] arr, int target)
    {
        int n = arr.Length;
        int[] fibNumbers = GenerateFibonacciNumbers(n);
        int offset = -1;

        while (fibNumbers[fibNumbers.Length - 1] > 1)
        {
            int i = MinOf(offset + fibNumbers[fibNumbers.Length - 2], n - 1);

            if (arr[i] < target)
            {
                fibNumbers = ResizeArray(fibNumbers, fibNumbers.Length - 2);
                offset = i;
            }
            else if (arr[i] > target)
            {
                fibNumbers = ResizeArray(fibNumbers, fibNumbers.Length - 1);
            }
            else
            {
                return i;
            }
        }

        if (fibNumbers[fibNumbers.Length - 1] == 1 && arr[offset + 1] == target)
        {
            return offset + 1;
        }

        return -1;
    }

    static int[] GenerateFibonacciNumbers(int n)
    {
        var fibNumbers = new int[] { 0, 1 };

        while (fibNumbers[fibNumbers.Length - 1] < n)
        {
            int nextFib = fibNumbers[fibNumbers.Length - 1] + fibNumbers[fibNumbers.Length - 2];
            Array.Resize(ref fibNumbers, fibNumbers.Length + 1);
            fibNumbers[fibNumbers.Length - 1] = nextFib;
        }

        return fibNumbers;
    }

    static int MinOf(int a, int b)
    {
        return a < b ? a : b;
    }

    static int[] ResizeArray(int[] arr, int newSize)
    {
        Array.Resize(ref arr, newSize);
        return arr;
    }