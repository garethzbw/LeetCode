using System;

namespace HOT100_647
{
    //方法1：dp 注意dp方向
    public class Solution
    {
        public int CountSubstrings(string s)
        {
            var dp = new bool[s.Length][];
            var count = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[s.Length];
            }
            for (int i = 0; i < dp.Length; i ++)
            {
                for (int j = i; j >= 0; j --)
                {
                    if (i == j) 
                    {
                        dp[j][i] = true;
                    }
                    else if (i == j + 1)
                    {
                        if (s[i] == s[j]) 
                        {
                            dp[j][i] = true;
                        }
                    }
                    else
                    {
                        if (j+1 <= i-1)
                        {
                            dp[j][i] = dp[j+1][i-1] & (s[i] == s[j]);
                        }
                    }
                    if (dp[j][i]) count ++;
                }
            }
            return count;
        }
    }
}