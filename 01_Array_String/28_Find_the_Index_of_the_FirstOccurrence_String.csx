/*
https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/description/

Given two strings needle and haystack, return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.

Example 1:

Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
Example 2:

Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
 

Constraints:

1 <= haystack.length, needle.length <= 104
haystack and needle consist of only lowercase English characters.
*/

public static class Solution {
    public static int StrStr(string haystack, string needle) {
        int j=0,k=0;
        for (int i = 0; i < haystack.Length-needle.Length+1; i++)
        {
            j=i;
            while(k<needle.Length && j<haystack.Length)
            {
                if(haystack[j]!=needle[k])
                {
                    break;
                }
                k++;j++;
            }
            if(k>=needle.Length)
            {
                return i;
            }
            k=0;
        }
        return -1;
        
    }
}

Dictionary<string, string> testcases = new()
{
    //  {"sadbutsad",  "sad"},
    //  {"leetcode",  "leeto"},
    // {"a", "a"},
    {"mississippi", "issip"}

};

foreach (var (haystack, needle) in testcases)
{
    Console.WriteLine($"haystack - {haystack} , needle - {needle} : Result - {Solution.StrStr(haystack, needle)}");
}