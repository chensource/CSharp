using System;
using System.Collections.Generic;

namespace Queen
{
    class Program
    {
        /*
         * 1.要想解出在n*n的棋盘上到底有多少种放置皇后的方法，主要用到两个方法，放皇后的PutQueen方法，检查皇后的CheckQueens方法。
         * 2.在Main函数里对动态数组进行初始化，这个动态数组用来记录N皇后中每一行所放置的皇后的位置（1就代表放置在该行第一列，n就代表放置在该行的第n列）。
         * 3.row代表的是八皇后棋盘的每一行。
         * 4.在Main函数中对动态数组进行了一下初始化，这一步是必须的，否则运行结果报错。
         * 5.变量count（解的个数）声明在Main函数外，是静态的。
         * 6.PutQueen方法采用递归思想——放皇后（该行中每一列都要放置）
         *   检查放皇后的位置是否合理，如果合理则到下一行，判断下一行是否存在，如果存在——放皇后（该行中每一列都要放置），检查放皇后的位置是否合理，
         *   如果合理则……直到不存在下一行为止每一行都已经放置好了皇后，这时我们将解的个数记录一下（count++），然后打印该种解法。
         * 7.在递归结束后，一定要记得返回到上一行（row--），
         *   这样才能让“for (queen[row] = 1; queen[row] <= n; queen[row]++)”生效，实现每一行中的每一列都放置过皇后。
         *   一定要注意row--的位置要放在整个if-else语句块的后面！
         *   因为整个if-else语句块形成了对递归过程中状态的判断，有两种状态，
         *   第一种状态是皇后当前在第2到n-1行，这时候如果想返回上一行，“row--”的位置其实可以写在if语句块中"PutQueen(n, queen, row);"这一句的后面；
         *   第二种状态是皇后当前在最后一行（也就是第n行），这时候如果想返回上一行，“row--”的位置其实可以写在else语句块中。
         *   因此，我们才将“row--”的位置移到了整个if-else语句块的后面。
         * **/

        static int count = 0;
        static void Main(string[] args)
        {
            int n = 4;
            List<int> queen = new List<int>(n);
            for (int i = 1; i <= n; i++)
            {
                queen.Add(0);
            }
            PutQueen(n, queen, 0);
            Console.WriteLine($"共{count}种结果");
            Console.ReadKey();
        }

        static void PutQueen(int n, List<int> queen, int row)
        {
            for (queen[row] = 1; queen[row] <= n; queen[row]++)
            {
                if (CheckQueen(queen, row))
                {
                    row++;
                    if (row < n)
                    {
                        PutQueen(n, queen, row);
                    }
                    else
                    {
                        count++;
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"{queen[i].ToString()}  ");
                        }
                        Console.WriteLine();
                    }
                    row--;
                }
            }
        }

        private static bool CheckQueen(List<int> queen, int row)
        {
            for (int i = 0; i < row; i++)
            {
                //判断2个皇后是否相等或者相差等于列数之差（即处于正反对角线）
                if (Math.Abs(queen[i] - queen[row]) == Math.Abs(i - row) || queen[i] == queen[row])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
