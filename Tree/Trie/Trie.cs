using System;
using System.Collections.Generic;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; private set; }
    public bool IsEndOfWord { get; set; }

    public TrieNode()
    {
        Children = new Dictionary<char, TrieNode>();
        IsEndOfWord = false;
    }
}

public class Trie
{
    private TrieNode root;

    public Trie()
    {
        root = new TrieNode();
    }

    public void Insert(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.IsEndOfWord = true;
    }

    public bool Search(string word)
    {
        TrieNode node = SearchNode(word);
        return node != null && node.IsEndOfWord;
    }

    public bool StartsWith(string prefix)
    {
        TrieNode node = SearchNode(prefix);
        return node != null;
    }

    private TrieNode SearchNode(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (node.Children.ContainsKey(c))
            {
                node = node.Children[c];
            }
            else
            {
                return null;
            }
        }
        return node;
    }
}

class Program
{
    static void Main()
    {
        Trie trie = new Trie();

        trie.Insert("apple");
        trie.Insert("app");
        trie.Insert("apricot");

        Console.WriteLine(trie.Search("apple")); // true
        Console.WriteLine(trie.Search("app"));   // true
        Console.WriteLine(trie.Search("apricot")); // true
        Console.WriteLine(trie.Search("ap"));     // false

        Console.WriteLine(trie.StartsWith("ap"));   // true
        Console.WriteLine(trie.StartsWith("banana")); // false
    }
}