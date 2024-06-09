using System.Collections.Generic;
namespace SameTree
{
    //https://leetcode-cn.com/problems/same-tree/
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution 
    {
        public bool IsSameTree(TreeNode p, TreeNode q) 
        {
            var l1 = new List<int>();
            var l2 = new List<int>();
            Through(p, l1);
            Through(q, l2);

            if (l1.Count != l2.Count) return false;
            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i] != l2[i]) return false;
            }
            return true;
        }
        public void Through(TreeNode p, List<int> ret)
        {
            if (p == null) 
            {
                ret.Add(int.MinValue);
                return;
            }
            ret.Add(p.val);
            Through(p.left, ret);
            Through(p.right, ret);
        }
    }
}