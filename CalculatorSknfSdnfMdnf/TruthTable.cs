using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Laba_2_DIS
{
    public class TruthTable
    {
        static Random rnd = new Random();
        private int[,] twoDimArr;
        private int sizeArr;

        public TruthTable()
        {
            sizeArr = 0;
            twoDimArr = new int[0,0];
        }
        public TruthTable(int count)
        {
            sizeArr = count;
            twoDimArr = new int[(int)Math.Pow(2, SizeArr), sizeArr + 1];
        }
        public int SizeArr
        {
            get { return sizeArr; }
            set { sizeArr = value; }
        }
        public void CreateTableCl()
        {
            int line = (int)Math.Pow(2, sizeArr);
            for (int i = 0; i < line; i++)
            {
                for (int j = sizeArr - 1; j >= 0; j--)
                {
                    int powerOfTwo = (int)Math.Pow(2, j);
                    twoDimArr[i, sizeArr - 1 - j] = Convert.ToInt32((i / powerOfTwo) % 2 == 1);
                }
            }
            Console.WriteLine("Введите (0 или 1) "+ line + " раз!");
            for (int i = 0; i < line; i++)
            {
                twoDimArr[i, sizeArr] = CheckWrite();
            }
        }
        public void CreateTableRnd()
        {
            int line = (int)Math.Pow(2, sizeArr);
            for(int i = 0; i < line; i++)
            {
                for(int j = sizeArr-1; j >= 0; j--)
                {
                    int powerOfTwo = (int)Math.Pow(2, j);
                    twoDimArr[i, sizeArr - 1 - j] = Convert.ToInt32((i / powerOfTwo) % 2 == 1);
                }
            }
            for (int i = 0; i < line; i++)
            {
                twoDimArr[i, sizeArr] = rnd.Next(0, 2);
            }
        }
        public bool[,] CreateImpMat(List<string> sdnf, List<string> sklei)
        {
            bool[,] implicArr = new bool[sklei.Count, sdnf.Count];
            for (int i = 0; i < sklei.Count; i++)
            {
                for (int j = 0; j < sdnf.Count; j++)
                {
                    if (IsCover(sklei[i], sdnf[j]))
                    {
                        implicArr[i, j] = true;
                    }
                    else
                    {
                        implicArr[i, j] = false;
                    }
                }
            }
            return implicArr;
        }
        public bool IsCover(string skl, string diz)
        {
            for (int i = 0; i < skl.Length; i++)
            {
                if (skl[i] != diz[i] && skl[i] != '-')
                {
                    return false;
                }
            }
            return true;
        }
        public string SearchSKNF()
        {
            string sknf = "";
            int line = (int)Math.Pow(2, sizeArr);
            for (int i = 0; i < line; i++)
            {
                if (twoDimArr[i, sizeArr] == 0)
                {
                    sknf += " (";
                    for (int j = 0; j < sizeArr; j++)
                    {
                        if (twoDimArr[i, j] == 0)
                        {
                            sknf += GetVariableName(j);
                        }
                        else
                        {
                            sknf += "!" + GetVariableName(j);
                        }
                        if (j < sizeArr - 1)
                            sknf += "v";
                        else
                        {
                            sknf += ") &";
                        }
                    }

                }
            }
            if (sknf.Length > 0)
            {
                sknf = sknf.Remove(sknf.Length - 1);
            }
            return sknf;
        }
        public string SearchSDNF(out HashSet<string> set)
        {
            string sdnf = "";
            set = new HashSet<string>();
            int line = (int)Math.Pow(2, sizeArr);
            for (int i = 0; i < line; i++)
            {
                string mdnf = "";
                if (twoDimArr[i, sizeArr] == 1)
                {
                    sdnf += " (";
                    for (int j = 0; j < sizeArr; j++)
                    {
                        mdnf += twoDimArr[i, j];
                        if (twoDimArr[i, j] == 1)
                        {
                            sdnf += GetVariableName(j);
                        }
                        else
                        {
                            sdnf += "!" + GetVariableName(j);
                        }
                        if (j >= sizeArr - 1)
                        {
                            sdnf += ") v";
                        }
                        
                    }
                    set.Add(mdnf);
                }
            }

            sdnf = sdnf.Remove(sdnf.Length - 1);
            return sdnf;
        }
        public List<string> GetSkei(List<string> list)
        {
            List<string> list2 = new List<string>();
            bool[] flagsForSdnf = new bool[list.Count];
            int count = 0;

            for (int k = 0; k < list.Count; k++)
            {
                for (int i = k + 1; i < list.Count; i++)
                {
                    string temp = "";
                    count = 0;
                    string str1 = list[k];
                    string str2 = list[i];

                    for (int j = 0; j < str1.Length; j++)
                    {
                        if (str1[j] == str2[j])
                        {
                            temp += str1[j];
                        }
                        else
                        {
                            temp += "-";
                            count++;
                        }

                        if (count > 1)
                        {
                            temp = "";
                            break;
                        }
                    }

                    if (count == 1)
                    {
                        list2.Add(temp);
                        flagsForSdnf[k] = true;
                        flagsForSdnf[i] = true;
                    }
                }
            }
            if (list2.Count > 0)
            {
                list2 = GetSkei(list2);
            }
            else
            {
                list2 = new List<string>(list);
            }

            for (int i = 0; i < flagsForSdnf.Length; i++)
            {
                if (!flagsForSdnf[i])
                {
                    list2.Add(list[i]);
                }
            }

            return list2;
        }
        public string NormalPrint(List<string> mdnfNoRep)
        {
            string str = "-";
            string str1 = "1";
            string mdnf = "";
            foreach(var item in mdnfNoRep)
            {
                for (int i = 0;i < item.Length; i++)
                {
                    if (item[i] != str[0])
                    {
                        if (item[i] == str1[0])
                        {
                            mdnf += GetVariableName(i);
                        }
                        else
                        {
                            mdnf += "!" + GetVariableName(i);
                        }
                    }
                }
                mdnf += " v ";
            }
            mdnf = mdnf.Remove(mdnf.Length - 2);
            return mdnf;
        }

        public string GetMDNF(bool[,] impMat, string[] sdnfArr, string[] skleiArr)
        {
            string mdnf = "";
            int countSklei = (int)Math.Pow(2, skleiArr.Length);
            List<string> currentMDNF = new List<string>();

            for (int i = 0; i < countSklei; i++)
            {
                bool[] flagsForSdnf = new bool[sdnfArr.Length];
                string res = Convert.ToString(i, 2).PadLeft(skleiArr.Length, '0');

                for (int j = 0; j < res.Length; j++)
                {
                    if (res[j] == '1')
                    {
                        for (int k = 0; k < impMat.GetLength(1); k++)
                        {
                            if (impMat[j, k])
                            {
                                flagsForSdnf[k] = true;
                            }
                        }
                    }
                }

                bool allCovered = true;
                for (int k = 0; k < flagsForSdnf.Length; k++)
                {
                    if (!flagsForSdnf[k])
                    {
                        allCovered = false;
                        break;
                    }
                }

                if (allCovered)
                {
                    List<string> currentCombination = new List<string>();
                    for (int g = 0; g < res.Length; g++)
                    {
                        if (res[g] == '1')
                        {
                            currentCombination.Add(skleiArr[g]);
                        }
                    }

                    if (currentMDNF.Count == 0 || currentCombination.Count < currentMDNF.Count)
                    {
                        currentMDNF = currentCombination;
                        mdnf = string.Join(" v ", currentMDNF);
                    }
                    else if (currentCombination.Count == currentMDNF.Count)
                    {
                        mdnf += "\nМДНФ: " + string.Join(" v ", currentCombination);
                    }
                }
            }

            return mdnf;
        }
        static string GetVariableName(int index)
        {
            switch (index)
            {
                case 0:
                    return "X";
                case 1:
                    return "Y";
                case 2:
                    return "Z";
                case 3:
                    return "G";
                case 4:
                    return "H";
                default:
                    throw new ArgumentOutOfRangeException();
            };
        }
        public void Display()
        {
            int column = (int)Math.Pow(2, sizeArr);
            Console.WriteLine("Таблица истинности: ");
            ShowSymbols(sizeArr);
            if (twoDimArr.Length == 0)
            {
                Console.WriteLine("Таблица пустая");
            }
            else
            {
                for (int i = 0; i < column; i++)
                {
                    for (int j = 0; j < sizeArr+1; j++)
                    {
                        Console.Write(twoDimArr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public static void ShowSymbols(int count)
        {
            switch (count)
            {
                case 2:
                    Console.WriteLine("X Y F");
                    break;
                case 3:
                    Console.WriteLine("X Y Z F");
                    break;
                case 4:
                    Console.WriteLine("X Y Z G F");
                    break;
                case 5:
                    Console.WriteLine("X Y Z G H F");
                    break;
            }
        }
        public static int CheckWrite()
        {
            bool ok;
            int input;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out input);
                if (!ok || input < 0 || input > 1)
                {
                    Console.WriteLine("Некорректное значение");
                }
            } while (!ok || input < 0 || input > 1);
            return input;
        }
    }
}
