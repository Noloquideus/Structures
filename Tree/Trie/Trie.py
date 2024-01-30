class TrieNode:
    def __init__(self):
        self.children = {}
        self.is_end_of_word = False


class Trie:
    def __init__(self):
        self.root = TrieNode()

    def insert(self, word):
        node = self.root
        for char in word:
            if char not in node.children:
                node.children[char] = TrieNode()
            node = node.children[char]
        node.is_end_of_word = True

    def search(self, word):
        node = self._search_node(word)
        return node is not None and node.is_end_of_word

    def starts_with(self, prefix):
        node = self._search_node(prefix)
        return node is not None

    def _search_node(self, word):
        node = self.root
        for char in word:
            if char in node.children:
                node = node.children[char]
            else:
                return None
        return node


# Пример использования
trie = Trie()
trie.insert("apple")
trie.insert("app")
trie.insert("apricot")

print(trie.search("apple"))  # True
print(trie.search("app"))  # True
print(trie.search("apricot"))  # True
print(trie.search("ap"))  # False

print(trie.starts_with("ap"))  # True
print(trie.starts_with("banana"))  # False
