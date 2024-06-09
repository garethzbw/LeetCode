using System.Collections.Generic;
namespace HOT100_19
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    // 1. 遍历一遍
    public class Solution {
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
            var list = new List<ListNode>() { head };
            var p = head;
            while (p.next != null)
            {
                p = p.next;
                list.Add(p);
            }
            var index = list.Count - n + 1; // index >= 1
            if (index == 1) return head.next;
            else
            {
                var trueIndex = index - 1;
                if (trueIndex < list.Count - 1) list[trueIndex - 1].next = list[trueIndex + 1];
                else list[trueIndex - 1].next = null;
            }
            return head;
        }
    }
    // 2. 栈
    public class Solution2 {
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
            var stack = new Stack<ListNode>();
            var p = head;
            do
            {
                stack.Push(p);
                p = p.next;
            } while (p != null);
            ListNode post = null;
            for (int i = 1; i <= n; i++)
            {
                var node = stack.Pop();
                if (i != n) post = node;
            }
            if (stack.Count > 0)
            {
                var prev = stack.Peek();
                prev.next = post;
            }
            else
            {
                return post;
            }
            return head;
        }
    }

    // 双指针 第二个指针与第一个指针距离n，同时遍历 第二个到末尾的时候第一个刚好在倒数第n个节点上
    // 优化：第一个指针指向dummy dummy指向head，即两个指针相距n+1 第二个到末尾的时候第一个指针在倒数第n个的前驱节点上
    public class Solution3
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
            var r = head;
            var l = head;
            ListNode prev = null;
            for (int i = 1; i < n; ++i)
            {
                r = r.next;
            }
            while (r.next != null)
            {
                prev = l;
                l = l.next;
                r = r.next;
            }
            if (prev == null) return head.next;
            prev.next = l.next;
            return head;
        }
    }
}