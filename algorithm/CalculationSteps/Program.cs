using System;

namespace CalculationSteps
{
    class Program
    {
        //动态规划表，用来记录到达i级台阶的方法数
        public static int[] steps = new int[11];
        static void Main(string[] args)
        {
            steps[10] = CalStep(10);

            for (int i = 1; i < steps.Length; i++)
            {
                Console.WriteLine($"到达第{i}级台阶方法:{steps[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"到达第10级台阶的方法数:{steps[10]}");
            Console.ReadKey();
        }

        public static int CalStep(int n)
        {
            //如果为第一级台阶或者第二级台阶 则直接返回n
            if (n == 1 || n == 2)
            {
                return n;
            }

            //计算到达n-1级台阶的方法数
            if (steps[n - 1] == 0)
            {
                steps[n - 1] = CalStep(n - 1);
            }

            //计算到达n-2级台阶的方法数
            if (steps[n - 2] == 0)
            {
                steps[n - 2] = CalStep(n - 2);
            }

            //到达第n级台阶=到达n-1级台阶+到达n-2级台阶
            return steps[n - 1] + steps[n - 2];
        }
    }
}
