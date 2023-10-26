namespace Struct.MergeSort;

class MergeSort
{
    /*
    Merge function merges two subarrays of arr[]. 
    First subarray is arr[left..mid] 
    Second subarray is arr[mid+1..right]
    Parameters:
       arr: The array containing the subarrays to be merged.
       left: The starting index of the first subarray.
       mid: The ending index of the first subarray.
       right: The ending index of the second subarray.
     */
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        for (int i = 0; i < n1; ++i)
            leftArr[i] = arr[left + i];

        for (int j = 0; j < n2; ++j)
            rightArr[j] = arr[mid + 1 + j];

        int k = left;
        int i1 = 0;
        int i2 = 0;

        while (i1 < n1 && i2 < n2)
        {
            if (leftArr[i1] <= rightArr[i2])
            {
                arr[k] = leftArr[i1];
                i1++;
            }
            else
            {
                arr[k] = rightArr[i2];
                i2++;
            }

            k++;
        }

        while (i1 < n1)
        {
            arr[k] = leftArr[i1];
            i1++;
            k++;
        }

        while (i2 < n2)
        {
            arr[k] = rightArr[i2];
            i2++;
            k++;
        }
    }
    /*
    Sorts an array using the merge sort algorithm.
    Parameters:
       arr: The array to be sorted.
       left: The starting index of the subarray.
       right: The ending index of the subarray.
    Returns:
       None.
     */

    static void MergeSortAlgorithm(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            MergeSortAlgorithm(arr, left, mid);
            MergeSortAlgorithm(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }
}