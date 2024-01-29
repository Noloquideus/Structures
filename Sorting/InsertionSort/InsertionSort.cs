using System;

class InsertionSort
{
    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", arr));

        InsertionSortAlgorithm(arr);

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", arr));
    }

    static void InsertionSortAlgorithm(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && key < arr[j])
            {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }
}