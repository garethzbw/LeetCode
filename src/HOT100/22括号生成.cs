using System.Collections.Generic;
namespace HOT100_22
{
    public class Solution {
        public List<string> rt = new List<string>();
        public IList<string> GenerateParenthesis(int n) {
            if (n == 0) return rt;
            AddParenthesis("", "(", n * 2, n, n, 0);
            return rt;
        }

        public void AddParenthesis(string s, string ch, int length, int left, int right, int unclosed)
        {
            s += ch;
            if (s.Length == length) 
            {
                rt.Add(s);
                return;
            }
            if (ch == "(")
            {
                unclosed += 1;
                left -= 1;
            }
            else
            {
                unclosed -= 1;
                right -= 1;
            }
            // s += "(" if left > 0
            if (unclosed == 0 || left > 0)
            {
                AddParenthesis(s, "(", length, left, right, unclosed);
            }
            // s += ")" if right > 0
            if (unclosed > 0 && right > 0)
            {
                AddParenthesis(s, ")", length, left, right, unclosed);
            }
        }
    }
}