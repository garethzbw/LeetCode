using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Collections.Generic;
using DS;
using Sort;
using HOT100_208;
using HOT100_146;

namespace LeetCode
{
    using TreeNode = Hot100_104.TreeNode;
    class Program
    {
        static void Main(string[] args)
        {
            var solution = Activator.CreateInstance<HOT100_238.Solution>();
            // var node3 = new ListNode(5, null);
            // var node2 = new ListNode(4, node3);
            // var node1 = new ListNode(1, node2);

            // var node9 = new ListNode(4, null);
            // var node5 = new ListNode(3, node9);
            // var node4 = new ListNode(1, node5);

            // var node7 = new ListNode(6, null);
            // var node6 = new ListNode(2, node7);
            
            // Display(solution.Permute(new int[] {2,3,6,7}));
            // Display(solution.Permute(new int[] {2,3,5}));
            // Display(solution.Permute(new int[] {2}));
            var lru = new LRUCache(2);
            lru.Put(1, 1);
            lru.Put(2, 2);
            Display(lru.Get(1));
            lru.Put(3, 3);
            Display(lru.Get(3));
            Display(lru.Get(2));
        }

        static void Display<T>(IList<T> l)
        {
            System.Console.Write("[");
            for (int i = 0; i < l.Count; i++)
            {
                if (i == l.Count - 1)
                {
                    System.Console.Write(l[i]);
                }
                else
                {
                    System.Console.Write(l[i] + ", ");
                }
            }
            System.Console.WriteLine("]");
        }

        static void Display(IList<IList<int>> l)
        {
            System.Console.Write("[ ");
            for (int j = 0; j < l.Count; j++)
            {
                var item = l[j];
                System.Console.Write("[");
                for (int i = 0; i < item.Count; i++)
                {
                    if (i == item.Count - 1)
                    {
                        System.Console.Write(item[i] + "]");
                    }
                    else
                    {
                        System.Console.Write(item[i] + ", ");
                    }
                }
                if (j == l.Count - 1)
                {
                    System.Console.Write(" ");
                }
                else
                {
                    System.Console.Write(", ");
                }
            }
            System.Console.WriteLine("]");
        }

        static void Display(string s)
        {
            System.Console.WriteLine(s);
        }

        static void Display(bool b)
        {
            System.Console.WriteLine(b);
        }

        static void Display(int i)
        {
            System.Console.WriteLine(i);
        }

        static void Display(double b)
        {
            System.Console.WriteLine(b);
        }

        static void Display(int[] item)
        {
            System.Console.Write("[");
            for (int i = 0; i < item.Length; i++)
            {
                if (i != item.Length - 1)
                {
                    System.Console.Write(item[i] + ", ");
                }
                else
                {
                    System.Console.WriteLine(item[i] + "]");
                }
            }
        }

        static void Display(char[][] l)
        {
            System.Console.Write("[ ");
            foreach (var item in l)
            {
                System.Console.Write("[");
                foreach (var i in item)
                {
                    System.Console.Write(i + " ");
                }
                System.Console.Write("]");
            }
            System.Console.WriteLine(" ]");
        }
        
        static void Display(TreeNode root)
        {
            System.Console.Write("[");
            RevDisplayTreeNode(root);
            System.Console.WriteLine("]");
        }
        static void RevDisplayTreeNode(TreeNode root)
        {
            if (root == null) return;
            RevDisplayTreeNode(root.left);
            System.Console.Write(root.val + ", ");
            RevDisplayTreeNode(root.right);
        }
        
        static void Display(ListNode list)
        {
            System.Console.Write("[");
            if (list != null)
            {
                do
                {
                    if (list.next != null)
                    {
                        System.Console.Write(list.val + ", ");
                    }
                    else
                    {
                        System.Console.Write(list.val);
                    }
                    list = list.next;
                } while (list != null);
            }
            System.Console.WriteLine("]");
        }
    }
}
