#include <iostream>
#include <vector>

// Функция для разделения массива на две части
int Partition(std::vector<int>& arr, int low, int high) {
    int pivot = arr[high];
    int i = low - 1;

    for (int j = low; j < high; j++) {
        if (arr[j] <= pivot) {
            i++;

            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }

    int temp1 = arr[i + 1];
    arr[i + 1] = arr[high];
    arr[high] = temp1;

    return i + 1;
}

// Основная функция сортировки
void QuickSortAlgorithm(std::vector<int>& arr, int low, int high) {
    if (low < high) {
        // Получаем индекс опорного элемента (pi)
        int pi = Partition(arr, low, high);

        // Рекурсивно сортируем две подмассива
        QuickSortAlgorithm(arr, low, pi - 1);
        QuickSortAlgorithm(arr, pi + 1, high);
    }
}

int main() {
    std::vector<int> arr = {64, 34, 25, 12, 22, 11, 90};
    int n = arr.size();

    std::cout << "Исходный массив: ";
    for (int i = 0; i < n; i++) {
        std::cout << arr[i] << " ";
    }
    std::cout << std::endl;

    // Вызываем функцию сортировки
    QuickSortAlgorithm(arr, 0, n - 1);

    std::cout << "Отсортированный массив: ";
    for (int i = 0; i < n; i++) {
        std::cout << arr[i] << " ";
    }
    std::cout << std::endl;

    return 0;
}