using System;

namespace Hot100_206
{
    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        //思路1:迭代。遍历链表，记下当前节点head的前一个节点prev，并将head.next设为prev即实现一个节点的反转，赋值之前要先用next记下head的next节点防止丢失
        public ListNode ReverseList(ListNode head) 
        {
            if (head == null) return head;
            ListNode prev = null;
            ListNode next = null;
            while (head != null)
            {
                next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }
            return prev;
        }
    }

    public class Solution2
    {
        //思路1:递归，一种比较难理解的思路
        //先一路递到最后一个节点，这个节点就是反转后链表的头节点，记为newHead
        //归的过程中，不断的把当前节点的next的next设为当前节点（就是反转节点），然后将当前节点的next设为null(为了避免出现环路，以及head节点的next应为null)
        //运行时间比迭代的快,dunno why
        public ListNode ReverseList(ListNode head) 
        {
            if (head == null || head.next == null) return head;
            var newHead = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            return newHead;
        }
    }

    public class Solution3
    {
        //思路3:双指针，
        public ListNode ReverseList(ListNode head) 
        {
            if (head == null) return head;
            var cur = head;
            while (head.next != null)
            {
                var temp = head.next.next;
                head.next.next = cur;
                cur = head.next;
                head.next = temp;
            }
            return cur;
        }
    }
}