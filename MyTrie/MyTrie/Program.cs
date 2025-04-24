using MyTrie.Models;

namespace MyTrie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Trie<int> trie = new Trie<int>();
            trie.Add("Привет");
            trie.Add("Мир");
            trie.Add("Пока");
            trie.Add("Мирный");
            Console.WriteLine(trie.Search("Мир"));
            trie.Remove("Мир");
            Console.WriteLine(trie.Search("Мир"));
            Console.WriteLine(trie.Search("Мирный"));
            Console.WriteLine(trie.Search("Пока"));
            trie.Remove("Пока");
            Console.WriteLine(trie.Search("Пока"));

        }
    }
}