using DS;
using System.Collections.Generic;
using System.Linq;
namespace Hot100_114
{
    public class Solution {
        public void Flatten(TreeNode root) {
            if (root == null) return;
            var st = new Stack<TreeNode>();
            st.Push(root);
            TreeNode prev = null;
            while(st.Any())
            {
                var cur = st.Pop();
                if (prev != null)
                {
                    prev.left = null;
                    prev.right = cur;
                }
                TreeNode l = cur.left, r = cur.right;
                if (r != null) st.Push(r);
                if (l != null) st.Push(l);
                prev = cur;
            }
            
        }
    }

    //解法2:前驱节点
    //因为是前序遍历，所以右子树肯定在左子树最右边节点的后面，左子树最右边节点成为前驱节点
    //所以就是遍历树，把右子树接在前驱节点的后面，再把左子树变成右子树，再重复这个过程。
    public class Solution2 {
    public void Flatten(TreeNode root) {
        if (root == null) return;
        while(root != null)
        {
            if (root.left != null)
            {
                var next = root.left;
                var pre = next;
                while(pre.right != null)
                {
                    pre = pre.right;
                }
                pre.right = root.right;
                root.left = null;
                root.right = next;
            }
            root = root.right;
        }
    }
}
}