using System;
namespace MinimumDepthOfBinaryTree
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution 
    {
        int min = int.MaxValue;
        public int MinDepth(TreeNode root) 
        {
            if (root == null) return 0;
            Depth(root, 0);
            return min;
        }
        public void Depth(TreeNode root, int depth)
        {
            depth += 1;
            if (root.left == null && root.right == null) //叶子节点
            {
                min = Math.Min(min, depth);
            }

            if (root.left != null)
            {
                Depth(root.left, depth);
            }
            if (root.right != null)
            {
                Depth(root.right, depth);
            }
        }
    }
}