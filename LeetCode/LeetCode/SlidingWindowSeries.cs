using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 滑动窗口系列
    /// </summary>
    public class SlidingWindowSeries
    {
        /// <summary>
        /// 第239题：滑动窗口最大值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSlidingWindow1(int[] nums, int k)
        {
            int len = nums.Length;
            if (len * k == 0) return new int[0];
            int[] win = new int[len - k + 1];
            //遍历所有的滑动窗口
            for (int i = 0; i < len - k + 1; i++)
            {
                int max = int.MinValue;
                //找到每一个滑动窗口的最大值
                for (int j = i; j < i + k; j++)
                {
                    max = Math.Max(max, nums[j]);
                }
                win[i] = max;
            }
            return win;
        }

		//双端队列 O(n)
		//使用两个指针表示滑动窗口的头和尾，向右移动
		//使用一个双端队列，存放索引，从头到尾对应的元素逐渐减小
		//当遍历到比队尾大的元素，从队尾出队直到插入元素比队尾小
		//每移动一个需要检测队头元素是否在合法索引范围内[head, tail]，不符合则从队头出队
		//每一轮都完成上面操作后队头即为当前窗口最大值
		public int[] MaxSlidingWindow(int[] nums, int k)
		{
			if (nums == null || nums.Length < 1 || k < 1)
			{
				return null;
			}
			if (nums.Length < 2)
			{
				return nums;
			}
			LinkedList<int> list = new LinkedList<int>();//C#自带的LinkedList就是一个双端队列
			int[] array = new int[nums.Length - k + 1];
			int tail = 0;           //窗口尾部指针
			int head = tail - k + 1;//窗口头部指针
			while (tail < nums.Length)
			{
				while (list.Count != 0 && nums[list.Last.Value] <= nums[tail])
				{
					list.RemoveLast();//移除所有比插入节点小的元素索引（要判空队列不然报错）
				}
				list.AddLast(tail);//插入窗口尾部索引
				if (list.First.Value < head)
				{
					list.RemoveFirst();//移除不合法的窗口头部索引（不用while的原因是每次只移动一格）
				}
				if (head >= 0)
				{
					array[head] = nums[list.First.Value];//head合法则可以添加进最大值数组
				}
				++head;
				++tail;
			}
			return array;
		}
        /// <summary>
        /// 第3题：无重复字符的最长子串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            List<char> ls = new List<char>();
            int n = s.Length;
            int intMaxLength = 0;
            for (int i = 0; i < n; i++)
            {
                if (ls.Contains(s[i]))
                {
                    ls.RemoveRange(0, ls.IndexOf(s[i]) + 1);
                }
                ls.Add(s[i]);
                intMaxLength = ls.Count > intMaxLength ? ls.Count : intMaxLength;
            }
            return intMaxLength;
        }

        /// <summary>
        /// 第438. 找到字符串中所有字母异位词
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams2(string s, string p)
        {
            int sLen = s.Length, pLen = p.Length;

            if (sLen < pLen)
            {
                return new List<int>();
            }

            IList<int> ans = new List<int>();
            int[] sCount = new int[26];
            int[] pCount = new int[26];
            for (int i = 0; i < pLen; ++i)
            {
                ++sCount[s[i] - 'a'];
                ++pCount[p[i] - 'a'];
            }

            if (Enumerable.SequenceEqual(sCount, pCount))
            {
                ans.Add(0);
            }

            for (int i = 0; i < sLen - pLen; ++i)
            {
                --sCount[s[i] - 'a'];
                ++sCount[s[i + pLen] - 'a'];

                if (Enumerable.SequenceEqual(sCount, pCount))
                {
                    ans.Add(i + 1);
                }
            }

            return ans;
        }

        public IList<int> FindAnagrams(string s, string p)
        {
            int sLen = s.Length, pLen = p.Length;

            if (sLen < pLen)
            {
                return new List<int>();
            }

            IList<int> ans = new List<int>();
            int[] count = new int[26];
            for (int i = 0; i < pLen; ++i)
            {
                ++count[s[i] - 'a'];
                --count[p[i] - 'a'];
            }

            int differ = 0;
            for (int j = 0; j < 26; ++j)
            {
                if (count[j] != 0)
                {
                    ++differ;
                }
            }

            if (differ == 0)
            {
                ans.Add(0);
            }

            for (int i = 0; i < sLen - pLen; ++i)
            {
                if (count[s[i] - 'a'] == 1)
                {  // 窗口中字母 s[i] 的数量与字符串 p 中的数量从不同变得相同
                    --differ;
                }
                else if (count[s[i] - 'a'] == 0)
                {  // 窗口中字母 s[i] 的数量与字符串 p 中的数量从相同变得不同
                    ++differ;
                }
                --count[s[i] - 'a'];

                if (count[s[i + pLen] - 'a'] == -1)
                {  // 窗口中字母 s[i+pLen] 的数量与字符串 p 中的数量从不同变得相同
                    --differ;
                }
                else if (count[s[i + pLen] - 'a'] == 0)
                {  // 窗口中字母 s[i+pLen] 的数量与字符串 p 中的数量从相同变得不同
                    ++differ;
                }
                ++count[s[i + pLen] - 'a'];

                if (differ == 0)
                {
                    ans.Add(i + 1);
                }
            }

            return ans;
        }

    }
}
