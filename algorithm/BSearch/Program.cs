using System;

namespace BSearch
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int index = BSearch(arr, 0, arr.Length - 1, 6);
            Console.WriteLine(index);
            Console.ReadKey();
        }

        public static int BSearch(int[] data, int left, int right, int key)
        {
            int middle = (left + right) / 2;

            if (data[middle] == key)
            {
                return key;
            }
            else if (data[middle] > key)
            {
                return BSearch(data, left, middle - 1, key);
            }
            else
            {
                return BSearch(data, middle + 1, right, key);
            }
        }
    }
}
