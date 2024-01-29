def fibonacci_search(arr, target):
    def generate_fibonacci_numbers(n):
        fib_numbers = [0, 1]
        while fib_numbers[-1] < n:
            fib_numbers.append(fib_numbers[-1] + fib_numbers[-2])
        return fib_numbers

    def min_of(a, b):
        return a if a < b else b

    n = len(arr)
    fib_numbers = generate_fibonacci_numbers(n)
    offset = -1

    while fib_numbers[-1] > 1:
        i = min_of(offset + fib_numbers[len(fib_numbers) - 2], n - 1)

        if arr[i] < target:
            fib_numbers = fib_numbers[:len(fib_numbers) - 2]
            offset = i
        elif arr[i] > target:
            fib_numbers = fib_numbers[:len(fib_numbers) - 1]
        else:
            return i

    if fib_numbers[-1] == 1 and arr[offset + 1] == target:
        return offset + 1

    return -1