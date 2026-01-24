/*
Given an array of strings words and an integer k, return the k most frequent strings.

Return the answer sorted by the frequency from highest to lowest. Sort the words with the same frequency by their lexicographical order.

Example 1:

Input: words = ["i","love","leetcode","i","love","coding"], k = 2
Output: ["i","love"]
Explanation: "i" and "love" are the two most frequent words.
Note that "i" comes before "love" due to a lower alphabetical order.
Example 2:

Input: words = ["the","day","is","sunny","the","the","the","sunny","is","is"], k = 4
Output: ["the","is","sunny","day"]
Explanation: "the", "is", "sunny" and "day" are the four most frequent words, with the number of occurrence being 4, 3, 2 and 1 respectively.

Constraints:

1 <= words.length <= 500
1 <= words[i].length <= 10
words[i] consists of lowercase English letters.
k is in the range [1, The number of unique words[i]]

Follow-up: Could you solve it in O(n log(k)) time and O(n) extra space?
*/

//Leave space for implementation here

public class WordFreqComparer : IComparer<(string word,int freq)>
{
    public static readonly WordFreqComparer Instance = new();
    
    public int Compare((string word,int freq) a, (string word,int freq) b)
    {
        int freqCompare = b.freq.CompareTo(a.freq);
        return freqCompare != 0 ? freqCompare : a.word.CompareTo(b.word);
    }
}


 public IList<string> TopKFrequent(string[] words, int k) {
        var dict = new Dictionary<string,int>();
        //Count the words
        for(int i=0; i < words.Length;i++)
        {
            if(dict.ContainsKey(words[i]))
            {
                dict[words[i]]++;
                continue;
            }
            dict.Add(words[i],1);
        }
        //Heapify
        var pQueue = new PriorityQueue<string,(string word,int freq)>(WordFreqComparer.Instance);
        foreach (var (word,count) in dict)
        {
            pQueue.Enqueue(word,(word,count));
        }

        //Pull K items
        IList<string> result = new List<string>();
        for(int i=0; i<k;i++)
        {
            if(pQueue.Count>0)
            {
                result.Add(pQueue.Dequeue());
            }
        }
        return result;
    }


List<(string[] words, int k)> testcases = [
    (["i","love","leetcode","i","love","coding"], 2),
    (["the","day","is","sunny","the","the","the","sunny","is","is"], 4)
];

foreach (var (words,k) in testcases)
{
    Console.WriteLine($"Testcase: words-{String.Join(',', words)} k-{k}");
    var result = TopKFrequent(words, k);
    Console.WriteLine($"TopKFrequent - [{String.Join(',', result)}]");
    Console.WriteLine();
}
