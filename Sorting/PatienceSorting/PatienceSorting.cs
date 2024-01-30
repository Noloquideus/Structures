using System;
using System.Collections.Generic;

class Program
{
    static void PatienceSort(List<int> arr)
    {
        List<List<int>> piles = new List<List<int>>();
        foreach (int num in arr)
        {
            bool placed = false;
            foreach (List<int> pile in piles)
            {
                if (pile[pile.Count - 1] >= num)
                {
                    pile.Add(num);
                    placed = true;
                    break;
                }
            }
            if (!placed)
            {
                piles.Add(new List<int> { num });
            }
        }

        // Слияние стопок
        arr.Clear();
        while (piles.Count > 0)
        {
            int minPileIndex = 0;
            for (int i = 1; i < piles.Count; i++)
            {
                if (piles[i][piles[i].Count - 1] < piles[minPileIndex][piles[minPileIndex].Count - 1])
                {
                    minPileIndex = i;
                }
            }

            List<int> minPile = piles[minPileIndex];
            arr.Add(minPile[minPile.Count - 1]);
            minPile.RemoveAt(minPile.Count - 1);
            if (minPile.Count == 0)
            {
                piles.RemoveAt(minPileIndex);
            }
        }
    }

    static void Main()
    {
        List<int> myArray = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
        PatienceSort(myArray);
        Console.WriteLine(string.Join(", ", myArray));
    }
}