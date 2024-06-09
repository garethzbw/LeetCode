using System.Collections.Generic;
namespace ConnectRightPointInBinaryTree
{
    //https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node-ii/
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class Solution {
        public Node Connect(Node root) 
        {
            var q = new Queue<Node>();
            q.Enqueue(root);
            Node t = null, pop = null;
            while(q.Count != 0)
            {
                var n = q.Count;
                for (int i = 0; i < n; i++)
                {
                    pop = q.Dequeue();
                    if (pop.left != null) 
                    {
                        q.Enqueue(pop.left);
                    }
                    if (pop.right != null)
                    {
                        q.Enqueue(pop.right);
                    }
                    if (i != 0) t.next = pop;
                    t = pop;
                }
                
            }
            return root;
        }
    }
}