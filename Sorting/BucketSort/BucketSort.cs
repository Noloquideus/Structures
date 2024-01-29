using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<double> BucketSort(List<double> arr)
    {
        List<List<double>> buckets = new List<List<double>>();
        for (int i = 0; i < arr.Count; i++)
        {
            buckets.Add(new List<double>());
        }

        // Распределение элементов по корзинам
        foreach (var num in arr)
        {
            int index = (int)(num * 10);  // Пример критерия распределения
            buckets[index].Add(num);
        }

        List<double> sortedArray = new List<double>();
        // Сортировка внутри каждой корзины (можно использовать другой алгоритм сортировки)
        foreach (var bucket in buckets)
        {
            sortedArray.AddRange(bucket.OrderBy(x => x));
        }

        return sortedArray;
    }

    static void Main()
    {
        List<double> myArray = new List<double> { 0.23, 0.65, 0.43, 0.12, 0.98, 0.34, 0.76, 0.45 };
        var result = BucketSort(myArray);
        Console.WriteLine(string.Join(", ", result));
    }
}