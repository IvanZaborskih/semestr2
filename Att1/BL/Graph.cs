using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Graph
    {
        private int[,] matrix;
        public int[,] Matrix { get { return matrix; } }
        private int size;
        public int Size { get { return size; } }
        private int realSize;
        public int RealSize { get { return realSize; } }
        private HashSet<int> vertInGraph;
        public HashSet<int> VertInGraph { get { return vertInGraph; } }
        public Graph(int size)
        {
            matrix = new int[size, size];
            this.size = size;
            this.realSize = size;
            this.vertInGraph = null;
        }

        public bool AddEdge(int ind1,int ind2)
        {
            if (ind1>=0&&ind1<size&&ind2 >= 0 && ind2 < size&&ind1!=ind2)
            {
                matrix[ind1, ind2] = 1;
                matrix[ind2, ind1] = 1;
                return true;
            }
            return false;
        }


        private void GetSubGrRecursive(ref HashSet<HashSet<int>> setSetVert,HashSet<int> hashInt, int counterEdge, int n)
        {
            Stack<int> vertInt = new Stack<int>();
            foreach (var vert in hashInt)  //нахождение смежных вершин
            {
                for (int i = 0; i < size; i++)
                {
                    if (matrix[i, vert] == 1 && !hashInt.Contains(i)&&!vertInt.Contains(i))
                    {
                        vertInt.Push(i);
                    }
                }
            }
            foreach (var vert in vertInt)  //попытка добавить каждую из смежных вершин по очереди
            {
                int counterEdgeCopy = counterEdge;
                HashSet<int> hashIntCopy = new HashSet<int>(hashInt);
                hashIntCopy.Add(vert);
                foreach (var i in hashInt) //пересчет ребер после добавления смежной вершины
                //for (int i = 0; i < size; i++)  
                {
                    if (matrix[i, vert] == 1)
                    {
                        counterEdgeCopy++;
                    }
                }
                if (counterEdgeCopy == n)  //выбор следующего действия 
                {
                    bool cont = false;
                    foreach (var setVert in setSetVert)
                    {
                        if (setVert.SetEquals(hashIntCopy))
                        {
                            cont = true;
                            break;
                        }
                    }
                    if (cont==false)
                    setSetVert.Add(hashIntCopy);
                }
                else if (counterEdgeCopy > n)  //если ребер больше чем треуется, то пропускаем
                {
                    continue;
                }
                else //если ребер меньше чем требуется
                {
                    GetSubGrRecursive(ref setSetVert, hashIntCopy, counterEdgeCopy, n);
                }
            }
        }



        public  List<Graph> GetSubGr(int n)
        {
            List<Graph> listGr = new List<Graph>();
            HashSet<HashSet<int>> setSetVert = new HashSet<HashSet<int>>();
            for (int i = 0; i < this.size; i++)
            {
                //Stack<int> vertInt = new Stack<int>();     //вершины кандидаты
                int counterEdge = 0;                       //счетчик ребер 
                HashSet<int> hashInt = new HashSet<int>(); //текущее состояние графа
                hashInt.Add(i);
                GetSubGrRecursive(ref setSetVert, hashInt, counterEdge, n);
            }
            foreach (var setVert in setSetVert)
            {
                Graph graph = new Graph(size);
                graph.realSize = setVert.Count;
                graph.vertInGraph = setVert;
                foreach (var i in setVert)
                {
                    foreach (var j in setVert)
                    {
                        if (matrix[i, j] == 1)
                            graph.AddEdge(i, j);
                    }
                }
                listGr.Add(graph);
            }

            return listGr;
        }

        public override string ToString()
        {
            if (this.vertInGraph == null)
                return base.ToString();
            else
            {
                string s = "";
                foreach (var vert in vertInGraph)
                {
                    s += vert + ", ";
                }
                return s.Substring(0, s.Length - 2);
            }
        }





    }
}
