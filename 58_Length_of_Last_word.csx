/*
https://leetcode.com/problems/length-of-last-word/description/?envType=study-plan-v2&envId=top-interview-150
Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal 
substring
 consisting of non-space characters only.

 

Example 1:

Input: s = "Hello World"
Output: 5
Explanation: The last word is "World" with length 5.
Example 2:

Input: s = "   fly me   to   the moon  "
Output: 4
Explanation: The last word is "moon" with length 4.
Example 3:

Input: s = "luffy is still joyboy"
Output: 6
Explanation: The last word is "joyboy" with length 6.
 

Constraints:

1 <= s.length <= 104
s consists of only English letters and spaces ' '.
There will be at least one word in s.

*/

public static class Solution {
    public static int LengthOfLastWord(string s) {
        string[] words = s.Split(' ');
        var result = 
        (from word in words 
        where word != String.Empty
        select word)
        .LastOrDefault();
        return result.Length;
        
    }
}

List<string> testcases = new()
{
    "Hello World",
    "   fly me   to   the moon  ",
    "luffy is still joyboy"
};

foreach (var _case in testcases)
{
    Console.WriteLine($"String {_case} : Result - {Solution.LengthOfLastWord(_case)}");
}