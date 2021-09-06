﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 排序
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// 快速排序
        /// </summary>
        public static void Quicksort()
        {
            int[] arr = { 15, 22, 35, 9, 16, 33, 15, 23, 68, 1, 33, 25, 14 }; //待排序数组
            QuickSort(arr, 0, arr.Length - 1);  //调用快速排序函数。传值(要排序数组，基准值位置，数组长度)

            //控制台遍历输出
            Console.WriteLine("排序后的数列：");
            foreach (int item in arr)
                Console.WriteLine(item);
        }

        private static void QuickSort(int[] arr, int begin, int end)
        {
            if (begin >= end) return;   //两个指针重合就返回，结束调用
            int pivotIndex = QuickSort_Once(arr, begin, end);  //会得到一个基准值下标

            QuickSort(arr, begin, pivotIndex - 1);  //对基准的左端进行排序  递归
            QuickSort(arr, pivotIndex + 1, end);   //对基准的右端进行排序  递归
        }

        private static int QuickSort_Once(int[] arr, int begin, int end)
        {
            int pivot = arr[begin];   //将首元素作为基准
            int i = begin;
            int j = end;
            while (i < j)
            {
                //从右到左，寻找第一个小于基准pivot的元素
                while (arr[j] >= pivot && i < j)
                {  //满足条件则指针前移（从后往前），继续循环
                    j--; //指针向前移
                }
                //当找到第一个小于基准的数组元素时就跳出循环，执行下一行代码
                arr[i] = arr[j];  //执行到此，j已指向从右端起第一个小于基准pivot的元素，执行替换

                //从左到右，寻找首个大于基准pivot的元素
                while (arr[i] <= pivot && i < j)
                {     //满足条件则指针前移（从后往前），继续循环
                    i++;   //指针向后移
                }
                //当找到第一个大于基准的数组元素时就跳出循环，执行下一行代码
                arr[j] = arr[i];  //执行到此,i已指向从左端起首个大于基准pivot的元素，执行替换

            }

            //退出while循环,执行至此，必定是 i= j的情况（最后两个指针会碰头）
            //i(或j)所指向的既是基准位置，定位该趟的基准并将该基准位置返回
            arr[i] = pivot;
            return i;
        }
    }
}
