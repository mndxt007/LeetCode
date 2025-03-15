/*
Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
Notice that the solution set must not contain duplicate triplets.

Example 1:
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation: 
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
The distinct triplets are [-1,0,1] and [-1,-1,2].
Notice that the order of the output and the order of the triplets does not matter.

Example 2:
Input: nums = [0,1,1]
Output: []
Explanation: The only possible triplet does not sum up to 0.

Example 3:
Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only possible triplet sums up to 0.
*/

public IList<IList<int>> ThreeSum(int[] nums)
{
    IList<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);
    int requiredsum;
    ReadOnlySpan<int> spannums = nums;
    ValueTuple<int,int> jk;
    for(int i=0;i<nums.Length-2;i++)
    {
        requiredsum = 0 - nums[i];
        if(TwoSum(spannums.Slice(i+1),requiredsum,out jk))
        {
            result.Add([nums[i],jk.Item1,jk.Item2]);
        }
    }
    return result;
}

bool TwoSum(ReadOnlySpan<int> nums, int target,out ValueTuple<int,int> jk)
{
    int j=0;
    int k=nums.Length -1;
    int sum;
    while(j<k)
    {
        sum = nums[j]+nums[k];
        if(sum==target)
        {
            jk = (nums[j],nums[k]);
            return true;
        }
        else if(sum>target)
        {
            k--;
        }
        else
        {
            j++;
        }
    }
    jk = (0,0);
    return false;
}

List<int[]> testcases = [
    [-1,0,1,2,-1,-4],
    [0,1,1],
    [0,0,0],
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase -> numbers=[{String.Join(',', testcase)}]");
    Console.WriteLine($"Two Sum - [{String.Join('|',ThreeSum(testcase).Select(item => String.Join(',',item) ))}]");
}