using System;
namespace LonggestCommonPrefix
{
    // https://leetcode-cn.com/problems/longest-common-prefix/ 14. 最长公共前缀
    // ["flower","flow","flight"] -> "fl"
    public class Solution 
    {
        // 1.暴力，纵向遍历，同时遍历所有字符串
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0) return "";
            else if (strs.Length == 1) return strs[0];
            else
            {
                int shortest = int.MaxValue;
                foreach (var item in strs)
                {
                    if (item.Length < shortest) shortest = item.Length;
                }

                int end = -1;
                bool flag = true;
                for (int i = 0; i < shortest; i++)
                {
                    for (int j = 1; j < strs.Length; j++)
                    {
                        if (strs[j].Substring(i, 1) != strs[0].Substring(i, 1))
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                    end = i;
                }
                return strs[0].Substring(0, end + 1);
            } 
        }
        
        //2.暴力，横向遍历，两两相比，不断更新公共前缀
        public string LongestCommonPrefix2(string[] strs)
        {
            if (strs.Length == 0) return "";

            int shortest = int.MaxValue;
            foreach (var item in strs)
            {
                if (item.Length < shortest) shortest = item.Length;
            }

            string ret = strs[0];
            for(int j = 1; j < strs.Length; j ++)
            {
                var item = strs[j];
                int i = 0;
                for (;i < ret.Length && i < shortest; i++)
                {
                    if(ret[i] != item[i])
                    {
                        break;
                    }
                }
                ret = ret.Substring(0, i);
                if (ret == "") break;
            }
            return ret;
        }

        //3.分治法
        public string LongestCommonPrefix3(string[] strs)
        {
            if (strs.Length == 0) return "";
            return RecursiveFindLCP(strs, 0, strs.Length - 1);
        }

        private string RecursiveFindLCP(string[] strs, int left, int right)
        {
            if (left == right)
            {
                return strs[left];
            }
            else
            {
                int mid = (left + right) / 2;
                string cpLeft = RecursiveFindLCP(strs, left, mid);
                string cpRight = RecursiveFindLCP(strs, mid + 1, right);
                int minLength = Math.Min(cpLeft.Length, cpRight.Length);

                string lcp = "";
                bool same = true;
                for (int i = 0; i < minLength; i++)
                {
                    if (cpLeft.Substring(i, 1) != cpRight.Substring(i, 1))
                    {
                        lcp = cpLeft.Substring(0, i);
                        same = false;
                        break;
                    }
                }
                if (same)
                {
                    lcp = cpLeft.Substring(0, minLength);
                }
                return lcp;
            }
        }
    }
}