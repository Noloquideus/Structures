using System;

class CountingSort
{
    static void Main()
    {
        int[] arr = {4, 2, 10, 5, 3, 1};
        Console.Write("Исходный массив: ");
        PrintArray(arr);

        CountingSortAlgorithm(arr);

        Console.Write("\nОтсортированный массив: ");
        PrintArray(arr);
    }

    static void CountingSortAlgorithm(int[] arr)
    {
        int max = arr[0];
        int min = arr[0];

        foreach (int num in arr)
        {
            max = Math.Max(max, num);
            min = Math.Min(min, num);
        }

        int range = max - min + 1;

        int[] count = new int[range];
        int[] output = new int[arr.Length];

        foreach (int num in arr)
        {
            count[num - min]++;
        }

        for (int i = 1; i < range; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            output[count[arr[i] - min] - 1] = arr[i];
            count[arr[i] - min]--;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = output[i];
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
    }
}