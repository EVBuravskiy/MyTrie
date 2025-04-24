namespace MyTrie.Models
{
    public class Trie<T>
    {
        public TrieNode<T> root;

        public Trie()
        {
            root = new TrieNode<T>();
        }

        public void Add(string key, T inputData = default(T))
        {
            key = key.ToLower();
            AddTrieNode(key, inputData, root);
        }

        private void AddTrieNode(string key, T inputData, TrieNode<T> currentNode) 
        { 
            if(string.IsNullOrEmpty(key))
            {
                if(currentNode.IsWordEnd == true)
                {
                    return;
                }
                currentNode.IsWordEnd = true;
                return;
            }
            else
            {
                char symbol = key[0];
                TrieNode<T> subTrieNode = currentNode.GetSubNode(symbol);
                if(subTrieNode != null)
                {
                    AddTrieNode(key.Substring(1), inputData, subTrieNode);
                }
                else
                {
                    TrieNode<T> newTrieNode = new TrieNode<T>(symbol, inputData, currentNode.Prefix + symbol);
                    currentNode.SubTrieNodes.Add(symbol, newTrieNode);
                    AddTrieNode(key.Substring(1), inputData, newTrieNode);
                }
            }
        }

        public void Remove(string key)
        {
            key = key.ToLower();
            RemoveIsEndOfWord(key, root);
        }

        private bool RemoveIsEndOfWord(string key, TrieNode<T> currentNode)
        {
            if(string.IsNullOrEmpty(key))
            {
                if (currentNode.IsWordEnd)
                {
                    currentNode.IsWordEnd = false;
                    return true;
                }
                return false;
            }
            else
            {
                char symbol = key[0];
                TrieNode<T> subTrieNode = currentNode.GetSubNode(symbol);
                if(subTrieNode != null )
                {
                    RemoveIsEndOfWord(key.Substring(1), subTrieNode);
                }
                return false;
            }
        }

        public bool Search(string key)
        {
            key = key.ToLower();
            return SearchNode(key, root);
        }

        private bool SearchNode(string key, TrieNode<T> currentNode)
        {
            bool result = false;
            if (string.IsNullOrEmpty(key))
            {
                if (currentNode.IsWordEnd)
                {
                    result = true;
                }
                else result = false;
            }
            else
            {
                char symbol = key[0];
                TrieNode<T> subTrieNode = currentNode.GetSubNode(symbol);
                if (subTrieNode != null)
                {
                    result = SearchNode(key.Substring(1), subTrieNode);
                }
                else result = false;
            }
            return result;
        }
        
    }
}
