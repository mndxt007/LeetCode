/*
https://leetcode.com/problems/remove-duplicates-from-sorted-array/?envType=study-plan-v2&envId=top-interview-150

Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
Return k.
Custom Judge:

The judge will test your solution with the following code:

int[] nums = [...]; // Input array
int[] expectedNums = [...]; // The expected answer with correct length

int k = removeDuplicates(nums); // Calls your implementation

assert k == expectedNums.length;
for (int i = 0; i < k; i++) {
    assert nums[i] == expectedNums[i];
}
If all assertions pass, then your solution will be accepted.

*/

using System.Threading;

public static class Solution
{
    public static int RemoveDuplicates(ref int[] nums)
    {
        //copied solution
        int i = 1;

        foreach (int n in nums)
        {
            if (nums[i - 1] != n) nums[i++] = n;
        }

        return i;
    }

    private static int UsingSets(int[] nums)
    {
        HashSet<int> set1 = new(nums);
        for (int i = 0; i < set1.Count; i++)
        {
            nums[i] = set1.ElementAt(i);
        }
        return set1.Count;
    }



}

int[] nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4];
int[] expectedNums = [0, 1, 2, 3, 4];
int k = Solution.RemoveDuplicates(ref nums);
Console.WriteLine(string.Join(", ", nums));



