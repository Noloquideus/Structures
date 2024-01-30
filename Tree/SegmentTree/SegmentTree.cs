using System;

class SegmentTree
{
    private int[] tree;
    private int n;

    public SegmentTree(int[] arr)
    {
        n = arr.Length;
        tree = new int[2 * n];
        ConstructTree(arr, 0, n - 1, 0);
    }

    private void ConstructTree(int[] arr, int low, int high, int pos)
    {
        if (low == high)
        {
            tree[pos] = arr[low];
            return;
        }

        int mid = (low + high) / 2;
        ConstructTree(arr, low, mid, 2 * pos + 1);
        ConstructTree(arr, mid + 1, high, 2 * pos + 2);
        tree[pos] = tree[2 * pos + 1] + tree[2 * pos + 2];
    }

    public int Query(int qlow, int qhigh)
    {
        return _Query(qlow, qhigh, 0, n - 1, 0);
    }

    private int _Query(int qlow, int qhigh, int low, int high, int pos)
    {
        if (qlow <= low && qhigh >= high)
            return tree[pos];

        if (qlow > high || qhigh < low)
            return 0;

        int mid = (low + high) / 2;
        return _Query(qlow, qhigh, low, mid, 2 * pos + 1) + _Query(qlow, qhigh, mid + 1, high, 2 * pos + 2);
    }

    public void Update(int index, int value)
    {
        int diff = value - tree[index + n];
        tree[index + n] = value;
        _Update(index, diff, 0, n - 1, 0);
    }

    private void _Update(int index, int diff, int low, int high, int pos)
    {
        if (index < low || index > high)
            return;

        tree[pos] += diff;

        if (low != high)
        {
            int mid = (low + high) / 2;
            _Update(index, diff, low, mid, 2 * pos + 1);
            _Update(index, diff, mid + 1, high, 2 * pos + 2);
        }
    }
}

class Program
{
    static void Main()
    {
        int[] arr = { 1, 3, 5, 7, 9, 11 };
        SegmentTree segTree = new SegmentTree(arr);

        Console.WriteLine("Сумма на отрезке [1, 3]: " + segTree.Query(1, 3));

        segTree.Update(2, 10);

        Console.WriteLine("Сумма на отрезке [1, 3] после обновления: " + segTree.Query(1, 3));
    }
}