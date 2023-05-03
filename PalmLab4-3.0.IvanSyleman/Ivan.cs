using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmLab4
{
    public class Ivan
    {
        //Завдання №1
        public static void Find_Even_One(ref int[] mass)
        {
            if (Is_Even_Exists(mass, out int indexOfEvenNumber))
            {
                Console.WriteLine($"\nНомер парного елементу |{indexOfEvenNumber + 1}|");
                Delete_Element(ref mass, mass.Length, indexOfEvenNumber);
                Console.WriteLine("\nРезультуючий масив");
                PrintMassAsOneString(in mass);
            }
            else
            {
                Console.WriteLine("\nНемає парних елементiв в масивi");
            }
        }
        public static bool Is_Even_Exists(int[] mass, out int indexOfEvenNumber)
        {
            indexOfEvenNumber = -1;
            bool isEven = false;
            foreach (int item in mass)
            {
                indexOfEvenNumber++;
                if (Math.Abs(item) % 2 == 0)
                {
                    isEven = true;
                    break;
                }
            }
            return isEven;
        }
        public static void Delete_Element(ref int[] mass, int n, int indexOfEvenNumber)
        {
            indexOfEvenNumber++;
            while (indexOfEvenNumber < n)
            {
                mass[indexOfEvenNumber - 1] = mass[indexOfEvenNumber];
                indexOfEvenNumber++;
            }
            Array.Resize(ref mass, n - 1);
        }
        //Завдання №2
        public static void Extend_Mass(ref int[][] mass)
        {
            Array.Resize(ref mass, mass.Length + 1);
            mass[mass.Length - 1] = new int[mass[mass.Length - 2].Length];
            BonusRow_Index(out int index, mass.Length - 1);
            Push_Down_Roows(ref mass, index);
            Add_Row(ref mass, index);
            Console.WriteLine("\nРезультуючий масив");
            Print_Jagged_Mass(in mass);
        }
        public static void Push_Down_Roows(ref int[][] mass, int index)
        {
            for (int i = mass.Length - 1; i > index; i--)
            {
                //Array.Resize(ref mass[i], mass[i - 1].Length);
                (mass[i], mass[i - 1]) = (mass[i - 1], mass[i]);
            }
        }
        public static void BonusRow_Index(out int index, int length)
        {
            Console.WriteLine($"\nКiлькiсть рядкiв рiвна |{length}|");
            do
            {
                Console.WriteLine("\nВи додаєте рядок з номером");
                index = int.Parse(Console.ReadLine()) - 1;
            } while (index > length || index < 0);
        }
        public static void Add_Row(ref int[][] mass, int index)
        {
            Console.WriteLine("\nВпишiть рядок, який додається");
            mass[index] = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        }
        //Завдання №3
        public static void Change_ZeroElement_With_MinElement(ref int[][] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                int minInt = mass[i][0];
                int k = 0;
                for (int j = 1; j < mass[i].Length; j++)
                {
                    if (mass[i][j] < minInt)
                    {
                        minInt = mass[i][j];
                        k = j;
                    }
                }
                int temp = mass[i][0];
                mass[i][0] = mass[i][k];
                mass[i][k] = temp;
            }
            Console.WriteLine("\nМасив, пiсля замiни елементiв");
            Print_Jagged_Mass(in mass);
            Row_With_Max_Element(in mass, out int index);
            Console.WriteLine($"\nРядок з першим максимальним елементом |{index + 1}|");
            PrintMassAsOneString(in mass[index]);
            Array.Reverse(mass[index]);
            Console.WriteLine("\nРеверсивний рядок");
            PrintMassAsOneString(in mass[index]);
            Console.WriteLine("\nРезультуючий масив");
            Print_Jagged_Mass(in mass);
        }
        public static void Row_With_Max_Element(in int[][] mass, out int index)
        {
            int maxInt = mass[0][0];
            index = 0;
            for (int i = 1; i < mass.Length; i++)
            {
                if (mass[i][0] > maxInt)
                {
                    maxInt = mass[i][0];
                    index = i;
                }
            }
        }
        public static void PrintMassAsOneString(in int[] mass)
        {
            string str = " ";
            foreach (int item in mass)
            {
                str += item + " ";
            }
            Console.WriteLine(str.Trim());
        }
        public static void Print_Jagged_Mass(in int[][] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                string str = " ";
                for (int j = 0; j < mass[i].Length; j++)
                {
                    str += mass[i][j] + " ";
                }
                Console.WriteLine(str.Trim());
            }
        }
    }
}
