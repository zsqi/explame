using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /// <summary>
    /// 链表系列
    /// </summary>
    public class LinkedListSeries
    {
        /// <summary>
        /// 第19题：删除链表倒数第N个节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            return RemoveNode(head, n) == n ? head.next : head;
        }
        public int RemoveNode(ListNode node, int n)
        {
            if (node.next == null) return 1;
            int m = RemoveNode(node.next, n);
            if (m == n)
                if (m == 1) node.next = null;
                else node.next = node.next.next;
            return m + 1;
        }

        public ListNode RemoveNthFromEnd2(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            ListNode second = dummy;
            // Advances first pointer so that the gap between first and second is n nodes apart
            for (int i = 0; i <= n; i++)
            {
                first = first.next;
            }
            // Move first to the end, maintaining the gap
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }
            second.next = second.next.next;
            return dummy.next;
        }
        /// <summary>
        /// 第21题：合并两个有序链表
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode prehead = new ListNode(-1);

            ListNode prev = prehead;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    prev.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    prev.next = l2;
                    l2 = l2.next;
                }
                prev = prev.next;
            }

            // 合并后 l1 和 l2 最多只有一个还未被合并完，我们直接将链表末尾指向未合并完的链表即可
            prev.next = l1 == null ? l2 : l1;

            return prehead.next;
        }
        /// <summary>
        /// 第141题：环形链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }
        /// <summary>
        /// 第2题：两数相加
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode pre = new ListNode(0);
            ListNode cur = pre;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int x = l1 == null ? 0 : l1.val;
                int y = l2 == null ? 0 : l2.val;
                int sum = x + y + carry;

                carry = sum / 10;
                sum = sum % 10;
                cur.next = new ListNode(sum);

                cur = cur.next;
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;
            }
            if (carry == 1)
            {
                cur.next = new ListNode(carry);
            }
            return pre.next;
        }

        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            int val = 0;
            ListNode prenode = new ListNode(0);
            ListNode lastnode = prenode;
            while (l1 != null || l2 != null || val != 0)
            {
                val = val + (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
                lastnode.next = new ListNode(val % 10);
                lastnode = lastnode.next;
                val = val / 10;
                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;
            }
            return prenode.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
