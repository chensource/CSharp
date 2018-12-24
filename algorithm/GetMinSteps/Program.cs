using System;

namespace GetMinSteps
{
    class Program
    {
        public static int[,] steps = new int[4, 5];
        static void Main(string[] args)
        {
            var arr = new int[4, 5] {
               { 4, 1, 5, 3, 7 },
               { 3, 2, 7, 7, 10 },
               { 6, 5, 2, 8, 25 },
               { 8, 9, 4, 5, 33 }
            };
            ShowArr(arr);
            steps[3, 4] = MinSteps(arr, 3, 4);
            Display(steps);
            Console.ReadKey();
        }

        public static int MinSteps(int[,] arr, int row, int col)
        {
            //如果为起始位置，则直接返回
            if (row == 0 && col == 0)
            {
                steps[row, col] = arr[row, col];
                return steps[row, col];
            }

            //计算到arr[row][col]的左面位置的值
            if (col >= 1 && steps[row, col - 1] == 0)
            {
                steps[row, col - 1] = MinSteps(arr, row, col - 1);
            }

            //计算到arr[row][col]的上面位置的值
            if (row >= 1 && steps[row - 1, col] == 0)
            {
                steps[row - 1, col] = MinSteps(arr, row - 1, col);
            }

            if (row == 0 && col != 0)
            {
                //如果为第一行，则直接加左面位置上最小的值
                steps[row, col] = arr[row, col] + steps[row, col - 1];
            }
            else if (col == 0 && row != 0)
            {
                //如果为第一列，则直接加上上面位置最小的值
                steps[row, col] = arr[row, col] + steps[row - 1, col];
            }
            else
            {
                //比较到达左面位置和到达上面位置的值的大小，加上两者的最小值
                steps[row, col] = arr[row, col] + Min(steps[row, col - 1], steps[row - 1, col]);
            }
            return steps[row, col];
        }

        public static int Min(int minSteps, int minSteps2)
        {
            return minSteps > minSteps2 ? minSteps2 : minSteps;
        }

        static void ShowArr(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Display(int[,] arr)
        {
           

            //数组类里面有个GetLength()方法，是用来获取数组指定维数中的元素个数。
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"到达arr[{i}][{j}]的最小路径：{arr[i, j]} ");
                }
            }
        }
    }
}
