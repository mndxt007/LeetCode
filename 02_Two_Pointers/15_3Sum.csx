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
    List<IList<int>> result = [];
    int j,k,sum;
    Array.Sort(nums); // Sorting enables the two-pointer approach

    for (int i = 0; i < nums.Length - 2; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) // Skip duplicate numbers for 'i'
            continue;

        j=i+1;
        k=nums.Length-1;
        while(j<k)
        {
            sum = nums[i]+nums[j]+nums[k];
            if(sum>0)
            {   
                k--;
            }
            else if(sum < 0)
            {
                j++;
            }
            else
            {
                result.Add([nums[i],nums[j],nums[k]]);
                j++;k--;
                while (j < k && nums[j] == nums[j - 1]) j++;
                while (j < k && nums[k] == nums[k + 1]) k--;
            }
        }
    }

    return result;
}



List<int[]> testcases = [
    [-1,0,1,2,-1,-4],
    [0,1,1],
    [0,0,0],
    [0,0,0,0],
    [-2,0,1,1,2]
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase -> numbers=[{String.Join(',', testcase)}]");
    Console.WriteLine($"Two Sum - [{String.Join('|',ThreeSum(testcase).Select(item => String.Join(',',item) ))}]");
}