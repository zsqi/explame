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

        public int FirstUniqChar2(string s)
        {
            Dictionary<char, int> arr = new Dictionary<char, int>();
            for (int i = 0;i < s.Length; i++)
            {
                char c = s[i];
                if (arr.ContainsKey(c))
                {
                    arr[c]+=1;
                }
                else
                {
                    arr.Add(c, 1);
                }
            }
            foreach (char c in arr.Keys)
            {
                if (arr[c] == 1)
                {
                    return s.IndexOf(c);
                }
            }
            return -1;
        }

        /// <summary>
        /// sunday算法
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="aim"></param>
        /// <returns></returns>
        public int StrStr(String origin, String aim)
        {
            if (origin == null || aim == null)
            {
                return 0;
            }
            if (origin.Length < aim.Length)
            {
                return -1;
            }
            //目标串匹配索
            int originIndex = 0;
            //模式串匹配索引
            int aimIndex = 0;
            // 成功匹配完终止条件：所有aim均成功匹配
            while (aimIndex < aim.Length)
            {
                // 针对origin匹配完，但aim未匹配完情况处理 如 mississippi sippia
                if (originIndex > origin.Length - 1)
                {
                    return -1;
                }
                if (origin[originIndex] == aim[aimIndex])
                {
                    // 匹配则index均加1
                    originIndex++;
                    aimIndex++;
                }
                else
                {
                    //在我们上面的样例中，第一次计算值为6，第二次值为13
                    int nextCharIndex = originIndex - aimIndex + aim.Length;
                    //判断下一个目标字符（上面图里的那个绿框框）是否存在。
                    if (nextCharIndex < origin.Length)
                    {
                        // 判断目标字符在模式串中匹配到，返回最后一个匹配的index
                        int step = aim.LastIndexOf(origin[nextCharIndex]);
                        if (step == -1)
                        {
                            // 不存在的话，设置到目标字符的下一个元素
                            originIndex = nextCharIndex + 1;
                        }
                        else
                        {
                            // 存在的话，移动对应的数字（参考上文中的存在公式）
                            originIndex = nextCharIndex - step;
                        }
                        //模式串总是从第一个开始匹配
                        aimIndex = 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return originIndex - aimIndex;
        }
        /// <summary>
        /// 第125题：验证回文串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            if (s == null)
            {
                return false;
            }

            int left = 0;
            int right = s.Length - 1;
            while (left <= right)
            {
                var leftElement = char.ToLower(s[left]);
                var rightElement = char.ToLower(s[right]);
                if ((leftElement >= 'a' && leftElement <= 'z' || leftElement >= '0' && leftElement <= '9') && rightElement >= 'a' && rightElement <= 'z' || rightElement >= '0' && rightElement <= '9')
                {
                    if (leftElement != rightElement)
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
                else if (leftElement >= 'a' && leftElement <= 'z' || leftElement >= '0' && leftElement <= '9')
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return true;
        }
        /// <summary>
        /// BF算法
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int BPTest(string haystack, string needle)
        {
            int needleLen = needle.Length;
            for (int i = 0; i <= haystack.Length - needleLen; i++)
            {
                for (int j = 0; j < needleLen; j++)
                {
                    if (haystack[j + i] != needle[j])
                    {
                        break;
                    }
                    if (j == needleLen - 1)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// 第796题：旋转字符串
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public bool RotateString(string A, string B)
        {
            int N = A.Length;
            if (N != B.Length) return false;
            if (N == 0) return true;

            //Compute shift table
            int[] shifts = new int[N + 1];
            Array.Fill(shifts, 1);
            int left = -1;
            for (int right = 0; right < N; ++right)
            {
                while (left >= 0 && (B[left] != B[right]))
                    left -= shifts[left];
                shifts[right + 1] = right - left++;
            }

            //Find match of B in A+A
            int matchLen = 0;
            foreach (char c in (A + A).ToCharArray())
            {
                while (matchLen >= 0 && B[matchLen] != c)
                    matchLen -= shifts[matchLen];
                if (++matchLen == N) return true;
            }

            return false;
        }
        /// <summary>
        /// https://blog.csdn.net/helloworldchina/article/details/104465772
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int[] kmpNext(String str)
        {
            int[] next = new int[str.Length];
            next[0] = 0;
            for (int j = 1, k = 0; j < str.Length; j++)
            {
                while (k > 0 && str[k] != str[j])
                {
                    k = next[k - 1];
                }
                if (str[j] == str[k])
                {
                    k++;
                }
                next[j] = k;
            }
            return next;
        }

        public int kmp(String s, String t, int[] next)
        {//主串  t 模式串
            for (int i = 0, j = 0; i < s.Length; i++)
            {

                while (j > 0 && s[i] != t[j])
                {
                    j = next[j - 1];    //下一个匹配位为next数组的第j-1位
                }
                if (s[i] == t[j])
                {
                    j++;//主串通过i进行加1，模式串通过j加1
                }
                if (j == t.Length)
                {
                    return i - j + 1;//返回匹配位置
                }
            }
            return -1;
        }
        /// <summary>
        /// 第58题：最后一个单词的长度
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLastWord(string s)
        {
            if (s == null || s.Length == 0) return 0;
            int count = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (count == 0) continue;
                    break;
                }
                count++;
            }
            return count;
        }
    }
}
