#include <iostream>
#include <vector>

int fibonacciSearchAlgorithm(std::vector<int>& arr, int target) {
    int n = arr.size();
    std::vector<int> fibNumbers = generateFibonacciNumbers(n);
    int offset = -1;

    while (fibNumbers[fibNumbers.size() - 1] > 1) {
        int i = minOf(offset + fibNumbers[fibNumbers.size() - 2], n - 1);

        if (arr[i] < target) {
            fibNumbers.resize(fibNumbers.size() - 2);
            offset = i;
        } else if (arr[i] > target) {
            fibNumbers.resize(fibNumbers.size() - 1);
        } else {
            return i;
        }
    }

    if (fibNumbers[fibNumbers.size() - 1] == 1 && arr[offset + 1] == target) {
        return offset + 1;
    }

    return -1;
}

std::vector<int> generateFibonacciNumbers(int n) {
    std::vector<int> fibNumbers = {0, 1};

    while (fibNumbers[fibNumbers.size() - 1] < n) {
        int nextFib = fibNumbers[fibNumbers.size() - 1] + fibNumbers[fibNumbers.size() - 2];
        fibNumbers.push_back(nextFib);
    }

    return fibNumbers;
}