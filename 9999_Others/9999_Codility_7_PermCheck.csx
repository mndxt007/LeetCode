using System;
using System.Collections.Generic;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

static class Solution {
    public static int IsPerm(int[] A) {
        // Implement your solution here
        var right = new HashSet<int>(A);
        var left = new HashSet<int>(Enumerable.Range(1,A.Length));
        if(left.IsSubsetOf(right))
        {
            return 1;
        }
        return 0;
    }
}

List<int[]> testcases = [
    [4,1,3,2],
    [4,1,3],
    [1,1]
];

foreach (var item in testcases)
{
    Console.WriteLine($"Test Case - {String.Join(",",item)}");
    Console.WriteLine($"Is Permutation - {Solution.IsPerm(item)}");
}