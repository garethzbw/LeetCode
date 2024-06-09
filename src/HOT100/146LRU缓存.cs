using System.Collections.Generic;
namespace HOT100_146
{
    public class LRUCache {
    int capacity;
    int[] nums;
    Dictionary<int, int> pos;
    Dictionary<int, int> val;
    public LRUCache(int capacity) {
        this.capacity = capacity;
        this.nums = new int[capacity];
        this.pos = new Dictionary<int, int>();
        this.val = new Dictionary<int, int>();
    }
    
    public int Get(int key) {
        if (val.TryGetValue(key, out var ret)) {
            //把pos的数移到数组最后面
            Move(pos[key]);
            return ret;
        }
        return 0;
    }

    public void Move(int position) {
        var val = nums[position];
        for (int i = position; i < nums.Length - 1; i ++) {
            nums[i] = nums[i + 1];
            pos[nums[i]] = i;
        }
        nums[nums.Length - 1] = val;
        pos[val] = nums.Length - 1;
    }
    
    public void Put(int key, int value) {
        if (val.ContainsKey(key)) {
            val[key] = value;
            Move(pos[key]);
        } else {
            var numsCount = pos.Count;
            if (numsCount < capacity) {
                nums[numsCount] = key;
                pos[key] = numsCount;
                val[key] = value;
            } else {
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
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
}