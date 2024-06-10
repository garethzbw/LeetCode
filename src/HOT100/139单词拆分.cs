using System.Collections.Generic;

namespace HOT100_139
{
    public class Solution
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            var dp = new bool[s.Length + 1];
            var dic = new HashSet<string>(wordDict);
            dp[0] = true;
            for (int i = 1; i <= s.Length; i ++)
            {
                for (int j = 1; j <= i; j ++)
                {
                    if (!dp[i])
                    {
                        dp[i] = dp[j - 1] & dic.Contains(s.Substring(j - 1, i - j + 1));
                    }
                }
            }
            return dp[dp.Length - 1];
        }
    }
}