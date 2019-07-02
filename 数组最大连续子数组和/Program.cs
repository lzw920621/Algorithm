using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数组最大连续子数组和
{
    //给定一个数组，求出数组中连续项的最大和
    //获取下标
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, -1, 3, -5, 4, 6, 2, -1, 100 };
            int low, high;
            GetMaxSum(array, out low, out high);
            Console.WriteLine("{0},{1}", low, high);
            Console.ReadKey();
            
        }


        static void GetMaxSum(int[] array,out int low,out int high)
        {
            low = 0;
            high = 0;
            int sum = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                int tempSum = 0;
                for (int j = i; j < array.Length; j++)
                {
                    tempSum += array[j];
                    if (tempSum>sum)
                    {
                        sum = tempSum;
                        low = i;
                        high = j;
                    }
                }
            }
        }

    }
}
