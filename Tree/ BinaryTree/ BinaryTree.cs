using System;

public class TreeNode
{
    public int Key { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public TreeNode(int key)
    {
        Key = key;
        Left = null;
        Right = null;
    }
}

public class BinaryTree
{
    private TreeNode root;

    private TreeNode Insert(TreeNode node, int key)
    {
        if (node == null)
            return new TreeNode(key);

        if (key < node.Key)
            node.Left = Insert(node.Left, key);
        else if (key > node.Key)
            node.Right = Insert(node.Right, key);

        return node;
    }

    private TreeNode Remove(TreeNode node, int key)
    {
        if (node == null)
            return node;

        if (key < node.Key)
            node.Left = Remove(node.Left, key);
        else if (key > node.Key)
            node.Right = Remove(node.Right, key);
        else
        {
            if (node.Left == null)
                return node.Right;
            else if (node.Right == null)
                return node.Left;

            node.Key = GetMinValue(node.Right);
            node.Right = Remove(node.Right, node.Key);
        }
        return node;
    }

    private int GetMinValue(TreeNode node)
    {
        while (node.Left != null)
            node = node.Left;
        return node.Key;
    }

    private TreeNode Search(TreeNode node, int key)
    {
        if (node == null || node.Key == key)
            return node;
        if (key < node.Key)
            return Search(node.Left, key);
        return Search(node.Right, key);
    }

    private void InOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Key + " ");
            InOrderTraversal(node.Right);
        }
    }

    public void Insert(int key)
    {
        root = Insert(root, key);
    }

    public void Remove(int key)
    {
        root = Remove(root, key);
    }

    public bool Search(int key)
    {
        return Search(root, key) != null;
    }

    public void PrintInOrderTraversal()
    {
        InOrderTraversal(root);
    }
}

class Program
{
    static void Main()
    {
        BinaryTree bst = new BinaryTree();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(3);
        bst.Insert(7);

        Console.Write("Inorder traversal: ");
        bst.PrintInOrderTraversal();
        Console.WriteLine();

        bst.Remove(5);
        Console.Write("After deleting 5: ");
        bst.PrintInOrderTraversal();
        Console.WriteLine();

        bool searchResult = bst.Search(10);
        if (searchResult)
            Console.WriteLine("Node with key 10 found.");
        else
            Console.WriteLine("Node with key 10 not found.");
    }
}