namespace HOT100_4
{
    public class Solution 
    {
        // 合并数组 复杂度O(m + n)
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
        {
            int[] nums = new int[nums1.Length + nums2.Length];
            int i = 0, j = 0, index = 0;
            while(i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    nums[index] = nums1[i];
                    ++i;
                }
                else if (nums1[i] > nums2[j])
                {
                    nums[index] = nums2[j];
                    ++j;
                }
                else
                {
                    nums[index] = nums1[i];
                    ++index;
                    nums[index] = nums2[j];
                    ++i;
                    ++j;
                }
                ++index;
            }
            if (i > nums1.Length - 1 && j < nums2.Length)
            {
                for (int k = index; k < nums.Length; k++)
                {
                    nums[k] = nums2[j++];
                }
            }
            if (j > nums2.Length - 1 && i < nums1.Length)
            {
                for (int k = index; k < nums.Length; k++)
                {
                    nums[k] = nums1[i++];
                }
            }
            if (nums.Length % 2 == 1) return nums[nums.Length / 2];
            return (nums[nums.Length / 2] + nums[nums.Length / 2 - 1]) / 2d;
        }
    }
}