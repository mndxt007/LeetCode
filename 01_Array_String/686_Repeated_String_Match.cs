/*
Given two strings a and b, return the minimum number of times you should repeat string a so that string b is a substring of it.
If it is impossible for b to be a substring of a after repeating it, return -1.

Notice: string "abc" repeated 0 times is "", repeated 1 time is "abc" and repeated 2 times is "abcabc".

Example 1:
Input: a = "abcd", b = "cdabcdab"
Output: 3
Explanation: We return 3 because by repeating a three times "abcdabcdabcd", b is a substring of it.

Example 2:
Input: a = "a", b = "aa"
Output: 2

Constraints:
1 <= a.length, b.length <= 10^4
a and b consist of lowercase English letters.
*/

// TODO: Implement solution
int RepeatedStringMatch(string a, string b)
{
     if(String.IsNullOrEmpty(b))
        return 0;
    if(a.Contains(b))
        return 1;
    int maxRepeats = (b.Length / a.Length) + 2;
    Span<char> repeats = stackalloc char[a.Length*maxRepeats];
    FillSpan(repeats,a,0);
    for(int i=1; i<maxRepeats;i++)
    {
        FillSpan(repeats,a,i*a.Length);
        if(repeats.IndexOf(b) > -1)
            return i+1;
    }

    return -1;
}

void FillSpan(Span<char> charSpan,string a,int start)
{
    for(int i=0; i<a.Length;i++)
    {
        charSpan[i+start] = a[i];
    }
}

List<(string a, string b)> testcases = [
    ("abcd", "cdabcdab"),
    ("a", "aa"),
    ("abc", "cabcabca")
];

foreach (var (a, b) in testcases)
{
    Console.WriteLine($"Testcase: a-{a} b-{b}");
    Console.WriteLine($"RepeatedStringMatch - {RepeatedStringMatch(a, b)}");
}