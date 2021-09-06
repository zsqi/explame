using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 递归
    /// </summary>
    public class Recursion
    {
        /// <summary>
        /// 1 1 2 3 5 8递归
        /// </summary>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int FibonacciSequence(int end)
        {
            if (end <= 0)
            {
                return 0;
            }
            else if (end == 1)
            {
                return 1;
            }
            else
            {
                return FibonacciSequence(end - 1) + FibonacciSequence(end - 2);
            }
        }
    }
}
