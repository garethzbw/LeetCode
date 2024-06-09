using System.Collections.Generic;
using System.Linq;
using System;
/**
给你一个 无重复元素 的整数数组 candidates 和一个目标整数 target ，找出 candidates 中可以使数字和为目标数 target 的 所有 不同组合 ，并以列表形式返回。你可以按 任意顺序 返回这些组合。
candidates 中的 同一个 数字可以 无限制重复被选取 。如果至少一个数字的被选数量不同，则两种组合是不同的。 
对于给定的输入，保证和为 target 的不同组合数少于 150 个。

示例 1：

输入：candidates = [2,3,6,7], target = 7
输出：[[2,2,3],[7]]
解释：
2 和 3 可以形成一组候选，2 + 2 + 3 = 7 。注意 2 可以使用多次。
7 也是一个候选， 7 = 7 。
仅有这两种组合。
示例 2：

输入: candidates = [2,3,5], target = 8
输出: [[2,2,2,2],[2,3,3],[3,5]]
示例 3：

输入: candidates = [2], target = 1
输出: []
**/
namespace HOT100_39
{
    // 回溯法dfs
    public class Solution
    {
        IList<IList<int>> rt;
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            rt = new List<IList<int>>();
            Backtrack(candidates, target, 0, new List<int>());
            return rt;
        }
        public void Backtrack(int[] candidates, int target, int index, List<int> rtt)
        {
            if (index == candidates.Length) return;
            if (target == 0)
            {
                rt.Add(new List<int>(rtt));
                return;
            }
            Backtrack(candidates, target, index + 1, rtt);

            if (target - candidates[index] >= 0)
            {
                rtt.Add(candidates[index]);
                Backtrack(candidates, target - candidates[index], index, rtt);
                rtt.RemoveAt(rtt.Count - 1);
            }
        }
    }

    //动态规划
    public class Solution3
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            var dp = new Dictionary<int, HashSet<List<int>>>();
            var rt = new List<IList<int>>();
            for (int i = 1; i <= target; i++)
            {
                dp[i] = new HashSet<List<int>>();
                for (int j = 0; j < candidates.Length && candidates[j] <= i; j++)
                {
                    if (candidates[j] == i)
                    {
                        dp[i].Add(new List<int>(){candidates[j]});
                    }
                    else if (candidates[j] < i)
                    {
                        var key = i - candidates[j];
                        foreach (var item in dp[key])
                        {
                            var newList = new List<int>(item);
                            newList.Add(candidates[j]);
                            newList.Sort();
                            if (!dp[i].Contains(newList))
                            {
                                dp[i].Add(newList);
                            }
                        }
                    }
                }
            }
            rt.AddRange(dp[target]);
            return rt;
        }
    }
}