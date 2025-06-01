/*
Given a pattern and a string s, find if s follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in s. Specifically:

Each letter in pattern maps to exactly one unique word in s.
Each unique word in s maps to exactly one letter in pattern.
No two letters map to the same word, and no two words map to the same letter.
 

Example 1:
Input: pattern = "abba", s = "dog cat cat dog"
Output: true
Explanation:
The bijection can be established as:

'a' maps to "dog".
'b' maps to "cat".

Example 2:
Input: pattern = "abba", s = "dog cat cat fish"
Output: false

Example 3:
Input: pattern = "aaaa", s = "dog cat cat dog"
Output: false

 

Constraints:

1 <= pattern.length <= 300
pattern contains only lower-case English letters.
1 <= s.length <= 3000
s contains only lowercase English letters and spaces ' '.
s does not contain any leading or trailing spaces.
All the words in s are separated by a single space.
*/

public bool WordPattern(string pattern, string s)
{
    string[] dict = new string[256];
    
    //capture lenghts 
    var words = s.Split(" ");
    if(pattern.Length != words.Length)
        return false;
    for (int i = 0; i < pattern.Length;i++)
    {
        if(String.IsNullOrEmpty(dict[pattern[i]]))
        {
            dict[pattern[i]] = words[i];
            continue;
        }
        if(dict[pattern[i]] != words[i])
            return false;
    }

    return true;
}

List<(string, string)> testcases = new List<(string, string)>
{
    {("abba","dog cat cat dog")},
    {("abba", "dog cat cat fish")},
    {("aaaa","dog cat cat dog")}
};

foreach(var (pattern,s) in testcases)
{
    Console.WriteLine((pattern, s));
    Console.WriteLine($"WordPattern - {WordPattern(pattern, s)}");
}

