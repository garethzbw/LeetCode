using DS;
using System;
//https://leetcode.cn/problems/diameter-of-binary-tree/description/?envType=problem-list-v2&envId=2cktkvj
namespace HOT100_543
{
    //深度优先遍历
    //以一个节点为根结点的二叉树的直径=左右子树的(最长路径+1)之和
    //所以遍历所有节点统计这个值并且维护一个最大值
    public class Solution {
        int ret = 0;
        public int DiameterOfBinaryTree(TreeNode root) {
            Depth(root);
            return ret;
        }
        public int Depth(TreeNode root){
            if (root == null) return 0;
            int L = Depth(root.left);
            int R = Depth(root.right);
            ret = Math.Max(ret, L + R);
            return Math.Max(L, R) + 1;
        }
    }
}