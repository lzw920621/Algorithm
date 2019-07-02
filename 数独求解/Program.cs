using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数独求解
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowGrid(testGrid); // 显示初盘。
            Backtracking(0); // 从没有填数的单元格开始。
                             // 反正填了数它会自己在方法里判断出来，就不用管它了。

            Console.ReadLine();

        }

        // 测试盘面。
        static int[,] testGrid = new int[9, 9]
        {
    {4, 2, 5, 0, 0, 8, 3, 6, 7},
    {0, 6, 0, 0, 0, 4, 1, 2, 0},
    {0, 8, 0, 0, 0, 2, 0, 0, 0},
    {0, 4, 0, 0, 0, 5, 9, 1, 2},
    {0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 1, 9, 4, 0, 0, 6, 7, 5},
    {0, 3, 0, 0, 0, 0, 0, 8, 0},
    {0, 0, 6, 0, 0, 0, 0, 9, 0},
    {1, 9, 4, 0, 0, 0, 0, 5, 0}
        };

        /// <summary>
        /// 数独求解。
        /// </summary>
        /// <param name="n">已经解出的单元格数（即确定值的个数）。</param>
        static void Backtracking(int n)
        {
            // 递归出口。递归出口一定要写在最开始。
            if (n == 81)
            {
                ShowGrid(testGrid); // 显示盘面的结果。是一个函数。
                return; // 退出递归。
            }

            int row = n / 9, col = n % 9;

            // 有填入的数据在里面，当前单元格不计算。
            if (testGrid[row, col] != 0)
            {
                Backtracking(n + 1); // 直接进入下一个单元格的判别。
                return; // 退出递归。
            }

            for (int i = 0; i < 9; i++) // 计算 9 次。
            {
                testGrid[row, col]++; // 逐个计算。
                if (IsValid(row, col)) // 如果所在行列填入后不矛盾就往下继续计算。
                    Backtracking(n + 1);
            }

            testGrid[row, col] = 0; // 赋值为 0 即达到回溯效果。
        }

        /// <summary>
        /// 显示盘面。
        /// </summary>
        static void ShowGrid(int[,] twoDimensionArray)
        {
            int firstDimension = twoDimensionArray.GetLength(0);
            int secondDimension = twoDimensionArray.GetLength(1);
            for (int i = 0; i < firstDimension; i++)
            {
                for (int j = 0; j < secondDimension; j++)
                    Console.WriteLine(testGrid[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("******************************");
        }

        /// <summary>
        /// 测试盘面所在行列下是否有重复的矛盾。
        /// </summary>
        static bool IsValid(int row, int col)
        {
            int number = testGrid[row, col];
            int i, j;

            // 检测行列是否有重复。
            for (i = 0; i < 9; i++)
                if (i != row && testGrid[i, col] == number || i != col && testGrid[row, i] == number)
                    return false;

            // 检测宫内是否有重复。
            for (i = row / 3 * 3; i < row / 3 * 3 + 3; i++)
                for (j = col / 3 * 3; j < col / 3 * 3 + 3; j++)
                    if ((i != row || j != col) && testGrid[i, j] == number)
                        return false;

            return true; // 都不重复，返回 true。
        }

    }
}
