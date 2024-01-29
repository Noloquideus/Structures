#include <iostream>
#include <vector>

void countingSort(std::vector<int>& arr, int exp) {
    int n = arr.size();
    std::vector<int> output(n, 0);
    std::vector<int> count(10, 0);

    for (int i = 0; i < n; i++) {
        int index = arr[i] / exp;
        count[index % 10]++;
    }

    for (int i = 1; i < 10; i++) {
        count[i] += count[i - 1];
    }

    for (int i = n - 1; i >= 0; i--) {
        int index = arr[i] / exp;
        output[count[index % 10] - 1] = arr[i];
        count[index % 10]--;
    }

    arr = output;
}

void radixSort(std::vector<int>& arr) {
    int maxNum = arr[0];
    int n = arr.size();

    for (int i = 1; i < n; i++) {
        if (arr[i] > maxNum) {
            maxNum = arr[i];
        }
    }

    for (int exp = 1; maxNum / exp > 0; exp *= 10) {
        countingSort(arr, exp);
    }
}

int main() {
    std::vector<int> myArray = {170, 45, 75, 90, 802, 24, 2, 66};
    radixSort(myArray);

    for (const auto& num : myArray) {
        std::cout << num << " ";
    }

    return 0;
}