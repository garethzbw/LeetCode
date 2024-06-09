namespace HOT101_10
{
    public class Solution {
        public bool IsMatch(string s, string p) 
        {
            int pp = 0, ps = 0;
            while(ps < s.Length && pp < p.Length)
            {
                var cs = s[ps];
                if (p[pp] == '.')
                {
                    ++ps;
                    ++pp;
                }
                else if (p[pp] == '*')
                {
                    if (cs == p[pp - 1] || p[pp - 1] == '.')
                    {
                        ++ps;
                    }
                    else
                    {
                        ++pp;
                    }
                }
                else
                {
                    if (cs != p[pp])
                    {
                        if (pp + 1 < p.Length && p[pp + 1] == '*')
                        {
                            ++pp;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        ++pp;
                        ++ps;
                    }
                }
            }
            if (ps == s.Length) return true;
            return false;
        }
    }
}