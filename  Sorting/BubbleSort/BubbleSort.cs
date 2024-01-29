using System;

class BubbleSort
{
    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", arr));

        BubbleSortAlgorithm(arr);

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", arr));
    }

    static void BubbleSortAlgorithm(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Меняем порядок, если элементы находятся в неправильном порядке
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}