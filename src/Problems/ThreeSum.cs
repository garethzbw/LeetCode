using System;
using System.Collections.Generic;
namespace ThreeSum
{
    //https://leetcode-cn.com/problems/3sum/ 三数之和
    //[-1, 0, 1, 2, -1, -4] -> [ [-1, 0, 1], [-1, -1, 2] ]
    public class Solution
    {
        //思路1 暴力
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var ret = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j ++)
                {
                    for (int k = i + 2; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            ret.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        }
                    }
                }
            }

            //去重
            return ret;
        }

        //排序+双向指针
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            var ret = new List<IList<int>>();
            Array.Sort(nums);

            if (nums.Length < 3) return ret;

            for (int i = 0; i < nums.Length - 2; i ++)
            {
                if (nums[i] > 0) break; //如果第一个数大于0 则三数之和不会等于0

                if (i!= 0 && nums[i] == nums[i-1]) continue; //和之前一轮重复，则最终结果会重复，跳过
                int L = i + 1, R = nums.Length - 1;

                while(L < R)
                {
                    if (nums[L] + nums[R] == - nums[i]) 
                    {
                        ret.Add(new List<int>{nums[i], nums[L], nums[R]});
                        L++;
                        R--;
                        while(L != i + 1 && L<R && nums[L] == nums[L-1]) L++; //和之前一轮重复，则最终结果会重复，跳过
                        while(R != nums.Length - 1 && L<R && nums[R] == nums[R+1]) R--; //和之前一轮重复，则最终结果会重复，跳过
                        
                    }
                    else if (nums[L] + nums[R] < - nums[i]) L++;
                    else R--;
                }
            }
            return ret;
        }
    }
}