/*
https://app.codility.com/programmers/lessons/3-time_complexity/perm_missing_elem/
*/

using System;
using System.Collections.Generic;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

static class Solution {
    public static int solution(int[] A) {
        // Implement your solution here
        var full = Enumerable.Range(1,A.Length+1);
        return full.Except(A).DefaultIfEmpty(1).First();
    }
}

List<int[]> testcases = [
    [2,3,1,5],
    [1],
    [2,3],
    [1,2,3]
];

foreach (var item in testcases)
{
    Console.WriteLine($"Test case - {String.Join(',',item)}");
    Console.WriteLine($"Missing - {Solution.solution(item)}");
}
