namespace PalindromicSubstrings
{
    public class Solution 
    {
        public int CountSubstrings(string s) 
        {
            if (s == null) return 0;
            var dp = new bool[s.Length][];
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = new bool[s.Length];
            }

            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (i == j) 
                    {
                        dp[i][j] = true;
                        count ++;
                    }
                    else if (j == i - 1 && s[i] == s[j]) 
                    {
                        dp[i][j] = true;
                        count ++;
                    }
                    else if (s[i] == s[j] && dp[i-1][j+1])
                    {
                        dp[i][j] = true;
                        count ++;
                    }
                }
            }
            return count;
        }
    }
}