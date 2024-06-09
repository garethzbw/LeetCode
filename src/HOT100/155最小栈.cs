using System;
using System.Collections.Generic;
namespace Hot100_155
{
    public class MinStack
    {
        public Stack<int> num;
        public Stack<int> min;
        public MinStack()
        {
            num = new Stack<int>();
            min = new Stack<int>();
        }

        public void Push(int val)
        {
            num.Push(val);
            if (min.Count == 0) {
                min.Push(val);
            }
            else {
                min.Push(Math.Min(min.Peek(), val));
            }
        }

        public void Pop()
        {
            num.Pop();
            min.Pop();
        }

        public int Top()
        {
            return num.Peek();
        }

        public int GetMin()
        {
            return min.Peek();
        }
    }
}