/*
Given a string s and an integer k, return the maximum number of vowel letters in any substring of s with length k.

Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.

 

Example 1:

Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.
Example 2:

Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.
Example 3:

Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.
*/
public int MaxVowels(string s, int k)
{
    var vowels = "aeiou";
    int maxVowels = 0;
    int windowVowels = 0;
    if(k > s.Length)
        return 0;
    //calculate initial number of vowels.
    foreach (var item in s[..k])
    {
        if(vowels.Contains(item))
            maxVowels++;
    }
    windowVowels = maxVowels;
    for (int i = 1; i < s.Length - k; i++)
    {
        windowVowels = windowVowels - (vowels.Contains(s[i-1])?1:0) + (vowels.Contains(s[i-1+k])?1:0);
        maxVowels = Math.Max(windowVowels,maxVowels);
    }


    return maxVowels;
}

public record TestCase
{
    public string s;
    public int k;
}

List<TestCase> testcases = new()
{
    new(){s="leetcode",k=3},
    new(){s="aeiou",k=2},
    new(){s="abciiidef",k=3},
    new(){s="zpuerktejfp",k=3}
    
};


foreach (var item in testcases)
{
    Console.WriteLine($"Test Case -> s = {item.s} \t k = {item.k}");
    Console.WriteLine($"Max Vowels - {MaxVowels(item.s,item.k)}");
}