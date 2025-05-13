/*
https://leetcode.com/problems/h-index/description/?envType=study-plan-v2&envId=top-interview-150

Given an array of integers citations where citations[i] is the number of citations a researcher received for their ith paper, return the researcher's h-index.

According to the definition of h-index on Wikipedia: The h-index is defined as the maximum value of h such that the given researcher has published at least h papers that have each been cited at least h times.

 

Example 1:

Input: citations = [3,0,6,1,5]
Output: 3
Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of them had received 3, 0, 6, 1, 5 citations respectively.
Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, their h-index is 3.
Example 2:

Input: citations = [1,3,1]
Output: 1
 

Constraints:

n == citations.length
1 <= n <= 5000
0 <= citations[i] <= 1000
*/
using System.Globalization;

public static class Solution
{
    public static int HIndex(int[] citations)
    {
        int len = citations.Length;
        if (len == 1)
            return citations[0] > 0 ? 1 : 0;
        Array.Sort(citations);
        int count = 0;
        for (int i = len-1; i >= 0; i--) 
        {
            if(citations[i] > count)
            {
                count++;
            }
        }
        return count;
    }
}


List<int[]> testcases = [
    [3,0,6,1,5],
    [1,3,1],
    [4,4,0,0],
    [1,7,9,4] //The result is not necessarily part of the array i.e 3
];

foreach (var _case in testcases)
{
    Console.WriteLine($"Test case - {String.Join(' ', _case)}, Result - {Solution.HIndex(_case)}");
}