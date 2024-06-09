namespace CountBinarySubstrings
{
    public class Solution 
    {
        public int CountBinarySubstrings(string s) 
        {
            int last0Index = -2, seq0 = -1, last1Index = -2, seq1 = -1, ret = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (last0Index < i - 1)
                    {
                        seq0 = 1;
                    }
                    else
                    {
                        seq0 ++;
                    }
                    last0Index = i;
                    if (seq0 <= seq1)
                    {
                        ret ++;
                    }
                }
                else if (s[i] == '1')
                {
                    if (last1Index < i - 1)
                    {
                        seq1 = 1;
                    }
                    else
                    {
                        seq1 ++;
                    }
                    last1Index = i;
                    if (seq1 <= seq0)
                    {
                        ret ++;
                    }
                }
            }
            return ret;
        }
    }
}