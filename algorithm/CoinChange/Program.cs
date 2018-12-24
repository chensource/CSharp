using System;

namespace CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            //人民币面值集合
            int money = 442;
            int[] values = { 1, 2, 5, 10, 20, 50, 100 };
            //各种面值对应数量集合
            int[] counts = { 3, 1, 2, 1, 1, 3, 5 };
            //求442元人民币需各种面值多少张
            int[] num = Change(money, values, counts);
            Display(money,num, values);
            Console.ReadKey();
        }

        public static int[] Change(int money, int[] values, int[] counts)
        {
            int[] result = new int[values.Length];
            for (int i = values.Length - 1; i >= 0; i--)
            {
                int num = 0;
                int c = Min(money / values[i], counts[i]);
                money = money - (values[i] * c);
                num += c;
                result[i] = num;
            }
            return result;
        }

        public static int Min(int i, int j)
        {
            return i > j ? j : i;
        }

        public static void Display(int money, int[] num, int[] values)
        {
            Console.WriteLine($"总共兑换：{money}元。");
            for (int i = 0; i < values.Length; i++)
            {
                if (num[i] != 0)
                {
                    Console.WriteLine($"{i}:需要面额为【{values[i]}】的人民币 【{num[i]}】张");
                }
            }
        }
    }
}
