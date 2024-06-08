/*
https://leetcode.com/problems/sort-even-and-odd-indices-independently/description/
You are given a 0-indexed integer array nums. Rearrange the values of nums according to the following rules:

Sort the values at odd indices of nums in non-increasing order.
For example, if nums = [4,1,2,3] before this step, it becomes [4,3,2,1] after. The values at odd indices 1 and 3 are sorted in non-increasing order.
Sort the values at even indices of nums in non-decreasing order.
For example, if nums = [4,1,2,3] before this step, it becomes [2,1,4,3] after. The values at even indices 0 and 2 are sorted in non-decreasing order.
Return the array formed after rearranging the values of nums.

 

Example 1:

Input: nums = [4,1,2,3]
Output: [2,3,4,1]
Explanation: 
First, we sort the values present at odd indices (1 and 3) in non-increasing order.
So, nums changes from [4,1,2,3] to [4,3,2,1].
Next, we sort the values present at even indices (0 and 2) in non-decreasing order.
So, nums changes from [4,1,2,3] to [2,3,4,1].
Thus, the array formed after rearranging the values is [2,3,4,1].
Example 2:

Input: nums = [2,1]
Output: [2,1]
Explanation: 
Since there is exactly one odd index and one even index, no rearrangement of values takes place.
The resultant array formed is [2,1], which is the same as the initial array. 
 

Constraints:

1 <= nums.length <= 100
1 <= nums[i] <= 100
*/

public static class Solution {
    public static int[] SortEvenOdd(int[] nums) {
        int[] oddindices = new int[nums.Length/2 ];
        int[] evenindices = new int[nums.Length % 2 == 0 ? nums.Length/2 : nums.Length/2+1 ];
        int oddcounter = 0;
        int evencounter =0;
        for(int i=0; i < nums.Length; i++)
        {
            if(i % 2 == 0)
            {
               evenindices[evencounter++] = nums[i];
                
            }
            else{
                oddindices[oddcounter++] = nums[i];
                
            }
        }
        Array.Sort(evenindices);
        Array.Sort(oddindices);
        Array.Reverse(oddindices);
        oddcounter = 0;
        evencounter =0;
        for(int i=0; i < nums.Length; i++)
        {
            if(i % 2 == 0)
            {
                 nums[i] = evenindices[evencounter++];
                
            }
            else{
                nums[i] = oddindices[oddcounter++];
            }
        }

        return nums;
        
    }
}

List<int[]> testcases = new()
{
    new int[] {4,1,2,3},
    new int[] {2,1},
    new int[] {36,45,32,31,15,41,9,46,36,6,15,16,33,26,27,31,44,34},
    new int[] {5,39,33,5,12,27,20,45,14,25,32,33,30,30,9,14,44,15,21}
};

foreach (var case_ in testcases)
{
    Console.WriteLine($"Test Case - {String.Join(',',case_)}");
    Console.WriteLine($"SortEvenOdd - {String.Join(',',Solution.SortEvenOdd(case_))}");
}
