using System;
using System.Collections.Generic;

class HashTable
{
    private int size;
    private List<KeyValuePair<string, string>>[] table;

    public HashTable(int size)
    {
        this.size = size;
        table = new List<KeyValuePair<string, string>>[size];
        for (int i = 0; i < size; i++)
        {
            table[i] = new List<KeyValuePair<string, string>>();
        }
    }

    private int Hash(string key)
    {
        return Math.Abs(key.GetHashCode()) % size;
    }

    public void Insert(string key, string value)
    {
        int index = Hash(key);
        foreach (var pair in table[index])
        {
            if (pair.Key == key)
            {
                pair.Value = value;
                return;
            }
        }
        table[index].Add(new KeyValuePair<string, string>(key, value));
    }

    public string Search(string key)
    {
        int index = Hash(key);
        foreach (var pair in table[index])
        {
            if (pair.Key == key)
            {
                return pair.Value;
            }
        }
        return "None";
    }

    public void Delete(string key)
    {
        int index = Hash(key);
        table[index].RemoveAll(pair => pair.Key == key);
    }
}

class Program
{
    static void Main()
    {
        HashTable hashTable = new HashTable(10);
        hashTable.Insert("key1", "value1");
        hashTable.Insert("key2", "value2");
        hashTable.Insert("key3", "value3");

        Console.WriteLine("Search key2: " + hashTable.Search("key2"));  // Output: "value2"
        hashTable.Delete("key2");
        Console.WriteLine("Search key2 after removal: " + hashTable.Search("key2"));  // Output: "None" (key removed)
    }
}