using System.Collections.Generic;
using System;
namespace Hot100_617
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    //自己做的解法1: 同时递归遍历两棵树，把值加在一起作为新树的节点
    //时间复杂度： O(min(m,n))
    public class Solution1
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null || root2 == null)
            {
                return root1 ?? root2;
            }

            root1.val += root2.val;
            root1.left = MergeTrees(root1.left, root2.left);
            root1.right = MergeTrees(root1.right, root2.right);
            return root1;
        }
    }
    
    //解法2:官方题解
    //深度优先DFS(先序遍历)，其实跟我自己的解法思路基本是一致的，只是新节点不是new的，是直接将t2合并到t1上
    public class Solution2
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null || root2 == null)
            {
                return root1 == null ? root2 : root1;
            }
            root1.val = root1.val + root2.val;
            root1.left = MergeTrees(root1.left, root2.left);
            root1.right = MergeTrees(root1.right, root2.right);
            return root1;
        }
    }

    //解法3:官方题解
    //迭代：广度优先BFS，队列/后序遍历：队列
    //时间复杂度：O(min(m,n)) m、n分别为两个二叉树的节点个数，因为到其中一棵树的叶节点就会停止遍历
    //空间复杂度：O(min(m,n))
    public class Solution3
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            var q1 = new Queue<TreeNode>();
            var q2 = new Queue<TreeNode>();
            var q = new Queue<TreeNode>();
            if (root1 == null || root2 == null)
            {
                return root1 == null ? root2 : root1;
            }
            var node = new TreeNode(root1.val + root2.val);
            q.Enqueue(node);
            q1.Enqueue(root1);
            q2.Enqueue(root2);
            while(q1.Count != 0 && q2.Count != 0) //用遍历一棵树的思路遍历两棵树
            {
                var node1 = q1.Dequeue();
                var node2 = q2.Dequeue();
                var node3 = q.Dequeue();
                if (node1.left != null || node2.left != null) //先左子树
                {
                    if (node1.left != null && node2.left != null) //左子树都不为空，组合
                    {
                        var newNode = new TreeNode(node1.left.val + node2.left.val);
                        node3.left = newNode;
                        q.Enqueue(newNode);
                        q1.Enqueue(node1.left);
                        q2.Enqueue(node2.left);
                    }
                    else if (node1.left == null) // 有一个为空，直接取另一个
                    {
                        node3.left = node2.left;
                    }
                    else if (node2.left == null)
                    {
                        node3.left = node1.left;
                    }
                }
                //右子树和左子树一样
                if (node1.right != null || node2.right != null)
                {
                    if (node1.right != null && node2.right != null)
                    {
                        var newNode = new TreeNode(node1.right.val + node2.right.val);
                        node3.right = newNode;
                        q.Enqueue(newNode);
                        q1.Enqueue(node1.right);
                        q2.Enqueue(node2.right);
                    }
                    else if (node1.right == null)
                    {
                        node3.right = node2.right;
                    }
                    else if (node2.right == null)
                    {
                        node3.right = node1.right;
                    }
                }
            }
            return node;
        }
    }
}