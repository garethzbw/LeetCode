using DS;
namespace HOT100_142
{
    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
    public class Solution
    {
        public ListNode DetectCycle(ListNode head)
        {
            ListNode fast = head, slow = head;
            while(fast != null)
            {
                slow = slow.next;
                fast = fast.next;
                if (fast != null)
                {
                    fast = fast.next;
                }
                else
                {
                    return null;
                }
                if (slow == fast)
                {
                    var ptr = head;
                    while (ptr != slow)
                    {
                        ptr = ptr.next;
                        slow = slow.next;
                    }
                    return ptr;
                }
            }
            return null;
        }
    }
}