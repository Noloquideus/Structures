def stoogesort(arr, l, h):
    if l >= h:
        return

    if arr[l] > arr[h]:
        arr[l], arr[h] = arr[h], arr[l]

    if h - l + 1 > 2:
        t = (h - l + 1) // 3
        stoogesort(arr, l, h - t)
        stoogesort(arr, l + t, h)
        stoogesort(arr, l, h - t)


def smoothsort(arr):
    n = len(arr)

    for i in range(1, n):
        if arr[i - 1] > arr[i]:
            arr[i - 1], arr[i] = arr[i], arr[i - 1]
            stoogesort(arr, 0, i)
