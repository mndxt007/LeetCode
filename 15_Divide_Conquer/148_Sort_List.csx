/*
Given the head of a linked list, return the list after sorting it in ascending order.
Example 1:
Input: head = [4,2,1,3]
Output: [1,2,3,4]

Example 2:
Input: head = [-1,5,3,4,0]
Output: [-1,0,3,4,5]

Example 3:
Input: head = []
Output: []
 
Constraints:

The number of nodes in the list is in the range [0, 5 * 104].
-105 <= Node.val <= 105
 

Follow up: Can you sort the linked list in O(n logn) time and O(1) memory (i.e. constant space)?
*/

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

public ListNode SortList(ListNode head)
{
    if (head is null || head.next is null)
    {
        return head;
    }

    var left = head;
    var right = GetMid(head);
    var temp = right.next;
    right.next = null;
    right = temp;

    left = SortList(left);
    right = SortList(right);

    return Merge(left, right);
}

private static ListNode GetMid(ListNode head)
{
    var slow = head;
    var fast = head.next;

    while (fast is not null && fast.next is not null)
    {
        slow = slow.next;
        fast = fast.next.next;
    }

    return slow;
}

private static ListNode Merge(ListNode left, ListNode right)
{
    var head = new ListNode();
    var tail = head;
    while (left is not null && right is not null)
    {
        if (left.val < right.val)
        {
            tail.next = left;
            left = left.next;
        }
        else
        {
            tail.next = right;
            right = right.next;
        }
        tail = tail.next;
    }
    if (left is not null)
    {
        tail.next = left;
    }
    if (right is not null)
    {
        tail.next = right;
    }
    return head.next;
}


static ListNode ArrayToList(int[] array)
{
    ListNode dummy = new();
    var current = dummy;
    foreach (var val in array)
    {
        current.next = new ListNode(val);
        current = current.next;
    }
    return dummy.next;
}



static List<int> ListToArray(ListNode head)
{
    var result = new List<int>();
    var node = head;
    while(node != null)
    {
        result.Add(node.val);
        node = node.next;
    }
    return result;
}


List<int[]> testcases = [
    [4,2,1,3],
    [-1,5,3,4,0],
    []
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase - {String.Join(',', testcase)}");
    var node = ArrayToList(testcase);
    var sortedList = ListToArray(SortList(node));
    Console.WriteLine($"Result - {String.Join(',', sortedList)}");
}

