/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example 1:


Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
 

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.
*/


public static ListNode LoadList(int[] values)
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

public static void PrintList(ListNode head)
{
    ListNode current = head;
    while (current != null)
    {
        Console.Write(current.val);
        if (current.next != null)
        {
            Console.Write(",");
        }
        current = current.next;
    }
    Console.WriteLine();
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


public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    ListNode result = new();
    var curl1 = l1;
    var curl2 = l2;
    var curresult = result;
    int rem = 0; int sum = 0; int carry = 0;
    while (true)
    {
        sum = curl1.val + curl2.val + carry;
        rem = sum % 10;
        carry = sum / 10;
        curresult.val = rem;
        curl1 = curl1.next;
        curl2 = curl2.next;
        if (curl1 == null || curl2 == null)
            break;
        curresult.next = new();
        curresult = curresult.next;
    }
    if (curl1 is not null || curl2 is not null)
    {
        curresult.next = new();
        curresult = curresult.next;
        while (curl1 is not null)
        {
            sum = curl1.val + carry;
            rem = sum % 10;
            curresult.val = rem;
            carry = sum / 10;
            curl1 = curl1.next;
            if (curl1 == null)
                break;
            curresult.next = new();
            curresult = curresult.next;
        }
        while (curl2 is not null)
        {
            sum = curl2.val + carry;
            rem = sum % 10;
            curresult.val = rem;
            carry = sum / 10;
            curl2 = curl2.next;
            if (curl2 == null)
                break;
            curresult.next = new();
            curresult = curresult.next;
        }
    }
    if (carry > 0)
    {
        curresult.next = new();
        curresult = curresult.next;
        curresult.val = carry;
    }
    return result;
}

List<(int[], int[])> testcases = [
    (
        [2,4,3], [5,6,4]
   ),
    (
        [0],[0]
    ),
    (
      [9,9,9,9,9,9,9],  [9,9,9,9]
    )
];

foreach (var (l1, l2) in testcases)
{
    Console.WriteLine($"L1 - {String.Join(',', l1)} | L2 - {String.Join(',', l2)}");
    var listl1 = LoadList(l1);
    var listl2 = LoadList(l2);
    Console.Write("Result - ");
    var result = AddTwoNumbers(listl1, listl2);
    PrintList(result);
}
