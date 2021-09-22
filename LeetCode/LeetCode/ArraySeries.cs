using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 数组系列
    /// </summary>
    public class ArraySeries
    {
        /// <summary>
        /// 第350题：两个数组的交集
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                Intersect(nums2, nums1);
            }
            var dic = new Dictionary<int, int>();
            List<int> list = new List<int>();
            foreach (int n in nums1)
            {
                if (dic.ContainsKey(n))
                    dic[n]++;
                else
                    dic.Add(n, 1);
            }
            foreach (int n in nums2)
            {
                if (dic.ContainsKey(n) && dic[n] > 0)
                {
                    dic[n]--;
                    list.Add(n);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 题目14: 最长公共前缀
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            string s = "";
            if (strs.Length == 0)
            {
                return s;
            }
            s = strs[0];
            for (var i = 1; i < strs.Length; i++)
            {
                s = longestCommonPrefix(s, strs[i]);
                if (strs[i].Length == 0)
                {
                    break;
                }
            }
            return s;
        }
        public String longestCommonPrefix(String str1, String str2)
        {
            int length = Math.Min(str1.Length, str2.Length);
            int index = 0;
            while (index < length && str1.Substring(index, 1) == str2.Substring(index, 1))
            {
                index++;
            }
            return str1.Substring(0, index);
        }

        /// <summary>
        /// 第122题：买卖股票的最佳时机 II
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            int maxprofit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    maxprofit += prices[i] - prices[i - 1];
            }
            return maxprofit;
        }

        /// <summary>
        /// 题目189: 旋转数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }
        public void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        /// <summary>
        /// 题目27：移除元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// 题目26：删除排序数组中的重复项
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}
