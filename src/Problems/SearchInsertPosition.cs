namespace SearchInsertPosition
{
    public class Solution 
    {
        // 解法1:递归二分查找
        public int SearchInsert(int[] nums, int target) 
        {
            return SearchRev(0, nums.Length - 1, target, nums);
        }

        public int SearchRev(int left, int right, int target, int[] nums)
        {
            int mid = (left + right) / 2;
            // System.Console.WriteLine(left + " " + right + " " + mid);
            if (nums[mid] == target) 
            {
                return mid;
            }

            if (left >= right)
            {
                if (target > nums[mid]) 
                {
                    return right + 1;
                }
                else 
                {
                    return left;
                }
            }
            else
            {
                if (target < nums[mid]) 
                {
                    return SearchRev(left, mid - 1, target, nums);
                }
                else
                {
                    return SearchRev(mid + 1, right, target, nums);
                }
            }
        }

        //解法2 非递归二分查找
        public int SearchInsert2(int[] nums, int target) 
        {
            int left = 0, right = nums.Length - 1;
            while(left < right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            if (target == nums[left])
            {
                return left;
            }
            if (target < nums[left])
            {
                return left;
            }
            else if (target > nums[right])
            {
                return right + 1;
            }
            return -1;
        }
    }
}