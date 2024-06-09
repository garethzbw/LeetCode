using System;
using System.Collections.Generic;
namespace HouseRobber3
{
    //https://leetcode-cn.com/problems/house-robber-iii/
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    public class Solution 
    {
        //1.dp。 节点n选择时的最大值=两子树都不选时的最大值之和  节点n不选时的最大值=两子树分别选或不选的最大值之和
        public int Rob(TreeNode root) 
        {
            if (root == null) return 0;
            var choose = new Dictionary<TreeNode, int>();
            var notChoose = new Dictionary<TreeNode, int>();
            Dfs(choose, notChoose, root);
            return Math.Max(choose[root], notChoose[root]);
        }
        public void Dfs(Dictionary<TreeNode, int> choose, Dictionary<TreeNode, int> notChoose, TreeNode root)
        {
            if (root == null) return;
            Dfs(choose, notChoose, root.left);
            Dfs(choose, notChoose, root.right);
            
            choose.Add(root, root.val + (root.left != null ? notChoose.GetValueOrDefault(root.left, 0) : 0) + (root.right != null ? notChoose.GetValueOrDefault(root.right, 0) : 0));
            notChoose.Add(root, Math.Max((root.left != null ? choose.GetValueOrDefault(root.left, 0) : 0), (root.left != null ? notChoose.GetValueOrDefault(root.left, 0) : 0)) +
                Math.Max((root.right != null ? choose.GetValueOrDefault(root.right, 0) : 0), (root.right != null ? notChoose.GetValueOrDefault(root.right, 0) : 0)));
        }
    }
}