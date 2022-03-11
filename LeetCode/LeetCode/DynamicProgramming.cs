using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 动态规划
    /// </summary>
    public class DynamicProgramming
    {
        /// <summary>
        /// 第70题：爬楼梯
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            int p = 0, q = 0, r = 1;
            for (int i = 1; i <= n; ++i)
            {
                p = q;
                q = r;
                r = p + q;
            }
            return r;
        }
        /// <summary>
        /// 第53题：最大子序和
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int pre = 0, maxAns = nums[0];
            foreach (int x in nums)
            {
                pre = Math.Max(pre + x, x);
                maxAns = Math.Max(maxAns, pre);
            }
            return maxAns;
        }

        /// <summary>
        /// 最长上升子序列(300)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int[] dp = new int[nums.Length];
            int res = 0;
            Array.Fill(dp, 1);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
        /// <summary>
        /// 三角形最小路径和(120)
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int row = triangle.Count - 2;
            for (; row >= 0; row--)
            {
                for (int j = 0; j < triangle[row].Count; j++)
                {
                    triangle[row][j] += triangle[row + 1][j] < triangle[row + 1][j + 1] ? triangle[row + 1][j] : triangle[row + 1][j + 1];
                }
            }
            return triangle[0][0];
        }
        /// <summary>
        /// 最小路径和(64)
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length < 1)
            {
                return 0;
            }
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    else if (i == 0)
                    {
                        grid[i][j] += grid[i][j - 1];
                    }
                    else if (j == 0)
                    {
                        grid[i][j] += grid[i - 1][j];
                    }
                    else
                    {
                        grid[i][j] += Math.Min(grid[i - 1][j], grid[i][j - 1]);
                    }
                }
            }
            return grid[grid.Length - 1][grid[0].Length - 1];
        }
        /// <summary>
        /// 第198题：打家劫舍
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            if (nums.Length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }
            nums[1] = Math.Max(nums[0], nums[1]);
            for (var i = 2; i < nums.Length; i++)
            {
                nums[i] = Math.Max(nums[i - 1], nums[i - 2] + nums[i]);
            }
            return nums[nums.Length - 1];
        }
    }
}
