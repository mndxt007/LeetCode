/*
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

Example 1:

Input: sentence = "A man, a plan, a canal, Panama!"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.
Example 2:

Input: sentence = "Was it a car or a cat I saw?"
Output: true
Explanation: Explanation: "wasitacaroracatisaw" is a palindrome.
Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
*/

public bool IsPalindrome(string s) {
        // ToDo: Write Your Code Here.
        int left=0;
        int right = s.Length-1;

        while(right > left && left < s.Length && right >= 0 )
        {
            //get the alphanumeric char at left
            while(right > left &&  left < s.Length && !Char.IsAsciiLetterOrDigit(s[left]))
            {
                left++;
            }
            //get the alphanumeric char at right
            while(right > left && right >= 0 && !Char.IsAsciiLetterOrDigit(s[right]) )
            {
                right--;
            }
            //Compare when I have alphanumeric char at both ends
            if(Char.ToLower(s[left])!=Char.ToLower(s[right]))
            {
                return false;
            }
            left++; right--;
        }
        return true;  
    }

 List<string> testcases = [
    "A man, a plan, a canal, Panama!",
    "Was it a car or a cat I saw?",
    "Hello Where are you"
  ];

  foreach (var testcase in testcases)
  {
    Console.WriteLine($"Testcase - {testcase}");
    Console.WriteLine($"Vowel oReversed - {IsPalindrome(testcase)}");
  }