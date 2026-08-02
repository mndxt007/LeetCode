/*
Given the head of a singly linked list, group all the nodes with odd indices together followed by the nodes with even indices, and return the reordered list.

The first node is considered odd, and the second node is even, and so on.

Note that the relative order inside both the even and odd groups should remain as it was in the input.

You must solve the problem in O(1) extra space complexity and O(n) time complexity.

 
Example 1:

Input: head = [1,2,3,4,5]
Output: [1,3,5,2,4]

Example 2:

Input: head = [2,1,3,5,6,4,7]
Output: [2,3,6,7,1,5,4]

 
Constraints:

The number of nodes in the linked list is in the range [0, 104].
-106 <= Node.val <= 106
*/

// TODO: Implement solution
ListNode OddEvenList(ListNode head)
{
    var evenCurrent = head;
    if(head is not null && head.next is not null)
    {
        var oddHead = head.next;
        var oddCurrent = oddHead;
        var currentNode = oddHead.next;
        while(currentNode != null)
        {
            oddCurrent.next = currentNode.next;
            evenCurrent.next = currentNode;
            currentNode = currentNode.next?.next;
            oddCurrent = oddCurrent.next;
            evenCurrent = evenCurrent.next;
        }
        evenCurrent.next = oddHead;
    }
    return head;
}

ListNode LoadList(int[] values)
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

List<int[]> testcases = [
    [1,2,3,4,5],
    [2,1,3,5,6,4,7]
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase: head-[{String.Join(',', testcase)}]");
    var head = LoadList(testcase);
    var result = OddEvenList(head);
    Console.Write("OddEvenList - [");
    PrintList(result);
    Console.WriteLine("]");
}

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.next = next;
        this.val = val;
    }
}
