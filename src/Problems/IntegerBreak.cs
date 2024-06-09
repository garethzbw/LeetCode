using System;
namespace IntegerBreak
{
    //https://leetcode-cn.com/problems/integer-break/
    public class Solution 
    {
        //1.dp
        public int IntegerBreak(int n) 
        {
            int[] dp = new int[n + 1];
            dp[0] = dp[1] = 0; 
            for(int i = 2; i <= n; i ++)
            {
                int max = 0;
                for(int j = 1; j < i; j ++)
                {
                    max = Math.Max(max, Math.Max(j * (i-j), j * dp[i-j]));
                }
                dp[i] = max;
            }
            return dp[n];
        }
    }
}