using DS;
using System.Collections.Generic;
using System.Linq;
namespace HOT100_102
{
    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var q = new Queue<TreeNode>();
            var ret = new List<IList<int>>();
            if (root == null) return ret;
            q.Enqueue(root);
            TreeNode node = null;
            while (q.Any())
            {
                var l = new List<int>();
                var n = q.Count;
                while (n > 0)
                {
                    n--;
                    node = q.Dequeue();
                    l.Add(node.val);
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }
                if (l.Count > 0) ret.Add(l);
            }
            return ret;
        }
    }
}