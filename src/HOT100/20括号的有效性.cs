using System.Collections.Generic;
namespace HOT100_20
{
    public class Solution {
    public bool IsValid(string s) {
        var st = new Stack<char>();
        foreach(var c in s)
        {
            if(c == '(' || c == '{' || c =='[')
            {
                st.Push(c);
            }
            else
            {
                if(st.Count == 0) return false;
                var ch = st.Pop();
                if(!Match(ch, c)) return false;
            }
        }
        if (st.Count != 0) return false;
        return true;
    }
    public bool Match(char c1, char c2)
    {
        return (c1=='('&&c2==')') || (c1=='['&&c2==']') || (c1=='{'&&c2=='}');
    }
}
}