namespace Hot100_283
{
    // 自己的解法：因为已经知道要移动的是0，遍历nums 如果nums[i]==0 把nums从tails开始整体前移一位 把nums[tail] = 0, --tail
    // 如果nums[i] == 0 i保持不变 否则i++
    public class Solution 
    {
        public void MoveZeroes(int[] nums) 
        {
            if (nums.Length <= 1) return;
            int tail = nums.Length - 1;
            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (tail <= i) break;
                if (nums[i] == 0)
                {
                    for (int j = i; j < tail; ++j)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[tail] = 0;
                    --tail;
                    --i;
                }
            }
        }
    }
    
    //快慢指针
    public class Solution2 {
    public void MoveZeroes(int[] nums) {
        int slow = 0, fast = 0;
        while(fast < nums.Length)
        {
            if(nums[fast] != 0)
            {
                //swap
                var t= nums[slow];
                nums[slow] = nums[fast];
                nums[fast] = t;
                slow++;
            }
            fast++;
        }
    }
}
}