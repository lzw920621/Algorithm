#define PlanB

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 动态规划_换零钱问题
{
    //一美元兑换成1美分,5美分,10美分,25美分和50美分这几种零钱有多少种方法?

    class Program
    {
        static void Main(string[] args)
        {
            int num = NumOfMoneyExchange(100, 5);
            Console.WriteLine(num);
            Console.ReadKey();
        }

#if PlanB
        struct StateStruct
        {
            int amout;
            int count;
            public StateStruct(int a,int b)
            {
                amout = a;
                count = b;
            }
        }
        static Dictionary<StateStruct, int> dic = new Dictionary<StateStruct, int>();

        static int NumOfMoneyExchange(int amout, int countOfChange)
        {
            if (amout < 0 || countOfChange == 0)
            {
                return 0;
            }
            else if (amout == 0)
            {
                return 1;
            }
            else
            {
                StateStruct state = new StateStruct(amout, countOfChange);
                if(dic.ContainsKey(state))
                {
                    return dic[state];
                }
                else
                {
                    int countMinusOne = countOfChange - 1;
                    int num = NumOfMoneyExchange(amout, countMinusOne) +
                        NumOfMoneyExchange(amout - First_Denomination(countOfChange), countOfChange);
                    dic[state] = num;//存储状态
                    return num;
                }                
            }
        }

        static int First_Denomination(int n)
        {
            switch (n)
            {
                case 1: return 1;
                case 2: return 5;
                case 3: return 10;
                case 4: return 25;
                case 5: return 50;
                default: return 0;
            }
        }
#endif

#if PlanA               //树形递归实现
        /// <summary>
        /// 兑换零钱的方式
        /// </summary>
        /// <param name="amout">现金总额</param>
        /// <param name="countOfChange">零钱种类</param>
        /// <returns></returns>
        static int NumOfMoneyExchange(int amout,int countOfChange)
        {
            if (amout < 0 || countOfChange == 0)
            {
                return 0;
            }
            else if (amout==0)
            {
                return 1;
            }
            else
            {
                int countMinusOne = countOfChange - 1;
                return NumOfMoneyExchange(amout, countMinusOne) + 
                    NumOfMoneyExchange(amout - First_Denomination(countOfChange), countOfChange);
            }

        }

        static int First_Denomination(int n)
        {
            switch(n)
            {
                case 1:return 1;
                case 2:return 5;
                case 3:return 10;
                case 4:return 25;
                case 5:return 50;
                default:return 0;
            }
        }
#endif

    }
}
