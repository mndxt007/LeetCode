using System;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

static class Solution {
    public static int solution(int[] A) {
        // Implement your solution here
        if(A.Length==2)
        {
            return Math.Abs(A[0]-A[1]); 
        }
        int sum = A.Sum();
        int[] diffs = new int[A.Length-1];
        int runningsum = A[0];
        for(int i =1; i< A.Length;i++)
        {
            diffs[i-1] = Math.Abs((runningsum)- (sum-runningsum));
            runningsum+=A[i];
        }
        //Console.WriteLine($"diffs is {String.Join(",",diffs)}");
        return diffs.Min();
    }
}

List<int[]> testcases = [
    [3,1,2,4,3],
    [1,1]
];

foreach (var item in testcases)
{
    Console.WriteLine($"Test Case - {String.Join(",",item)}");
    Console.WriteLine($"Minimum Difference - {Solution.solution(item)}");
}