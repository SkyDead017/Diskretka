using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3_DIS
{
    /*
     * Функция перемножения матриц поэлементно
     */
    public class Matrix
    {
        int[,] _tableMatrix;
        int _sizeMatrix;

        public Matrix()
        {
            _sizeMatrix = 0;
            _tableMatrix = new int[0,0];
        }
        public Matrix(int sizeMatrix)
        {
            _sizeMatrix = sizeMatrix;
            _tableMatrix = new int[sizeMatrix, sizeMatrix];
        }
        public Matrix(int sizeMatrix, int[,] table)
        {
            _sizeMatrix = sizeMatrix;
            _tableMatrix = table; ;
        }

        public void CreateMatrixKeyboard()
        {
            Console.WriteLine("Введите вершины(начало конец дуги, через пробел). Чтобы выйти из режима заполнения таблицы введите 0");
            Console.WriteLine("Пример: a b(Enter)");
            Console.WriteLine("        c a");
            string str;
            do
            {
                str = Console.ReadLine();
                try
                {
                    if (str != "0")
                    {
                        int[] vertex = CheckWriteStr(str);
                        _tableMatrix[vertex[0], vertex[1]] = 1;
                    }
                }
                catch
                {
                    Console.WriteLine("Некорректное значение");
                }
                
            } while (str != "0");
        }
        public void Display()
        {
            if (_sizeMatrix == 0)
            {
                Console.WriteLine("Матрица пустая");
            }
            else
            {
                for (int i = 0; i < _sizeMatrix; i++)
                {
                    for (int j = 0; j < _sizeMatrix; j++)
                    {
                        Console.Write(_tableMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        //возведение в квадрат
        public Matrix MultiplyMatrix(Matrix matr, Matrix matr_)
        {
            Matrix item = new Matrix(_sizeMatrix);

            for (int k = 0; k < _sizeMatrix; k++)
            {
                for (int i = 0; i < _sizeMatrix; i++)
                {
                    for (int j = 0; j < _sizeMatrix; j++)
                    {
                        if((matr._tableMatrix[k, j]==1 & matr_._tableMatrix[j, i] == 1) || item._tableMatrix[k, i] == 1)
                        {
                            item._tableMatrix[k, i] = 1;
                        }
                        else { item._tableMatrix[k, i] = 0; }
                    }
                }
            }
            return item;
        }
        //возведение в нужную степень
        public Matrix PowMatrix(int degree)
        {
            Matrix item = new Matrix(_sizeMatrix);
            Matrix sumMatrix = new Matrix(_sizeMatrix);
            for (int i = 0; i < _sizeMatrix; i++)
            {
                for (int j = 0; j < _sizeMatrix; j++)
                {
                    sumMatrix._tableMatrix[i, j] = this._tableMatrix[i, j];
                }
            }
            for (int i = 0; i < _sizeMatrix; i++)
            {
                sumMatrix._tableMatrix[i, i] = 1;
            }
            if (degree == 1)
            {
                return sumMatrix;
            }
            if (degree == 0)
            {
                for(int i=0;i< _sizeMatrix; i++)
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
                    sumMatrix += item;
                }
            }
            

            return sumMatrix;
        }

        public static int[] CheckWriteStr(string str)
        {
            string[] pairVertex = str.Split(' ');
            int[] vertex = new int[2];
            int i = 0;
            foreach(string arc in pairVertex)
            {
                vertex[i] = GetVariableName(arc);
                i++;
            }
            return vertex;
        }
        static int GetVariableName(string vertex)
        {
            switch (vertex)
            {
                case "a":
                    return 0;
                case "b":
                    return 1;
                case "c":
                    return 2;
                case "d":
                    return 3;
                case "e":
                    return 4;
                case "f":
                    return 5;
                case "g":
                    return 6;
                case "h":
                    return 7;
                case "k":
                    return 8;
                case "l":
                    return 9;
                default:
                    throw new ArgumentOutOfRangeException("Некорректное значение");
            };
        }
        static string GetVariableName(int index)
        {
            switch (index)
            {
                case 0:
                    return "a";
                case 1:
                    return "b";
                case 2:
                    return "c";
                case 3:
                    return "d";
                case 4:
                    return "e";
                case 5:
                    return "f";
                case 6:
                    return "g";
                case 7:
                    return "h";
                case 8:
                    return "h";
                case 9:
                    return "h";
                default:
                    throw new ArgumentOutOfRangeException("Некорректное значение");
            };
        }
        public static int CheckWrite()
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok || input < 0 || input > 10)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok || input < 0 || input > 10);
            return input;
        }

        //сложение
        public static Matrix operator +(Matrix matr, Matrix matr_)
        {
            int size=matr._sizeMatrix;
            Matrix item = new Matrix(size);
            for(int i=0;i< size; i++)
            {
                for(int j=0;j< size; j++)
                {
                    if (matr._tableMatrix[i, j] == 1 || matr_._tableMatrix[i, j] == 1)
                    {
                        item._tableMatrix[i, j] = 1;
                    }
                    else { item._tableMatrix[i, j] = 0; }
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

        //транспонирование
        public Matrix TransporationMatrix()
        {
            Matrix item = new Matrix(_sizeMatrix);
            for(int i=0; i< _sizeMatrix; i++)
            {
                for (int j=0; j< _sizeMatrix; j++)
                {
                    item._tableMatrix[i,j] = this._tableMatrix[j,i];
                }
            }
            return item;
        }
        public string CompConnect()
        {
            bool[] boolTable = new bool[_sizeMatrix];
            string str = "";
            int[] table = new int[_sizeMatrix];
            bool indicatorAdd = false;
            for(int i=0; i<_sizeMatrix; i++)
            {
                for(int j=0;j< _sizeMatrix; j++)
                {
                    if (this._tableMatrix[i, j] == 1 && boolTable[j]==false)
                    {
                        indicatorAdd = true;
                        str += GetVariableName(j);
                        str += " ";
                        boolTable[j] = true;
                    }
                }
                if(indicatorAdd==true)
                {
                    str += ";";
                    indicatorAdd = false;
                }
                
            }
            str=str.TrimEnd(';');
            return str;
        }
        public void PrintCompConnect(string str)
        {
            string[] compCon = str.Split(';');
            for(int i=0;i< compCon.Length; i++)
            {
                Console.WriteLine(i+1+") "+ compCon[i]);
            }
        }
    }
}
