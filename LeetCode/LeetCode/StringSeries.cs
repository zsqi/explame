using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class StringSeries
    {
        /// <summary>
        /// 第344题：反转字符串
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            var start = 0;
            var end = s.Length - 1;
            while (start < end)
            {
                var temp = s[start];
                s[start] = s[end];
                s[end] = temp;
                start++;
                end--;
            }
        }
        /// <summary>
        /// 字符串中的第一个唯一字符(387)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstUniqChar(string s)
        {
            int[] arr = new int[26];  //26个字母的数组
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a'] += 1;  //a--0 b--1………… 对应位置数字+1
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (arr[s[i] - 'a'] == 1)  //当该位置数字为1
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
