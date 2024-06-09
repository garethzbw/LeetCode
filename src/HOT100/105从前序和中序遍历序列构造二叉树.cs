using DS;
using System;
using System.Linq;
namespace HOT100_105
{
    public class Solution {
        //前序: 根, [左子树], [右子树]
        //中序：[左子树], 根，[右子树]
        //根据前序序列找到根节点，在中序序列中找出左子树和右子树的长度，就拿到了左子树和右子树的前序和中序序列，递归的构造左右子树，并且接到根节点的左右
        public TreeNode BuildTree(int[] preorder, int[] inorder) {
            
            var n = preorder.Length;
            return Build(preorder, inorder, 0, n-1, 0, n-1);
        }
        public TreeNode Build(int[] preorder, int[] inorder, int prel, int prer, int inl, int inr)
        {
            if (prel > prer) return null;
            var root = preorder[prel];
            var inorderRootIndex = Array.IndexOf(inorder, root);
            var rTreeLen = inr - inorderRootIndex;
            var lTreeLen = inorderRootIndex - inl;
            var node = new TreeNode(val: root);
            node.left = Build(preorder, inorder, prel + 1, prel + lTreeLen, inl, inorderRootIndex - 1);
            node.right = Build(preorder, inorder, prel + lTreeLen + 1, prer, inorderRootIndex + 1, inr);
            return node;
        }
    }
}