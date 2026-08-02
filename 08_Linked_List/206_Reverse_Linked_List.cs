/*
Given the head of a singly linked list, reverse the list, and return the reversed list.

 

Example 1:


Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]
Example 2:


Input: head = [1,2]
Output: [2,1]
Example 3:

Input: head = []
Output: []
 

Constraints:

The number of nodes in the list is the range [0, 5000].
-5000 <= Node.val <= 5000
 

Follow up: A linked list can be reversed either iteratively or recursively. Could you implement both?
*/


List<int[]> testcases = [
    [1,2,3,4,5],
    [5,4,3,2,1]
];

foreach (var test in testcases)
{
    var head = CreateLinkedList(test);
    Console.Write("Test case - [");
    PrintList(head);
    Console.WriteLine("]");
    Console.Write("Reversed? - [");
    PrintList(ReverseList(head));
    Console.WriteLine("]");
}


ListNode ReverseList(ListNode head)
{
    ListNode prev = null;
    var current = head; 
    while(current!=null)
    {
        var next = current.next;
        current.next = prev; 
        prev = current;
        current = next;

    }
    return prev;
}


ListNode CreateLinkedList(int[] values)
{
    if (values == null || values.Length == 0)
        return null;
    ListNode head = new ListNode(values[0]);
    ListNode current = head;
    for (int i = 1; i < values.Length; i++)
    {
        current.next = new ListNode(values[i]);
        current = current.next;
    }
    return head;
}


void PrintList(ListNode head)
{
    ListNode current = head;
    while (current != null)
    {
        Console.Write(current.val);
        if (current.next != null) Console.Write(",");
        current = current.next;
    }
}



//Definition for singly-linked list.
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
