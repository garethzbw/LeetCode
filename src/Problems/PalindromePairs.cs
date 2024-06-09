using System.Collections.Generic;
namespace PalindromePairs
{
    //https://leetcode-cn.com/problems/palindrome-pairs/
    public class Solution 
    {
        //1.遍历+双指针，血妈超时
        public IList<IList<int>> PalindromePairs(string[] words) 
        {
            var ret = new List<IList<int>>();
            if (words == null) return ret;
            for (int i = 0; i < words.Length - 1; i++)
            {
                for (int j = i + 1; j < words.Length; j++)
                {
                    if (isPalindrome(i, j, words))
                    {
                        ret.Add(new List<int>(){i, j});
                    }
                    if (isPalindrome(j, i, words))
                    {
                        ret.Add(new List<int>(){j, i});
                    }
                }
            }
            return ret;
        }
        public bool isPalindrome(int i, int j, string[] words)
        {
            string s = words[i] + words[j];
            int L = 0, R = s.Length - 1;
            bool flag = true;
            while(L <= R)
            {
                if (s[L] != s[R])
                {
                    flag = false;
                    break;
                }
                L ++;
                R --;
            }
            return flag;
        }
    }   
}