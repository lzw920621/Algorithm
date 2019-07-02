using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数组转置
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static T[,] Rotate<T>(T[,] array)//二维数组转置
        {
            int x = array.GetUpperBound(0); // 一维 
            int y = array.GetUpperBound(1); // 二维 
            T[,] newArray = new T[y + 1, x + 1]; // 构造转置二维数组 
            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    newArray[j, i] = array[i, j];
                }
            }
            return newArray;
        }


        public static T[,] Rotate<T>(T[] array)//一维数组转置
        {
            int length = array.Length;
            T[,] newArray = new T[length, 1]; // 构造转置二维数组 
            for (int i = 0; i < length; i++)
            {
                newArray[i, 0] = array[i];
            }
            return newArray;
        }
    }
}
