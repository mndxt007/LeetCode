/*
You are given an integer array coins representing coins of different denominations and an integer amount representing a total amount of money.
Return the fewest number of coins that you need to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1.
You may assume that you have an infinite number of each kind of coin.
 
Example 1:
Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1

Example 2:
Input: coins = [2], amount = 3
Output: -1

Example 3:
Input: coins = [1], amount = 0
Output: 0

 
Constraints:
1 <= coins.length <= 12
1 <= coins[i] <= 231 - 1
0 <= amount <= 104
*/

//Leave space for implementation here

public int CoinChange(int[] coins, int amount)
{
    // No recursion - just loops
    int[] dp = new int[amount + 1];
    Array.Fill(dp, amount + 1); // Initialize with impossible value
    dp[0] = 0;

    for (int i = 1; i <= amount; i++)
    {
        foreach (var coin in coins)
        {
            if (i >= coin)
            {
                dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
            }
        }
    }

    return dp[amount] > amount ? -1 : dp[amount];
}


List<(int[] coins, int amount)> testcases = [
        (new int[] {1, 2, 5}, 11),
    (new int[] {2}, 3),
    (new int[] {1}, 0),
    (new int[] {3, 7, 405, 436}, 8839),    // 25
    (new int[] {1, 5, 10, 25}, 100),       // 4 (25+25+25+25)
    (new int[] {2, 4, 6}, 5)               // -1 (impossible with even coins)
    ];

    foreach (var (coins, amount) in testcases)
    {
        Console.WriteLine($"Testcase: coins=[{String.Join(',', coins)}] amount={amount}");
        Console.WriteLine($"CoinChange - {CoinChange(coins, amount)}");
    }
