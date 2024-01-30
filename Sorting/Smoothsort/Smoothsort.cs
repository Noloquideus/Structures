using System;

class SmoothSort
{
    public static void StoogeSort(int[] arr, int l, int h)
    {
        if (l >= h)
            return;

        if (arr[l] > arr[h])
            Swap(arr, l, h);

        if (h - l + 1 > 2)
        {
            int t = (h - l + 1) / 3;
            StoogeSort(arr, l, h - t);
            StoogeSort(arr, l + t, h);
            StoogeSort(arr, l, h - t);
        }
    }

    public static void Smoothsort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                Swap(arr, i - 1, i);
                StoogeSort(arr, 0, i);
            }
        }
    }

    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void Main()
    {
        int[] myArray = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
        Smoothsort(myArray);
        Console.WriteLine(string.Join(", ", myArray));
    }
}