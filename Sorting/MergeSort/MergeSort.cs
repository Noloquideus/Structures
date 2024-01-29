using System;

class MergeSort
{
    static void Main()
    {
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine("Исходный массив: " + string.Join(", ", arr));

        MergeSortAlgorithm(arr, 0, arr.Length - 1);

        Console.WriteLine("Отсортированный массив: " + string.Join(", ", arr));
    }

    static void MergeSortAlgorithm(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

            MergeSortAlgorithm(arr, left, mid);
            MergeSortAlgorithm(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftHalf = new int[n1];
        int[] rightHalf = new int[n2];

        Array.Copy(arr, left, leftHalf, 0, n1);
        Array.Copy(arr, mid + 1, rightHalf, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (leftHalf[i] <= rightHalf[j])
            {
                arr[k] = leftHalf[i];
                i++;
            }
            else
            {
                arr[k] = rightHalf[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            arr[k] = leftHalf[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = rightHalf[j];
            j++;
            k++;
        }
    }
}