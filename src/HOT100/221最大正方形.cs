using System;

namespace Hot100_221
{
    //暴力
    public class Solution {
        public int MaximalSquare(char[][] matrix) {
            int max = 0;
            int w = matrix.Length;
            if (w < 1) return max;
            int l = matrix[0].Length;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (matrix[i][j] == '1')
                    {
                        var ml = (w - i) < (l - j) ? w - i : l - j;
                        for (int k = 1; k <= ml; ++k)
                        {
                            var flag = true;
                            //新增行
                            for(int co = j; co <= j + k - 1; co ++)
                            {
                                if (matrix[i + k - 1][co] != '1')
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            //新增列
                            if (!flag) break;
                            for (int co = i; co <= i + k - 1; co ++)
                            {
                                if (matrix[co][j + k - 1] != '1')
                                {
                                    flag = false;
                                    break;
                                }
                            }
                            if (flag) max = Math.Max(max, k * k);
                            else break;
                        }
                    }
                }
            }
            return max;
        }
    }
    
    //动态规划
    public class Solution2 {
        public int MaximalSquare(char[][] matrix) {
            int w = matrix.Length;
            int max = 0;
            if (w < 1) return max;
            var dp = new int[matrix.Length, matrix[0].Length];
            int l = matrix[0].Length;
            for(int i = 0; i < w; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    if (i == 0 || j == 0) dp[i,j] = matrix[i][j] == '1' ? 1 : 0;
                    else
                    {
                        if (matrix[i][j] == '1')
                        {
                            dp[i,j] = Math.Min(dp[i-1,j], Math.Min(dp[i,j-1], dp[i-1,j-1])) + 1;
                        }
                        else
                        {
                            dp[i,j] = 0;
                        }
                    }
                    max = Math.Max(max, dp[i,j]);
                }
            }
            return max * max;
        }
    }
}