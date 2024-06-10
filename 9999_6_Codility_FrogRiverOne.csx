/*
https://app.codility.com/programmers/lessons/4-counting_elements/frog_river_one/
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

static class Solution {
    public static int solution(int X, int[] A) {
        // Implement your solution here
        long sum=0;
        HashSet<int> range= new HashSet<int>(Enumerable.Range(1,X));
        //long expectedsum = range.Sum();
        var current = new HashSet<int>();
        bool final = false;
        for(int i=0;i<A.Length;i++)
        {
            //sum+=A[i];
            current.Add(A[i]);
            if(A[i]==X || final)
            {
                final = true;
                if(current.Count >= X)
                {
                   // Console.WriteLine($"current is {String.Join(",",current)} - Is subset? - {range.IsSubsetOf(current)}");
                    if(range.IsSubsetOf(current))
                    {
                        return i;
                    }
                    
                }
            }
            
        }
        return -1;
    }
}

Dictionary<int, int[]> testcases = new()
{
    { 3, new int[] { 1, 3, 1, 3, 2, 1, 3 } },
    { 2, new int[] { 2, 2, 2, 2, 2 } },
  //  { 3, new int[] { 1, 1, 1, 2, 4, 3 } },
    { 4, new int[] { 1, 3, 3, 3, 3, 2, 4 } }
};

foreach (var (X,A) in testcases)
{
    Console.WriteLine($"Test Case : X - {X} A - {String.Join(",",A)}");
    Console.WriteLine($"Minimum Time Required - {Solution.solution(X,A)}");
}
