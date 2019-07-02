using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 合并两个有序数组
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayA = new int[] { 2, 5, 7, 9, 13 };
            int[] arrayB = new int[] { 1, 3, 6, 8, 10 };
            int[] newArray = MergeArray_1(arrayA, arrayB);

            
        }

        static int[] MergeArray_1(int[] arrayA,int[] arrayB)//合并两个有序数组(两个都是递增)
        {
            int left = 0, right = 0;
            int[] newArray = new int[arrayA.Length + arrayB.Length];
            int index = 0;
            while(left<arrayA.Length && right<arrayB.Length)
            {
                if(arrayA[left]<=arrayB[right])
                {
                    newArray[index] = arrayA[left];                    
                    left++;
                }
                else
                {
                    newArray[index] = arrayB[right];                    
                    right++;
                }
                index++;
            }
            while(left < arrayA.Length)
            {
                newArray[index] = arrayA[left];
                left++;
                index++;
            }
            while(right < arrayB.Length)
            {
                newArray[index] = arrayB[right];
                right++;
                index++;
            }
            return newArray;
        }
    }
}
