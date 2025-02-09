/*
https://leetcode.com/problems/majority-element/description/?envType=study-plan-v2&envId=top-interview-150
Given an array nums of size n, return the majority element.

The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.

 

Example 1:

Input: nums = [3,2,3]
Output: 3
Example 2:

Input: nums = [2,2,1,1,1,2,2]
Output: 2
 

Constraints:

n == nums.length
1 <= n <= 5 * 104
-109 <= nums[i] <= 109
 

Follow-up: Could you solve the problem in linear time and in O(1) space?
*/
public static class Solution {
    public static int MajorityElement(int[] nums) {
        //sort the array
        Array.Sort(nums);
        int count = 1;
        int length = nums.Length;
        if(length ==1) return nums[0];
        //check the count if it is greater than length/2
        for(int i=1; i < nums.Length ; i++)
        {
            if(nums[i]==nums[i-1])
                count++;
            else
                count = 1;
            if (count> (length/2))
            {
                return nums[i];
            }
            else
                break;
        }
        return 0;
    }
}


List<int[]> testcases = [
    [3,2,3],
    [2,2,1,1,1,2,2]
];

foreach (var item in testcases)
{
    Console.WriteLine($"TestCase - {String.Join(' ',item)}");
    Console.WriteLine($"Result - {Solution.MajorityElement(item)}");
}