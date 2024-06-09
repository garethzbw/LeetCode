namespace HOT100_160
{
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
 }
public class Solution {
    // 暴力 o(mn)
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var bHead = headB;
        while(headA != null)
        {
            while(headB != null)
            {
                if (headB == headA) return headB;
                else
                {
                    headB = headB.next;
                }
            }
            headB = bHead;
            headA = headA.next;
        }
        return null;
    }

    //o(m+n)
    //双指针,同时遍历两个链表，每次比较，如果不想交都向前，A到尾部之后指向B的头，B到尾部之后指向A的头。直到找到想交节点或两个节点都为null
    //a链表长度m b链表长度n，相交长度为l 则两个指针在不相交的情况下都移动m+n次，同时到达尾部，这时他们的next都为null
    //相交的情况下 a指针移动 m+(n-l)次 b指针移动 n+(m-l)次 同时到达相交点
     public ListNode GetIntersectionNode2(ListNode headA, ListNode headB) {
        var aHead = headA;
        var bHead = headB;
        while(true)
        {
            if (headA == headB) return headA;
            else if (headA.next == null && headB.next == null) return null;
            else
            {
                if (headA.next == null) headA = bHead;
                else headA = headA.next;
                if (headB.next == null) headB = aHead;
                else headB = headB.next;
            }
        }
     }
}
}