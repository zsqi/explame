using Newtonsoft.Json;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            StringSeries series = new StringSeries();

            var a = series.kmpNext("XXYXXYXXX");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

        }
    }
}
