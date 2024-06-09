using System;
namespace AddStrings
{
    //https://leetcode-cn.com/problems/add-strings/
    public class Solution 
    {
        //1. 逐位相加
        public string AddStrings(string num1, string num2) 
        {
            if (num1 == "" || num1 == "0") return num2;
            else if (num2 == "" || num2 == "0") return num1;

            int carry = 0, length = Math.Max(num1.Length, num2.Length);
            var ret = "";

            for(int i = 0; i < length; i ++)
            {
                int a = i >= num1.Length ? 0 : int.Parse(num1.Substring(num1.Length - i - 1, 1));
                int b = i >= num2.Length ? 0 : int.Parse(num2.Substring(num2.Length - i - 1, 1));
                int c = (a + b + carry) > 9 ? (a + b + carry) % 10 : a + b + carry;
                carry = (a + b + carry) / 10;
                ret = c + ret;
            }
            if (carry > 0) ret = carry + ret;

            return ret;
        }
    }
}