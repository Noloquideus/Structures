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

public class BinarySearchTree
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
        BinarySearchTree bst = new BinarySearchTree();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);
        bst.Insert(3);
        bst.Insert(7);

        Console.Write("Inorder traversal: ");
        bst.PrintInOrderTraversal();
        Console.WriteLine();

        bool searchResult = bst.Search(10);
        if (searchResult)
            Console.WriteLine("Node with key 10 found.");
        else
            Console.WriteLine("Node with key 10 not found.");
    }
}