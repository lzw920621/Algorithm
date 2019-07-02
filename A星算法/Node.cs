using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A星算法
{
    class Node
    {
        int x;
        public int X
        {
            get { return x; }
        }

        int y;
        public int Y
        {
            get { return y; }
        }

        Node parentNode;
        public Node ParentNode
        {
            get { return parentNode; }
            set { parentNode = value; }
        }

        bool isBarrier = false;
        public bool IsBarrier
        {
            get { return isBarrier; }
            set { isBarrier = value; }
        }


        public int G//开始节点到当前节点的距离
        {
            get;
            set;
        }

        public int H//当前节点到目标节点的距离
        {
            get;
            set;
        }

        public Node(int x,int y)//构造函数
        {
            this.x = x;
            this.y = y;            
        }
        
        public static int Distance(Node A,Node B)
        {
            int distance;
            int Dis_x = Math.Abs(A.x - B.x);
            int Dis_y = Math.Abs(A.y - B.y);
            if(Dis_x>=Dis_y)
            {
                distance= Dis_y * 14 + (Dis_x - Dis_y) * 10;
            }
            else
            {
                distance = Dis_x * 14 + (Dis_y - Dis_x) * 10;
            }
            return distance;
        }

        
    }
}
