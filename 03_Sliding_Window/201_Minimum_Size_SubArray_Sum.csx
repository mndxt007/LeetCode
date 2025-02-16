/*
Given an array of positive integers nums and a positive integer target, return the minimal length of a 
subarray
 whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.
Example 1:
Input: target = 7, nums = [2,3,1,2,4,3]
Output: 2
Explanation: The subarray [4,3] has the minimal length under the problem constraint.

Example 2:
Input: target = 4, nums = [1,4,4]
Output: 1

Example 3:
Input: target = 11, nums = [1,1,1,1,1,1,1,1]
Output: 0
 
Constraints:

1 <= target <= 109
1 <= nums.length <= 105
1 <= nums[i] <= 104
 
Follow up: If you have figured out the O(n) solution, try coding another solution of which the time complexity is O(n log(n)).
*/

public static class Solution {
    public static int MinSubArrayLen(int target, int[] nums) {
        int windowSum = 0;
        int left = 0;
        int minLength = Int32.MaxValue;
        for(int right = 0; right < nums.Length ; right++)
        {
            windowSum += nums[right];
            while(windowSum >= target)
            {
                minLength = Math.Min(minLength,right-left+1);
                windowSum-=nums[left];
                left++;
            }
        }
        return minLength == Int32.MaxValue ? 0 : minLength;
    }
}

public record TestCase
{
    public int[] nums { get; set; }
    public int target { get; set;}
}

List<TestCase> testCases = [
    new TestCase { nums = [2,3,1,2,4,3], target = 7},
    new TestCase { nums = [1,4,4], target = 4},
    new TestCase { nums = [1,1,1,1,1,1,1,1], target = 11},
];

foreach (var testCase in testCases)
{
    Console.WriteLine($"nums - {String.Join(',',testCase.nums)} | nums - {testCase.nums}");
    Console.WriteLine($"MinSubArrayLen - {Solution.MinSubArrayLen(testCase.target,testCase.nums)}");
}