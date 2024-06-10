using System.Collections.Generic;
namespace HOT100_146
{
    //存取不是O(1)的解法 超时咯
    public class LRUCache
    {
        int capacity;
        int[] nums;
        Dictionary<int, int> pos;
        Dictionary<int, int> val;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.nums = new int[capacity];
            this.pos = new Dictionary<int, int>();
            this.val = new Dictionary<int, int>();
        }

        public int Get(int key)
        {
            if (val.TryGetValue(key, out var ret))
            {
                //把pos的数移到数组最后面
                Move(pos[key]);
                return ret;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (val.ContainsKey(key))
            { //更新
                val[key] = value;
                Move(pos[key]);
            }
            else
            {
                var numsCount = pos.Count;//最新index
                if (numsCount < capacity)
                {//没满
                    nums[numsCount] = key;
                    pos[key] = numsCount;
                    val[key] = value;
                }
                else
                {//满了 要踢掉头部的
                    var oldest = nums[0];
                    Move(0);
                    nums[numsCount - 1] = key;
                    pos[key] = numsCount - 1;
                    val[key] = value;
                    pos.Remove(oldest);
                    val.Remove(oldest);
                }
            }
        }

        private void Move(int position)
        {
            var tempValue = nums[position];
            var lastIndex = pos.Count - 1;
            for (int i = position; i < lastIndex; i++)
            {
                nums[i] = nums[i + 1];
                pos[nums[i]] = i;
            }
            nums[lastIndex] = tempValue;
            pos[tempValue] = lastIndex;
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */

    //双向链表结构 + 保存链表节点位置的哈希表
    public class LRUCache2
    {
        public class LinkedNode
        {
            public int key;
            public int val;
            public LinkedNode prev;
            public LinkedNode next;
            public LinkedNode() {}
            public LinkedNode(int key, int val, LinkedNode prev, LinkedNode next)
            {
                this.key = key;
                this.val = val;
                this.prev = prev;
                this.next = next;
            }
        }
        int size;
        int capacity;
        Dictionary<int, LinkedNode> map;
        //链表节点 最新使用的在头部
        LinkedNode head;
        LinkedNode tail;
        
        public LRUCache2(int capacity)
        {
            this.capacity = capacity;
            this.size = 0;
            this.map = new Dictionary<int, LinkedNode>();
            head = new LinkedNode();
            tail = new LinkedNode();
            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                //链表节点移动到头部
                Move(node);
                return node.val;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                node.val = value;
                Move(node);
            }
            else
            {
                //满了，抛弃最后一个节点
                if (this.size == this.capacity)
                {
                    var oldestNode = this.tail.prev;
                    this.map.Remove(oldestNode.key);
                    oldestNode.prev.next = oldestNode.next;
                    oldestNode.next.prev = oldestNode.prev;
                    this.size --;
                }
                var newNode = new LinkedNode(key, value, this.head, this.head.next);
                this.head.next.prev = newNode;
                this.head.next = newNode;
                map[key] = newNode;
                this.size ++;
            }
        }

        private void Move(LinkedNode node)
        {
            //链表节点移动到头部
            node.prev.next = node.next;
            node.next.prev = node.prev;
            node.prev = this.head;
            node.next = this.head.next;
            this.head.next = node;
            node.next.prev = node;
        }
    }
}