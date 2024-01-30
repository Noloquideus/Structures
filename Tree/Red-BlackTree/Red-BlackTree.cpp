#include <iostream>

enum Color { RED, BLACK };

class Node {
public:
    int key;
    Color color;
    Node* left;
    Node* right;
    Node* parent;

    Node(int k, Color c = RED) : key(k), color(c), left(nullptr), right(nullptr), parent(nullptr) {}
};

class RedBlackTree {
private:
    Node* root;
    Node* NIL;

    void leftRotate(Node* x) {
        Node* y = x->right;
        x->right = y->left;

        if (y->left != NIL)
            y->left->parent = x;

        y->parent = x->parent;

        if (x->parent == nullptr)
            root = y;
        else if (x == x->parent->left)
            x->parent->left = y;
        else
            x->parent->right = y;

        y->left = x;
        x->parent = y;
    }

    void rightRotate(Node* y) {
        Node* x = y->left;
        y->left = x->right;

        if (x->right != NIL)
            x->right->parent = y;

        x->parent = y->parent;

        if (y->parent == nullptr)
            root = x;
        else if (y == y->parent->left)
            y->parent->left = x;
        else
            y->parent->right = x;

        x->right = y;
        y->parent = x;
    }

    void insertFixup(Node* z) {
        while (z->parent->color == RED) {
            if (z->parent == z->parent->parent->left) {
                Node* y = z->parent->parent->right;
                if (y->color == RED) {
                    z->parent->color = BLACK;
                    y->color = BLACK;
                    z->parent->parent->color = RED;
                    z = z->parent->parent;
                } else {
                    if (z == z->parent->right) {
                        z = z->parent;
                        leftRotate(z);
                    }

                    z->parent->color = BLACK;
                    z->parent->parent->color = RED;
                    rightRotate(z->parent->parent);
                }
            } else {
                Node* y = z->parent->parent->left;
                if (y->color == RED) {
                    z->parent->color = BLACK;
                    y->color = BLACK;
                    z->parent->parent->color = RED;
                    z = z->parent->parent;
                } else {
                    if (z == z->parent->left) {
                        z = z->parent;
                        rightRotate(z);
                    }

                    z->parent->color = BLACK;
                    z->parent->parent->color = RED;
                    leftRotate(z->parent->parent);
                }
            }
        }

        root->color = BLACK;
    }

    void insert(Node* z) {
        Node* y = NIL;
        Node* x = root;

        while (x != NIL) {
            y = x;
            if (z->key < x->key)
                x = x->left;
            else
                x = x->right;
        }

        z->parent = y;
        if (y == NIL)
            root = z;
        else if (z->key < y->key)
            y->left = z;
        else
            y->right = z;

        z->left = NIL;
        z->right = NIL;
        z->color = RED;

        insertFixup(z);
    }

    void inorderTraversal(Node* node) {
        if (node != NIL) {
            inorderTraversal(node->left);
            std::cout << node->key << " ";
            inorderTraversal(node->right);
        }
    }

public:
    RedBlackTree() {
        NIL = new Node(-1, BLACK);
        root = NIL;
    }

    void insert(int key) {
        Node* z = new Node(key);
        insert(z);
    }

    void printInOrderTraversal() {
        inorderTraversal(root);
    }
};

int main() {
    RedBlackTree rbTree;
    rbTree.insert(10);
    rbTree.insert(5);
    rbTree.insert(15);
    rbTree.insert(3);
    rbTree.insert(7);

    std::cout << "Inorder traversal: ";
    rbTree.printInOrderTraversal();
    std::cout << std::endl;

    return 0;
}