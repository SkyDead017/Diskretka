using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4_DIS
{
    public partial class Matrix
    {
        public void CreateMatrixKeyboardShimbell()
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
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректное значение");
                }

            } while (str != "0");
        }
        //сложение
        public static Matrix operator +(Matrix matr, Matrix matr_)
        {
            int size = matr._sizeMatrix;
            Matrix item = new Matrix(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    item._tableMatrix[i,j] = matr._tableMatrix[i,j]+matr_._tableMatrix[i,j];
                }
            }
            return item;
        }

        //перемножение поэлементно
        public static Matrix operator *(Matrix matr, Matrix matr_)
        {
            int size = matr._sizeMatrix;
            Matrix item = new Matrix(size);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    item._tableMatrix[i, j] = matr._tableMatrix[i, j] * matr_._tableMatrix[i, j];
                }
            }
            return item;
        }
        public int MinEl(List<int> elements)
        {
            bool flag = false;
            int minEl = 0;
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    if (flag==false)
                    {
                        minEl = element;
                        flag = true;
                    }
                    else
                    {
                        if (element < minEl)
                        {
                            minEl = element;
                        }
                    }
                }
                return minEl;
            }
            else { return minEl; }

        }

        //возведение в квадрат
        public Matrix MultiplyMatrix(Matrix matr, Matrix matr_)
        {
            Matrix item = new Matrix(_sizeMatrix);

            for (int k = 0; k < _sizeMatrix; k++)
            {
                for (int i = 0; i < _sizeMatrix; i++)
                {
                    List<int> elements = new List<int>();
                    for (int j = 0; j < _sizeMatrix; j++)
                    {
                        if ((matr._tableMatrix[k, j] != 0 && matr_._tableMatrix[j, i] != 0))
                        {
                            elements.Add(matr._tableMatrix[k, j] + matr_._tableMatrix[j, i]);
                        }

                    }
                    item._tableMatrix[k, i] = MinEl(elements);
                }
            }
            return item;
        }
        //возведение в нужную степень
        public Matrix PowMatrix(int degree)
        {
            Matrix item = new Matrix(_sizeMatrix);
            Matrix sumMatrix = new Matrix(_sizeMatrix);
            //for (int i = 0; i < _sizeMatrix; i++)
            //{
            //    for (int j = 0; j < _sizeMatrix; j++)
            //    {
            //        sumMatrix._tableMatrix[i, j] = this._tableMatrix[i, j];
            //    }
            //}
            //for (int i = 0; i < _sizeMatrix; i++)
            //{
            //    sumMatrix._tableMatrix[i, i] = 1;
            //}
            if (degree == 1)
            {
                return this;
            }
            if (degree == 0)
            {
                for (int i = 0; i < _sizeMatrix; i++)
                {
                    item._tableMatrix[i, i] = 1;
                }
                return item;
            }
            else
            {
                for (int i = 0; i < _sizeMatrix; i++)
                {
                    for (int j = 0; j < _sizeMatrix; j++)
                    {
                        item._tableMatrix[i, j] = this._tableMatrix[i, j];
                    }
                }
                for (int i = 1; i < degree; i++)
                {
                    item = MultiplyMatrix(item, this);
                    //sumMatrix += item;
                }
            }
            return item;
        }
    }
}
