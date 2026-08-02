/*
Given two strings s and goal, return true if and only if s can become goal after some number of shifts on s.

A shift on s consists of moving the leftmost character of s to the rightmost position.

For example, if s = "abcde", then it will be "bcdea" after one shift.

Example 1:
Input: s = "abcde", goal = "cdeab"
Output: true

Example 2:
Input: s = "abcde", goal = "abced"
Output: false

Constraints:
1 <= s.length, goal.length <= 100
s and goal consist of lowercase English letters.
*/

// TODO: Implement solution
bool RotateString(string s, string goal)
{
    return s.Length == goal.Length && (goal + goal).Contains(s, StringComparison.Ordinal);

}


List<(string s, string goal)> testcases = [
    ("abcde", "cdeab"),
    ("abcde", "abced"),
    ("w", "w"),
    ("yn","xi")
];

foreach (var (s, goal) in testcases)
{
    Console.WriteLine($"Testcase: s-{s} goal-{goal}");
    Console.WriteLine($"RotateString - {RotateString(s, goal)}");
}
