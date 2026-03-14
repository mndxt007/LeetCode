/*
Given an array nums of n integers where nums[i] is in the range [1, n], return an array of all the integers in the range [1, n] that do not appear in nums.

Example 1:
Input: nums = [4,3,2,7,8,2,3,1]
Output: [5,6]

Example 2:
Input: nums = [1,1]
Output: [2]

Constraints:
n == nums.length
1 <= n <= 105
1 <= nums[i] <= n

Follow up: Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.
*/


// TODO: Implement solution
public IList<int> FindDisappearedNumbers(int[] nums)
{
    bool[] map = new bool[nums.Length+1];
    for(int i=0; i<nums.Length;i++)
    {
        map[nums[i]]=true;
    }
    IList<int> result = [];
    for(int i=1; i < map.Length;i++)
    {
        if(!map[i])
            result.Add(i);
    }
    return result;
}


List<int[]> testcases = [
    [4,3,2,7,8,2,3,1],
    [1,1]
];

foreach (var nums in testcases)
{
    Console.WriteLine($"Testcase: nums-[{String.Join(',', nums)}]");
    Console.WriteLine($"FindDisappearedNumbers - [{String.Join(',', FindDisappearedNumbers(nums))}]");
}
