using System;

namespace PalmLab4
{
    public class Lexa
    {
        public static int[] FindCountNegNum(int[] arrayStartNum)
        {
            int countNegNum = 0;
            int[] indexAllNegNum = new int[0];
            for (int i = 0; i < arrayStartNum.Length; i++)
            {
                if (arrayStartNum[i] < 0)
                {
                    countNegNum++;
                }
            }
            if (countNegNum != 0)
            {
                indexAllNegNum = FindIndexesNegNum(arrayStartNum, countNegNum);
            }
            return indexAllNegNum;
        }
        public static int[] FindIndexesNegNum(int[] arrayStartNum, int countNegNum)
        {
            int[] indexAllNegNum = new int[countNegNum];
            for (int i = 0, j = 0; i < arrayStartNum.Length; i++)
            {
                if (arrayStartNum[i] < 0)
                {
                    indexAllNegNum[j] = i;
                    j++;
                }
            }
            return indexAllNegNum;
        }
        public static int[] ResizePrimaryArray(int[] arrayStartNum, int[] indexAllNegNum)
        {
            Array.Resize(ref arrayStartNum, arrayStartNum.Length + indexAllNegNum.Length);
            return arrayStartNum;
        }
        public static int[] MoveNum(int[] arrayStartNum, int[] indexAllNegNum)
        {
            for (int i = 1; i < indexAllNegNum.Length + 1; i++)
            {
                for (int j = arrayStartNum.Length - 1; j > indexAllNegNum[i - 1] + i; j--)
                {
                    (arrayStartNum[j], arrayStartNum[j - 1]) = (arrayStartNum[j - 1], arrayStartNum[j]);
                }
            }
            return arrayStartNum;
        }
        public static int[] ReplaceZeros(int[] arrayStartNum, int[] indexAllNegNum)
        {
            for (int i = 0; i < indexAllNegNum.Length; i++)
            {
                arrayStartNum[indexAllNegNum[i] + i + 1] = Math.Abs(arrayStartNum[indexAllNegNum[i] + i]);
            }
            return arrayStartNum;
        }
        public static void MainMethodBlock1(int[] arrayStartNum)
        {
            int[] indexAllNegNum = FindCountNegNum(arrayStartNum);
            if (indexAllNegNum.Length != 0)
            {
                arrayStartNum = ResizePrimaryArray(arrayStartNum, indexAllNegNum);
                arrayStartNum = MoveNum(arrayStartNum, indexAllNegNum);
                arrayStartNum = ReplaceZeros(arrayStartNum, indexAllNegNum);
                for (int i = 0; i < arrayStartNum.Length; i++)
                {
                    Console.Write($"{arrayStartNum[i]} ");
                }

                Console.WriteLine();
            }
        }
        public static int[][] ResizeStartArray_Block2(int[][] arrayStart)
        {
            Array.Resize(ref arrayStart, arrayStart.Length + 1);
            Console.WriteLine("Введіть бажану кількість стовпчиків у новому рядку");
            arrayStart[arrayStart.Length - 1] = new int[int.Parse(Console.ReadLine())];
            return arrayStart;
        }
        public static int[][] ReplaceStartArray_Block2(int[][] arrayStart, int indexMaxVal)
        {
            for (int i = arrayStart.Length - 1; i > indexMaxVal; i--)
            {
                (arrayStart[i], arrayStart[i - 1]) = (arrayStart[i - 1], arrayStart[i]);
            }
            return arrayStart;
        }
        public static int FindingMaxVal(int[][] arrayStart)
        {
            int elementMax = Int32.MinValue;
            int indexMaxVal = 0;
            for (int i = 0; i < arrayStart.Length; i++)
            {
                for (int j = 0; j < arrayStart[i].Length; j++)
                {
                    if (elementMax <= arrayStart[i][j])
                    {
                        elementMax = arrayStart[i][j];
                        indexMaxVal = i;
                    }
                }
            }
            return indexMaxVal;
        }
        public static void MainMethodBlock2(int[][] arrayStart)
        {
            int indexMaxVal = FindingMaxVal(arrayStart);
            arrayStart = ResizeStartArray_Block2(arrayStart);
            arrayStart = ReplaceStartArray_Block2(arrayStart, indexMaxVal); //indexMaxValInArray наибольший елемент миссива
            OutPutBlock3_2(arrayStart);
        }
        public static int[][] FindNumOfSelectNum(int[] arrayIdenticalElements,ref int[][] arrayOfNumbers_First,ref int[][] arrayOfNumbers_Second)
        {
            if (arrayIdenticalElements.Length != 0)
            {
                int sumRowsAndColm = SumAllRowsAndColmInTwoArrays(ref arrayOfNumbers_First);
                Console.WriteLine("\nВведіть число");
                int numTheFindInArr = int.Parse(Console.ReadLine());
                int[] indexFindNum = new int[2];
                bool chekCompliteIteration = false;
                for (int i = 0, j = 0; i < arrayIdenticalElements.Length; i++)
                {
                    if (numTheFindInArr == arrayIdenticalElements[i])
                    {
                        indexFindNum[j] = i;
                        chekCompliteIteration = true;
                        if (j < 1)
                        {
                            j++;
                        }
                    }
                }
                if (chekCompliteIteration == false)
                {
                    Console.WriteLine("Значення яке ви шукаєте не знайдено!");
                    return arrayOfNumbers_First;
                }
                if (indexFindNum[1] != 0 )
                {
                    int index1 = indexFindNum[0] % sumRowsAndColm;
                    int index2 = indexFindNum[1] % sumRowsAndColm;
                    if (index1 < arrayOfNumbers_First.GetLength(0) & index2 < arrayOfNumbers_First[index1].Length)
                    {
                        Console.WriteLine($"Елемент {index1 + 1}-го рядка {index2 + 1}-го стовпчика був замінений з {arrayOfNumbers_First[index1][index2]} на {numTheFindInArr}");
                        arrayOfNumbers_First[index1][index2] = numTheFindInArr;
                        return arrayOfNumbers_First;
                    }
                    else
                    {
                        Console.WriteLine($"Індексів які були вказані програмою були більші ніж розмір масиву");
                        return arrayOfNumbers_First;
                    }
                }
                else
                {
                    int index1 = indexFindNum[0] % sumRowsAndColm;
                    if (index1 < arrayOfNumbers_Second.GetLength(0) & index1 < arrayOfNumbers_Second[index1].Length)
                    {
                        Console.WriteLine($"Елемент {index1 + 1}-го рядка {index1 + 1}-го стовпчика був замінений з {arrayOfNumbers_Second[index1][index1]} на {numTheFindInArr}");
                        arrayOfNumbers_Second[index1][index1] = numTheFindInArr;            
                        return arrayOfNumbers_Second;
                    }
                    else
                    {
                        Console.WriteLine($"Індексів які були вказані програмою були більші ніж розмір масиву");
                        return arrayOfNumbers_Second;
                    }
                }
                return arrayOfNumbers_First;
            }
            else
            {
                Console.WriteLine();
                return arrayOfNumbers_First;
            }
        }
        public static int[][] FindIdenticalElement(ref int[][] arrayOfNumbers_First, ref int[][] arrayOfNumbers_Second)
        {
            int[] arrayIdenticalElements = new int[0];
            for (int i = 0; i < arrayOfNumbers_First.GetLength(0) & i < arrayOfNumbers_Second.GetLength(0); i++)
            {
                for (int j = 0; j < arrayOfNumbers_First[i].Length & j < arrayOfNumbers_Second[i].Length; j++)
                {
                    if (arrayOfNumbers_First[i][j] == arrayOfNumbers_Second[i][j])
                    {
                        Array.Resize(ref arrayIdenticalElements, arrayIdenticalElements.Length + 1);
                        arrayIdenticalElements[arrayIdenticalElements.Length - 1] = arrayOfNumbers_First[i][j];
                    }
                }
            }
            if (arrayIdenticalElements.Length != 0)
            {
                Console.WriteLine("Елементи мартиць які співпадають за індексами та значеннями ");
                for (int i = 0; i < arrayIdenticalElements.Length; i++)
                {
                    Console.Write($"{arrayIdenticalElements[i]} ");
                }
                return FindNumOfSelectNum(arrayIdenticalElements,ref arrayOfNumbers_First,ref arrayOfNumbers_Second);
            }
            else
            {
                Console.WriteLine("Не має жодного числа в обох масивах які співпадають за індексом та значенням");
                return arrayOfNumbers_First;
            }
        }
        public static int SumAllRowsAndColmInTwoArrays(ref int[][] arrayOfNumbers_First)
        {
            int sumRowsAndColm = arrayOfNumbers_First.GetLength(0) * 2;
            for (int i = 0; i < arrayOfNumbers_First.GetLength(0); i++)
            {
                sumRowsAndColm += arrayOfNumbers_First[i].Length * 2;
            }
            return sumRowsAndColm;
        }
        public static void MainMethodBlock3(int[][] arrayOfNumbers_First,int[][] arrayOfNumbers_Second)
        {
            FindIdenticalElement(ref arrayOfNumbers_First,ref arrayOfNumbers_Second);
            OutPutBlock3_2(arrayOfNumbers_First);
            OutPutBlock3_2(arrayOfNumbers_Second);
        }
        public static void OutPutBlock3_2(int[][] arr)
        {
            foreach (var oneDimArr in arr)
            {
                Console.WriteLine(String.Join(", ", oneDimArr));
            }

            Console.WriteLine();
        }

    }
}
