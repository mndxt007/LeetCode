/*
https://leetcode.com/problems/reduce-array-size-to-the-half/description/
You are given an integer array arr. You can choose a set of integers and remove all the occurrences of these integers in the array.

Return the minimum size of the set so that at least half of the integers of the array are removed.

 

Example 1:

Input: arr = [3,3,3,3,5,5,5,2,2,7]
Output: 2
Explanation: Choosing {3,7} will make the new array [5,5,5,2,2] which has size 5 (i.e equal to half of the size of the old array).
Possible sets of size 2 are {3,5},{3,2},{5,2}.
Choosing set {2,7} is not possible as it will make the new array [3,3,3,3,5,5,5] which has a size greater than half of the size of the old array.
Example 2:

Input: arr = [7,7,7,7,7,7]
Output: 1
Explanation: The only possible set you can choose is {7}. This will make the new array empty.
 

Constraints:

2 <= arr.length <= 105
arr.length is even.
1 <= arr[i] <= 105
*/

public static class Solution {
    public static int MinSetSize(int[] arr) {
        Dictionary<int,int> counts = new();
        for(int i=0; i<arr.Length;i++)
        {
            if(counts.ContainsKey(arr[i]))
            {
                counts[arr[i]]++;
            }
            else
            {
                counts.Add(arr[i],1);
            }
        }
        //most likely timespent below;
        //var ordercount = counts.OrderByDescending(item => item.Value);
        var listofcounts = counts.Values.ToArray();
        Array.Sort(listofcounts);
        Array.Reverse(listofcounts);//
        int minsetsize = 0;
        int removedcount = 0;
        int length = arr.Length;
        foreach (var count in listofcounts)
        {
            minsetsize++;
            removedcount+=count;
            if(removedcount >= arr.Length/2)
                return minsetsize;
        }
        return 0;
    }
}

List<int[]> testcases = 
[
    [3,3,3,3,5,5,5,2,2,7],
    [7,7,7,7,7,7],
    [1,9]
];

foreach (var case_ in testcases)
{
    Console.WriteLine($" Test case - {String.Join(',',case_)}");
    Console.WriteLine($"Min Set Size - {Solution.MinSetSize(case_)}");
}