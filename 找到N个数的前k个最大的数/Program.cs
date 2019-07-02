using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 找到N个数的前k个最大的数
{
    //从N个无序的数中找到其中最大的k个数 (N>>k)
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayN = GetArray(10000);//获取10000个随机数
            //找到其中最大的100个数
            List<int> list = new List<int>();

        }
        static int[] GetArray(int n)
        {
            int[] array = new int[n];
            Random rd = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rd.Next(0, 10 * n);
            }

            return array;
        }

        
    }

    public class MinHeap<T>
    {
        private T[] heap;
        private IComparer<T> comparer;
        private int Size = 0;
        private int capacity;

        public MinHeap(int capacity, IComparer<T> comparer)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException("capacity can not less than 1");
            }

            if (heap == null)
            {
                heap = new T[capacity];
            }

            this.capacity = capacity;
            this.comparer = comparer;
        }

        public int GetSize()
        {
            return Size;
        }

        public T[] GetHeap()
        {
            return heap;
        }

        public void Add(T node)
        {
            if (Size == 0)
            {
                heap[0] = node;
                this.Size++;
            }
            else if (this.Size == this.capacity)
            {
                ProcessFullHeap(node);
            }
            else if (this.Size < this.capacity)
            {
                heap[this.Size] = node;

                int ParentPos = (this.Size - 1) >> 1;
                int curPos = this.Size;

                while (ParentPos > 0)
                {
                    if (comparer.Compare(heap[ParentPos], heap[curPos]) > 0)
                    {
                        Swap(ref heap[ParentPos], ref heap[curPos]);
                        curPos = ParentPos;
                        ParentPos = (curPos - 1) >> 1;
                    }
                    else
                    {
                        break;
                    }
                }

                this.Size++;
            }
        }

        public T GetTop()
        {
            if (this.Size > 0)
            {
                return (T)heap[0];
            }
            throw new InvalidOperationException("堆空");
        }

        private void ProcessFullHeap(T node)
        {
            if (comparer.Compare(node, GetTop()) <= 0)
            {
                return;
            }

            heap[0] = node;
            int curPos = 0;
            int left = (curPos << 1) + 1;
            int right = (curPos << 1) + 2;

            while (left < this.Size)
            {
                T root = heap[curPos];

                if (right < this.Size)
                {
                    if (comparer.Compare(heap[left], heap[right]) > 0)
                    {
                        if (comparer.Compare(heap[curPos], heap[right]) > 0)
                        {
                            //跟右孩子交换
                            Swap(ref heap[curPos], ref heap[left]);
                            curPos = right;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        if (comparer.Compare(heap[curPos], heap[left]) > 0)
                        {
                            //跟左孩子交换
                            Swap(ref heap[curPos], ref heap[left]);
                            curPos = left;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (comparer.Compare(heap[curPos], heap[left]) > 0)
                {
                    //当前根节点的左孩子是最后一个节点
                    Swap(ref heap[curPos], ref heap[left]);
                }
                else
                {
                    break;
                }

                left = (curPos << 1) + 1;
                right = (curPos << 1) + 2;
            }

        }

        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

}
