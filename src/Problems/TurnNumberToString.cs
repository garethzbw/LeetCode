namespace TurnNumberToString
{
    // https://leetcode-cn.com/problems/ba-shu-zi-fan-yi-cheng-zi-fu-chuan-lcof/ 面试题46. 把数字翻译成字符串
    // 11258 -> 5
    
    // 思路1: 深度优先
    // 11258 -> 1125 -> 112 -> 11 -> 1 -> 0
    //                            -> 0
    //                      -> 1  -> 0
    //               -> 11  -> 1  -> 0
    //                      -> 0
    public class Solution 
    {
        public int TranslateNum(int num) 
        {
            return Rec(num, 0);
        }

        public int Rec(int num, int ret)
        {
            // System.Console.WriteLine(num);
            if (num == 0) 
            {
                return ret + 1;
            }

            ret = Rec(num / 10, ret);

            // 00
            if (num > 9 && num % 100 >= 10 && num % 100 <= 25)
            {
                ret = Rec(num / 100, ret);
            }

            return ret;
        }
    }

    // 思路2 动态规划dp
    // dp[i] = dp[i-1] when x > 25 or x < 10
    // dp[i] = dp[i-1] + dp[i-2] when 10 <= x <= 25
    internal sealed class SolutionDP
    {
        public int TranslateNum(int num) 
        {
            int prepre = 1, pre = 1; // prepre = i-2, pre = i-1
            while(num > 0)
            {
                int dpi = (num >= 10 && num % 100 <= 25 && num % 100 >= 10) ? prepre + pre : pre;

                num = num / 10;

                prepre = pre;
                pre = dpi;
            }
            return pre;
        }
    }
}