/*
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

public void Merge(int[] nums1, int m, int[] nums2, int n)
{
    int nums1i=0;
    int nums2i=0;
    int fillindex = m;
    while(nums1i < m+n && nums2i < n)
    {
        if(nums1[nums1i]<=nums2[nums2i])
        {
            nums1i++;
        }
        else
        {
            nums1[fillindex++] = nums1[nums1i];
            nums1[nums1i] = nums2[nums2i];
            nums2i++;
        }
    }
    while(fillindex < m+n && nums2i < n)
    {
        nums1[fillindex++]=nums2[nums2i++];
    }
    Console.WriteLine($"After merging nums1=[{String.Join(',',nums1)}]");
}

List<ValueTuple<int[],int,int[],int>> testcases = [
    ([1,2,3,0,0,0],3,[2,5,6],3),
    ([1],1,[],0),
    ([0],0,[1],1),
    ([4,0,0,0,0,0],1,[1,2,3,5,6],5)
];

foreach(var testcase in testcases)
{
    Console.WriteLine($"nums1=[{String.Join(',',testcase.Item1)}] m={testcase.Item2} nums2=[{String.Join(',',testcase.Item3)}] n={testcase.Item4}");
    Merge(testcase.Item1,testcase.Item2,testcase.Item3,testcase.Item4);
}