/**
给定一个不含重复数字的数组 nums ，返回其 所有可能的全排列 。你可以 按任意顺序 返回答案。

示例 1：
输入：nums = [1,2,3]
输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
示例 2：
输入：nums = [0,1]
输出：[[0,1],[1,0]]
示例 3：
输入：nums = [1]
输出：[[1]]

提示：
1 <= nums.length <= 6
-10 <= nums[i] <= 10
nums 中的所有整数 互不相同
**/
using System.Collections.Generic;
using System;
namespace HOT100_46
{
    public class Solution
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            var rt = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                Permute(new List<int>(){i}, new List<int>(), nums, rt);
            }
            return rt;
        }
        public void Permute(List<int> indexes, List<int> result, int[] nums, List<IList<int>> rt)
        {
            var index = indexes[indexes.Count - 1];
            result.Add(nums[index]);

            if (result.Count == nums.Length)
            {
                rt.Add(new List<int>(result));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!indexes.Contains(i))
                {
                    indexes.Add(i);
                    Permute(indexes, result, nums, rt);
                    indexes.RemoveAt(indexes.Count - 1);
                    result.RemoveAt(result.Count - 1);
                }
            }
        }
    }
}