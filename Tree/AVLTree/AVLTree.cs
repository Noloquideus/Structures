using System;

public class AVLNode
{
    public int Key { get; set; }
    public AVLNode Left { get; set; }
    public AVLNode Right { get; set; }
    public int Height { get; set; }

    public AVLNode(int key)
    {
        Key = key;
        Left = null;
        Right = null;
        Height = 1;
    }
}

public class AVLTree
{
    private AVLNode root;

    private int Height(AVLNode node)
    {
        if (node == null)
            return 0;
        return node.Height;
    }

    private int UpdateHeight(AVLNode node)
    {
        if (node == null)
            return 0;
        node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
        return node.Height;
    }

    private int BalanceFactor(AVLNode node)
    {
        if (node == null)
            return 0;
        return Height(node.Left) - Height(node.Right);
    }

    private AVLNode RightRotate(AVLNode y)
    {
        AVLNode x = y.Left;
        AVLNode T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        UpdateHeight(y);
        UpdateHeight(x);

        return x;
    }

    private AVLNode LeftRotate(AVLNode x)
    {
        AVLNode y = x.Right;
        AVLNode T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        UpdateHeight(x);
        UpdateHeight(y);

        return y;
    }

    private AVLNode Balance(AVLNode node, int key)
    {
        UpdateHeight(node);
        int balance = BalanceFactor(node);

        // Left Heavy
        if (balance > 1 && key < node.Left.Key)
            return RightRotate(node);

        // Right Heavy
        if (balance < -1 && key > node.Right.Key)
            return LeftRotate(node);

        // Left-Right Heavy
        if (balance > 1 && key > node.Left.Key)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right-Left Heavy
        if (balance < -1 && key < node.Right.Key)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    private AVLNode Insert(AVLNode node, int key)
    {
        if (node == null)
            return new AVLNode(key);

        if (key < node.Key)
            node.Left = Insert(node.Left, key);
        else if (key > node.Key)
            node.Right = Insert(node.Right, key);
        else
            return node;  // Duplicate keys are not allowed

        return Balance(node, key);
    }

    private void InOrderTraversal(AVLNode node)
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

    public void PrintInOrderTraversal()
    {
        InOrderTraversal(root);
    }
}

class Program
{
    static void Main()
    {
        AVLTree avlTree = new AVLTree();
        avlTree.Insert(10);
        avlTree.Insert(5);
        avlTree.Insert(15);
        avlTree.Insert(3);
        avlTree.Insert(7);

        Console.Write("Inorder traversal: ");
        avlTree.PrintInOrderTraversal();
        Console.WriteLine();
    }
}