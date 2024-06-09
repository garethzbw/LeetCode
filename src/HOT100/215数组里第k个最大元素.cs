using System;
namespace HOt100_215
{
    //小根堆
    //维护一个size=k的小根堆,遍历数组调整小根堆，从k+1开始遍历，把比nums[0]大的和nums[0]换位，最后的nums[0:k-1]就是数组最大的k个数，Nums[0]就是第k个最大数
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            BuildMinHeap(nums, k);
            for (int i = k; i < nums.Length; ++i)
            {
                if (nums[i] > nums[0])
                {
                    swap(nums, i, 0);
                    AdjustHeap(nums, 0, k);
                }
            }
            return nums[0];
        }

        public void BuildMinHeap(int[] nums, int size)
        {
            for (int i = size / 2 - 1; i >= 0; --i)
            {
                AdjustHeap(nums, i, size);
            }
        }

        //对每一个节点，从上向下调整堆:将两个子节点中最小的和根节点互换，然后调整以最小节点位置为根的堆
        public void AdjustHeap(int[] nums, int root, int size)
        {
            int l = root * 2 + 1, r = root * 2 + 2, min = root;
            if (l < size && nums[l] < nums[min])
            {
                min = l;
            }
            if (r < size && nums[r] < nums[min])
            {
                min = r;
            }
            if (min != root)
            {
                swap(nums, min, root);
                AdjustHeap(nums, min, size);
            }
        }

        public void swap(int[] nums, int a, int b)
        {
            var t = nums[a];
            nums[a] = nums[b];
            nums[b] = t;
        }
    }
}