namespace Struct;


class QuickSort
{
    /*
    Sorts an array of integers using the QuickSort algorithm. 
    Parameters:
       array - The array of integers to be sorted. 
    Returns:
       None.
     */
    public static void Sort(int[] array)
    {
        QuickSortRecursive(array, 0, array.Length - 1);
    }
    /*
    Sorts an array in ascending order using the QuickSort algorithm.
    The function is recursive and operates on a subarray defined by
    the low and high indices.
    Parameters:
       array - The array to be sorted.
       low - The lowest index of the subarray to be sorted.
       high - The highest index of the subarray to be sorted.
    Returns:
       None.
     */

    private static void QuickSortRecursive(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            QuickSortRecursive(array, low, pivotIndex - 1);
            QuickSortRecursive(array, pivotIndex + 1, high);
        }
    }
    /*
    Partitions an array using the QuickSort algorithm. 
    Parameters:
       array: The array to be partitioned.
       low: The starting index of the partition.
       high: The ending index of the partition.
    Returns:
       The index of the pivot after partitioning.
     */

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }
    /*
    Swaps the elements at the specified indices in the given array.
    Parameters:
       array: The array in which to swap elements.
       i: The index of the first element to be swapped.
       j: The index of the second element to be swapped.
    Returns:
       None.
     */

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}
