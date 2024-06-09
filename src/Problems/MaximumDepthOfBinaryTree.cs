using System.Collections.Generic;
using System;
namespace MaximumDepthOfBinaryTree
{
    //https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution 
    {
        //1.遍历二叉树，递归
        public int MaxDepth(TreeNode root) 
        {
            if (root == null) return 0;
            return Rev(root, 0, -1);
        }

        public int Rev(TreeNode root, int count, int max)
        {
            count ++;
            if (count > max) max = count;

            if (root.left != null) max = Rev(root.left, count, max);
            if (root.right != null) max = Rev(root.right, count, max);
            return max;
        }

        public int MaxDepth2(TreeNode root)
        {
            return root == null ? 0 : Math.Max(MaxDepth2(root.left), MaxDepth2(root.right)) + 1;
        }
        public int Rev2(TreeNode root, int count)
        {
            if (root == null) return count;
            else
            {
                count ++;
                return Math.Max(Rev2(root.left, count), Rev2(root.right, count));
            }
        }
    }
}