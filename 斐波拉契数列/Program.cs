using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 斐波拉契数列
{
    class Program
    {
        static void Main(string[] args)
        {
            ////打印斐波拉契数列前50项 用list来存储每一项的值
            //List<long> myList = new List<long>();
            //myList.Add(1);
            //myList.Add(1);
            //for (int i = 0; i < 50; i++)
            //{
            //    if(i<2)
            //    {
            //        Console.WriteLine(myList[i]);
            //    }
            //    else
            //    {
            //        myList.Add(myList[i - 1] + myList[i - 2]);
            //        Console.WriteLine(myList[i]);
            //    }
            //}

            //Console.ReadKey();



            //打印斐波拉契数列的前100项
            //分析：
            //第100项数值特别大 不能直接用数值类型来存储，这里可以使用数组来存每个数

            int[] array1 = new int[50];
            int[] array2 = new int[50];
            int[] array3 = new int[50];

            array1[0] = 1;
            array2[0] = 1;
            Console.WriteLine(1);
            Console.WriteLine();
            Console.WriteLine(1);
            Console.WriteLine();
            for (int i = 2; i < 100; i++)
            {
                AddTwoArray(array1, array2, array3);
                array2.CopyTo(array1, 0);
                array3.CopyTo(array2, 0);
                
                for (int j = array3.Length-1; j >= 0; j--)
                {
                    if (array3[j] != 0)
                    {
                        for (int k = j; k >= 0; k--)
                        {
                            Console.Write(array3[k]);
                        }
                        break;
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array1">待加数组1</param>
        /// <param name="array2">待加数组2</param>
        /// <param name="array3">结果数组</param>
        static void AddTwoArray(int[] array1, int[] array2,int[] array3)
        {            
            int carry = 0;
            int temp = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                temp = array1[i] + array2[i] + carry;
                if(temp>=10)
                {
                    array3[i] = temp - 10;
                    carry = 1;
                }
                else
                {
                    array3[i] = temp;
                    carry = 0;
                }
            }
        }
    }
}
