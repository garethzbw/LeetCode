using System.Collections.Generic;
namespace CloneGraph
{
    //https://leetcode-cn.com/problems/clone-graph/
    // Definition for a Node.
    public class Node {
        public int val;
        public IList<Node> neighbors;
        
        public Node() {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val) {
            val = _val;
            neighbors = new List<Node>();
        }
        
        public Node(int _val, List<Node> _neighbors) {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution 
    {
        Dictionary<Node, Node> visted = new Dictionary<Node, Node>();

        public Node CloneGraph(Node node) 
        {
            if (node == null) return null;
            var copy = new Node(node.val);
            visted.Add(node, copy);
            copy = DFS(node, copy);
            return copy;
        }
        public Node DFS(Node node, Node parent)
        {
            foreach (var item in node.neighbors)
            {
                // 如果这个点是已经搜索过的，只添加到neighborlist里
                if (visted.ContainsKey(item)) 
                {
                    parent.neighbors.Add(visted[item]);
                }
                else
                {
                    var nNode = new Node(item.val);
                    visted.Add(item, nNode);
                    parent.neighbors.Add(DFS(item, nNode));
                }
            }
            return parent;
        }

        // public Node BFS(Node node, Node parent)
        // {
        //     foreach (var item in node.neighbors)
        //     {
        //         if (visted.ContainsKey(item))
        //         {
        //             parent.neighbors.Add(visted[item]);
        //         }
        //     }
        // }
    }
}