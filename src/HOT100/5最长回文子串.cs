using System;
using System.Globalization;

namespace HOT100_5
{
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (s == "") return s;
            int maxl = 0, maxr = 0;
            var dp = new bool[s.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new bool[s.Length];
            }

            for (int j = 0; j < s.Length; j ++)
            {
                for (int i = 0; i <= j; i ++)
                {
                    if (i == j) dp[i][j] = true;
                    else if (i + 1 == j && s[i] == s[j]) dp[i][j] = true;
                    else
                    {
                        dp[i][j] = dp[i+1][j-1] & (s[i] == s[j]);
                    }
                    if (dp[i][j])
                    {
                        if (j - i > maxr - maxl) 
                        {
                            maxl = i;
                            maxr = j;
                        }
                    }
                }
            }
            return s.Substring(maxl, maxr - maxl + 1);
        }
    }
}