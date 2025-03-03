/*
Given an integer array nums and an integer k, return the kth largest element in the array.
Note that it is the kth largest element in the sorted order, not the kth distinct element.
Can you solve it without sorting?
 
Example 1:
Input: nums = [3,2,1,5,6,4], k = 2
Output: 5

Example 2:
Input: nums = [3,2,3,1,2,4,5,5,6], k = 4
Output: 4

Constraints:

1 <= k <= nums.length <= 105
-104 <= nums[i] <= 104
*/

public static class Solution {
    public static int FindKthLargest(int[] nums, int k) {
        //build heap until k elements
        for(int i=(k/2);i>=0;i--)
        {
            HeapifyDown(nums,i,k);
        }
        //process remaining elements
        for(int i=k; i<nums.Length;i++)
        {
            if(nums[i] > nums [0])
            {
                nums[0] = nums[i];
                HeapifyDown(nums,0,k);
            }
            
        }

        return nums[0];
    }

    static void HeapifyDown(int[] nums, int index, int size)
    {
        int current = index;
        int left = 2 * index + 1;
        int right = 2 * index + 2;

        if(left < size && nums[left] < nums[current])
            current = left;
        if(right < size && nums[right] < nums[current])
            current = right;
        
        if(current!=index)
        {
            (nums[index],nums[current]) = (nums[current],nums[index]);
            HeapifyDown(nums,current,size);
        }

    }
}

 List<Tuple<int[],int>> testcases = [
    new([3,2,1,5,6,4],2),
    new([3,2,3,1,2,4,5,5,6], 4)
 ];

 foreach(var testcase in  testcases)
 {
    Console.WriteLine($"nums - {String.Join(",",testcase.Item1)}  | k = {testcase.Item2} ");
    Console.WriteLine($"Kth Largest Element - {Solution.FindKthLargest(testcase.Item1, testcase.Item2)}");
 }