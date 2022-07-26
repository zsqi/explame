using Newtonsoft.Json;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            SlidingWindowSeries slidingWindowSeries= new SlidingWindowSeries();
            string s = "cbaebabacd";
            string q = "acd";
            var r=slidingWindowSeries.FindAnagrams(s, q);
            Console.WriteLine(JsonConvert.SerializeObject(r));
        }
    }
}
