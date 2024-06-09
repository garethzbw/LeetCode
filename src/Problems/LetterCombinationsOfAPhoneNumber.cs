namespace LetterCombinationsOfAPhoneNumber
{
    using System.Collections.Generic;
    public class Solution 
    {
        Dictionary<char, string> map = new Dictionary<char, string>() 
        {
            {'2', "abc"}, 
            {'3', "def"}, 
            {'4', "ghi"},
            {'5', "jkl"},
            {'6', "mno"},
            {'7', "pqrs"},
            {'8', "tuv"},
            {'9', "wxyz"}
        };
        public IList<string> LetterCombinations(string digits) 
        {  
            var ret = new List<string>();
            if (digits == null || digits.Length < 1) return ret;
            TraceBack(digits, 0, ret, new List<char>());
            return ret;
        }
        public void TraceBack(string digits, int digitIndex, IList<string> ret, List<char> now)
        {
            if(now.Count == digits.Length)
            {
                ret.Add(string.Join(null, now));
            }
            else
            {
                for (int i = 0; i < map[digits[digitIndex]].Length; i++)
                {
                    now.Add(map[digits[digitIndex]][i]);
                    TraceBack(digits, digitIndex + 1, ret, now);
                    if (now.Count > 0)
                    {
                        now.RemoveAt(now.Count - 1);
                    }
                }
            }
        }
    }
}