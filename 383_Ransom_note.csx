/*
https://leetcode.com/problems/ransom-note/description/?envType=study-plan-v2&envId=top-interview-150
Given two strings ransomNote and magazine, return true if ransomNote can be constructed by using the letters from magazine and false otherwise.

Each letter in magazine can only be used once in ransomNote.

Example 1:

Input: ransomNote = "a", magazine = "b"
Output: false
Example 2:

Input: ransomNote = "aa", magazine = "ab"
Output: false
Example 3:

Input: ransomNote = "aa", magazine = "aab"
Output: true
 

Constraints:

1 <= ransomNote.length, magazine.length <= 105
ransomNote and magazine consist of lowercase English letters.
*/

public bool CanConstruct(string ransomNote, string magazine)
{
    Dictionary<char,int> hash = new();
    foreach (var item in magazine)
    {
        if(hash.TryGetValue(item,out var count))
        {
            hash[item]++;
        }
        else
        {
            hash.Add(item,1);
        }
    }
    foreach (var item in ransomNote)
    {
        if(hash.TryGetValue(item,out var count))
        {
            if(hash[item]>0)
            {
                hash[item]--;
            }
            else
            {
                return false;
            }
            
        }
        else
        {
          return false;  
        }
    }
    return true;
}


List<string[]> testcases = [
   ["a","b"],
   ["aa","ab"],
   ["aa","aab"]
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"ransomNote - {testcase[0]} , magzine - {testcase[1]}");
    Console.WriteLine($"CanConstruct? - {CanConstruct(testcase[0],testcase[1])}");
}
