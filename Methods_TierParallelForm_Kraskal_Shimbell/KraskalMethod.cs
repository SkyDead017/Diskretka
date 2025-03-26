using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Laba_4_DIS
{
    public partial class Matrix
    {
        public void CreateMatrixKeyboardKraskalOrShimbell()
        {
            Console.WriteLine("Введите вершины(начало ребра _ конец ребра _ вес ребра, через пробел). Чтобы выйти из режима заполнения таблицы введите 0");
            Console.WriteLine("Пример: a b 5(Enter)");
            Console.WriteLine("        c a 23");
            string str;
            do
            {
                str = Console.ReadLine();
                try
                {
                    if (str != "0")
                    {
                        int[] vertex = CheckWriteStrByKraskal(str);
                        _tableMatrix[vertex[0], vertex[1]] = vertex[2];
                        _tableMatrix[vertex[1], vertex[0]] = vertex[2];
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректное значение");
                }

            } while (str != "0");
        }
        public List<Edge> CreateSortTableWeight()
        {
            int point = 1;
            List<Edge> edges = new List<Edge>();
            for(int i=0;i<this._sizeMatrix-1;i++)
            {
                for(int j=point;j<this._sizeMatrix;j++)
                {
                    if (this._tableMatrix[i,j] != 0)
                    {
                        edges.Add(new Edge(i, j, this._tableMatrix[i, j]));
                    }
                }
                point++;
            }
            edges.Sort();
            return edges;
        }
        public List<int> SearchNeedEdge(List<Edge> edges)
        {
            bool flag = false;
            int[] checkCycle = new int[this._sizeMatrix];
            List<int> tableWithWeight = new List<int>();
            int i = 2;
            while(edges != null)
            {
                foreach(var edge in edges)
                {
                    if (tableWithWeight.Count != this._sizeMatrix - 1)
                    {
                        if (flag == false)
                        {
                            checkCycle[edge.Vertex1] = 1;
                            checkCycle[edge.Vertex2] = 1;
                            tableWithWeight.Add(edge.Weight);
                            flag = true;
                        }
                        else
                        {
                            if (checkCycle[edge.Vertex1] == 0 && checkCycle[edge.Vertex2] == 0)
                            {
                                checkCycle[edge.Vertex1] = i;
                                checkCycle[edge.Vertex2] = i;
                                tableWithWeight.Add(edge.Weight);
                                i++;
                            }
                            else
                            {
                                if ((checkCycle[edge.Vertex1] == 1 && checkCycle[edge.Vertex2] == 0)
                                || (checkCycle[edge.Vertex1] == 0 && checkCycle[edge.Vertex2] == 1))
                                {
                                    if (checkCycle[edge.Vertex1] == 1)
                                    {
                                        checkCycle[edge.Vertex2] = 1;
                                        tableWithWeight.Add(edge.Weight);
                                    }
                                    else
                                    {
                                        checkCycle[edge.Vertex1] = 1;
                                        tableWithWeight.Add(edge.Weight);
                                    }
                                }
                                else
                                {
                                    for(int j = 2; j <= i; j++)
                                    {
                                        if (checkCycle[edge.Vertex1] == 1 && checkCycle[edge.Vertex2] == j)
                                        {
                                            checkCycle[(edge.Vertex2)] = 1;
                                            for(int k = 0; k < checkCycle.Length; k++)
                                            {
                                                if(checkCycle[k] == j)
                                                {
                                                    checkCycle[k] = 1;
                                                }
                                            }
                                            tableWithWeight.Add(edge.Weight);
                                        }
                                        else
                                        {
                                            if (checkCycle[edge.Vertex1] == j && checkCycle[edge.Vertex2] == 1)
                                            {
                                                checkCycle[(edge.Vertex1)] = 1;
                                                for (int k = 0; k < checkCycle.Length; k++)
                                                {
                                                    if (checkCycle[k] == j)
                                                    {
                                                        checkCycle[k] = 1;
                                                    }
                                                }
                                                tableWithWeight.Add(edge.Weight);
                                            }
                                        }
                                    }
                                    
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        return tableWithWeight;
                    }
                }
            }
            throw new NotImplementedException();
        }
        public int TryNumber(int index)
        {
            for(int i = 2;i<=index;i++)
            {
                if (i == index)
                {
                    return i;
                }
            }
            throw new Exception();

        }
        public int CalculatAmountWeight(List<int> tableWitchWeight)
        {
            int sumWeight=0;
            for(int i = 0; i < tableWitchWeight.Count; i++)
            {
                sumWeight += tableWitchWeight[i];
            }
            return sumWeight;
        }
        public static int[] CheckWriteStrByKraskal(string str)
        {
            string[] pairVertex = str.Split(' ');
            int[] vertex = new int[3];
            int i = 0;
            foreach (string arc in pairVertex)
            {
                if (i != 2)
                {
                    vertex[i] = GetVariableName(arc);
                    i++;
                }
                else
                {
                    vertex[i] = int.Parse(arc);
                }
            }
            return vertex;
        }
        public static char[] TransformStr(string str)
        {
            char[] strTran = new char[2];
            string[] pairVertex = str.Split(' ');
            int i = 0;
            foreach (string arc in pairVertex)
            {
                if(i != 2)
                {
                    strTran[i] = char.Parse(arc);
                    i++;
                }
            }
            return strTran;
        }

    }
}
