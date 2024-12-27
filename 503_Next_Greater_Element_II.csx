/*
Given a circular integer array nums (i.e., the next element of nums[nums.length - 1] is nums[0]), return the next greater number for every element in nums.

The next greater number of a number x is the first greater number to its traversing-order next in the array, which means you could search circularly to find its next greater number. If it doesn't exist, return -1 for this number.

Example 1:

Input: nums = [1,2,1]
Output: [2,-1,2]
Explanation: The first 1's next greater number is 2; 
The number 2 can't find next greater number. 
The second 1's next greater number needs to search circularly, which is also 2.
Example 2:

Input: nums = [1,2,3,4,3]
Output: [2,3,4,-1,4]
 
Constraints:

1 <= nums.length <= 104
-109 <= nums[i] <= 109
*/
#r "nuget: Dumpify, 0.6.6"
using Dumpify;
using System.Collections.Generic;

 public static int[] NextGreaterElements(int[] nums) {
        int n = nums.Length;
        int[] result = new int[n];
        Stack<int> stack = new();
        // Process from right to left
        for (int i = (2*n) - 1; i >= 0; i--) {
            // Remove smaller elements from stack
            while (stack.Count > 0 && stack.Peek() <= nums[i%n]) {
                stack.Pop();
            }
            
            // Set result
            result[i%n] = stack.Count == 0 ? -1 : stack.Peek();
            
            // Add current element
            stack.Push(nums[i%n]);
        }
        
        return result;
    }

List<int[]> testcases = [
    [1,2,1],
    [1,2,3,4,3],
    [1,2,3,4,4],
    [1,2,3,2,1]
];

foreach (var case_ in testcases)
{
    Console.WriteLine($"Test Case - {case_.Dump()}");
    Console.WriteLine($"Maximum Profit - {NextGreaterElements(case_).Dump()}");
}