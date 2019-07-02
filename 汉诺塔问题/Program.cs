using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 汉诺塔问题
{
    /*
    汉诺塔：
    汉诺塔(Tower of Hanoi)源于印度传说中，大梵天创造世界时造了三根金钢石柱子，其中一根柱子自底向上叠着64片黄金盘。
    大梵天命令婆罗门把圆盘从下面开始按大小顺序重新摆放在另一根柱子上。并且规定，在小圆盘上不能放大圆盘，在三根柱子
    之间一次只能移动一个圆盘
    */
    class Program
    {
        static void Main(string[] args)
        {
            int num = Hanoi(5);
            Console.WriteLine(num);

            HanNuo(5, 'a', 'b', 'c');
            Console.ReadKey();
        }
        /// <summary>
        /// 汉诺塔问题 最少移动次数
        /// </summary>
        /// <param name="n">盘子个数</param>
        /// <returns></returns>
        static int Hanoi(int n)
        {
            if(n==1)
            {
                return 1;
            }            
            else
            {
                return 2*Hanoi(n - 1) + 1;
            }           
        }

        /// <summary>
        /// 汉诺塔问题解决方法
        /// </summary>
        /// <param name="n">汉诺塔的层数</param>
        /// <param name="a">承载最初圆盘的柱子</param>
        /// <param name="b">起到中转作用的柱子</param>
        /// <param name="c">移动到的目标柱子</param>
        static void HanNuo(int n, char a, char b, char c)
        {
            if (n == 1)   //这也是递归的终止条件
            {
                Console.WriteLine("将盘子[{0}]从 {1} -----> {2}", n, a, c); //控制台输出每次操作盘子的动向
            }
            else
            {
                HanNuo(n - 1, a, c, b);      //将a柱子上的从上到下n-1个盘移到b柱子上
                Console.WriteLine("将盘子[{0}]从 {1} -----> {2}", n, a, c);
                HanNuo(n - 1, b, a, c);      //将b柱子上的n-1个盘子移到c柱子上
            }
        }

    }

    
}
