/*
Given an array of strings words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.
You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.
Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line does not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
For the last line of text, it should be left-justified, and no extra space is inserted between words.

Note:

A word is defined as a character sequence consisting of non-space characters only.
Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
The input array words contains at least one word.
 

Example 1:

Input: words = ["This", "is", "an", "example", "of", "text", "justification."], maxWidth = 16
Output:
[
   "This    is    an",
   "example  of text",
   "justification.  "
]

Example 2:

Input: words = ["What","must","be","acknowledgment","shall","be"], maxWidth = 16
Output:
[
  "What   must   be",
  "acknowledgment  ",
  "shall be        "
]
Explanation: Note that the last line is "shall be    " instead of "shall     be", because the last line must be left-justified instead of fully-justified.
Note that the second line is also left-justified because it contains only one word.

Example 3:

Input: words = ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"], maxWidth = 20
Output:
[
  "Science  is  what we",
  "understand      well",
  "enough to explain to",
  "a  computer.  Art is",
  "everything  else  we",
  "do                  "
]
 

Constraints:

1 <= words.length <= 300
1 <= words[i].length <= 20
words[i] consists of only English letters and symbols.
1 <= maxWidth <= 100
words[i].length <= maxWidth
*/


public static IList<string> FullJustify(string[] words, int maxWidth)
{
    List<string> justifiedLines = new();
    int left = 0;

    while (left < words.Length)
    {
        int right = left;
        int lineLength = 0;

        // Try to fit as many words as possible in the line
        while (right < words.Length && lineLength + words[right].Length + (right - left) <= maxWidth)
        {
            lineLength += words[right].Length;
            right++;
        }

        int wordCount = right - left;
        int gapCount = wordCount - 1;
        int totalSpaces = maxWidth - lineLength;

        // Get the current slice of words as Span
        ReadOnlySpan<string> lineWords = new ReadOnlySpan<string>(words, left, wordCount);

        // Last line or single word: left-justify
        if (right == words.Length || wordCount == 1)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < wordCount; i++)
            {
                sb.Append(lineWords[i]);
                if (i < wordCount - 1)
                    sb.Append(' ');
            }
            sb.Append(' ', maxWidth - sb.Length);
            justifiedLines.Add(sb.ToString());
        }
        else
        {
            int spacePerGap = totalSpaces / gapCount;
            int extraSpaces = totalSpaces % gapCount;

            var sb = new StringBuilder();
            for (int i = 0; i < wordCount; i++)
            {
                sb.Append(lineWords[i]);
                if (i < gapCount)
                {
                    int spacesToInsert = spacePerGap + (i < extraSpaces ? 1 : 0);
                    sb.Append(' ', spacesToInsert);
                }
            }
            justifiedLines.Add(sb.ToString());
        }

        left = right;
    }

    return justifiedLines;
}

List<(string[],int)> testcases = [
 (["This", "is", "an", "example", "of", "text", "justification."],16),
 (["What","must","be","acknowledgment","shall","be"],16),
 (["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"],20)
];

foreach (var (words,maxWidth) in testcases)
{
    Console.WriteLine($"Test Case - '{(String.Join(',',words),maxWidth)}'");
    Console.WriteLine("Justified -\n[\n  " + 
    string.Join(",\n  ", FullJustify(words, maxWidth).Select(line => $"\"{line}\"")) + 
    "\n]");
}