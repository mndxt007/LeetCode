/*
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
Given a string s, return true if it is a palindrome, or false otherwise.


Example 1:
Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

Example 2:
Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.

Example 3:
Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.

Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
*/

using System.Collections;

public bool IsPalindrome(string s) 
{
    int i=0;
    int j=s.Length-1;

    while(i<j)
    {
        while(!Char.IsAsciiLetterOrDigit(s[i]) && i<j)
        {
            i++;
        }
        while(!Char.IsAsciiLetterOrDigit(s[j]) && i<j)
        {
            j--;
        }
        if(Char.ToLower(s[i])!=Char.ToLower(s[j]))
        {
            return false;
        }
        i++;
        j--;

    }
    return true;
}

List<string> testcases = [
    "A man, a plan, a canal: Panama",
    "race a car",
    " ",
    "gadag",
    "0P",
    ".,"
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"testcase - {testcase}");
    Console.WriteLine($"IsPalindrome? - {IsPalindrome(testcase)}");
}