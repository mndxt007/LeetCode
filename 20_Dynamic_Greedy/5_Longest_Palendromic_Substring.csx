/*
Given a string s, return the longest palindromic substring in s.
 
Example 1:
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.

Example 2:
Input: s = "cbbd"
Output: "bb"

 
Constraints:
1 <= s.length <= 1000
s consist of only digits and English letters.
*/

public string LongestPalindrome(string s)
{
    string result = String.Empty;
    for (int i = 0; i < s.Length; i++)
    {
        //Check Palidromes that are odd
        CheckPalindromes(s, i, i, ref result);
        //Check Palidromes that are even
        CheckPalindromes(s, i, i + 1, ref result);
    }
    return result;
}

void CheckPalindromes(string s, int left, int right, ref string result)
{
    int length = s.Length;
    while 
    (
        left >= 0 &&
        right < length &&
        s[left] == s[right]
    )
    {
        var palindrome = s[left..(right+1)];
        if(palindrome.Length > result.Length)
        {
            result = palindrome;
        }
        left--; right++;
    }
}

List<string> testcases = [
    "babad",
    "cbbd"
];

foreach (var s in testcases)
{
    Console.WriteLine($"Testcase: s-{s}");
    Console.WriteLine($"LongestPalindrome - {LongestPalindrome(s)}");
}
