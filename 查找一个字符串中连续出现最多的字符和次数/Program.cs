using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 查找一个字符串中连续出现最多的字符和次数
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<char, int> tuple = LongesConsecutiveCharacters("abcceeeeefg");
            Console.WriteLine(tuple);
            Console.ReadKey();

            
        }

        public static Tuple<char, int> LongesConsecutiveCharacters(string input)
        {
            var max_char = input[0];

            var max = 1;
            var current = 1;

            for (var i = 1; i < input.Length; i++)
            {
                if (input[i] == input[i - 1])
                {
                    current++;
                    if (current > max)
                    {
                        max = current;
                        max_char = input[i];
                    }
                }
                else
                {
                    current = 1;
                }
            }

            return new Tuple<char, int>(max_char, max);
        }

    }
}
