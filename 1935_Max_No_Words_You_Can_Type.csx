/*
https://leetcode.com/problems/maximum-number-of-words-you-can-type/description/

There is a malfunctioning keyboard where some letter keys do not work. All other keys on the keyboard work properly.

Given a string text of words separated by a single space (no leading or trailing spaces) and a string brokenLetters of all distinct letter keys that are broken, return the number of words in text you can fully type using this keyboard.

 

Example 1:

Input: text = "hello world", brokenLetters = "ad"
Output: 1
Explanation: We cannot type "world" because the 'd' key is broken.
Example 2:

Input: text = "leet code", brokenLetters = "lt"
Output: 1
Explanation: We cannot type "leet" because the 'l' and 't' keys are broken.
Example 3:

Input: text = "leet code", brokenLetters = "e"
Output: 0
Explanation: We cannot type either word because the 'e' key is broken.
 

Constraints:

1 <= text.length <= 104
0 <= brokenLetters.length <= 26
text consists of words separated by a single space without any leading or trailing spaces.
Each word only consists of lowercase English letters.
brokenLetters consists of distinct lowercase English letters.
*/

public static class Solution {
    public static int CanBeTypedWords(string text, string brokenLetters) {
        bool containBrokenLetter;
        int count = 0;
        foreach(string word in text.Split(' '))
        {
            containBrokenLetter = word.All(x =>
                !brokenLetters.Contains(x)
            );
            if(containBrokenLetter)
            {
                count++;
            }

        }
        return count;
    }

    public static bool Check(char x)
    {
        Console.WriteLine(x);
        return false;
    }
}

Dictionary<string,string> testcases = new()
{
    {"hello world","ad"},
    {"leet code","lt"}
};

foreach (var (text,brokenLetters) in testcases)
{
    Console.WriteLine($"text - {text} || brokenLetters - {brokenLetters}");
    Console.WriteLine($"Can be typed - {Solution.CanBeTypedWords(text,brokenLetters)}");
}



