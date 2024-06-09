using System.Collections.Generic;
using System.Reflection;
using DS;
namespace Hot100_236
{
    //p和q的最近公共祖先n满足：
    //p在n的左/右子树 && q在n的右/左子树
    //或 n==p且q在n的一棵子树上 || n==q且p在n的一棵子树上
    public class Solution {
        TreeNode ret;
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            Traversal(root, p, q);
            return ret;
        }

        public bool Traversal(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null) return false;
            var l = Traversal(root.left, p, q);
            var r = Traversal(root.right, p, q);
            if (((root.val == p.val || root.val == q.val) && (l || r)) || (l && r))
            {
                ret = root;
            }
            return l || r || (root.val == p.val) || (root.val == q.val);
        }
    }

    //解法2:记录父节点
    public class Solution2 {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            var map = new Dictionary<int, TreeNode>();
            dfs(root, map);

            var fathers = new HashSet<TreeNode>();
            //所有祖先节点
            while(p != null)
            {
                fathers.Add(p);
                if (map.TryGetValue(p.val, out var n))
                {
                    p = n;
                }
                else
                {
                    p = null;
                }
            }

            while(q != null)
            {
                if (fathers.Contains(q)) return q;
                if (map.TryGetValue(q.val, out var n))
                {
                    q = n;
                }
                else
                {
                    q = null;
                }
            }
            return null;
        }

        public void dfs(TreeNode root, Dictionary<int, TreeNode> map)
        {
            if (root.left != null)
            {
                map[root.left.val] = root;
                dfs(root.left, map);
            }
            if (root.right != null)
            {
                map[root.right.val] = root;
                dfs(root.right, map);
            }
        }
    }
}