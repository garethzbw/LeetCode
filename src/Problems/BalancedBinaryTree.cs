using System;
namespace BalancedBinaryTree
{
    // https://leetcode-cn.com/problems/balanced-binary-tree/
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution 
    {
        //方法1.自顶向下的递归
        public bool IsBalanced1(TreeNode root) 
        {
            if (root == null) return true;
            else
            {
                return Math.Abs(GetDepth(root.left) - GetDepth(root.right)) <= 1 && IsBalanced1(root.left) && IsBalanced1(root.right);
            }
        }
        public int GetDepth(TreeNode root)
        {
            if(root == null) return 0;
            else
            {
                return Math.Max(GetDepth(root.left), GetDepth(root.right)) + 1;
            }
        }

        //方法2.自底向上的递归
        public bool IsBalanced2(TreeNode root)
        {
            if (root == null) return true;
            return GetDepth2(root) != -1;
        }
        public int GetDepth2(TreeNode root)
        {
            if (root == null) return 0;
            int left = GetDepth2(root.left);
            int right = GetDepth2(root.right);

            if (left - right > 1 || left == -1 || right == -1)
            {
                return -1;
            }
            return Math.Max(left, right) + 1;
        }
    }
}
