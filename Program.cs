using System;
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public static ListNode MergeKLists(ListNode[] lists)
    {
        var minHeap = new PriorityQueue<ListNode, int>();

        foreach (var list in lists)
        {
            if (list != null)
                minHeap.Enqueue(list, list.val);
        }

        var dummy = new ListNode();
        var current = dummy;


        while (minHeap.Count > 0)
        {
            var node = minHeap.Dequeue();
            current.next = node;
            current = current.next;


            if (node.next != null)
                minHeap.Enqueue(node.next, node.next.val);
        }

        return dummy.next;
    }


    public static void PrintList(ListNode head)
    {
        var current = head;
        while (current != null)
        {
            Console.Write(current.val + " ");
            current = current.next;
        }
        Console.WriteLine();
    }

    public static void Main()
    {

        var list1 = new ListNode(1, new ListNode(4, new ListNode(5)));
        var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
        var list3 = new ListNode(2, new ListNode(6));

        ListNode[] lists = { list1, list2, list3 };

        var result = MergeKLists(lists);

        Console.WriteLine("Merged List:");
        PrintList(result);
    }
}