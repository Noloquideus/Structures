using System;

class QuickSort
{
    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", arr));

        QuickSortAlgorithm(arr, 0, arr.Length - 1);

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", arr));
    }

    static void QuickSortAlgorithm(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSortAlgorithm(arr, low, pi - 1);
            QuickSortAlgorithm(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp1;

        return i + 1;
    }
}