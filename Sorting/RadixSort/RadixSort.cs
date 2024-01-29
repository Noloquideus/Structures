using System;

class Program
{
    static void CountingSort(int[] arr, int exp)
    {
        int n = arr.Length;
        int[] output = new int[n];
        int[] count = new int[10];

        for (int i = 0; i < n; i++)
        {
            int index = arr[i] / exp;
            count[index % 10]++;
        }

        for (int i = 1; i < 10; i++)
        {
            count[i] += count[i - 1];
        }

        for (int i = n - 1; i >= 0; i--)
        {
            int index = arr[i] / exp;
            output[count[index % 10] - 1] = arr[i];
            count[index % 10]--;
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }

    static void RadixSort(int[] arr)
    {
        int maxNum = arr[0];
        int n = arr.Length;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > maxNum)
            {
                maxNum = arr[i];
            }
        }

        for (int exp = 1; maxNum / exp > 0; exp *= 10)
        {
            CountingSort(arr, exp);
        }
    }

    static void Main()
    {
        int[] myArray = { 170, 45, 75, 90, 802, 24, 2, 66 };
        RadixSort(myArray);
        Console.WriteLine(string.Join(", ", myArray));
    }
}