namespace PalmLab4
{
    internal class VanDarckhoule
    {
        public static int[] VanVol1(int[] arr)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int maxIndex = -1;
            int minIndex = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                    maxIndex = i;
                }

                if (arr[i] < min)
                {
                    min = arr[i];
                    minIndex = i;
                }
            }

            if (maxIndex < minIndex)
            {
                int temp = maxIndex;
                maxIndex = minIndex;
                minIndex = temp;
            }

            Array.Resize(ref arr, arr.Length - (maxIndex - minIndex + 1));

            Console.WriteLine(string.Join(" ", arr));

            return arr;
        }
        public static int[][] VanVol2(int[][] jaggedArray)
        {
            int maxElement = jaggedArray[0][0];
            int maxRowIndex = 0;

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    if (jaggedArray[i][j] > maxElement)
                    {
                        maxElement = jaggedArray[i][j];
                        maxRowIndex = i;
                    }
                }
            }

            int[][] newJaggedArray = new int[jaggedArray.Length - 1][];
            int destRowIndex = 0;
            for (int srcRowIndex = 0; srcRowIndex < jaggedArray.Length; srcRowIndex++)
            {
                if (srcRowIndex != maxRowIndex)
                {
                    newJaggedArray[destRowIndex] = jaggedArray[srcRowIndex];
                    destRowIndex++;
                }
            }

            for (int i = 0; i < newJaggedArray.Length; i++)
            {
                for (int j = 0; j < newJaggedArray[i].Length; j++)
                {
                    Console.Write(newJaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            return newJaggedArray;
        }
        public static int[][] VanVol3(int[,] B)
        {
            int[] P = new int[B.GetLength(0)];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] == 0)
                    {
                        count++;
                    }
                }
                P[i] = count;
            }

            int[][] Z = new int[B.GetLength(0)][];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                Z[i] = new int[P[i]];
                int k = 0;
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (B[i, j] == 0)
                    {
                        Z[i][k++] = j;
                    }
                }
            }

            for (int i = 0; i < Z.GetLength(0); i++)
            {
                Array.Reverse(Z[i]);
            }

            for (int i = 0; i < Z.Length; i++)
            {
                for (int j = 0; j < Z[i].Length; j++)
                {
                    Console.Write(Z[i][j] + " ");
                }
                Console.WriteLine();
            }

            return Z;
        }
    }
}