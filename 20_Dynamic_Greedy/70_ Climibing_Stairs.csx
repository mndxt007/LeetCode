/*
You are climbing a staircase. It takes n steps to reach the top.
Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?

Example 1:
Input: n = 2
Output: 2
Explanation: There are two ways to climb to the top.
1. 1 step + 1 step
2. 2 steps

Example 2:
Input: n = 3
Output: 3
Explanation: There are three ways to climb to the top.
1. 1 step + 1 step + 1 step
2. 1 step + 2 steps
3. 2 steps + 1 step
 
Constraints:
1 <= n <= 45

Testing - 4:

1 -1 
2 -2 
3 -3 
4- 5
5 - 8
*/

public static class Solution {
    public static int ClimbStairs(int n) {
        Dictionary<int,int> memo = new();
        memo[1] = 1;
        memo[2] = 2;
        for(int i=3;i<=n;i++)
        {
            memo[i]=memo[i-1]+memo[i-2];
        }
        return memo[n];
    }
}

List<int> testcases = [
    2,
    3
];

foreach(int testcase in testcases)
{
    Console.WriteLine($"Testcase - {testcase}");
    Console.WriteLine($"Climb Stairs - {Solution.ClimbStairs(testcase)}");
}
