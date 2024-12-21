using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Laba_2_DIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOne = 0;
            //Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Введите количество переменных (от 2 до 5)");
            int countPer = CheckWrite();
            TruthTable p = new TruthTable(countPer);
            ShowMenu();
            int choise = CheckWrite(true);
            switch (choise)
            {
                case 1:
                    p.CreateTableRnd(out countOne);
                    break;
                case 2:
                    p.CreateTableCl(out countOne);
                    break;
            }
            Console.Clear();
            p.Display();
            Console.WriteLine("СКНФ:");
            string sknf = p.SearchSKNF();
            Console.WriteLine(sknf);
            if (countOne > 0)
            {
                Console.WriteLine("СДНФ:");
                string sdnf = p.SearchSDNF(out HashSet<string> set);
                Console.WriteLine(sdnf);
                List<string> diz = new List<string>(set);
                List<string> sklei = p.GetSkei(diz);
                sklei = sklei.Distinct().ToList();
                string skleiForImpMat = p.NormalPrint(sklei);
                Console.WriteLine("Импликанты:");
                Console.WriteLine(skleiForImpMat);
                string[] sdnfArr = sdnf.Split('v');
                string[] skleiArr = skleiForImpMat.Split('v');
                bool[,] impMat = p.CreateImpMat(diz, sklei);
                PrintImpMat(impMat, sdnfArr, skleiArr);
                string mdnf = p.GetMDNF(impMat, sdnfArr, skleiArr);
                Console.WriteLine("МДНФ: " + mdnf);
            }
            else
            {
                Console.WriteLine("МДНФ нет, так как нет СДНФ");
            }
        }
        static void PrintImpMat(bool[,] impMat, string[] sndfArr, string[] skleiArr)
        {
            Console.WriteLine("ИМПЛИКАНТНАЯ МАТРИЦА");
            Console.Write("\t\t");
            for(int i = 0; i < sndfArr.Length; i++)
            {
                Console.Write(sndfArr[i] + "\t");
            }
            Console.WriteLine();
            for(int i = 0; i < impMat.GetLength(0); i++)
            {
                Console.Write(skleiArr[i]);
                Console.Write("\t\t");
                for (int j = 0; j < impMat.GetLength(1); j++)
                {
                    Console.Write(" ");
                    //Console.Write(impMat[i,j] + "\t\t");
                    if (impMat[i, j])
                    {
                        Console.Write("+\t\t");
                    }
                    else
                    {
                        Console.Write("\t\t");

                    }
                }
                Console.WriteLine();
            }
        }
        static int CheckWrite()
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok || input < 2 || input >5)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok || input < 2 || input > 5);
            return input;
        }
        static int CheckWrite(bool flag)
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok || input < 1 || input > 2)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok || input < 1 || input > 2);
            return input;
        }
        static void ShowMenu()
        {
            Console.WriteLine("1. Заполнение рандомом");
            Console.WriteLine("2. Заполнение с клавиатуры");
        }
    }
}
