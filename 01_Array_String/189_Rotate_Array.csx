/*
https://leetcode.com/problems/rotate-array/description/?envType=study-plan-v2&envId=top-interview-150
Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
Example 1:

Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]
Example 2:

Input: nums = [-1,-100,3,99], k = 2
Output: [3,99,-1,-100]
Explanation: 
rotate 1 steps to the right: [99,-1,-100,3]
rotate 2 steps to the right: [3,99,-1,-100]
 

Constraints:

1 <= nums.length <= 105
-231 <= nums[i] <= 231 - 1
0 <= k <= 105
 

Follow up:

Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
Could you do it in-place with O(1) extra space?

*/

public static class Solution {
    public static void Rotate(int[] nums, int k) {
        //without exta space;
        if(nums.Length == 1)
        {
            return;
        }
        int numsrotate = k%nums.Length;
        Array.Reverse(nums);
        Array.Reverse(nums,0,numsrotate);
        Array.Reverse(nums,numsrotate,nums.Length-numsrotate);
        Console.WriteLine($"Nums Rotated - {String.Join(' ',nums)}");
    }
}


List<ValueTuple<int[],int>> testcases = [
([1,2,3,4,5,6,7], 3),
([-1,-100,3,99], 2),
([1,2],3)
];

foreach(var (nums,k) in testcases)
{
    Console.WriteLine($"Nums - {String.Join(' ',nums)}, k - {k} ");
    Solution.Rotate(nums,k);
}

/*
Play ground
 k =3 
[1 2 3 4 5 6 7] [5,6,7,1,2,3,4]
[7 6 5 4 3 2 1]

k =2 
[1 2 3 4 5 6 7] [6,7,1,2,3,4,5]
[1 7 3 4 5 6 2]
[6 7 3 4 5 1 2]

*/