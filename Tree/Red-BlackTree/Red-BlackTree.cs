using System;

enum Color
{
    Red,
    Black
}

class RedBlackNode
{
    public int Key { get; set; }
    public Color NodeColor { get; set; }
    public RedBlackNode Parent { get; set; }
    public RedBlackNode Left { get; set; }
    public RedBlackNode Right { get; set; }

    public RedBlackNode(int key, Color color)
    {
        Key = key;
        NodeColor = color;
        Parent = null;
        Left = null;
        Right = null;
    }
}

class RedBlackTree
{
    private RedBlackNode root;

    private void LeftRotate(RedBlackNode x)
    {
        RedBlackNode y = x.Right;
        x.Right = y.Left;

        if (y.Left != null)
            y.Left.Parent = x;

        y.Parent = x.Parent;

        if (x.Parent == null)
            root = y;
        else if (x == x.Parent.Left)
            x.Parent.Left = y;
        else
            x.Parent.Right = y;

        y.Left = x;
        x.Parent = y;
    }

    private void RightRotate(RedBlackNode y)
    {
        RedBlackNode x = y.Left;
        y.Left = x.Right;

        if (x.Right != null)
            x.Right.Parent = y;

        x.Parent = y.Parent;

        if (y.Parent == null)
            root = x;
        else if (y == y.Parent.Left)
            y.Parent.Left = x;
        else
            y.Parent.Right = x;

        x.Right = y;
        y.Parent = x;
    }

    private void InsertFixup(RedBlackNode z)
    {
        while (z.Parent != null && z.Parent.NodeColor == Color.Red)
        {
            if (z.Parent == z.Parent.Parent.Left)
            {
                RedBlackNode y = z.Parent.Parent.Right;

                if (y != null && y.NodeColor == Color.Red)
                {
                    z.Parent.NodeColor = Color.Black;
                    y.NodeColor = Color.Black;
                    z.Parent.Parent.NodeColor = Color.Red;
                    z = z.Parent.Parent;
                }
                else
                {
                    if (z == z.Parent.Right)
                    {
                        z = z.Parent;
                        LeftRotate(z);
                    }

                    z.Parent.NodeColor = Color.Black;
                    z.Parent.Parent.NodeColor = Color.Red;
                    RightRotate(z.Parent.Parent);
                }
            }
            else
            {
                RedBlackNode y = z.Parent.Parent.Left;

                if (y != null && y.NodeColor == Color.Red)
                {
                    z.Parent.NodeColor = Color.Black;
                    y.NodeColor = Color.Black;
                    z.Parent.Parent.NodeColor = Color.Red;
                    z = z.Parent.Parent;
                }
                else
                {
                    if (z == z.Parent.Left)
                    {
                        z = z.Parent;
                        RightRotate(z);
                    }

                    z.Parent.NodeColor = Color.Black;
                    z.Parent.Parent.NodeColor = Color.Red;
                    LeftRotate(z.Parent.Parent);
                }
            }
        }

        root.NodeColor = Color.Black;
    }

    public void Insert(int key)
    {
        RedBlackNode z = new RedBlackNode(key, Color.Red);
        RedBlackNode y = null;
        RedBlackNode x = root;

        while (x != null)
        {
            y = x;
            if (z.Key < x.Key)
                x = x.Left;
            else
                x = x.Right;
        }

        z.Parent = y;
        if (y == null)
            root = z;
        else if (z.Key < y.Key)
            y.Left = z;
        else
            y.Right = z;

        InsertFixup(z);
    }

    private void InOrderTraversal(RedBlackNode node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.WriteLine($"{node.Key} ({node.NodeColor})");
            InOrderTraversal(node.Right);
        }
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
        RedBlackTree rbTree = new RedBlackTree();
        rbTree.Insert(10);
        rbTree.Insert(5);
        rbTree.Insert(15);
        rbTree.Insert(3);
        rbTree.Insert(7);

        Console.WriteLine("Inorder traversal:");
        rbTree.PrintInOrderTraversal();
    }
}