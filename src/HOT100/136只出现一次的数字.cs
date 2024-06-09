using System.Collections.Generic;
using System;
namespace Hot100_136
{
    public class Solution 
    {
        //自己的解法1:先排序，再遍历
        //执行时间拉满了.. 击败了5.97%的用户
        public int SingleNumber(int[] nums) 
        {
            Array.Sort(nums);
            int i = 1;
            for (; i < nums.Length; i += 2)
            {
                if (nums[i] != nums[i-1])
                {
                    return nums[i-1];
                }
            }
            return nums[nums.Length - 1];
        }

        //自己的解法2:用字典，虽然不符合题目里说的不使用额外空间
        //27.78%..
        public int SingleNumber2(int[] nums) 
        {
            var dic = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                dic[item] = dic.GetValueOrDefault(item) + 1;
            }
            foreach (var k in dic.Keys)
            {
                if(dic[k] == 1)
                {
                    return k;
                }
            }
            return -1;
        }

        //官方题解：异或，辣是真的牛皮
        public int SingleNumber3(int[] nums)
        {
            var single = 0;
            foreach (var item in nums)
            {
                single ^= item;
            }
            return single;
        }
    }
}