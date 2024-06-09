using System;
using DS;
namespace Hot100_23
{
    /// <summary>
    /// 思路1: 顺序合并 合并方法采用递归合并2个链表
    /// </summary>
    public class Solution1 {
        public ListNode MergeKLists(ListNode[] lists) {
            ListNode l = null;
            if (lists.Length > 0)
            {
                l = lists[0];
                for (int i = 1; i < lists.Length; i++)
                {
                    l = Merge(l, lists[i]);
                }
            }
            return l;
        }
        public ListNode Merge(ListNode n1, ListNode n2)
        {
            if (n1 == null) return n2;
            if (n2 == null) return n1;
            if (n1.val >= n2.val)
            {
                n2.next = Merge(n1, n2.next);
                return n2;
            }
            else
            {
                n1.next = Merge(n1.next, n2);
                return n1;
            }
        }
    }

    /// <summary>
    /// 思路2: 二分法合并 合并方法采用递归合并2个链表
    /// </summary>
    public class Solution2 {
        public ListNode MergeKLists(ListNode[] lists) {
            return MergeListsPartition(lists, 0, lists.Length - 1);
        }

        //用二分的方式两两合并
        public ListNode MergeListsPartition(ListNode[] lists, int l, int r)
        {
            if (l > r) return null;
            if (l == r) return lists[l];
            int divide = (l + r) / 2;
            return Merge(MergeListsPartition(lists, l, divide), MergeListsPartition(lists, divide + 1, r));
        }

        public ListNode Merge(ListNode n1, ListNode n2)
        {
            if (n1 == null) return n2;
            if (n2 == null) return n1;
            if (n1.val >= n2.val)
            {
                n2.next = Merge(n1, n2.next);
                return n2;
            }
            else
            {
                n1.next = Merge(n1.next, n2);
                return n1;
            }
        }
    }

    /// <summary>
    /// 思路3: 优先队列/小根堆
    /// </summary>
    public class Solution3 {
        
    }
}