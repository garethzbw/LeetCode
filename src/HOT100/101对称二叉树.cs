using DS;
using System;
using System.Collections.Generic;
using System.Linq;
//https://leetcode.cn/problems/symmetric-tree/?envType=problem-list-v2&envId=2cktkvj
namespace HOT100_101
{
    //自己的解法1-递归
    public class Solution {
        public bool IsSymmetric(TreeNode root) {
            return Sym(root.left, root.right);
        }
        public bool Sym(TreeNode l, TreeNode r)
        {
            if (l == null && r == null) return true;
            var flag = l != null && r != null && (l.val == r.val);
            if (!flag) return flag;
            var flag1 = Sym(l.left, r.right);
            var flag2 = Sym(l.right, r.left);
            return flag & flag1 & flag2;
        }
    }

    //自己的解法2-迭代
    public class Solution2 {
        public bool IsSymmetric(TreeNode root) {
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(root);
            while(q.Any()) {
                var l = q.Dequeue();
                var r = q.Dequeue();
                if (l == null && r == null) continue;
                if ((l == null || r == null) || (l.val != r.val)) return false;

                q.Enqueue(l.left);
                q.Enqueue(r.right);
                q.Enqueue(l.right);
                q.Enqueue(r.left);
            }
            return true;
        }
    }
}