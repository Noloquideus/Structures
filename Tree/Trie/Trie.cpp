#include <iostream>
#include <unordered_map>

class TrieNode {
public:
    std::unordered_map<char, TrieNode*> children;
    bool isEndOfWord;

    TrieNode() : isEndOfWord(false) {}
};

class Trie {
private:
    TrieNode* root;

public:
    Trie() : root(new TrieNode()) {}

    void insert(const std::string& word) {
        TrieNode* node = root;
        for (char c : word) {
            if (node->children.find(c) == node->children.end()) {
                node->children[c] = new TrieNode();
            }
            node = node->children[c];
        }
        node->isEndOfWord = true;
    }

    bool search(const std::string& word) {
        TrieNode* node = searchNode(word);
        return node != nullptr && node->isEndOfWord;
    }

    bool startsWith(const std::string& prefix) {
        TrieNode* node = searchNode(prefix);
        return node != nullptr;
    }

private:
    TrieNode* searchNode(const std::string& word) {
        TrieNode* node = root;
        for (char c : word) {
            if (node->children.find(c) != node->children.end()) {
                node = node->children[c];
            } else {
                return nullptr;
            }
        }
        return node;
    }
};

int main() {
    Trie trie;

    trie.insert("apple");
    trie.insert("app");
    trie.insert("apricot");

    std::cout << std::boolalpha;
    std::cout << trie.search("apple") << std::endl;   // true
    std::cout << trie.search("app") << std::endl;     // true
    std::cout << trie.search("apricot") << std::endl; // true
    std::cout << trie.search("ap") << std::endl;      // false

    std::cout << trie.startsWith("ap") << std::endl;   // true
    std::cout << trie.startsWith("banana") << std::endl; // false

    return 0;
}