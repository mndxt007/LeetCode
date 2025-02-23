/*
Given two integers n and k, return all possible combinations of k numbers chosen from the range [1, n].
You may return the answer in any order.

Example 1:
Input: n = 4, k = 2
Output: [[1,2],[1,3],[1,4],[2,3],[2,4],[3,4]]
Explanation: There are 4 choose 2 = 6 total combinations.
Note that combinations are unordered, i.e., [1,2] and [2,1] are considered to be the same combination.

Example 2:
Input: n = 1, k = 1
Output: [[1]]
Explanation: There is 1 choose 1 = 1 total combination.

Constraints:

1 <= n <= 20
1 <= k <= n
*/


public static class Solution {
    static List<List<int>> result;
    public static List<List<int>> Combine(int n, int k) {
        result = new();
         BackTrack(1, new List<int>(), n, k);
        return result;
    }

    private static void BackTrack(int current, List<int> list, int n, int k)
    {
        if (list.Count == k)
        {
            result.Add(new List<int>(list)); // Store a copy of the valid combination
            return;
        }

        for (int i = current; i <= n; i++)
        {
            list.Add(i);
            BackTrack(i + 1, list, n, k); // Ensure unique elements
            list.RemoveAt(list.Count - 1); // Backtrack
        }
    }
}

List<List<int>> testcases = [
    [4,2],
    [1,1],
    [4,3]
];

foreach (var cases in testcases)
{
    Console.WriteLine($"n = {cases[0]}, k = {cases[1]}");
    Console.WriteLine($"Solution - {string.Join(",", Solution.Combine(cases[0], cases[1]).Select(sublist => $"[{string.Join(",", sublist)}]"))}");
}