using System.Collections.Generic;
/**
给你一个只包含 '(' 和 ')' 的字符串，找出最长有效（格式正确且连续）括号子串的长度。

示例 1：

输入：s = "(()"
输出：2
解释：最长有效括号子串是 "()"
示例 2：

输入：s = ")()())"
输出：4
解释：最长有效括号子串是 "()()"

**/
namespace HOT100_32
{
    public class Solution {
        // dp[i]表示以下标为i结尾的最长有效子串长度
        // )()())
        public int LongestValidParentheses(string s) {
            if(s.Length < 2) return 0;
            var max = 0;
            var dp = new int[s.Length];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == ')')
                {
                    if (s[i-1] == '(') //和左边的括号匹配成了
                    {
                        dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                    }
                    else // ))
                    {
                        if (i > dp[i - 1] && s[i - dp[i - 1] - 1] == '(') // [..)])的左边是个( 可以匹配上
                        {
                            if (i > dp[i - 1] + 2) // ([..)])的左边还有,也就是dp[i - dp[i - 1] - 2]
                            {
                                dp[i] = dp[i - 1] + 2 + dp[i - dp[i - 1] - 2];
                            }
                            else // ([..)])的左边没了
                            {
                                dp[i] = dp[i - 1] + 2;
                            }
                        }
                    }
                }
                max = System.Math.Max(max, dp[i]);
            }
            return max;
        }
    }
}