namespace MinArray
{
    // https://leetcode-cn.com/problems/xuan-zhuan-shu-zu-de-zui-xiao-shu-zi-lcof/
    public class Solution 
    {
        //1.遍历 o(n)
        public int MinArray(int[] numbers) 
        {
            if (numbers.Length < 1) return 0;
            int min = numbers[0];
            foreach (var item in numbers)
            {
                if (item < min) return item;
            }
            return numbers[0];
        }

        //2.二分
        public int MinArray2(int[] numbers)
        {
            if (numbers.Length < 1) return 0;
            
            int left = 0, right = numbers.Length - 1;
            int pivot = 0;
            while (left <= right)
            {
                pivot = left + (right - left) / 2;
                if (numbers[pivot] < numbers[right])
                {
                    right = pivot;
                }
                else if (numbers[pivot] > numbers[right])
                {
                    left = pivot + 1;
                }
                else
                {
                    right --;
                }
            }
            return numbers[pivot];
        }
    }
}