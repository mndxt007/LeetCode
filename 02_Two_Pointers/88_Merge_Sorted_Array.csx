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
        List<int> merged = nums1[..m].ToList();
        merged.AddRange(nums2);
        merged.Sort();
        for (int i = 0; i < merged.Count; i++)
        {
            nums1[i] = merged[i];
        }
        Console.WriteLine($"Result : {String.Join(' ', nums1)}");


    }

    public static void Merge2(int[] nums1, int m, int[] nums2, int n)
    {
        int i = 0, j = 0, k = 0;
        int[] nums3 = nums1[..m];
        while (i < m && j < n)
        {
            if (nums3[i] <= nums2[j])
            {
                nums1[k++] = nums3[i++];
            }
            else
            {
                 nums1[k++] = nums2[j++];
            }
        }
        while(i<m)
        {
            nums1[k++] = nums3[i++];
        }
        while(j<n)
        {
             nums1[k++] = nums2[j++];
        }

        //implement merge sort here;
        Console.WriteLine($"Result : {String.Join(' ', nums1)}");


    }




}

public class TestCases()
{
    public int[] nums1;
    public int m;
    public int[] nums2;
    public int n;
}

List<TestCases> testcases = new(){
    new TestCases(){
        nums1 =[1,2,3,0,0,0],
        m =3,
        nums2 = [2,5,6],
        n = 3
    },
    new TestCases(){
        nums1 =[1],
        m =1,
        nums2 = new int[0],
        n = 0
    },
    new TestCases(){
        nums1 =[0],
        m =0,
        nums2 = [1],
        n = 1
    },
    new TestCases(){
        nums1 =[-1,0,0,3,3,3,0,0,0],
        m =6,
        nums2 = [1,2,2],
        n = 3
    },
};

foreach (var testcase in testcases)
{
    Console.WriteLine($"nums1 - {string.Join(", ", testcase.nums1)} , nums2 - {string.Join(", ", testcase.nums2)}");
    Solution.Merge2(testcase.nums1, testcase.m, testcase.nums2, testcase.n);
}

