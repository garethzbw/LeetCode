using System;
using DS;
namespace Hot100_21
{
    public class Solution
    {   
        // 解法1: 遍历其中一个链表，将其插入到另一个链表上
        // 剪枝：被插入的链表B如果遍历完了都没有可以插入的位置，则将A直接连到B的末尾
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var flag = false;
            ListNode a1 = l1 == null ? null : l1.next;
            ListNode a2 = null;
            while (l1 != null)
            {
                while (l2 != null) // l1插入到l2上
                {
                    if (l1.val <= l2.val) // l1插入l2的前一个节点
                    {
                        // l1.next = l2.next;
                        // l2.next = l1;
                        // l2 = l1.next;

                        if (a2 == null)
                        {
                            l1.next = l2;
                        }
                        else 
                        {
                            l1.next = a2.next;
                            a2.next = l1;
                        }
                        break;
                    }
                    else // l1.val > l2.val l2向前
                    {
                        a2 = l2;
                        l2 = l2.next;
                    }
                }
                l1 = a1;
                a1 = a1.next;
            }
            return a1;
        }
    }

    // 官方题解：递归
    // if l1[0].val > l2[0].val: l2[0] + merge(l1, l2(1:))
    // else: l1[0] + merge(l1[1:], l2)
    // 时间复杂度：O(m + n)
    // 空间复杂度：O(m + n)
    public class Solution2
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val > l2.val)
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
            else
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
        }
    }

    // 官方题解： 迭代
    // 重头建立一个新的链表，取head做新头，作为返回值，prev指向新链表
    public class Solution3
    {
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var head = new ListNode(-1);
            var prev = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }
            prev.next = l1 ?? l2;
            return head.next;
        }
    }
}