public static class Solution {
    public static int StrStr(string haystack, string needle) {
        int j=0,k=0;
        for (int i = 0; i < haystack.Length-needle.Length+1; i++)
        {
            j=i;
            while(k<needle.Length && j<haystack.Length)
            {
                if(haystack[j]!=needle[k])
                {
                    break;
                }
                k++;j++;
            }
            if(k>=needle.Length)
            {
                return i;
            }
        }
        return -1;
        
    }
}

Dictionary<string, string> testcases = new()
{
     {"sadbutsad",  "sad"},
     {"leetcode",  "leeto"},
    {"a", "a"}

};

foreach (var (haystack, needle) in testcases)
{
    Console.WriteLine($"haystack - {haystack} , needle - {needle} : Result - {Solution.StrStr(haystack, needle)}");
}