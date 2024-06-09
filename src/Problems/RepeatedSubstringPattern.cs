namespace RepeatedSubstringPattern
{
    // https://leetcode-cn.com/problems/repeated-substring-pattern/
    public class Solution 
    {
        // 1.双指针
        public bool RepeatedSubstringPattern(string s) 
        {
            if (s == null || s == "") return false;
            for (int i = 1; i <= s.Length / 2; i++)
            {
                if (s[i] == s[0] && s.Length % i == 0)
                {
                    var start = i;
                    bool flag = true;
                    while (start < s.Length) 
                    {
                        if (s.Substring(0, i) != s.Substring(start, i))
                        {
                            flag = false;
                            break;
                        }
                        start += i;

                        // for (int j = 0; j < i; j++, start++) //比较每一段
                        // {
                        //     if (s[j] != s[start])
                        //     {
                        //         flag = false;
                        //         break;
                        //     }
                        // }
                        if (!flag) break;
                    }
                    if (flag) return true;
                }
            }
            return false;
        }
    }
}