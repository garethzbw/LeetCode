using DS;
namespace HOT100_148
{
    public class Solution
    {
        //归并的思想
        public ListNode SortList(ListNode head)
        {
            return Sort(head, null);
        }

        public ListNode Sort(ListNode head, ListNode tail)
        {
            if (head == null) return null; //链表最后一个节点
            if (head.next == tail) //递归终止条件 合并到最小单位时，左侧链表不包含最右边节点（因为右侧链表要用）
            {
                head.next = null;
                return head;
            }

            //用快慢指针找到链表中间点
            ListNode slow = head, fast = head;
            while (fast != tail)
            {
                slow = slow.next;
                fast = fast.next;
                if (fast != tail)
                {
                    fast = fast.next;
                }
            }
            var mid = slow;
            var list1 = Sort(head, mid);
            var list2 = Sort(mid, tail);
            var sorted = Merge(list1, list2);
            return sorted;
        }

        public ListNode Merge(ListNode n1, ListNode n2)
        {
            var dummy = new ListNode(0);
            ListNode t = dummy, t1 = n1, t2 = n2;
            while (t1 != null && t2 != null)
            {
                if (t1.val < t2.val)
                {
                    t.next = t1;
                    t1 = t1.next;
                }
                else
                {
                    t.next = t2;
                    t2 = t2.next;
                }
                t = t.next;
            }
            if (t1 != null)
            {
                t.next = t1;
            }
            if (t2 != null)
            {
                t.next = t2;
            }
            return dummy.next;
        }
    }
}
