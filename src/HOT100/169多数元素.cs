using System;
namespace Hot100_169
{
    //排序法
    public class Solution
    {
        //自己的解法1:先排序，再遍历
        public int MajorityElement(int[] nums)
        {
            int half = nums.Length / 2;
            int num = 0;
            int current;
            Array.Sort(nums);
            current = nums[0];
            foreach (var item in nums)
            {
                if (item == current) 
                {
                    num ++;
                    if (num > half) return item;
                }
                else 
                {
                    num = 1;
                    current = item;
                }
                
            }
            return nums[nums.Length - 1];
        }

        //官方题解：排序法优化。先排序，下标为n/2的下界的元素一定为众数
        // [0, 1, 2, 3, 4, 5, 6]
        public int MajorityElement2(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }

    }

    public class Solution2
    {
        public int MajorityElement(int[] nums)
        {
            //官方题解：随机化，根据众数的定义，随机挑选一个下标对应的数是众数的概率很高，验证这个数是否众数，是就返回，否则继续随机挑选。
            Random random = new Random();
            while (true)
            {
                var index = random.Next(0, nums.Length);
                if (IsMajority(nums[index], nums))
                {
                    return nums[index];
                }
            }
        }

        private bool IsMajority(int num, int[] nums)
        {
            var count = 0;
            var major = nums.Length / 2;
            foreach (var item in nums)
            {
                if (item == num)
                {
                    ++count;
                }
            }
            if (count >= major) return true;
            return false;
        }
    }

    //boyer-moore投票算法
    //candidate表示潜在众数；num表示当前遍历的数；count当num=candidate时+1否则-1，当count=0时candidate=num
    //因为众数一定比其他数加起来数量都多
    public class Solution3
    {
        public int MajorityElement(int[] nums) {
            var candidate = 0;
            var count = 0;
            for (int i = 0; i < nums.Length; i ++)
            {
                if (count == 0) candidate = nums[i];
                if (nums[i] == candidate) count ++;
                else count --;
            }
            return candidate;
        }
    }
}