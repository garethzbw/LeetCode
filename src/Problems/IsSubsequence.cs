namespace IsSubsequence
{
    public class Solution 
    {
        public bool IsSubsequence(string s, string t) 
        {
            if (s == null || t == null) return false;
            foreach (var c in s)
            {
                if (t.Contains(c))
                {
                    var _i = t.IndexOf(c);
                    t = t.Substring(_i + 1, t.Length - _i - 1);
                    // System.Console.WriteLine(t);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        //2.双指针
        public bool IsSubsequence2(string s, string t) 
        {
            int jTemp = -1;
            bool flag;
            for(int i = 0; i < s.Length; i ++)
            {
                flag = false;
                for (int j = jTemp + 1; j < t.Length; j ++)
                {
                    if(s[i] == t[j])
                    {
                        flag = true;
                        jTemp = j;
                        break;
                    }
                }
                if (!flag)
                {
                    return false;
                }
            }
            return true;
        }
    }
}