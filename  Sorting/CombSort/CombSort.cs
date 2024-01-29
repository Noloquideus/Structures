using System;

class CombSort
{
    static void Main()
    {
        int[] arr = {64, 34, 25, 12, 22, 11, 90};
        Console.Write("Исходный массив: ");
        PrintArray(arr);

        CombSortAlgorithm(arr);

        Console.Write("\nОтсортированный массив: ");
        PrintArray(arr);
    }

    static void CombSortAlgorithm(int[] arr)
    {
        int n = arr.Length;
        int gap = n;
        double shrinkFactor = 1.3;
        bool swapped;

        do
        {
            gap = (int)(gap / shrinkFactor);
            if (gap < 1)
            {
                gap = 1;
            }

            swapped = false;
            for (int i = 0; i + gap < n; i++)
            {
                if (arr[i] > arr[i + gap])
                {
                    Swap(ref arr[i], ref arr[i + gap]);
                    swapped = true;
                }
            }
        } while (gap > 1 || swapped);
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}