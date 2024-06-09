using System;
using DS;
namespace Sort
{
    public class HeapSort
    {
        public class MaxHeap
        {
            //建堆，从最后一个非叶子节点开始，从下向上，从右向左建立堆
            public void BuildHeap(int[] nums, int size)
            {
                for(int i = nums.Length / 2 - 1; i >= 0; --i)
                {
                    AdjustHeap(nums, i, size);
                }
            }

            //调整一个节点，将根+左+右三个节点调整成根为最大节点，发生交换之后再向下调整
            public void AdjustHeap(int[] nums, int root, int size)
            {
                int l = root * 2 + 1, r = root * 2 + 2, max = root;
                if (l < size && nums[l] > nums[max]) 
                {
                    max = l;
                }
                if (r < size && nums[r] > nums[max]) 
                {
                    max = r;
                }
                if (max != root)
                {
                    Swap(nums, max, root);
                    AdjustHeap(nums, max, size);
                }
            }

            public void Swap(int[] nums, int a, int b)
            {
                var t = nums[a];
                nums[a] = nums[b];
                nums[b] = t;
            }

            public int[] MaxHeapSort(int[] nums)
            {
                var size = nums.Length;
                BuildHeap(nums, size);
                //每一步把顶部元素和末尾元素交换，再从顶部调整堆
                for(int i = 0; i < nums.Length; ++ i)
                {
                    Swap(nums, 0, size - 1);
                    -- size;
                    AdjustHeap(nums, 0, size);
                }
                return nums;
            }
        }

        public class MinHeap
        {
            //建堆，从最后一个非叶子节点开始，从下向上，从右向左建立堆
            public void BuildHeap(int[] nums, int size)
            {
                for(int i = nums.Length / 2 - 1; i >= 0; --i)
                {
                    AdjustHeap(nums, i, size);
                }
            }

            //调整一个节点，将根+左+右三个节点调整成根为最大节点，发生交换之后再向下调整
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
                    Swap(nums, min, root);
                    AdjustHeap(nums, min, size);
                }
            }

            public void Swap(int[] nums, int a, int b)
            {
                var t = nums[a];
                nums[a] = nums[b];
                nums[b] = t;
            }

            public int[] MinHeapSort(int[] nums)
            {
                var size = nums.Length;
                BuildHeap(nums, size);
                //每一步把顶部元素和末尾元素交换，再从顶部调整堆
                for(int i = 0; i < nums.Length; ++ i)
                {
                    Swap(nums, 0, size - 1);
                    -- size;
                    AdjustHeap(nums, 0, size);
                }
                return nums;
            }
        }
    }
}