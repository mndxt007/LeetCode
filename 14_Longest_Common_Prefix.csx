/*
Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

 

Example 1:

Input: strs = ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
 

Constraints:

1 <= strs.length <= 200
0 <= strs[i].length <= 200
strs[i] consists of only lowercase English letters.
*/

public static class Solution {
    public static string LongestCommonPrefix(string[] strs) {
        //Brute force
        int count;
        int match=0;
        //step 1 - find the smallest word
        string smallest = strs.OrderBy(x => x.Length).FirstOrDefault();
        for(int i=1; i <= smallest.Length ; i++)
        {
            count = strs.Count(
                g => g.StartsWith(smallest[..i])
            );
            if(count==strs.Length)
            {
                match = i;
            }
            else
                break;
        }

        //step 2 - use LINQ slice the string and find out the prefix present in all words.
        if (match > 0)
            return smallest[..match];
        return String.Empty;
    }
}

List<string[]> testcases = new(){
new string[] {"flower","flow","flight"},
new string[] {"dog","racecar","car"},
};

foreach (var item in testcases)
{
  Console.WriteLine($"Testcase - {String.Join(' ',item)}") ;
  Console.WriteLine($"Result - {Solution.LongestCommonPrefix(item)}");
}

