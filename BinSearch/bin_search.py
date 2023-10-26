"""
Perform a binary search on a sorted array to find the index of a target element.
Parameters:
    arr (List[int]): The sorted array to search in.
    target (int): The element to search for.
Returns:
    int: The index of the target element if found, otherwise -1.
"""


def binary_search(arr, target):
    low = 0
    high = len(arr) - 1

    while low <= high:
        mid = (low + high) // 2
        if arr[mid] == target:
            return mid
        elif arr[mid] < target:
            low = mid + 1
        else:
            high = mid - 1

    return -1