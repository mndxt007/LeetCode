/*
Given a string s, reverse only all the vowels in the string and return it.
The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower and upper cases, more than once.

Example 1:
Input: s= "hello"
Output: "holle"
Example 2:

Input: s= "AEIOU"
Output: "UOIEA"
Example 3:

Input: s= "DesignGUrus"
Output: "DusUgnGires"
Constraints:

1 <= s.length <= 3 * 105
s consist of printable ASCII characters.
*/


public string ReverseVowels(string s) {
    // TODO: Write your code here
     HashSet<char> vowels = ['a','e','i','o','u','A','E','I','O','U'];
     Stack<char> stack = new();
     for(int i=0;i<s.Length;i++)
     {
      if(vowels.Contains(s[i]))
      {
        stack.Push(s[i]);
      }
     }
     StringBuilder sb = new();
     for(int i=0;i<s.Length;i++)
     {
      if(vowels.Contains(s[i]))
      {
        sb.Append(stack.Pop());
        continue;
      }
      sb.Append(s[i]);
     }
    return sb.ToString(); 
  }

  List<string> testcases = [
    "hello",
    "AEIOU",
    "DesignGUrus"
  ];

  foreach (var testcase in testcases)
  {
    Console.WriteLine($"Testcase - {testcase}");
    Console.WriteLine($"Vowel oReversed - {ReverseVowels(testcase)}");
  }