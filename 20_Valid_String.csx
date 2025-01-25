/*
https://leetcode.com/problems/valid-parentheses/?envType=study-plan-v2&envId=top-interview-150

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 
Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "()[]{}"
Output: true

Example 3:
Input: s = "(]"
Output: false

Example 4:
Input: s = "([])"
Output: true

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'.
*/

public bool IsValid(string s)
{
    if (s.Length % 2 == 1)
    {
        return false;
    }
    Stack<char> stack = new();
    char parentheses;
    for (int i = 0; i < s.Length - 1; i++)
    {
        parentheses = s[i];
        switch (parentheses)
        {
            case '(':
            case '[':
            case '{':
                stack.Push(parentheses);
                break;
            case ')':
                if (stack.Count > 0 && stack.Pop() != '(')
                {
                    return false;
                }
                break;
            case ']':
                if (stack.Count > 0 &&  stack.Pop() != '[')
                {
                    return false;
                }
                break;
            case '}':
                if (stack.Count > 0 && stack.Pop() != '{')
                {
                    return false;
                }
                break;

        }
    }
    switch (s[^1])
    {
        case '(':
        case '[':
        case '{':
            return false;
        case ')':
                if (stack.Count > 0 && stack.Pop() != '(')
                {
                    return false;
                }
                break;
            case ']':
                if (stack.Count > 0 && stack.Pop() != '[')
                {
                    return false;
                }
                break;
            case '}':
                if (stack.Count > 0 && stack.Pop() != '{')
                {
                    return false;
                }
                break;
        
    }
    return true;
}


List<string> testcases = [
    "()",
    "()[]{}",
    "(]",
    "([])",
    "((",
    "){"
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"TestCase - {testcase}");
    Console.WriteLine($"IsValid? - {IsValid(testcase)}");
}