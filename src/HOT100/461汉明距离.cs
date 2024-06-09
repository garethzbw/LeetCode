using System.Linq;
/**
https://leetcode-cn.com/problems/hamming-distance/
思路：用异或运算，得出的数中1的个数就是汉明距离。不同解法的区别是计算1的数量的方法不同，是使用内置函数或者手写。
**/

using System;
namespace Hot100
{
    public class Solution
    {
        //解法1. 先异或，再用内置函数计算1的数量，c#没有直接算的内置函数，只能先转成二进制字符串再用linq
        public int HammingDistance1(int x, int y) 
        {
            return Convert.ToString(x ^ y, 2).Count(x => x == '1');
        } 

        //解法2，先异或，再将结果的每一位右移/左移，如果最右/最左位是1则距离+1，那么怎么判断最右位是否=1呢？(x%2)或(x&1)的结果是1
        //时间复杂度:O(1)
        public int HammingDistance2(int x, int y)
        {
            var xor = x ^ y;
            var distance = 0;
            while (xor != 0)
            {
                if ((xor & 1) == 1) distance ++;
                xor = xor >> 1;    
            }
            return distance;
        }
        
        //解法3，尤尼根算法，属于对解法2的改良。计算1的个数的时候，跳过两个1中间的所有0，模拟人脑数1的操作
        // (x-1)相当于把x最右边的1置成0,右边的0置成1；这时 x & (x-1)会把最右边的1移除（置成0），如果结果不为0，说明有一个1, distance++
        public int HammingDistance3(int x, int y)
        {
            var xor = x ^ y;
            var distance = 0;
            while(xor != 0)
            {
                distance ++;
                xor = xor & (xor - 1);
            }
            return distance;
        }

        //解法4，转化成二进制然后嗯数，，，纯粹追求运行速度的野蛮算法，，，
        public int HammingDistance4(int x, int y)
        {
            //交换值，把y设成大数
            if(x > y)
            {
                x = x + y;
                y = x - y;
                x = x - y;
            }
            var x_str = Convert.ToString(x, 2);
            var y_str = Convert.ToString(y, 2);
            int start = y_str.Length - x_str.Length;
            int distance = 0;
            //先统计大数多出来的位数
            for (int i = 0; i < start; ++i)
            {
                if(y_str[i] == '1') distance ++;
            }
            //逐位比较
            for (int i = start, j = 0; i < y_str.Length; ++i, ++j)
            {
                System.Console.WriteLine(i);
                if (y_str[i] != x_str[j])
                {
                    distance ++;
                }
            }
            return distance;
        }
    }
}