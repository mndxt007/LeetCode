/*
Given an array of characters chars, compress it using the following algorithm:

Begin with an empty string s. For each group of consecutive repeating characters in chars:

If the group's length is 1, append the character to s.
Otherwise, append the character followed by the group's length.
The compressed string s should not be returned separately, but instead, be stored in the input character array chars. Note that group lengths that are 10 or longer will be split into multiple characters in chars.

After you are done modifying the input array, return the new length of the array.

You must write an algorithm that uses only constant extra space.

 

Example 1:

Input: chars = ["a","a","b","b","c","c","c"]
Output: Return 6, and the first 6 characters of the input array should be: ["a","2","b","2","c","3"]
Explanation: The groups are "aa", "bb", and "ccc". This compresses to "a2b2c3".
Example 2:

Input: chars = ["a"]
Output: Return 1, and the first character of the input array should be: ["a"]
Explanation: The only group is "a", which remains uncompressed since it's a single character.
Example 3:

Input: chars = ["a","b","b","b","b","b","b","b","b","b","b","b","b"]
Output: Return 4, and the first 4 characters of the input array should be: ["a","b","1","2"].
Explanation: The groups are "a" and "bbbbbbbbbbbb". This compresses to "ab12".
 

Constraints:

1 <= chars.length <= 2000
chars[i] is a lowercase English letter, uppercase English letter, digit, or symbol.
*/

using System.Net.WebSockets;

public static class Solution
{
    public static int Compress(char[] chars)
    {
        Dictionary<char, int> dict = new();
        foreach (var items in chars)
        {
            if (dict.TryGetValue(items, out int value))
            {
                dict[items] = value + 1;
            }
            else
            {
                dict.Add(items, value + 1);
            }

        }
        int i = 0;
        string valuestr;
        if (dict.Count == 1)
            return 1;
        foreach (var (key, value) in dict)
        {
            chars[i++] = key;
            if (value > 1 && value < 10)
                chars[i++] = (char)(value  + '0');
            else if(value > 10)
            {
                valuestr = value.ToString();
                foreach (char c in valuestr)
                {
                    chars[i++] = c;
                }
            }

        }
        Console.WriteLine($"Converted Char - {String.Join(' ', chars)}");
        return i;

    }
}


List<char[]> testcases = new(){
new char[] {'a','a','b','b','c','c','c'},
new char[] {'a'},
new char[] {'a','b','b','b','b','b','b','b','b','b','b','b','b'},

};
// for (int i = 0; i < 300; i++)
// {
//     char val = (char)(i);
//     Console.WriteLine(val);
// }

foreach (var _case in testcases)
{
    Console.WriteLine($"String {String.Join(' ', _case)} : Result - {Solution.Compress(_case)}");
}