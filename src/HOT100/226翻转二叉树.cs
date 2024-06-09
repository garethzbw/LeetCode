using System;
using System.Collections.Generic;
namespace Hot100_226
{
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    //思路1:自己的思路，递归翻转每个节点的左右子节点，直到没有叶子节点为止
    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            var temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        } 
    }

    //官方题解：深度优先递归，但是不占用额外空间
    public class Solution2
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            var left = InvertTree(root.left);
            var right = InvertTree(root.right);
            root.right = left;
            root.left = right;
            return root;
        }
    }

    //思路2:广度优先遍历,每层每个节点依次处理，然后再把子节点加入队列
    //时间复杂度：O(N)
    public class Solution3
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var node = q.Dequeue();
                var temp = node.left;
                node.left = node.right;
                node.right = temp;
                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }    
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
            return root;
        }

        public void doSomething(TreeNode node)
        {
            System.Console.WriteLine(node.val);
        }

        public void PostOrderStacks(TreeNode root)
        {
            if (root == null) return;
            var st1 = new Stack<TreeNode>();
            var st2 = new Stack<TreeNode>();
            st1.Push(root);
            while (st1.Count != 0)
            {
                var node = st1.Pop();
                if (node.left != null)
                {
                    st1.Push(node.left);
                }
                if (node.right != null)
                {
                    st1.Push(node.right);
                }
                st2.Push(node);
            }
            while (st2.Count != 0)
            {
                doSomething(st2.Pop());
            }
        }

        public void PostOrderStack(TreeNode root)
        {
            if (root == null) return;
            var st = new Stack<TreeNode>();
            st.Push(root);
            var node = root;
            while (st.Count != 0)
            {
                var head = st.Peek();
                if (head.left != null && head.left != node && head.right != node)
                {
                    st.Push(head.left);
                }
                else if (head.right != null && head.right != node)
                {
                    st.Push(head.right);
                }
                else 
                {
                    head = st.Pop();
                    doSomething(head);
                    node = head;
                }
            }
        }

        public void LevelOrder(TreeNode root)
        {
            if (root == null) return;
            var q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count != 0)
            {
                var node = q.Dequeue();
                doSomething(node);
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
        }
    }
}