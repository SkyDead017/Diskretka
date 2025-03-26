using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4_DIS
{
    public partial class Matrix
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
