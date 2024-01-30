class HashTable:
    def __init__(self, size):
        self.size = size
        self.table = [[] for _ in range(size)]

    def _hash(self, key):
        return hash(key) % self.size

    def insert(self, key, value):
        index = self._hash(key)
        for pair in self.table[index]:
            if pair[0] == key:
                pair[1] = value
                return
        self.table[index].append([key, value])

    def search(self, key):
        index = self._hash(key)
        for pair in self.table[index]:
            if pair[0] == key:
                return pair[1]
        return None

    def delete(self, key):
        index = self._hash(key)
        for i, pair in enumerate(self.table[index]):
            if pair[0] == key:
                del self.table[index][i]
                return


# Пример использования
hash_table = HashTable(10)
hash_table.insert("key1", "value1")
hash_table.insert("key2", "value2")
hash_table.insert("key3", "value3")

print(hash_table.search("key2"))  # Вывод: "value2"
hash_table.delete("key2")
print(hash_table.search("key2"))  # Вывод: None (ключ удален)
