#include <iostream>

class TreeNode {
public:
    int key;
    TreeNode* left;
    TreeNode* right;

    TreeNode(int k) : key(k), left(nullptr), right(nullptr) {}
};

class BinaryTree {
private:
    TreeNode* root;

    TreeNode* insert(TreeNode* node, int key) {
        if (node == nullptr)
            return new TreeNode(key);

        if (key < node->key)
            node->left = insert(node->left, key);
        else if (key > node->key)
            node->right = insert(node->right, key);

        return node;
    }

    TreeNode* remove(TreeNode* node, int key) {
        if (node == nullptr)
            return node;

        if (key < node->key)
            node->left = remove(node->left, key);
        else if (key > node->key)
            node->right = remove(node->right, key);
        else {
            if (node->left == nullptr) {
                TreeNode* temp = node->right;
                delete node;
                return temp;
            } else if (node->right == nullptr) {
                TreeNode* temp = node->left;
                delete node;
                return temp;
            }

            node->key = getMinValue(node->right);
            node->right = remove(node->right, node->key);
        }
        return node;
    }

    int getMinValue(TreeNode* node) {
        while (node->left != nullptr)
            node = node->left;
        return node->key;
    }

    TreeNode* search(TreeNode* node, int key) {
        if (node == nullptr || node->key == key)
            return node;
        if (key < node->key)
            return search(node->left, key);
        return search(node->right, key);
    }

    void inOrderTraversal(TreeNode* node) {
        if (node != nullptr) {
            inOrderTraversal(node->left);
            std::cout << node->key << " ";
            inOrderTraversal(node->right);
        }
    }

public:
    BinaryTree() : root(nullptr) {}

    void insert(int key) {
        root = insert(root, key);
    }

    void remove(int key) {
        root = remove(root, key);
    }

    bool search(int key) {
        return search(root, key) != nullptr;
    }

    void printInOrderTraversal() {
        inOrderTraversal(root);
    }
};

int main() {
    BinaryTree bst;
    bst.insert(10);
    bst.insert(5);
    bst.insert(15);
    bst.insert(3);
    bst.insert(7);

    std::cout << "Inorder traversal: ";
    bst.printInOrderTraversal();
    std::cout << std::endl;

    bst.remove(5);
    std::cout << "After deleting 5: ";
    bst.printInOrderTraversal();
    std::cout << std::endl;

    bool searchResult = bst.search(10);
    if (searchResult)
        std::cout << "Node with key 10 found." << std::endl;
    else
        std::cout << "Node with key 10 not found." << std::endl;

    return 0;
}