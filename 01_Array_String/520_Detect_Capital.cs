/*
We define the usage of capitals in a word to be right when one of the following cases holds:

All letters in this word are capitals, like "USA".
All letters in this word are not capitals, like "leetcode".
Only the first letter in this word is capital, like "Google".
Given a string word, return true if the usage of capitals in it is right.

 
Example 1:
Input: word = "USA"
Output: true

Example 2:
Input: word = "FlaG"
Output: false

 
Constraints:
1 <= word.length <= 100
word consists of lowercase and uppercase English letters.
*/

// TODO: Implement solution


List<string> testcases = [
    "USA",
    "FlaG",
    "leetcode",
    "Google"
];

foreach (var word in testcases)
{
    Console.WriteLine($"Testcase: word-{word}");
    Console.WriteLine($"DetectCapitalUse - {DetectCapitalUse(word)}");
}

bool DetectCapitalUse(string word)
{
    var firstChar = word[0];
    if (Char.IsLower(firstChar))
    {
        return DetectCase(word, 1, Cases.Lower);
    }
    else
    {
        if (word.Length > 1)
        {
            if (Char.IsLower(word[1]))
            {
                return DetectCase(word, 1, Cases.Lower);
            }
            else
            {
                return DetectCase(word, 1, Cases.Upper);
            }
        }

    }
    return true;

}
bool DetectCase(string word, int startIndex, Cases caseEnum)
{
    switch (caseEnum)
    {
        case Cases.Lower:
            for (int i = startIndex; i < word.Length; i++)
            {
                if (word[i] < 97)
                    return false;
            }
            break;
        case Cases.Upper:
            for (int i = startIndex; i < word.Length; i++)
            {
                if (word[i] >= 97)
                    return false;
            }
            break;
    }
    return true;
}


enum Cases
{
    Upper,
    Lower
};





