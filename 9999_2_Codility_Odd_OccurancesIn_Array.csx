/*
https://app.codility.com/programmers/lessons/2-arrays/odd_occurrences_in_array/
*/

using System;
using System.Linq;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

static class Solution {
    public static int solution(int[] A) {
        // Implement your solution here
        // return A.Where(
        //     x => A.Count(i => i==x) == 1
        // ).FirstOrDefault();
        Dictionary<int,int> dict = new Dictionary<int,int>();
        int count = 1;
        for (int i=0; i<A.Length;i++)
        {
            if(dict.TryGetValue(A[i],out count))
            {
                //Console.WriteLine($" Found value - A[i] - {A[i]} count - {count} dict[A[i]] - {dict[A[i]]}");
                dict[A[i]]++;

            }
            else
            {
                dict.Add(A[i],1);
            }
             //Console.WriteLine($" After the loop - A[i] - {A[i]} count - {count} dict[A[i]] - {dict[A[i]]}");
        }
        //Console.WriteLine($"Dict - {String.Join(',',dict.Select( item => item.ToString()))}");
        return dict.Where(
            item => (item.Value % 2) == 1
        ).FirstOrDefault().Key;
    }
}

List<int[]> testcases = new()
{
    new int[] {9,3,9,3,9,7,9},
    new int[] {5,5,5,5,3,3,3}
};

foreach (var case_ in testcases)
{
    Console.WriteLine($"Test case - {String.Join(',',case_)}");
    Console.WriteLine($"Odd occurence - {Solution.solution(case_)}");
}

