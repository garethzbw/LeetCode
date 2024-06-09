using System;
namespace HOT100_11
{
    //双循环 直接进行一个时的超
    public class Solution {
        public int MaxArea(int[] height) {
            var max = 0;
            for (int i = 0; i < height.Length - 1; i++)
            {
                for (int j = i + 1; j < height.Length; j++)
                {
                    var result = height[i] >= height[j] ? height[j] * (j - i) : height[i] * (j - i);
                    if (result > max) max = result;
                }
            }
            return max;
        }
    }

    // 双指针
    public class Solution2
    {
        public int MaxArea(int[] height) 
        {
            int l = 0, r = height.Length - 1, max = -1;
            while (l < r)
            {
                max = Math.Max(max, (r - l) * Math.Min(height[l], height[r]));
                if (height[l] <= height[r]) ++l;
                else --r;
            }
            return max;
        }
    }
}