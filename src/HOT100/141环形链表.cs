using System.Collections.Generic;
using DS;
namespace HOT100_141
{
    //遍历记录
    public class Solution {
        public bool HasCycle(ListNode head) {
            var record = new HashSet<ListNode>();
            while(head != null)
            {
                if (record.Contains(head)) return false;
                record.Add(head);
                head = head.next;
            }
            return true;
        }
    }

    //快慢指针 龟兔赛跑赛跑算法
    //因为有环的存在，快指针会先进入环，慢指针后进入，在环中快慢指针会相遇
    public class Solution2
    {
        public bool HasCycle(ListNode head) {
            if (head == null) return false;
            var f = head.next;
            var s = head;
            while(f != s)
            {
                if (f == null || s == null || f.next == null) return false;
                s = s.next;
                f = f.next.next;
            }
            return true;
        }
    }
}