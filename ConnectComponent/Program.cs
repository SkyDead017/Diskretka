using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3_DIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chooseCreateMatrix;
            int sizeMatrix=0;
            Matrix matrix = new Matrix();
            do
            {
                ShowMenu();
                chooseCreateMatrix = CheckWrite();
                switch(chooseCreateMatrix)
                {
                    case 1:
                        
                        do
                        {
                            Console.WriteLine("Задайте размерность графа (от 1 до 10)");
                            sizeMatrix = CheckWrite();
                        } while (sizeMatrix > 10 || sizeMatrix < 1);
                        matrix = new Matrix(sizeMatrix);
                        matrix.CreateMatrixKeyboard();
                        matrix.Display();
                        break;
                    case 2:
                        int chooseTestMatrix;
                        int[,] table = {
                            {0,1,0,0,0 },
                            {0,0,0,1,0 },
                            {0,1,0,0,0 },
                            {0,0,1,0,0 },
                            {1,0,1,1,0 }
                        };
                        int[,] table2 =
                        {
                            {0,1,1,1 },
                            {1,0,0,1 },
                            {1,0,0,1 },
                            {0,0,0,0 }
                        };
                        
                        do
                        {
                            Console.WriteLine("Выберете матрицу из тестовых данных: ");
                            Console.WriteLine("Тестовая матрица 1");
                            PrintTable(table);
                            Console.WriteLine("Тестовая матрица 2");
                            PrintTable(table2);
                            chooseTestMatrix = CheckWrite();
                            Console.Clear();
                            switch (chooseTestMatrix)
                            {
                                case 1:
                                    Matrix testMatrix = new Matrix(5, table);
                                    matrix = testMatrix;
                                    sizeMatrix = 5;
                                    break;
                                case 2:
                                    Matrix testMatrix2 = new Matrix(4, table2);
                                    matrix = testMatrix2;
                                    sizeMatrix = 4;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        } while (chooseTestMatrix<1 || chooseTestMatrix>2);
                        
                        
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break;
                }
            } while (chooseCreateMatrix<1 || chooseCreateMatrix>2);

            Console.WriteLine("Матрица смежности:");
            matrix.Display();
            Console.WriteLine("Матрица достижимости");
            matrix = matrix.PowMatrix(sizeMatrix);
            matrix.Display();
            Console.WriteLine("Транспонированная матрица");
            Matrix matrixTran = matrix.TransporationMatrix();
            matrixTran.Display();
            Console.WriteLine("Матрица сильной связности");
            matrix = matrix * matrixTran;
            matrix.Display();
            string companSv = matrix.CompConnect();
            Console.WriteLine("Компоненты сильной связности: ");
            PrintCompConnect(companSv);



            //Matrix matrix = new Matrix(3);
            //matrix.CreateMatrixKeyboard();
            //matrix.Display();
            //Matrix matrix2 = new Matrix(3);
            //matrix2.CreateMatrixKeyboard();
            //matrix2.Display();
            //Console.WriteLine();
            //var p2 = matrix.PowMatrix(0);
            //p2.Display();
            //Matrix mat = matrix + matrix2;
            //mat.Display();
            //matrix = mat.TransporationMatrix();
            //matrix.Display();
            //List<Matrix> list = new List<Matrix>();
            
        }
        public static void PrintCompConnect(string str)
        {
            string[] compCon = str.Split(';');
            for (int i = 0; i < compCon.Length; i++)
            {
                Console.WriteLine(i + 1 + ") " + compCon[i]);
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("1. Задать матрицу с клавиатуры");
            Console.WriteLine("2. Выбрать матрицу из тестовых данных");
        }
        static void PrintTable(int[,] table)
        {
            for (int i = 0;i < table.GetLength(0); i++)
            {
                for(int j = 0;j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j]+" ");
                }
                Console.WriteLine();
            }
        }
        public static int CheckWrite()
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok);
            return input;
        }
    }
}
