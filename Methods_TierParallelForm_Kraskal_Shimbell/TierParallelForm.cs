using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_4_DIS
{
    public partial class Matrix
    {
        public void CreateMatrixKeyboardTPF()
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
        public int[] CountUnitColumn()
        {
            int[] countUnit = new int[_sizeMatrix];
            for(int i = 0; i < _sizeMatrix; i++)
            {
                int count = 0;
                for(int j = 0; j < _sizeMatrix; j++)
                {
                    if(_tableMatrix[j,i] == 1)
                    {
                        count++;
                    }
                }
                countUnit[i] = count;
            }
            return countUnit;
        }
        public int[] Zeroing(Matrix matr, int[] countUnit, int index)
        {
            for(int i = 0;i < matr._sizeMatrix; i++) //столбцы
            {
                if (matr._tableMatrix[index, i] == 1)
                {
                    matr._tableMatrix[index, i] = 0;
                    countUnit[i]--;
                }
            }
            return countUnit;
        }
        public string PassingMatrix(int[] countUnit)
        {
            string str = "";
            bool[] isPassedColumn = new bool[countUnit.Length];
            while (!IsTrue(isPassedColumn))
            {
                int[] copyCountUnit = (int[])countUnit.Clone();
                for (int i = 0; i < countUnit.Length; i++)
                {
                    if (copyCountUnit[i] == 0 && isPassedColumn[i]==false)
                    {
                        isPassedColumn[i] = true;
                        countUnit = Zeroing(this, countUnit, i);
                        str += GetVariableName(i);
                        str += ' ';
                    }
                }
                str += ";";
            }
            str = str.TrimEnd(';');
            return str;
        }
        public bool IsTrue(bool[] isPassedColumn)
        {
            foreach(bool value in isPassedColumn)
            {
                if (!value)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
