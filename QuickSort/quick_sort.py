"""
Sorts a given list in ascending order using the quicksort algorithm.
Parameters:
    arr (List): The list to be sorted.
Returns:
    List: The sorted list in ascending order.
Example:
    arr = [4, 2, 7, 1, 9]
    quick_sort(arr)
    [1, 2, 4, 7, 9]
"""


def quick_sort(arr):
    if len(arr) <= 1:
        return arr

    pivot = arr[len(arr) // 2]
    left = [x for x in arr if x < pivot]
    middle = [x for x in arr if x == pivot]
    right = [x for x in arr if x > pivot]

    return quick_sort(left) + middle + quick_sort(right)