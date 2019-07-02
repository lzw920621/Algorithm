using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 正方形内的两点的欧几里得距离期望
{
    
    class Program
    {
        static void Main(string[] args)
        {
            double distanceExp = GetDistanceExpect();           
        }

        static double GetDistanceExpect()
        {
            double x1, y1, x2, y2;
            double sum = 0;
            double distance;
            Random rd = new Random();
            for (int i = 0; i < 1000000; i++)//重复100万次
            {
                x1 = rd.NextDouble();
                y1 = rd.NextDouble();
                x2 = rd.NextDouble();
                y2 = rd.NextDouble();
                distance = Math.Sqrt(Math.Abs((x1-x2)*(x1-x2)+(y1-y2)*(y1-y2)));
                sum += distance;
            }
            double avg = sum / 1000000;
            return avg;
        }
    }
}
