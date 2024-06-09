using System.Collections.Generic;
using System.Linq;
namespace HOt100_739
{
    public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        var ret = new int[temperatures.Length];
        var st = new Stack<int>();
        for (int i = 0; i < temperatures.Length;i ++) {
            var t = temperatures[i];
            while (st.Any())
            {
                var ind = st.Peek();
                if (temperatures[ind] >= t) break;
                
                ret[ind] = i - ind;
                st.Pop();
            }
            st.Push(i);
        }
        return ret;
    }
}
}