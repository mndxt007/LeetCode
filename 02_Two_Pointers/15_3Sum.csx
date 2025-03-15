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
    HashSet<string> seen = new(); // Track unique triplets
    List<IList<int>> result = new();

    Array.Sort(nums); // Sorting enables the two-pointer approach

    for (int i = 0; i < nums.Length - 2; i++)
    {
        if (i > 0 && nums[i] == nums[i - 1]) // Skip duplicate numbers for 'i'
            continue;

        int requiredSum = -nums[i];
        List<(int, int)> pairs = TwoSum(nums, i + 1, requiredSum);

        foreach (var (num1, num2) in pairs)
        {
            string key = $"{nums[i]},{num1},{num2}"; // Unique identifier
            if (!seen.Contains(key))
            {
                result.Add(new List<int> { nums[i], num1, num2 });
                seen.Add(key);
            }
        }
    }

    return result;
}

private List<(int, int)> TwoSum(int[] nums, int start, int target)
{
    int left = start, right = nums.Length - 1;
    List<(int, int)> pairs = new();

    while (left < right)
    {
        int sum = nums[left] + nums[right];

        if (sum == target)
        {
            pairs.Add((nums[left], nums[right]));
            left++;
            right--;

            // Skip duplicate numbers
            while (left < right && nums[left] == nums[left - 1]) left++;
            while (left < right && nums[right] == nums[right + 1]) right--;
        }
        else if (sum < target)
        {
            left++;
        }
        else
        {
            right--;
        }
    }

    return pairs;
}

List<int[]> testcases = [
    [-1,0,1,2,-1,-4],
    [0,1,1],
    [0,0,0],
    [-2,0,1,1,2]
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase -> numbers=[{String.Join(',', testcase)}]");
    Console.WriteLine($"Two Sum - [{String.Join('|',ThreeSum(testcase).Select(item => String.Join(',',item) ))}]");
}