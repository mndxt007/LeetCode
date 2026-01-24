public class ListNode
{
    public int val;
    public ListNode next;
}

/*
 12
X12
====
 24
12
===
144
*/

024
144

public ListNode Multiply(ListNode n1, ListNode n2)
{
    List<int> n1List = new();
    List<int> n2List = new();
    var current = n1;
    while (current !=null)
    {
        n1List.Add(current.val);
        current = current.next;
    }
    current = n2;
    while (current !=null)
    {
        n2List.Add(current.val);
        current = current.next;
    }
    int[] result = new int[Math.Max(n1List.Count, n2List.Count) + 10];

    for (int i = 0; i < n2List.Count; i++)
    {
        result[0] =  
    }




}