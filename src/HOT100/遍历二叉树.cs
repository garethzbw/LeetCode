using CloneGraph;
using DS;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
namespace BinaryTree
{
    public class Traverse
    {
        //一直往左走入栈并且输出，左边没了出栈向右子树走，再重复前面的
        public void PreOrder(TreeNode root)
        {
            var node = root;
            var st = new Stack<TreeNode>();
            while(st.Any() || node != null)
            {
                if(node != null)
                {
                    System.Console.WriteLine(node);
                    st.Push(node);
                    node = node.left;
                }
                else
                {
                    node = st.Pop();
                    node = node.right;
                }
            }
        }

        //一直往左走入栈，左边没了往右走出栈并输出，重复前面的
        public void InOrder(TreeNode root)
        {
            var node = root;
            var st = new Stack<TreeNode>();
            while(st.Any() || node != null)
            {
                if (node != null)
                {
                    st.Push(node);
                    node = node.left;
                }
                else
                {
                    node = st.Pop(); //弹出的都是左边已经走完的
                    System.Console.WriteLine(node);
                    node = node.right;
                }
            }
        }

        public class NodeSt
        {
            public TreeNode node;
            public int flag; //0表示右子树还没遍历 1表示右子树已遍历，可以访问该节点
        }

        //用一个标识位flag标记是否该节点左右子树均已访问
        //还是一路向左入栈，初始化每个节点flag为0，左子树走完出栈判断flag=0表示右子树还没走，置为1重新入栈；flag=1表示左右都走完，访问节点，重复前面的
        public void PostOrder(TreeNode root)
        {
            var st = new Stack<NodeSt>();
            while(st.Any() || root != null)
            {
                while(root != null)
                {
                    var data = new NodeSt() { node = root, flag = 0 };
                    st.Push(data);
                    root = root.left;
                }
                var node = st.Pop();
                if (node.flag == 1)
                {
                    System.Console.WriteLine(node);
                    root = null;
                }
                else
                {
                    node.flag = 1;
                    st.Push(node);
                    root = node.node.right;
                }
            }
        }

        //非递归后序遍历思路2
        //将p出栈，如果是叶子节点或左右子树都访问过了 则直接访问；否则先将右再左儿子入栈，
        //用prev指针指向前一个访问的节点,cur指针指向当前栈顶节点，判断prev是否为cur的孩子，如果是则表示cur的左右子树都已被访问，可以访问cur
        public void PostOrder2(TreeNode root)
        {
            var st = new Stack<TreeNode>();
            TreeNode cur, prev = null;
            st.Push(root);
            while (st.Any())
            {
                cur = st.Peek();
                if ((cur.left == null && cur.right == null)
                    || ((prev == cur.left || prev == cur.right) && prev != null))
                {
                    st.Pop();
                    System.Console.WriteLine(cur);
                    prev = cur;
                }
                else
                {
                    if (cur.right != null) st.Push(cur.right);
                    if (cur.left != null) st.Push(cur.left);
                }
            }
        }
    }
}