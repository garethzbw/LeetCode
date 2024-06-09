//https://leetcode.cn/problems/best-time-to-buy-and-sell-stock/description/?envType=problem-list-v2&envId=2cktkvj
using System;

namespace ET
{
    public class Solution {
        public int MaxProfit(int[] prices) {
            var minPrice = Int32.MaxValue;
            var profit = 0;
            for(int i = 0; i < prices.Length; i ++)
            {
                if (prices[i] < minPrice) minPrice = prices[i];
                profit = prices[i] - minPrice > profit ? prices[i] - minPrice : profit;
            }
            return profit;
        }
    }
}