using System.Collections.Generic;
namespace FindModeInBST
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution {
        List<int> l = new List<int>();
        public int[] FindMode(TreeNode root) {
            Rev(root);
            var ret = new List<int>[l.Count + 1];
            var hash = new Dictionary<int, int>();
            foreach (var item in l)
            {
                if (!hash.ContainsKey(item))
                {
                    hash.Add(item, 0);
                }
                hash[item] += 1;
            }

            foreach (var item in hash.Keys)
            {
                if (ret[hash[item]] == null)
                {
                    ret[hash[item]] = new List<int>();
                }
                ret[hash[item]].Add(item);
            }
            for (int i = ret.Length - 1; i > 0; i--)
            {
                if (ret[i] != null && ret[i].Count != 0)
                {
                    return ret[i].ToArray();
                }
            }
            return new int[]{};
        }

        public void Rev(TreeNode root)
        {
            if (root == null) return;
            Rev(root.left);
            l.Add(root.val);
            Rev(root.right);
        }
    }
}