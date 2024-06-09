using System.Collections.Generic;
namespace BinaryTreeInorder
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    
    public class Solution 
    {
        public IList<int> InorderTraversal(TreeNode root) 
        {
            var ret = new List<int>();
            var st = new Stack<TreeNode>();
            while (st.Count != 0 || root != null)
            {
                while (root != null)
                {
                    st.Push(root);
                    root = root.left;
                }
                root = st.Pop();
                ret.Add(root.val);
                root = root.right;
            }
            return ret;
        }
    }
}