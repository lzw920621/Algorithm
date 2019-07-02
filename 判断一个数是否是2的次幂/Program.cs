using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 判断一个数是否是2的次幂
{
    //用O(1)时间检测整数N是否是2的次幂

    //技巧: x&(x-1)可以用来消去x的最后一位的1
    //x = 1100
    //x - 1 = 1011
    //x & (x - 1) = 1000
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsEven(1024));

            Console.WriteLine(BitCount(0xfffe));

            Console.WriteLine(BitsForNumAtoNumB(0xff, 0xffff));

            int x = 5;
            int y = 7;
            Console.WriteLine("交换前x:{0} y:{1}", x, y);
            Exchange(ref x, ref y);
            Console.WriteLine("交换后x:{0} y:{1}", x, y);
            Console.ReadKey();

        }

        //判断n是否是2的次幂
        static bool IsEven(int n)
        {
            return (n & (n - 1)) == 0;
        }

        //n以2进制表示时 1的个数
        static int BitCount(int n)
        {
            int count = 0;
            
            while(n != 0)
            {
                count++;
                n = n & (n - 1);
            }

            return count;
        }

        //将整数A转换为B，需要改变多少个bit位？
        static int BitsForNumAtoNumB(int numA,int numB)
        {
            int numC = numA ^ numB;
            return BitCount(numC);
        }

        //位运算交换两个变量的值
        static void Exchange(ref int x,ref int y)
        {
            //异或运算支持运算的交换律和结合律
            x = x ^ y;  
            y = x ^ y;  
            x = x ^ y;  
        }
    }
}
