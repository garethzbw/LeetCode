using System.Collections.Generic;
/**
给你一个按照非递减顺序排列的整数数组 nums，和一个目标值 target。请你找出给定目标值在数组中的开始位置和结束位置。
如果数组中不存在目标值 target，返回 [-1, -1]。
你必须设计并实现时间复杂度为 O(log n) 的算法解决此问题。

示例 1：

输入：nums = [5,7,7,8,8,10], target = 8
输出：[3,4]
示例 2：

输入：nums = [5,7,7,8,8,10], target = 6
输出：[-1,-1]
示例 3：

输入：nums = [], target = 0
输出：[-1,-1]
**/
namespace HOT100_34
{
    public class Solution
    {
        int max;
        int min;
        public int[] SearchRange(int[] nums, int target)
        {
            max = -1;
            min = nums.Length;
            Search(nums, target, 0, nums.Length - 1);
            if (min == nums.Length) min = -1;
            return max == -1 && min != -1 ? new int[]{ min, min } : max != -1 && min == -1 ? new int[] { max, max } : new int[] { min, max };
        }
        public void Search(int[] nums, int target, int l, int r)
        {
            if (l > r) return;
            int mid = (l + r) / 2;
            if (nums[mid] == target)
            {
                if (mid < min) min = mid;
                if (mid > max) max = mid;
                Search(nums, target, l, mid - 1);
                Search(nums, target, mid + 1, r);
            }
            else if (nums[mid] < target)
            {
                Search(nums, target, mid + 1, r);
            }
            else
            {
                Search(nums, target, l, mid - 1);
            }
        }
    }
}