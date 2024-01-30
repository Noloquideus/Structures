using System;
using System.Collections.Generic;

class TreeNode
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

class TreeSort
{
    private static TreeNode Insert(TreeNode root, int key)
    {
        if (root == null)
            return new TreeNode(key);

        if (key < root.Key)
            root.Left = Insert(root.Left, key);
        else
            root.Right = Insert(root.Right, key);

        return root;
    }

    private static void InOrderTraversal(TreeNode root, List<int> result)
    {
        if (root != null)
        {
            InOrderTraversal(root.Left, result);
            result.Add(root.Key);
            InOrderTraversal(root.Right, result);
        }
    }

    public static List<int> TreeSort(List<int> arr)
    {
        TreeNode root = null;

        foreach (int key in arr)
        {
            root = Insert(root, key);
        }

        List<int> result = new List<int>();
        InOrderTraversal(root, result);

        return result;
    }

    static void Main()
    {
        List<int> myArray = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
        List<int> result = TreeSort(myArray);
        Console.WriteLine(string.Join(", ", result));
    }
}