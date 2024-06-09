namespace HOT100_238
{
    public class Solution
    {
        //维护两个左乘积和右乘积的数组
        public int[] ProductExceptSelf(int[] nums)
        {
            if (nums.Length <= 1) return nums;
            var ret = new int[nums.Length];
            int[] L = new int[nums.Length], R = new int[nums.Length];
            L[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                L[i] = L[i - 1] * nums[i - 1];
            }
            R[nums.Length - 1] = 1;
            for (int i = nums.Length - 2; i >= 0; --i)
            {
                R[i] = R[i + 1] * nums[i + 1];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                ret[i] = L[i] * R[i];
            }
            return ret;
        }
    }
}