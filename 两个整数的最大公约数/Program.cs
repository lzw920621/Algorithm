using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 两个整数的最大公约数
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = GetBiggestCommonDivisor(1030, 40);

        }

        static int GetBiggestCommonDivisor(int num1, int num2)//假设num1>=num2
        {
            if (num2 == 0)
            {
                return num1;
            }
            int num3 = num1 % num2;
            return GetBiggestCommonDivisor(num2, num3);
        }
    }

    
}
