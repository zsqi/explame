using Newtonsoft.Json;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 2, 7, 9, 3, 1 };
            DynamicProgramming dynamicProgramming = new DynamicProgramming();
            var r=dynamicProgramming.Rob(a);
            Console.WriteLine(JsonConvert.SerializeObject(r));
        }
    }
}
