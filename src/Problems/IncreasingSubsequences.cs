namespace IncreasingSubsequences
{
    using System.Collections.Generic;
    //https://leetcode-cn.com/problems/increasing-subsequences/
    public class Solution 
    {
        //1.递归遍历
        public IList<IList<int>> FindSubsequences(int[] nums) 
        {
            var ret = new List<IList<int>>();
            if (nums == null) return ret;
            DFS(nums, 0, ret, new List<int>());
            return ret;
        }
        public void DFS(int[] nums, int start, IList<IList<int>> ret, IList<int> now)
        {
            if (now.Count > 1)
            {
                ret.Add(new List<int>(now));
            }
            List<int> dup = new List<int>();
            for(int i = start; i < nums.Length; i ++)
            {
                if (dup.Contains(nums[i])) continue;
                dup.Add(nums[i]); // 同一个位置，即同一个深度的递归 不能出现相同的数，否则会出现重复的情况

                if (now.Count == 0 || nums[i] >= now[now.Count - 1]) 
                {
                    now.Add(nums[i]);
                    DFS(nums, i + 1, ret, now);
                    if (now.Count > 0)
                    {
                        now.RemoveAt(now.Count - 1);
                    }
                }
            }
        }
        public IList<int> copy(IList<int> now)
        {
            var ret = new List<int>();
            foreach (var item in now)
            {
                ret.Add(item);
            }
            return ret;
        }
    }
}