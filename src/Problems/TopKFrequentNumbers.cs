using System.Collections.Generic;
namespace TopKFrequentElements
{
    public class Solution 
    {
        //1.哈希表+小根堆
        public int[] TopKFrequent(int[] nums, int k) 
        {
            var ret = new int[k];
            var hash = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (!hash.ContainsKey(item)) 
                {
                    hash.Add(item, 0);
                }
                hash[item] += 1;
            }

            var a = new SortedList<int, int>(new Cmp());
            foreach (var item in hash.Keys)
            {
                if (a.Count < k)
                {
                    a.Add(hash[item], item);
                }
                else
                {
                    if (a[1] < hash[item])
                    {
                        // a.Remove(a.Min);
                        a.Add(hash[item], item);
                    }
                }
            }

            for (int i = 0; i < ret.Length; i++)
            {
                // ret[i] = a.Max[0];
                // a.Remove(a.Max);
            }

            return ret;
        }

        public class Cmp : Comparer<int>
        {
            public override int Compare(int x, int y)
            {
                return x - y;
            }
        }

        //2.哈希表+桶排序
        public int[] TopKFrequent2(int[] nums, int k) 
        {
            var ret = new List<int>();
            var hash = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (!hash.ContainsKey(item)) 
                {
                    hash.Add(item, 0);
                }
                hash[item] += 1;
            }

            var l = new List<int>[nums.Length + 1];
            foreach (var item in hash.Keys)
            {
                if (l[hash[item]] == null)
                {
                    l[hash[item]] = new List<int>();
                }
                l[hash[item]].Add(item);
            }
            for (int i = l.Length - 1; i >= 0; i--)
            {
                if (ret.Count == k) break;
                if (l[i] != null)
                {
                    ret.AddRange(l[i]);
                }
            }
            return ret.ToArray();
        }
    }
}