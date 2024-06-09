using System;
using System.Linq;
namespace MinimumPathSum
{
    //https://leetcode-cn.com/problems/minimum-path-sum/
    // 输入:
    // [
    //   [1,3,1],
    //   [1,5,1],
    //   [4,2,1]
    // ]
    // 输出: 7
    public class Solution 
    {
        //1.穷举法
        public int MinPathSum(int[][] grid) 
        {
            for (int i = 0; i < grid.Length; i++)
            {
                
            }
            return 0;
        }

        //2.dp
        // dp[i][j] = min(dp[i-1][j], dp[i][j-1]) + grid[i][j]
        // dp[0][j] = dp[0][j-1] + grid[0][j]
        // dp[i][0] = dp[i-1][0] + grid[i][0]
        public int MinPathSumDP(int[][] grid) 
        {
            if (grid.Length == 0) return 0;

            int rows = grid.Length, cols = grid[0].Length;
            int[][] dp = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                dp[i] = new int[cols];
            }
            dp[0][0] = grid[0][0];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 && j == 0) continue;
                    else if (i == 0 && j != 0) dp[i][j] = dp[i][j-1] + grid[i][j];
                    else if (i != 0 && j == 0) dp[i][j] = dp[i-1][0] + grid[i][j];
                    else dp[i][j] = Math.Min(dp[i-1][j], dp[i][j-1]) + grid[i][j];
                }
            }
            return dp[rows-1][cols-1];
        }
    }
}