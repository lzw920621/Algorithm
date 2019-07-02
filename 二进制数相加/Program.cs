using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二进制数相加
{
    //把两个N位的二进制数相加，这两个整数分别存在两个n元数组 A 和 B 中，
    //这两个整数的和要按照二进制形式存储在一个（n+1）元数组C中,给出问题的形式化描述
    //并写出伪代码
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayA = new int[] { 0, 1, 1, 0, 1 ,1};//左边为低位 右边为高位
            int[] arrayB = new int[] { 1, 0, 1, 0, 1 ,1};
            int[] arrayC = AddTwoNum(arrayA, arrayB);

            foreach (var item in arrayC)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        static int[] AddTwoNum(int[] a,int[] b)
        {
            int[] c = new int[a.Length + 1];
            int carry = 0;
            for (int i = 0; i < a.Length; i++)
            {
                switch(a[i]+b[i]+carry)
                {
                    case 0: carry = 0; c[i] = 0; break;
                    case 1: carry = 0; c[i] = 1; break;
                    case 2: carry = 1; c[i] = 0; break;
                    case 3: carry = 1; c[i] = 1; break;
                }
                
            }
            if (carry == 1)
            {
                c[a.Length] = 1;
            }
            return c;
        }
    }
}
