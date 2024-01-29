using System;

class SelectionSort
{
    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", arr));

        SelectionSortAlgorithm(arr);

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", arr));
    }

    static void SelectionSortAlgorithm(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            // Меняем минимальный элемент с текущим элементом
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }
}