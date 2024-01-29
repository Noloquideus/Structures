#include <iostream>
#include <vector>

void countingSort(std::vector<int>& arr) {
    int max = *std::max_element(arr.begin(), arr.end());
    int min = *std::min_element(arr.begin(), arr.end());
    int range = max - min + 1;

    std::vector<int> count(range, 0);
    std::vector<int> output(arr.size());

    for (int i = 0; i < arr.size(); i++) {
        count[arr[i] - min]++;
    }

    for (int i = 1; i < range; i++) {
        count[i] += count[i - 1];
    }

    for (int i = arr.size() - 1; i >= 0; i--) {
        output[count[arr[i] - min] - 1] = arr[i];
        count[arr[i] - min]--;
    }

    for (int i = 0; i < arr.size(); i++) {
        arr[i] = output[i];
    }
}

int main() {
    std::vector<int> arr = {4, 2, 10, 5, 3, 1};
    std::cout << "Исходный массив: ";
    for (int num : arr) {
        std::cout << num << " ";
    }

    countingSort(arr);

    std::cout << "\nОтсортированный массив: ";
    for (int num : arr) {
        std::cout << num << " ";
    }

    return 0;
}