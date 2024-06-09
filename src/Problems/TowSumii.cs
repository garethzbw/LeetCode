namespace TwoSumii
{
    // https://leetcode-cn.com/problems/two-sum-ii-input-array-is-sorted/
    // numbers = [2, 7, 11, 15], target = 9
    // [1, 2]
    public class Solution 
    {
        //1. 二分法
        public int[] TwoSum(int[] numbers, int target) 
        {
            if (numbers.Length <= 2) return new int[] {1, 2};

            for (int i = 0; i < numbers.Length - 1; i ++)
            {
                int left = i + 1, right = numbers.Length - 1;
                int t = target - numbers[i];
                int mid = (left + right) / 2;
                while(left <= right)
                {
                    mid = (left + right) / 2;
                    if (numbers[mid] == t) 
                    {
                        break;
                    }
                    else if (numbers[mid] > t)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                if (numbers[mid] + numbers[i] == target)
                {
                    return new int[] {i+1 , mid+1};
                }
            }
            return new int[]{};
        }

        //2.双向指针
        public int[] TwoSum2(int[] numbers, int target) 
        {
            int left = 0, right = numbers.Length - 1;
            while(left <= right)
            {
                if (numbers[left] + numbers[right] == target) return new int[]{left + 1, right + 1};
                else if (numbers[left] + numbers[right] < target) left ++;
                else right --;
            }
            return new int[] {};
        }
    }    
}