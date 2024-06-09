namespace RunningSumOf1DArray
{
    public class Solution 
    {
        public int[] RunningSum(int[] nums) 
        {
            if (nums == null || nums.Length == 0)
            {
                return new int[]{};
            }
            var ret = new int[nums.Length];
            Rev(nums.Length - 1, nums, ret);
            return ret;
        }
        public void Rev(int index, int[] nums, int[] ret)
        {
            if (index == 0) 
            {
                ret[index] = nums[index];
            }
            else
            {
                Rev(index - 1, nums, ret);
                ret[index] = ret[index - 1] + nums[index];
            }
        }
    }
}