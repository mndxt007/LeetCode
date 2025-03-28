/*
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

public int MajorityElement(int[] nums)
{
    int result = nums[0];
    int count = 1;
    for (int i = 1; i < nums.Length; i++)
    {
        count = nums[i] == result ? count + 1 : count - 1;
        if (count < 0)
        {
            result = nums[i];
            count = 1;
        }
    }
    return result;
}

List<int[]> testcases = [
    [3,2,3],
    [2,2,1,1,1,2,2],
    [10,9,9,9,10]
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"nums=[{String.Join(',', testcase)}]");
    Console.WriteLine($"Majority Element - {MajorityElement(testcase)}");
}
