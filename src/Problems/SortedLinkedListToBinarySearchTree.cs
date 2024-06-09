namespace SortedLinkedListToBinarySearchTree
{
    //https://leetcode-cn.com/problems/convert-sorted-list-to-binary-search-tree
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    public class Solution 
    {
        ListNode pointer;
        //方法1. 分治： bst的根结点为链表的中位数节点，因为bst的每个子树都是bst，所以转化为分治问题
        public TreeNode SortedListToBST(ListNode head) 
        {
            if (head == null) return null;
            return BuildTree(head, null);
        }
        public TreeNode BuildTree(ListNode head, ListNode tail)
        {
            if (head == tail) return null;

            var median = FindMedian(head, tail);
            var root = new TreeNode(median.val);
            root.left = BuildTree(head, median);
            root.right = BuildTree(median.next, tail);
            return root;
        }
        //快慢指针法找到中位数的链表节点，作为BST子树的根结点
        public ListNode FindMedian(ListNode head, ListNode tail)
        {
            ListNode fast = head, slow = head;
            while(fast != tail && fast.next != tail)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        //方法2:分治+中序遍历优化快慢指针：有序链表就是中序遍历的bst
        public TreeNode SortedListToBST2(ListNode head)
        {
            if (head == null) return null;
            pointer = head;
            int length = 1; //用来标识终止条件
            while(head.next != null)
            {
                head = head.next;
                length ++;
            }
            return Inorder(0, length - 1);
        }
        // 中序遍历构建bst，每个子树的根结点先用空值占位，然后 左->中->右
        public TreeNode Inorder(int left, int right)
        {
            if (left > right) return null;

            var mid = (left + right) / 2;
            TreeNode root = new TreeNode();
            root.left = Inorder(left, mid - 1);
            root.val = pointer.val;
            pointer = pointer.next;
            root.right = Inorder(mid + 1, right);

            return root;
        }
    }
}