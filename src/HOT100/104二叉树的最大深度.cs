using System.Collections.Generic;
using System;
namespace Hot100_104
{
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    //1.深度优先
    public class Solution
    {
        //官方题解递归
        public int MaxDepth(TreeNode root)
        {
            // return 1 + Math.Max(root.left == null ? 0 : MaxDepth(root.left), root.right == null ? 0 : MaxDepth(root.right));
            if (root == null) return 0;
            return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }

        //自己的写法
        public int MaxDepth2(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + Math.Max(root.left == null ? 0 : MaxDepth(root.left), root.right == null ? 0 : MaxDepth(root.right));
        }
    }
    
    //广度优先
    public class Solution2
    {
        public int MaxDepth(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            var distance = 0;
            q.Enqueue(root);
            while (q.Count != 0)
            {
                distance ++;
                var size = q.Count;
                while (size > 0)
                {
                    var node = q.Dequeue();
                    size --;
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
            }
            return distance;
        }
    }
}