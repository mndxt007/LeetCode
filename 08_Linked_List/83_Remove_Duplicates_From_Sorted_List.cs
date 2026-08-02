/*
Given the head of a sorted linked list, delete all duplicates such that each element appears only once.
Return the linked list sorted as well.

Example 1:
Input: head = [1,1,2]
Output: [1,2]

Example 2:
Input: head = [1,1,2,3,3]
Output: [1,2,3]

Constraints:
The number of nodes in the list is in the range [0, 300].
-100 <= Node.val <= 100
The list is guaranteed to be sorted in ascending order.
*/

// TODO: Implement solution
ListNode DeleteDuplicates(ListNode head)
{
    ListNode previous = head;
    ListNode current = head?.next;
    while(current!=null)
    {
        if(previous.val == current.val)
        {
            previous.next = current.next;
            current = current.next;
            continue;
        }
        previous = current;
        current = current.next;
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
    //Console.WriteLine();
}

List<int[]> testcases = [
    [1,1,2],
    [1,1,2,3,3],
    [1,1,1]
];

foreach (var tc in testcases)
{
    Console.WriteLine($"Testcase: head-[{String.Join(',', tc)}]");
    var head = LoadList(tc);
    var result = DeleteDuplicates(head);
    Console.Write("DeleteDuplicates - [");
    PrintList(result);
    Console.WriteLine("]");
}

// Class definitions MUST come after all top-level statements
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
