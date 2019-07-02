using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_爬台阶问题
{
    //一个人爬楼梯，每次只能爬1级或2级台阶
    //假设有n级台阶，那么有多少种不同的爬楼梯方法
    class Program
    {
        static void Main(string[] args)
        {
            int num = PaLouTi(5);
            Console.WriteLine(num);
            Console.ReadKey();
        }

        static Dictionary<int, int> dic = new Dictionary<int, int>();

        static int PaLouTi(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 2;
            }
            else
            {
                if(dic.ContainsKey(n))
                {
                    return dic[n];
                }
                int num= PaLouTi(n - 1) + PaLouTi(n - 2);
                dic[n] = num;
                return dic[n];
            }
        }
    }

    
}
