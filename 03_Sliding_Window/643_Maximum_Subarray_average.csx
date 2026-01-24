/*
You are given an integer array nums consisting of n elements, and an integer k.
Find a contiguous subarray whose length is equal to k that has the maximum average value and return this value. Any answer with a calculation error less than 10-5 will be accepted.
 
Example 1:
Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75

Example 2:
Input: nums = , k = 1
Output: 5.00000

 
Constraints:
n == nums.length
1 <= k <= n <= 10^5
-10^4 <= nums[i] <= 10^4
*/

// Leave space for implementation here

public double MaxAverageSubarray(int[] nums, int k)
{
    double curentSum = nums.Take(k).Sum();
    double maxSum = curentSum;
    for (int i = k; i < nums.Length;i++)
    {
        curentSum += nums[i];
        curentSum -= nums[i - k];
        maxSum = Math.Max(maxSum, curentSum);
    }
    return maxSum/k;
}

// Define test cases
List<(int[] nums, int k)> testcases = [
(new int[]{1,12,-5,-6,50,3}, 4),
(new int[]{5}, 1),
(new int[]{0,4,0,3,2},1),
(new int[]{7,4,5,8,8,3,9,8,7,6},7)
];

// Run each test case
foreach (var (nums, k) in testcases)
{
    Console.WriteLine($"Testcase: nums-[{string.Join(",", nums)}] k-{k}");
    Console.WriteLine($"MaxAverageSubarray - {MaxAverageSubarray(nums, k):F5}");
}