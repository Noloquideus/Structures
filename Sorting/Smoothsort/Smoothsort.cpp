#include <iostream>
#include <vector>

class SmoothSort
{
public:
    static void stoogesort(std::vector<int>& arr, int l, int h)
    {
        if (l >= h)
            return;

        if (arr[l] > arr[h])
            swap(arr, l, h);

        if (h - l + 1 > 2)
        {
            int t = (h - l + 1) / 3;
            stoogesort(arr, l, h - t);
            stoogesort(arr, l + t, h);
            stoogesort(arr, l, h - t);
        }
    }

    static void smoothsort(std::vector<int>& arr)
    {
        int n = arr.size();

        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                swap(arr, i - 1, i);
                stoogesort(arr, 0, i);
            }
        }
    }

private:
    static void swap(std::vector<int>& arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
};

int main()
{
    std::vector<int> myArray = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
    SmoothSort::smoothsort(myArray);

    for (const auto& num : myArray)
    {
        std::cout << num << " ";
    }

    return 0;
}