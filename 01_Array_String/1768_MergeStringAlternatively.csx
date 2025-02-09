/*
https://leetcode.com/problems/merge-strings-alternately/description/?envType=study-plan-v2&envId=leetcode-75
You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1. If a string is longer than the other, append the additional letters onto the end of the merged string.

Return the merged string.

 

Example 1:

Input: word1 = "abc", word2 = "pqr"
Output: "apbqcr"
Explanation: The merged string will be merged as so:
word1:  a   b   c
word2:    p   q   r
merged: a p b q c r
Example 2:

Input: word1 = "ab", word2 = "pqrs"
Output: "apbqrs"
Explanation: Notice that as word2 is longer, "rs" is appended to the end.
word1:  a   b 
word2:    p   q   r   s
merged: a p b q   r   s
Example 3:

Input: word1 = "abcd", word2 = "pq"
Output: "apbqcd"
Explanation: Notice that as word1 is longer, "cd" is appended to the end.
word1:  a   b   c   d
word2:    p   q 
merged: a p b q c   d
*/


public static class Solution
{
    public static string MergeAlternately(string word1, string word2)
    {
        StringBuilder merged = new StringBuilder();
        int max = Math.Max(word1.Length, word2.Length);
        for (int i = 0; i < max; i++)
        {
            if (i >= word1.Length)
                merged.Append(word2[i]);
            else if (i >= word2.Length)
            {
                merged.Append(word1[i]);
            }
            else{
                merged.Append(word1[i]);
                merged.Append(word2[i]);
            }
        }
        return merged.ToString();
    }
}

Dictionary<string, string> testcases = new()
{
    {"abc",  "pqr"},
    {"ab",  "pqr"},
    {"abcd",  "pq"},

};

foreach (var (word1, word2) in testcases)
{
    Console.WriteLine($"Word1 - {word1} , word2 - {word2} : Result - {Solution.MergeAlternately(word1, word2)}");
}





