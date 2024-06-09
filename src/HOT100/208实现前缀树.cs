using System.Linq;
using BalancedBinaryTree;

namespace HOT100_208
{
//            root
//          [a....z]
// [a....z] [a....z] [a.....z] ...    
    public class Trie
    {
        public Trie[] children;
        public bool isEnd;
        public Trie()
        {
            children = new Trie[26];
        }

        public void Insert(string word)
        {
            var node = this;
            foreach (var ch in word)
            {
                var index = ch - 'a';
                if (node.children[index] == null) //一层一层检查 没有就插入
                {
                    node.children[index] = new Trie();
                }
                node = node.children[index];
            }
            node.isEnd = true; //最后一个字符标记
        }

        public Trie SearchPrefix(string prefix)
        {
            var node = this;
            foreach (var ch in prefix)
            {
                var index = ch - 'a';
                if (node.children[index] == null)
                {
                    return null;
                }
                node = node.children[index];
            }
            return node;
        }

        public bool Search(string word)
        {
            var node = SearchPrefix(word);
            return node != null && node.isEnd;
        }

        public bool StartsWith(string prefix)
        {
            var node = SearchPrefix(prefix);
            return node != null;
        }
    }
}