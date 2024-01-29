#include <iostream>
#include <vector>

template <typename T>
class Stack {
private:
    std::vector<T> items;

public:
    bool IsEmpty() const {
        return items.empty();
    }

    void Push(const T& item) {
        items.push_back(item);
    }

    T Pop() {
        if (!IsEmpty()) {
            T poppedItem = items.back();
            items.pop_back();
            return poppedItem;
        } else {
            return T();
        }
    }

    T Peek() const {
        if (!IsEmpty()) {
            return items.back();
        } else {

            return T();
        }
    }