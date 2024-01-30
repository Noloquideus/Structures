#include <iostream>

class AVLNode {
public:
    int key;
    AVLNode* left;
    AVLNode* right;
    int height;

    AVLNode(int k) : key(k), left(nullptr), right(nullptr), height(1) {}
};

class AVLTree {
private:
    AVLNode* root;

    int height(AVLNode* node) {
        if (!node)
            return 0;
        return node->height;
    }

    int updateHeight(AVLNode* node) {
        if (!node)
            return 0;
        node->height = 1 + std::max(height(node->left), height(node->right));
        return node->height;
    }

    int balanceFactor(AVLNode* node) {
        if (!node)
            return 0;
        return height(node->left) - height(node->right);
    }

    AVLNode* rightRotate(AVLNode* y) {
        AVLNode* x = y->left;
        AVLNode* T2 = x->right;

        x->right = y;
        y->left = T2;

        updateHeight(y);
        updateHeight(x);

        return x;
    }

    AVLNode* leftRotate(AVLNode* x) {
        AVLNode* y = x->right;
        AVLNode* T2 = y->left;

        y->left = x;
        x->right = T2;

        updateHeight(x);
        updateHeight(y);

        return y;
    }

    AVLNode* balance(AVLNode* node, int key) {
        updateHeight(node);
        int balance = balanceFactor(node);

        // Left Heavy
        if (balance > 1 && key < node->left->key)
            return rightRotate(node);

        // Right Heavy
        if (balance < -1 && key > node->right->key)
            return leftRotate(node);

        // Left-Right Heavy
        if (balance > 1 && key > node->left->key) {
            node->left = leftRotate(node->left);
            return rightRotate(node);
        }

        // Right-Left Heavy
        if (balance < -1 && key < node->right->key) {
            node->right = rightRotate(node->right);
            return leftRotate(node);
        }

        return node;
    }

    AVLNode* insert(AVLNode* node, int key) {
        if (!node)
            return new AVLNode(key);

        if (key < node->key)
            node->left = insert(node->left, key);
        else if (key > node->key)
            node->right = insert(node->right, key);
        else
            return node;  // Duplicate keys are not allowed

        return balance(node, key);
    }

    void inorderTraversal(AVLNode* node) {
        if (node) {
            inorderTraversal(node->left);
            std::cout << node->key << " ";
            inorderTraversal(node->right);
        }
    }

public:
    AVLTree() : root(nullptr) {}

    void insert(int key) {
        root = insert(root, key);
    }

    void printInOrderTraversal() {
        inorderTraversal(root);
    }
};

int main() {
    AVLTree avlTree;
    avlTree.insert(10);
    avlTree.insert(5);
    avlTree.insert(15);
    avlTree.insert(3);
    avlTree.insert(7);

    std::cout << "Inorder traversal: ";
    avlTree.printInOrderTraversal();
    std::cout << std::endl;

    return 0;
}