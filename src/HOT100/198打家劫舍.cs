using System;
namespace HOT100_198
{
    //dp
    public class Solution
    {
        public int Rob(int[] nums)
        {
            var dp = new int[nums.Length + 1];
            for (int i = 1; i <= nums.Length; i++)
            {
                if (i == 1) dp[i] = nums[i - 1];
                else if (i == 2) dp[i] = Math.Max(nums[i - 1], nums[i - 2]);
                else dp[i] = Math.Max(dp[i - 2] + nums[i - 1], dp[i - 1]);
            }
            return dp[nums.Length];
        }
    }
}