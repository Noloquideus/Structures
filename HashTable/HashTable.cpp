#include <iostream>
#include <list>
#include <vector>

class HashTable {
private:
    int size;
    std::vector<std::list<std::pair<std::string, std::string>>> table;

    size_t _hash(const std::string& key) {
        return std::hash<std::string>{}(key) % size;
    }

public:
    HashTable(int size) : size(size), table(size) {}

    void insert(const std::string& key, const std::string& value) {
        size_t index = _hash(key);
        for (auto& pair : table[index]) {
            if (pair.first == key) {
                pair.second = value;
                return;
            }
        }
        table[index].emplace_back(key, value);
    }

    std::string search(const std::string& key) {
        size_t index = _hash(key);
        for (const auto& pair : table[index]) {
            if (pair.first == key) {
                return pair.second;
            }
        }
        return "None";
    }

    void remove(const std::string& key) {
        size_t index = _hash(key);
        for (auto it = table[index].begin(); it != table[index].end(); ++it) {
            if (it->first == key) {
                table[index].erase(it);
                return;
            }
        }
    }
};

int main() {
    HashTable hashTable(10);
    hashTable.insert("key1", "value1");
    hashTable.insert("key2", "value2");
    hashTable.insert("key3", "value3");

    std::cout << "Search key2: " << hashTable.search("key2") << std::endl;  // Output: "value2"
    hashTable.remove("key2");
    std::cout << "Search key2 after removal: " << hashTable.search("key2") << std::endl;  // Output: "None" (key removed)

    return 0;
}