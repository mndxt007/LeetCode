/*
Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
You must write an algorithm with O(log n) runtime complexity.

 
Example 1:
Input: nums = [1,3,5,6], target = 5
Output: 2

Example 2:
Input: nums = [1,3,5,6], target = 2
Output: 1

Example 3:
Input: nums = [1,3,5,6], target = 7
Output: 4

Constraints:
1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums contains distinct values sorted in ascending order.
-104 <= target <= 104
*/

public int SearchInsert(int[] nums, int target)
{
    return RecursiveSearchInsert(nums, target, 0, nums.Length - 1);
}

private int RecursiveSearchInsert(int[] nums, int target, int start, int end)
{
    //for cases where length is 1 or 2
    var length = (end - start) + 1;
    if (length == 1)
    {
        if (nums[start] == target)
        {
            return start;
        }
        else if (target > nums[start])
        {
            return start + 1;
        }
        else
        {
            return start;
        }

    }
    else
    {
        int mid = (end - start) / 2;
        mid += start;
        if (nums[mid] == target)
        {
            return mid;
        }
        else if (target > nums[mid])
        {
            return RecursiveSearchInsert(nums, target, mid+1, end);
        }
        else
        {
            return RecursiveSearchInsert(nums, target, start, mid);
        }
    }
}


List<(int[] nums, int target)> testcases = [
    ([1,3,5,6],5),
    ([1,3,5,6],2),
    ([1,3,5,6],7)
];

foreach (var (nums, target) in testcases)
{
    Console.WriteLine($"nums - {String.Join(',', nums)} | target - {target}");
    Console.WriteLine($"SearchInsert - {SearchInsert(nums, target)}");
}