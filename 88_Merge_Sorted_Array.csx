/*
https://leetcode.com/problems/merge-sorted-array/description/?envType=study-plan-v2&envId=top-interview-150
You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n, representing the number of elements in nums1 and nums2 respectively.

Merge nums1 and nums2 into a single array sorted in non-decreasing order.

The final sorted array should not be returned by the function, but instead be stored inside the array nums1. To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged, and the last n elements are set to 0 and should be ignored. nums2 has a length of n.

 

Example 1:

Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
Output: [1,2,2,3,5,6]
Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
Example 2:

Input: nums1 = [1], m = 1, nums2 = [], n = 0
Output: [1]
Explanation: The arrays we are merging are [1] and [].
The result of the merge is [1].
Example 3:

Input: nums1 = [0], m = 0, nums2 = [1], n = 1
Output: [1]
Explanation: The arrays we are merging are [] and [1].
The result of the merge is [1].
Note that because m = 0, there are no elements in nums1. The 0 is only there to ensure the merge result can fit in nums1.
 

Constraints:

nums1.length == m + n
nums2.length == n
0 <= m, n <= 200
1 <= m + n <= 200
-109 <= nums1[i], nums2[j] <= 109
 

Follow up: Can you come up with an algorithm that runs in O(m + n) time?
*/


using System.Data;

public static class Solution
{
    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        // List<int> merged = nums1.ToList();
        // merged.AddRange(nums2);
        // int writeindex=0;
        // for (int i = 1; i < (m+n); i++)
        // {
        //     if(merged[i]==0 && merged[i-1]>0){
        //         merged.RemoveAt(i--);
        //     }
        // }
        // merged.Sort();
        // for (int i = 0; i < nums1.Length; i++)
        // {
        //     nums1[i]=merged[i];
        // }
         List<int> merged = nums1.ToList();
        merged.AddRange(nums2);
        merged.RemoveAll(
           x => x==0
        );
        merged.Sort();
        for (int i = 0; i < merged.Count; i++)
        {
            nums1[i]=merged[i];
        } 
        Console.WriteLine($"Result : {String.Join(' ', nums1)}");


    }




}

Dictionary<int[], int[]> testcases = new(){
    { new int[] {1,2,3,0,0,0}, new int [] {2,5,6}},
    { new int[] {1}, new int[0] },
    { new int[1], new[] {1}},
     { new int[] {-1,0,0,3,3,3,0,0,0}, new int [] {1,2,2}},
};

foreach (var (nums1, nums2) in testcases)
{
    Console.WriteLine($"nums1 - {string.Join(", ", nums1)} , costs - {string.Join(", ", nums2)}");
    Solution.Merge(nums1, nums1.Length, nums2, nums2.Length);
}

