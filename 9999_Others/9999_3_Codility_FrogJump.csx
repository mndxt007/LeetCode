//https://app.codility.com/programmers/lessons/3-time_complexity/frog_jmp/

using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

public class Solution {
    public static int solution(int X, int Y, int D) {
        // Implement your solution here
         int remainingdist = Y-X;
        if (remainingdist==0)
        {
            return 0;
        }
        else
        {
            if(remainingdist%D==0)
            {
                return remainingdist/D;
            }
            else
            {
                return(remainingdist/D) + 1;
            }
        }
    }
}

List<int[]> testcases = new()
{
    new int[] {10,85,30},
    new int[] {1,5,2},
    new int[] {5,5,10}
};

foreach (var case_ in testcases)
{
    Console.WriteLine($"Test case - {String.Join(',',case_)}");
    Console.WriteLine($"Number of steps - {Solution.solution(case_[0],case_[1],case_[2])}");
}