using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A星算法
{
    enum SelectMarker
    {
        Start,
        End,
        Barrier,
        None
    }

    public partial class Form1 : Form
    {
        SelectMarker selectMarker = SelectMarker.None;

        Button[,] GridMap = new Button[20, 20];
        Node[,] nodeMap = new Node[20, 20];

        Node startNode;
        Node endNode;

        List<Node> openList = new List<Node>();
        List<Node> closeList = new List<Node>();

        public Form1()
        {
            InitializeComponent();

            int index;
            int i;
            int j;
            foreach (Control ctl in Controls)
            {
                index = ctl.TabIndex;
                if(index<400)
                {
                    i = index / 20;
                    j = index % 20; ;
                    GridMap[i, j] = ctl as Button;
                    nodeMap[i, j] = new Node(i, j);
                }
            }
        }

        private void btn_SelectStartPoint_Click(object sender, EventArgs e)
        {
            selectMarker = SelectMarker.Start;
        }

        private void btn_SelectEndPoint_Click(object sender, EventArgs e)
        {
            selectMarker = SelectMarker.End;
        }

        private void btn_SetBarriers_Click(object sender, EventArgs e)
        {
            selectMarker = SelectMarker.Barrier;
        }

        private void btn_StartPathFinding_Click(object sender, EventArgs e)
        {
            if(startNode==null || endNode==null)
            {
                MessageBox.Show("缺少 起点 或 终点！！！");
                return;
            }
            selectMarker = SelectMarker.None;
            ResetParentNode(nodeMap);
            ResetPoint("path");
            openList.Clear();
            closeList.Clear();
            FindPath();
        }

        private void GridPointClick(object sender,EventArgs e)
        {
            Button button = sender as Button;
            switch(selectMarker)
            {
                case SelectMarker.Start:
                    ResetPoint("StartPoint");
                    SetGridColor(button,Color.Lime);
                    SetGridTag(button, "StartPoint");
                    GetStartNode(button);
                    break;
                case SelectMarker.End:
                    ResetPoint("EndPoint");
                    SetGridColor(button, Color.Red);
                    SetGridTag(button, "EndPoint");
                    GetEndNode(button);
                    break;
                case SelectMarker.Barrier:
                    if(button.Tag=="Barrier")
                    {
                        button.Tag = null;
                        button.BackColor = SystemColors.Control;
                        SetBarrierNode(button, false);
                    }
                    else
                    {
                        SetGridColor(button, Color.Black);
                        SetGridTag(button, "Barrier");
                        SetBarrierNode(button, true);
                    }                    
                    break;
                case SelectMarker.None:;break;
            }
        }


        private void SetBarrierNode(Button button,bool isBarrier)
        {
            int index = button.TabIndex;
            int i = index / 20;
            int j = index % 20;
            nodeMap[i, j].IsBarrier = isBarrier;
        }

        private void GetEndNode(Button button)
        {
            int index = button.TabIndex;
            int i = index / 20;
            int j = index % 20;
            endNode = nodeMap[i, j];
        }

        private void GetStartNode(Button button)
        {
            int index = button.TabIndex;
            int i = index / 20;
            int j = index % 20;
            startNode = nodeMap[i, j];
        }

        private void ResetAllNodes(Node[,] nodeMap)
        {
            for (int i = 0; i < nodeMap.GetLength(0); i++)
            {
                for (int j = 0; j < nodeMap.GetLength(1); j++)
                {
                    nodeMap[i, j].IsBarrier = false;
                    nodeMap[i, j].ParentNode = null;
                }
            }
        }

        private void ResetParentNode(Node[,] nodeMap)
        {
            for (int i = 0; i < nodeMap.GetLength(0); i++)
            {
                for (int j = 0; j < nodeMap.GetLength(1); j++)
                {                    
                    nodeMap[i, j].ParentNode = null;
                }
            }
        }
       

        private void SetGridColor(Button button, Color color)
        {
            button.BackColor = color;
        }

        private void SetGridTag(Button button,string tag)
        {
            button.Tag = tag;
        }

        private void FindPath()
        {
            startNode.G = 0;
            Node currentNode = startNode;
            openList.Add(currentNode);
            while(currentNode!=endNode && openList.Count>0)
            {
                //获取 当前节点 的 相邻节点
                List<Node> adjacentNodes = GetAdjacentNodes(currentNode);
                //将当前节点放入 closelist;
                closeList.Add(currentNode);
                //将当前节点从 openlist中移除
                openList.Remove(currentNode);
                //对每个 相邻节点 进行检查，获取G值
                Node tempNode;
                for (int i = 0; i < adjacentNodes.Count; i++)
                {
                    tempNode = adjacentNodes[i];
                    if(!openList.Contains(tempNode))//如果不在Openlist中则将其放入openlist
                    {
                        openList.Add(tempNode);
                        tempNode.ParentNode = currentNode;//设置父节点为当前节点
                        tempNode.G = currentNode.G + Node.Distance(tempNode, currentNode);//获取G值
                    }
                    else//如果相邻节点在Openlist中，比较原G值 和 新G值，如果新G值更小，则以新G值为准，并将其父节点设置为currentNode
                    {
                        if(tempNode.G>currentNode.G+ Node.Distance(tempNode, currentNode))
                        {
                            tempNode.G = currentNode.G + Node.Distance(tempNode, currentNode);
                            tempNode.ParentNode = currentNode;
                        }
                    }
                }

                int F = int.MaxValue;
                int index = 0;
                for (int i = 0; i < openList.Count; i++)//寻找F值最小的节点
                {
                    if (F > openList[i].G + Node.Distance(endNode, openList[i]))
                    {
                        F = openList[i].G + Node.Distance(endNode, openList[i]);
                        index = i;
                    }
                }
                //将F值最小的节点设为当前节点
                if(openList.Count>0)
                {
                    currentNode = openList[index];
                }
                
            }

            if(currentNode!=endNode)
            {
                MessageBox.Show("未找到路径！！！");
            }
            else//找到路径
            {
                Node pathNode = endNode.ParentNode;
                int i, j;
                while(pathNode!=startNode)
                {
                    i = pathNode.X;
                    j = pathNode.Y;
                    GridMap[i, j].BackColor = Color.Blue;
                    GridMap[i, j].Tag = "path";
                    pathNode = pathNode.ParentNode;
                }
            }
        }

        private List<Node> GetAdjacentNodes(Node currentNode)
        {
            List<Node> listNode = new List<Node>();
            int x1, y1;
            for (int i = -1; i <=1; i++)
            {
                for (int j = -1; j <=1; j++)
                {
                    if(i==0 && j==0)
                    {
                        continue;
                    }
                    x1 = i + currentNode.X;
                    y1 = j + currentNode.Y;
                    if(x1<0 || x1>19 || y1<0 || y1>19)
                    {
                        continue;
                    }
                    if(nodeMap[x1,y1].IsBarrier==false && !closeList.Contains(nodeMap[x1,y1]))//判断该节点是否是障碍物
                    {
                        listNode.Add(nodeMap[x1, y1]);
                    }                    
                }
            }
            return listNode;
        }


        private void button_Reset_Click(object sender, EventArgs e)
        {
            List<Control> buttonList = new List<Control>();
            foreach(Control ctl in Controls)
            {
                if(ctl.Tag!=null)
                {
                    buttonList.Add(ctl);
                }
            }
            foreach (var button in buttonList)
            {
                button.BackColor = SystemColors.Control;
                button.Tag = null;
            }
            selectMarker = SelectMarker.None;

            ResetAllNodes(nodeMap);
            startNode = null;
            endNode = null;
        }

        private void ResetPoint(string tag)//重置指定标签的控件
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if(Controls[i].Tag==tag)
                {                   
                    Controls[i].BackColor = SystemColors.Control;
                    Controls[i].Tag = null;
                }
            }
        }
        
    }
}
