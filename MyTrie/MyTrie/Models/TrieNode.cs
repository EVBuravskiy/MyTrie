namespace MyTrie.Models
{
    public class TrieNode<T>
    {
        public char Symbol { get; set; }
        public Dictionary<char, TrieNode<T>> SubTrieNodes { get; set; }
        public bool IsWordEnd { get; set; }

        public T AdditionalData { get; set; }
        public string Prefix { get; set; }

        public TrieNode() 
        { 
            Symbol = '\0';
            SubTrieNodes = new Dictionary<char, TrieNode<T>>();
            IsWordEnd = false;
            AdditionalData = default(T);
            Prefix = string.Empty;
        }

        public TrieNode(char symbol, T additionalData, string prefix) : this()
        {
            Symbol = symbol;
            AdditionalData = additionalData;
            Prefix = prefix;
        }

        public TrieNode<T> GetSubNode(char symbol)
        {
            if (SubTrieNodes.Count == 0)
            {
                return null;
            }
            if(SubTrieNodes.TryGetValue(symbol, out TrieNode<T> subTrieNode)) 
            {
                return subTrieNode;
            }
            else return null;
        }

        public override bool Equals(object? obj)
        {
            if (obj is TrieNode<T> other) 
                return true;
            return false;
        }

    }
}
