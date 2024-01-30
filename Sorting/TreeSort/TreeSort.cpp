#include <iostream>
#include <vector>

class TreeNode
{
public:
    int key;
    TreeNode* left;
    TreeNode* right;

    TreeNode(int k) : key(k), left(nullptr), right(nullptr) {}
};

TreeNode* insert(TreeNode* root, int key)
{
    if (root == nullptr)
        return new TreeNode(key);

    if (key < root->key)
        root->left = insert(root->left, key);
    else
        root->right = insert(root->right, key);

    return root;
}

void inOrderTraversal(TreeNode* root, std::vector<int>& result)
{
    if (root != nullptr)
    {
        inOrderTraversal(root->left, result);
        result.push_back(root->key);
        inOrderTraversal(root->right, result);
    }
}

std::vector<int> treeSort(const std::vector<int>& arr)
{
    TreeNode* root = nullptr;

    for (int key : arr)
    {
        root = insert(root, key);
    }

    std::vector<int> result;
    inOrderTraversal(root, result);

    return result;
}

int main()
{
    std::vector<int> myArray = {3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5};
    std::vector<int> result = treeSort(myArray);

    for (int num : result)
    {
        std::cout << num << " ";
    }

    return 0;
}