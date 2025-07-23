/*
Given two strings s and t, return true if t is an anagram of s, and false otherwise.

Example 1:
Input: s = "anagram", t = "nagaram"
Output: true

Example 2:
Input: s = "rat", t = "car"
Output: false

Constraints:
1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
*/

public bool IsAnagram(string s, string t)
{
    if (s.Length != t.Length)
        return false;
    Dictionary<char, int> sMap = [];
    Dictionary<char, int> tMap = [];
    for (int i = 0; i < s.Length; i++)
    {
        if(sMap.ContainsKey(s[i]))
        {
            sMap[s[i]]++;
        }
        else
        {
            sMap.Add(s[i], 1);
        }
        if(tMap.ContainsKey(t[i]))
        {
            tMap[t[i]]++;
        }
        else
        {
            tMap.Add(t[i], 1);
        }
    }
    foreach (var (sKey,sValue) in sMap)
    {
        if(tMap.TryGetValue(sKey, out int tValue))
        {
            if(sValue!=tValue)
                return false;
            continue;
        }
        return false;
    }
    return true;

}

List<(string s, string t)> testcases = [
    ("anagram", "nagaram"),
    ("rat", "car")
];

foreach (var (s, t) in testcases)
{
    Console.WriteLine($"Testcase: s-{s} t-{t}");
    Console.WriteLine($"IsAnagram - {IsAnagram(s, t)}");
}
