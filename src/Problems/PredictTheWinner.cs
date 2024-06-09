using System.Collections.Generic;
using System;
namespace PredictTheWinner
{
    public class Solution 
    {
        int[][] map;
        //1.递归
        public bool PredictTheWinner(int[] nums) 
        {
            if (nums.Length == 0) return true;
            return Choose(nums, 0, nums.Length - 1) >= 0;
        }
        public int Choose(int[] nums, int l, int r)
        {
            if (l == r)
            {
                return nums[l];
            }
            
            var chooseL = nums[l] - Choose(nums, l + 1, r);
            var chooseR = nums[r] - Choose(nums, l, r - 1);
            return Math.Max(chooseL, chooseR);
        }
        //2.递归+哈希优化
        public bool PredictTheWinner2(int[] nums) 
        {
            if (nums.Length == 0) return true;

            map = new int[nums.Length][];
            for (int i = 0; i < map.Length; i++)
            {
                map[i] = new int[nums.Length];
            }

            return ChooseWithHash(nums, 0, nums.Length - 1) >= 0;
        }
        public int ChooseWithHash(int[] nums, int l, int r)
        {
            if (map[l][r] != 0) return map[l][r];
            
            if (l == r)
            {
                map[l][r] = nums[l];
                return nums[l];
            }

            var chooseL = nums[l] - ChooseWithHash(nums, l + 1, r);
            var chooseR = nums[r] - ChooseWithHash(nums, l, r - 1);
            map[l][r] = Math.Max(chooseL, chooseR);
            return map[l][r];
        }
    }
}