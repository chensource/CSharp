using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalWeight = 150;
            string[] names = { "A", "B", "C", "D", "E", "F", "G" };
            int[] prices = { 10, 30, 30, 35, 40, 40, 50 };
            int[] weights = { 35, 30, 60, 50, 40, 10, 25 };

            //根据权重排序
            var goods = InitData(names, prices, weights).OrderBy(p => p.Price / p.Weight).ToList();


            /*
             * 让你把物品一个个的往包里装，要求装入包中的物品总价值最大，要让总价值最大，就可以想到怎么放一个个的物品才能让总的价值最大，
             * 因此可以想到如下三种选择物品的方法，即可能的局部最优解：
             * ①：每次都选择价值最高的往包里放。
             * ②：每次都选择重量最小的往包里放。
             * ③：每次都选择单位重量价值最高的往包里放。
             * 
             * **/
            int[] num = Change(totalWeight, goods);
            Display(totalWeight, num, goods);
            Console.ReadKey();
        }

        public static List<GoodInfo> InitData(string[] names, int[] prices, int[] weights)
        {
            List<GoodInfo> goods = new List<GoodInfo>();
            for (int i = 0; i < names.Length; i++)
            {
                goods.Add(new GoodInfo()
                {
                    Name = names[i],
                    Price = prices[i],
                    Weight = weights[i]
                });
            }
            return goods;
        }


        public static int[] Change(int weight, List<GoodInfo> list)
        {
            int[] result = new int[list.Count];
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int num = 0;
                int c = (weight / list[i].Weight);
                weight = weight - list[i].Weight * c;
                num += c;
                result[i] = c;
            }
            return result;
        }

        public static void Display(int weight, int[] nums, List<GoodInfo> lists)
        {
            Console.WriteLine($"总负重：{weight}。");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"{i}:需要{lists[i].Name}为价格[{lists[i].Price}]({lists[i].Weight}){nums[i]}件");
            }
        }

    }

    public class GoodInfo
    {
        public int Price { get; set; } //物品效益
        public int Weight { get; set; } //物品重量
        public string Name { get; set; } //物品编号
    };
}
