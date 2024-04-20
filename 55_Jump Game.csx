/*
https://leetcode.com/problems/jump-game/description/?envType=study-plan-v2&envId=top-interview-150

You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.

Return true if you can reach the last index, or false otherwise.

Example 1:

Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
Example 2:

Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
 

Constraints:

1 <= nums.length <= 104
0 <= nums[i] <= 105
*/

using System;

public static class Solution
{
    public static bool CanJump(int[] nums)
    {
        var len = nums.Length > 1 ? nums.Length - 1 : 1;
        if (nums[nums.Length - 1] == 0) return true;
        for (int i = 0; i < len; i++)
        {
             if (nums[i] == 0)
                return false;
            if (i + nums[i] >= len)
                return true;
        }
        return false;

    }
}

//int[] nums = [2,3,1,1,4];
int[] nums = [3, 2, 1, 0, 4];
Console.WriteLine(Solution.CanJump(nums));
