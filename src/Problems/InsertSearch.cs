using System.Net.WebSockets;
namespace InsertSearch
{
    public class Solution
    {
        public int InsertSearch(int[] nums, int target)
        {
            return InsertSearch(nums, target, 0, nums.Length - 1);
        }

        public int InsertSearch(int[] nums, int target, int left, int right)
        {
            int mid = left + (((target - nums[left]) / (nums[right] - nums[left])) * (right - left));
            System.Console.WriteLine(string.Format("{0}, {1}, {2}", mid, left, right));

            if (left >= right)
            {
                return -1;
            }
            
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (target < nums[mid])
            {
                return InsertSearch(nums, target, left, mid - 1);
            }
            else
            {
                return InsertSearch(nums, target, mid + 1, left);
            }
            
        }

        public int InsertSearch2(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (((target - nums[left]) / (nums[right] - nums[left])) * (right - left));
                if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else 
                {
                    return mid;
                }
            }
            return -1;
        }
    }

}