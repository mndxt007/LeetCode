/*
https://app.codility.com/programmers/lessons/1-iterations/binary_gap/
Find longest sequence of zeros in binary representation of an integer.
*/

using System;
using System.Text.RegularExpressions;
using System.Linq;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

static class Solution {
    static public int solution(int N) {
        // Implement your solution here
        string input = Convert.ToString(N,2);
        string pattern = @"(?<=1)(0+)(?=1)";
        MatchCollection matches = Regex.Matches(input, pattern);
        int highest = 0;
        foreach(Match match in matches)
        {
            //Console.WriteLine($"Match - {match.Value}");
            if(highest < match.Value.Length)
                highest = match.Value.Length;
        }
        return highest;
    }
}

List<int> testcases = new()
{
    1041,
    15,
    32,
    1153,
};

foreach (int case_ in testcases)
{
    Console.WriteLine($"Test Case - {case_}, In Binary - {Convert.ToString(case_,2)}");
    Console.WriteLine($"Binary Difference - {Solution.solution(case_)}");
}