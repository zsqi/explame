using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 2, 3,3,4,1,5 };
            int[] b = new int[] { 1, 2,1,3,8};
            string[] s = new string[] { "flower", "flow", "flight" };
            ArraySeries arraySeries = new ArraySeries();
            var result = arraySeries.Convert("LEETCODEISHIRING", 4);
            Console.WriteLine(result);
        }
    }
}
