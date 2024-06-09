using System;
namespace MagicIndex
{
    //https://leetcode-cn.com/problems/magic-index-lcci/
    public class Solution 
    {
        //1.双指针
        public int FindMagicIndex(int[] nums) 
        {
            int L = 0, R = nums.Length - 1, index = int.MaxValue;
            while(L <= R)
            {
                if (nums[L] == L)
                {
                    return L;
                }
                else if (nums[R] == R)
                {
                    index = R;
                }
                L ++;
                R --;
            }
            return index == int.MaxValue ? -1 : index;
        }

        //2.折半查找
        public int FindMagicIndex2(int[] nums) 
        {
            if (nums.Length < 1) return -1;
            var ret = Find(nums, 0, nums.Length - 1, int.MaxValue);
            return ret == int.MaxValue ? -1 : ret;
        }

        public int Find(int[]nums, int left, int right, int index)
        {
            int mid = left + (right - left) / 2;

            // System.Console.WriteLine(string.Format("{0}, {1}, {2}", left, right, mid));

            if (left >= right) return nums[left] == left ? left : int.MaxValue;
    
            if (nums[mid] == mid)
            {
                if (mid < index) index = mid;
                return Math.Min(index, Find(nums, left, mid - 1, index));
            }
            else if (nums[mid] < 0)
            {
                return Math.Min(index, Find(nums, mid + 1, right, index));
            }
            else
            {
                return Math.Min(index, Math.Min(Find(nums, left, mid - 1, index), Find(nums, mid + 1, right, index)));
            }
        }
    }
}