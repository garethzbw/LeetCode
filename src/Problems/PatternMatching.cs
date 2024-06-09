namespace PatterMatching
{
    using System;
    // https://leetcode-cn.com/problems/pattern-matching-lcci/
    // 输入： pattern = "abba", value = "dogcatcatdog"
    // 输出： true
    public class Solution 
    {
        //1.暴力枚举
        public bool PatternMatching(string pattern, string value)
        {
            //处理特殊情况
            if (pattern.Length == 0) {
                if (value.Length == 0) return true;
                else return false;
            }
            //值为空，如果pattern只有一种字母或者长度为1，则字母匹配空串，返回true，否则返回false
            if (value.Length == 0) 
            {
                if (pattern.Length == 1) return true;
                for (int i = 1; i < pattern.Length; i++)
                {
                    if (pattern[i] != pattern[0]) return false;
                }
            }

            // 枚举每个a的长度
            int numA = 0;
            foreach (var c in pattern)
            {
                if (c == 'a') numA ++;
            }
            int numB = pattern.Length - numA;

            // lenA*numA + lenB*numB = lenValue
            // 得：0 <= lenA <= lenValue/numA

            // if (numB)

            for(int lenA = 0; lenA <= value.Length/numA; lenA ++)
            {
                int lenB = 0;
                if (numB > 0)
                {
                    if ((value.Length - lenA * numA) % numB != 0) continue;
                    lenB = (value.Length - lenA * numA) / numB;
                }
                string strA = "", strB = "";
                int nowAt = 0;
                bool match = true;
                foreach (var p in pattern)
                {
                    if(p == 'a') 
                    {
                        
                        if (strA == "")
                        {
                            strA = value.Substring(nowAt, lenA);
                        }
                        else
                        {
                            if (strA != value.Substring(nowAt, lenA))
                            {
                                match = false;
                                break;
                            }
                        }
                        nowAt += lenA;
                    }
                    if(p == 'b') 
                    {
                        if (strB == "")
                        {
                            strB = value.Substring(nowAt, lenB);
                        }
                        else
                        {
                            if (strB != value.Substring(nowAt, lenB))
                            {
                                match = false;
                                break;
                            }
                        }
                        nowAt += lenB;
                    }
                }
                if (match) return match;
            }
            return false;
        }
    }
}