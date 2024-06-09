using System.Collections.Generic;
namespace DailyTemprature
{
    // https://leetcode-cn.com/problems/daily-temperatures/ 739.每日温度
    // [73, 74, 75, 71, 69, 72, 76, 73] -> [1, 1, 4, 2, 1, 1, 0, 0]
    internal sealed class Solution
    {
        // 思路1 二重遍历 超时tmd
        public int[] DailyTemperatures(int[] T) 
        {
            if (T.Length <= 1) return new int[]{0};

            var ret = new int[T.Length];
            for (int i = 0; i < T.Length; i++)
            {
                for (int j = i + 1; j < T.Length; j++)
                {
                    if (T[j] > T[i])
                    {
                        ret[i] = j - i;
                        break;
                    }
                    ret[i] = 0;
                }
            }
            return ret;
        }

        //思路2 优化思路1:从后往前-条件遍历
        public int[] DailyTemperatures2(int[] T)
        {
            if (T.Length <= 1) return new int[]{0};
            var ret = new int[T.Length];
            ret[T.Length - 1] = 0;
            for (int i = T.Length - 2; i >= 0; i --)
            {
                if (ret[i+1] == 0) 
                {
                    if (T[i] >= T[i+1]) 
                    {
                        ret[i] = 0;
                    }
                    else ret[i] = 1;
                }
                else
                {
                    if (T[i] == T[i+1])
                    {
                        ret[i] = ret[i+1] + 1;
                    }
                    else if (T[i] > T[i+1])
                    {
                        ret[i] = 0;
                        for (int j = i + 1; j < T.Length; j ++)
                        {
                            if (T[j] == T[i] && ret[j] != 0) // 加一个优化，但是为啥优化了之后更慢呢
                            {
                                ret[i] = ret[j] + j - i;
                                break;
                            }
                            if (T[j] > T[i]) 
                            {
                                ret[i] = j - i;
                                break;
                            }
                        }
                    }
                    else ret[i] = 1;
                }
            }
            return ret;
        }

        //思路3 遍历温度

        //思路4 单调栈
        //维护一个栈，它初始为空，里面存当前下标；遍历数组，如果栈为空或当前值小于等于栈顶对应的值，压栈，否则ret数组置为ret[pop] = i - pop，直到当前值小于等于栈顶或栈空 压栈 继续遍历
        public int[] DailyTemperatures4(int[] T)
        {
            var st = new Stack<int>();
            var ret = new int[T.Length];

            for (int i = 0; i < T.Length; i++)
            {
                if (st.Count == 0) st.Push(i);
                else
                {
                    while (st.Count > 0 && T[i] > T[st.Peek()])
                    {
                        int tmp = st.Pop();
                        ret[tmp] = i - tmp;
                    }
                    st.Push(i);
                }
            }
            return ret;
        }
    }
}