using System.Collections.Generic;
namespace HOT100_448
{
    //因为nums里的数是1<=i<=nums.length 所以用nums的下标i来记录每个数字i是否出现过，
    //遍历nums中的num，每出现一次就给nums[(num-1)%nums.length]加nums.length
    public class Solution {
        public IList<int> FindDisappearedNumbers(int[] nums) {
            var n = nums.Length;
            for(int i = 0; i < n; i ++)
            {
                var num = (nums[i] - 1) % n;
                nums[num] += n;
            }
            var l = new List<int>();
            for(int i = 0; i < n; i ++)
            {
                if (nums[i] <= n) l.Add(i + 1);
            }
            return l;
        }
    }
}