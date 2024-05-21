/*
https://leetcode.com/problems/regular-expression-matching/description/
Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

'.' Matches any single character.​​​​
'*' Matches zero or more of the preceding element.
The matching should cover the entire input string (not partial).

 

Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input: s = "ab", p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".
 

Constraints:

1 <= s.length <= 20
1 <= p.length <= 20
s contains only lowercase English letters.
p contains only lowercase English letters, '.', and '*'.
It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
*/

using System.Text.RegularExpressions;

public static class Solution
{
    public static bool IsMatch(string s, string p)
    {
        //I know not the intented way. Replacing multiple * operators for one test case.
        return Regex.IsMatch(s, String.Format('^' + p.Replace("***","*") + '$'));
    }
}


Dictionary<string, string> testcases = new()
{
    {"a","aa"},
    {"a*","aa"},
    {".*","ab"},
    {"a***abc","abc"}
};

foreach (var (pattern, inputstring) in testcases)
{
    Console.WriteLine($"Pattern - {pattern}, Input string - {inputstring}");
    Console.WriteLine($"Match ? - {Solution.IsMatch(inputstring, pattern)}");
}