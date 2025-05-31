/*
Given two strings s and t, return true if t is an anagram of s, and false otherwise.
An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.

Example 1:

Input: s = "listen", t = "silent"
Output: true
Example 2:

Input: s = "rat", t = "car"
Output: false
Example 3:

Input: s = "hello", t = "world"
Output: false
Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
*/

public bool IsAnagram(string s, string t) {
      // TODO: Write your code here
      if(s.Length != t.Length) return false;
      Dictionary<char,int> occurs = new();
      for (int i = 0; i < s.Length; i++)
      {
        if(occurs.ContainsKey(s[i]))
        {
            occurs[s[i]]++;
            continue;
        }
        occurs.Add(s[i],1);
      }
      for (int i = 0; i < t.Length; i++)
      {
        if(!occurs.ContainsKey(t[i]))
        {
            return false;
        }
        if(!(occurs[t[i]]>0))
        {
            return false;
        }
        occurs[t[i]]--;
      }
      return true;
    }

List<(string,string)> testcases = [
    ("listen","silent"),
    ("rat","cat"),
    ("hello","world")
];

foreach (var (s,t) in testcases)
{
    Console.WriteLine($"s-{s} t-{t}");
    Console.WriteLine($"Valid Anagram - {IsAnagram(s,t)}");
}