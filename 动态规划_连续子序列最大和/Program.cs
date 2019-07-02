using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_连续子序列最大和
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, -1, 3, -5, 4, 6, 2, -1, 100 };
            int num = max_array_v4(array);
            Console.WriteLine(num);
            Console.ReadKey();
        }

        static int max_array_v4(int[] array)
        {            
            int maxsofar = array[0];
            int maxendinghere = 0;
            for (int i = 0; i < array.Length; i++)
            {
                maxendinghere = Math.Max(maxendinghere + array[i], array[i]);                
                maxsofar = Math.Max(maxsofar, maxendinghere);
            }
            return maxsofar;
        }
    }
}
