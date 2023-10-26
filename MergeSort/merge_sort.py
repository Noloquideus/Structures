"""
Sorts an array using the merge sort algorithm.
Parameters:
- arr (list): The array to be sorted.
Returns:
- list: The sorted array.
This function recursively divides the array into two halves,
sorts each half separately using merge sort, and then merges
the two sorted halves to produce the final sorted array.
"""


def merge_sort(arr):
    if len(arr) <= 1:
        return arr

    mid = len(arr) // 2
    left = arr[:mid]
    right = arr[mid:]

    left = merge_sort(left)
    right = merge_sort(right)

    return merge(left, right)


"""
Merge two sorted lists into a single sorted list.
Parameters:
    left (List): The first sorted list.
    right (List): The second sorted list.
Returns:
    List: The merged sorted list.
"""


def merge(left, right):
    merged = []
    i = j = 0

    while i < len(left) and j < len(right):
        if left[i] < right[j]:
            merged.append(left[i])
            i += 1
        else:
            merged.append(right[j])
            j += 1

    while i < len(left):
        merged.append(left[i])
        i += 1

    while j < len(right):
        merged.append(right[j])
        j += 1

    return merged