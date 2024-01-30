#include <iostream>
#include <vector>
#include <algorithm>

void patienceSort(std::vector<int>& arr) {
    std::vector<std::vector<int>> piles;
    for (int num : arr) {
        bool placed = false;
        for (std::vector<int>& pile : piles) {
            if (pile.back() >= num) {
                pile.push_back(num);
                placed = true;
                break;
            }
        }
        if (!placed) {
            piles.push_back({num});
        }
    }

    // Слияние стопок
    arr.clear();
    while (!piles.empty()) {
        auto minPileIt = std::min_element(piles.begin(), piles.end(),
                                          [](const auto& a, const auto& b) {
                                              return a.back() < b.back();
                                          });
        std::vector<int>& minPile = *minPileIt;
        arr.push_back(minPile.back());
        minPile.pop_back();
        if (minPile.empty()) {
            piles.erase(minPileIt);
        }
    }
}

int main() {
    std::vector<int> myArray = {3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5};
    patienceSort(myArray);

    for (int num : myArray) {
        std::cout << num << " ";
    }

    return 0;
}