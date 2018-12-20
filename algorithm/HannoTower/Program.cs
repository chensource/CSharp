using System;

namespace HannoTower
{
    class Program
    {
        public static int count = 1;
        static void Main(string[] args)
        {
            Moved(4, "第一根柱子", "第二根柱子", "第三根柱子");
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="i">初始圆盘数量</param>
        /// <param name="a">圆盘初始所在位置</param>
        /// <param name="b">圆盘要移动的塔座</param>
        /// <param name="c">辅助圆盘要移动的塔座</param>
        public static void Moved(int i, string a, string b, string c)
        {
            if (i == 1)
            {
                Display(i, a, b);
            }
            else
            {
                // 将 i-1 根圆盘由A移动到C
                Moved(i - 1, a, c, b);
                // 将圆盘 i 由 A 移动 到 B
                Display(i, a, b);
                // 将 i-1 根圆盘由C移动到A
                Moved(i - 1, c, b, a);
            }
        }

        public static void Display(int i, string a, string b)
        {
            Console.WriteLine($"第{count}步:移动{i}号圆盘，从{a}到{b}");
            count++;
        }
    }
}
