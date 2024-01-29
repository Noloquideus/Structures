#include <iostream>
#include <vector>
#include <algorithm>

std::vector<double> bucketSort(std::vector<double>& arr) {
    std::vector<std::vector<double>> buckets(arr.size());

    // Распределение элементов по корзинам
    for (const auto& num : arr) {
        int index = static_cast<int>(num * 10);  // Пример критерия распределения
        buckets[index].push_back(num);
    }

    std::vector<double> sortedArray;
    // Сортировка внутри каждой корзины (можно использовать другой алгоритм сортировки)
    for (const auto& bucket : buckets) {
        std::sort(bucket.begin(), bucket.end());
        sortedArray.insert(sortedArray.end(), bucket.begin(), bucket.end());
    }

    return sortedArray;
}

int main() {
    std::vector<double> myArray = {0.23, 0.65, 0.43, 0.12, 0.98, 0.34, 0.76, 0.45};
    auto result = bucketSort(myArray);
    
    for (const auto& num : result) {
        std::cout << num << " ";
    }

    return 0;
}