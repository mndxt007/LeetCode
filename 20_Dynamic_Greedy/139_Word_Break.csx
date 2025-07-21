/*
Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.

Note that the same word in the dictionary may be reused multiple times in the segmentation.
Example 1:
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.

Example 3:
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
 

Constraints:

1 <= s.length <= 300
1 <= wordDict.length <= 1000
1 <= wordDict[i].length <= 20
s and wordDict[i] consist of only lowercase English letters.
All the strings of wordDict are unique.
*/


public bool WordBreak(string s, IList<string> wordDict)
{
    var sSpan = s.AsSpan();
    var dp = new bool[sSpan.Length+1];
    dp[^1] = true;

    for (int i = sSpan.Length - 1; i >= 0; i--)
    {
        foreach (var word in wordDict)
        {
            var wordSpan = word.AsSpan();
            if (i + wordSpan.Length <= sSpan.Length &&
                sSpan.Slice(i, wordSpan.Length).SequenceEqual(wordSpan))
            {
                dp[i] = dp[i + wordSpan.Length];
                if (dp[i]) break;
            }
        }
    }
    return dp[0];
}


List<(string s, string[] wordDict)> testcases = [
    ("leetcode",["leet","code"]),
    ("applepenapple", ["apple","pen"]),
    ("catsandog",["cats","dog","sand","and","cat"])
];

foreach (var (s,wordDict) in testcases)
{
    Console.WriteLine($"Testcase: s-{s} wordDict-{String.Join(',', wordDict)}");
    Console.WriteLine($"WordBreak - {WordBreak(s, wordDict)}");
}