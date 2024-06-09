//https://leetcode.cn/problems/counting-bits/description/?envType=problem-list-v2&envId=2cktkvj
namespace HOT100_338
{
    //最高有效位
    //最高有效位是指对于正整数x，如果可以知道最大的正整数y，使得y<=x且y是2的整数次幂，则y的二进制表示中只有最高位是1，其余都是0，此时称y为x的「最高有效位」。
    //x的一比特数等于x-y的一比特数+1
    //所以遍历数组，每个bits[x] = bits[x - highBits] + 1，因为highBits比x小，所以遍历到x的时候highBits是已知的
    public class Solution {
    public int[] CountBits(int n) {
        var ret = new int[n + 1];
        var high = 0;
        for(int i = 1; i <= n; i ++)
        {
            //找到最高有效位
            if ((i & (i - 1)) == 0)
            {
                high = i;
            }
            //i的一比特数=(i-最高有效位)的一比特数+1
            ret[i] = ret[i - high] + 1;
        }
        return ret;
    }

    //最低有效位
    //当x是偶数，bits[x]=bits[x >> 1] + 0,奇数:bits[x]=bits[x >> 1] + 1
    //所以 bits[x]=bits[x >> 1] + (x & 1)
    public class Solution2 {
        public int[] CountBits(int n) {
            var ret = new int[n + 1];
            for(int i = 1; i < ret.Length; i ++)
            {
                ret[i] = ret[i >> 1] + (i & 1);
            }
            return ret;
        }
    }

    //最低设置位
    //设x的最低位的1为最低设置位 
    //令 y=x & (x−1), 则 y 为将 x 的最低设置位从 1 变成 0 之后的数，显然 0≤y<x，
    //则 bits[x]=bits[y]+1 因此对任意正整数 x，都有 bits[x]=bits[x & (x−1)]+1
    public class Solution3 {
        public int[] CountBits(int n) {
            var ret = new int[n + 1];
            for(int i = 1; i < ret.Length; i ++)
            {
                ret[i] = ret[i & (i - 1)] + 1;
            }
            return ret;
        }
    }
}
}
