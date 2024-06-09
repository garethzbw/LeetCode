using DS;
namespace HOT100_234
{
    //递归 o(n) 空间o(1)
    //通过递归反向遍历链表，再和一个正向指针做比较
    public class Solution {
        private ListNode cur;
        public bool IsPalindrome(ListNode head) {
            cur = head;
            return Reverse(head);
        }
        public bool Reverse(ListNode head)
        {
            if (head != null)
            {
                if (!Reverse(head.next)) return false;
                if (head.val != cur.val) return false;
                cur = cur.next;
            }
            return true;
        }
    }
}  