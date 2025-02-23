/*
Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.
A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

Example 1:
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

Example 2:
Input: digits = ""
Output: []

Example 3:
Input: digits = "2"
Output: ["a","b","c"]

Constraints:
0 <= digits.length <= 4
digits[i] is a digit in the range ['2', '9'].
*/

using System.Globalization;

public static class Solution
{
     static Dictionary<char, string> map = new()
        {
            {'2',"abc"},
            {'3',"def"},
            {'4',"ghi"},
            {'5',"jkl"},
            {'6',"mno"},
            {'7',"pqrs"},
            {'8',"tuv"},
            {'9',"wxyz"},
        };
    private static void Solve(int index,List<string> result,string digits,string temp)
    {
        if(index==digits.Length)
        {
            result.Add(temp);
            return;
        }
        foreach (var alpha in map[digits[index]])
        {
            Solve(index+1, result, digits,temp+alpha);
        }
    }
    public static IList<string> LetterCombinations(string digits)
    {
        List<string> result = new();
        if (digits.Length == 0) 
            return result;
        Solve(0,result,digits,"");
        return result;

    }
}

List<string> testcases = [
    "23",
    "234",
    "",
    "2"
];

foreach (var cases in testcases)
{
    Console.WriteLine($"Test case - {cases}");
    Console.WriteLine($"Combinations - {String.Join(',', Solution.LetterCombinations(cases))}");
}