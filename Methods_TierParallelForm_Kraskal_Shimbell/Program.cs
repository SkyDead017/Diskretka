using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4_DIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int sizeMatrix = 0;
            int degree = 0;
            int choiceAlgoritm;
            Matrix matrix = new Matrix();
            do
            {
                ShowChoiceAlgoritm();
                choiceAlgoritm = CheckWrite();
                switch(choiceAlgoritm)
                {
                    case 1:
                        int chooseCreateMatrixTPF;
                        do
                        {
                            ShowMenu();
                            chooseCreateMatrixTPF = CheckWrite();
                            switch (chooseCreateMatrixTPF)
                            {
                                case 1:
                                    do
                                    {
                                        Console.WriteLine("Задайте размерность графа (от 1 до 10)");
                                        sizeMatrix = CheckWrite();
                                    } while (sizeMatrix > 10 || sizeMatrix < 1);
                                    matrix = new Matrix(sizeMatrix);
                                    matrix.CreateMatrixKeyboardTPF();
                                    matrix.Display();
                                    break;
                                case 2:
                                    int chooseTestMatrix;
                                    int[,] table = {
                                        {0,1,0,1,0,0,0,1 },
                                        {0,0,0,1,0,0,0,0 },
                                        {0,0,0,0,0,0,0,0 },
                                        {0,0,1,0,1,0,0,0 },
                                        {0,0,0,0,0,0,0,0 },
                                        {0,1,0,1,0,0,0,0 },
                                        {0,0,1,1,1,0,0,0 },
                                        {0,0,1,0,0,0,0,0 }
                                    };
                                    int[,] table2 =
                                    {
                                        {0,1,1,0,0,0},
                                        {0,0,0,0,0,0},
                                        {0,1,0,0,0,0},
                                        {1,0,1,0,1,0},
                                        {0,0,0,0,0,0},
                                        {1,0,1,1,1,0}
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
                                                Matrix testMatrix = new Matrix(8, table);
                                                matrix = testMatrix;
                                                sizeMatrix = 8;
                                                break;
                                            case 2:
                                                Matrix testMatrix2 = new Matrix(6, table2);
                                                matrix = testMatrix2;
                                                sizeMatrix = 6;
                                                break;
                                            default:
                                                Console.Clear();
                                                Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                                break;
                                        }
                                    } while (chooseTestMatrix < 1 || chooseTestMatrix > 2);
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        } while (chooseCreateMatrixTPF < 1 || chooseCreateMatrixTPF > 2);
                        Console.WriteLine("Ярусно-параллельная форма:");
                        Console.WriteLine("Матрица смежности:");
                        matrix.Display();
                        int[] countUnit = new int[sizeMatrix];
                        countUnit = matrix.CountUnitColumn();
                        string tierParForm = matrix.PassingMatrix(countUnit);
                        PrintTPF(tierParForm);
                        break;
                    case 2:
                        int chooseCreateMatrixKraskal;
                        do
                        {
                            ShowMenu();
                            chooseCreateMatrixKraskal = CheckWrite();
                            switch (chooseCreateMatrixKraskal)
                            {
                                case 1:
                                    do
                                    {
                                        Console.WriteLine("Задайте размерность графа (от 1 до 10)");
                                        sizeMatrix = CheckWrite();
                                    } while (sizeMatrix > 10 || sizeMatrix < 1);
                                    matrix = new Matrix(sizeMatrix);
                                    matrix.CreateMatrixKeyboardKraskalOrShimbell();
                                    matrix.Display();
                                    break;
                                case 2:
                                    int chooseTestMatrix;
                                    int[,] table = {
                                        {0,10,0,5,0,0,14 },
                                        {0,0,6,2,4,8,0 },
                                        {0,0,0,3,1,1,0 },
                                        {0,0,0,0,0,0,3 },
                                        {0,0,0,0,0,5,0 },
                                        {0,0,0,0,0,0,2 },
                                        {0,0,0,0,0,0,0 }
                                    };
                                    int[,] table2 =
                                    {
                                        {0,3,0,0,1 },
                                        {0,0,4,4,2 },
                                        {0,0,0,3,0 },
                                        {0,0,0,0,3 },
                                        {0,0,0,0,0 }
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
                                                Matrix testMatrix = new Matrix(7, table);
                                                matrix = testMatrix;
                                                sizeMatrix = 7;
                                                break;
                                            case 2:
                                                Matrix testMatrix2 = new Matrix(5, table2);
                                                matrix = testMatrix2;
                                                sizeMatrix = 5;
                                                break;
                                            default:
                                                Console.Clear();
                                                Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                                break;
                                        }
                                    } while (chooseTestMatrix < 1 || chooseTestMatrix > 2);
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        } while (chooseCreateMatrixKraskal < 1 || chooseCreateMatrixKraskal > 2);
                        Console.WriteLine("Алгоритм Краскала:");
                        Console.WriteLine("Матрица смежности:");
                        matrix.Display();
                        List<Edge> edges = matrix.CreateSortTableWeight();
                        List<int> tableWithWeight = matrix.SearchNeedEdge(edges);
                        int sum = matrix.CalculatAmountWeight(tableWithWeight);
                        Console.WriteLine("Кратчайший пусть = " + sum);
                        break;
                    case 3:
                        int chooseCreateMatrixShimbell;
                        do
                        {
                            ShowMenu();
                            chooseCreateMatrixShimbell = CheckWrite();
                            switch (chooseCreateMatrixShimbell)
                            {
                                case 1:
                                    do
                                    {
                                        Console.WriteLine("Задайте размерность графа (от 1 до 10)");
                                        sizeMatrix = CheckWrite();
                                    } while (sizeMatrix > 10 || sizeMatrix < 1);
                                    int orGraph;
                                    do
                                    {
                                        Console.WriteLine("Выберете вид графа");
                                        ShowOrient();
                                        orGraph = CheckWrite();
                                        switch (orGraph)
                                        {
                                            case 1:
                                                matrix = new Matrix(sizeMatrix);
                                                matrix.CreateMatrixKeyboardKraskalOrShimbell();
                                                break;
                                            case 2:
                                                matrix = new Matrix(sizeMatrix);
                                                matrix.CreateMatrixKeyboardShimbell();
                                                break;
                                        }
                                    } while (orGraph > 2 || orGraph < 1);
                                    matrix.Display();
                                    break;
                                case 2:
                                    int chooseTestMatrix;
                                    int[,] table = {
                                        {0,10,0,0,0},
                                        {0,0,12,0,8},
                                        {0,0,0,8,0},
                                        {0,6,8,0,3},
                                        {0,0,0,3,0}

                                    };
                                    int[,] table2 =
                                    {
                                        {0,1,3,2},
                                        {2,0,2,0},
                                        {0,0,0,0},
                                        {0,2,1,0}
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
                                    } while (chooseTestMatrix < 1 || chooseTestMatrix > 2);
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                                    break;
                            }
                        } while (chooseCreateMatrixShimbell < 1 || chooseCreateMatrixShimbell > 2);
                        Console.WriteLine("Алгоритм Шимбелла:");
                        Console.WriteLine("Матрица смежности:");
                        matrix.Display();
                        do
                        {
                            Console.WriteLine("Через сколько ребер необходимо пройти?");
                            degree = CheckWrite();
                        } while (degree > sizeMatrix - 1 || degree < 0);
                        matrix = matrix.PowMatrix(degree);
                        Console.WriteLine("Все кратчайшие пути из "+degree+" ребер");
                        matrix.Display();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ошибка! Выберите вариант из предложенных");
                        break;

                }
            } while (choiceAlgoritm<1 || choiceAlgoritm>3);
        }
        public static void PrintTPF(string str)
        {
            string[] compCon = str.Split(';');
            for (int i = 0; i < compCon.Length; i++)
            {
                Console.WriteLine(i + 1 + ") " + compCon[i]);
            }
        }
        static void ShowChoiceAlgoritm()
        {
            Console.WriteLine("1. Ярусно-параллельная форма");
            Console.WriteLine("2. Алгоритм Краскала");
            Console.WriteLine("3. Алгоритм Шимбелла");
        }
        static void ShowMenu()
        {
            Console.WriteLine("1. Задать матрицу с клавиатуры");
            Console.WriteLine("2. Выбрать матрицу из тестовых данных");
        }
        static void ShowOrient()
        {
            Console.WriteLine("1. Неориентированный");
            Console.WriteLine("2. Ориентированный");
        }
        static void PrintTable(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j] + " ");
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
