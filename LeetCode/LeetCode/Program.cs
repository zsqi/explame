using Newtonsoft.Json;
using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode listNode = new ListNode(3);
            listNode.next=new ListNode(2);
            listNode.next.next=new ListNode(0);
            listNode.next.next.next=new ListNode(-4);
            listNode.next.next.next.next = listNode.next;

            ListNode listNode2 = new ListNode(1);
            listNode2.next = new ListNode(3);
            listNode2.next.next = new ListNode(5);
            listNode2.next.next.next = new ListNode(6);

            LinkedListSeries linkedListSeries = new LinkedListSeries();
           var r= linkedListSeries.HasCycle(listNode);
            Console.WriteLine(JsonConvert.SerializeObject(r));
        }
    }
}
