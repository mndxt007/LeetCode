/*
Given an integer array nums of unique elements, return all possible subsets (the power set).
The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Example 2:
Input: nums = [0]
Output: [[],[0]]

Constraints:
1 <= nums.length <= 10
-10 <= nums[i] <= 10
All the numbers of nums are unique.
*/



// TODO: Implement solution
IList<IList<int>> result = [];
public IList<IList<int>> Subsets(int[] nums)
{
    BackTrack(0,nums,[]);
    return result;
}

void BackTrack(int i,int[] nums, List<int>current)
{
    if(i==nums.Length)
    {
        result.Add(new List<int>(current));
        return;
    }
    current.Add(nums[i]);
    BackTrack(i+1,nums,current);
    current.RemoveAt(current.Count-1);
    BackTrack(i+1,nums,current);
}

List<int[]> testcases = [
[1,2,3],
[0]
];

foreach (var nums in testcases)
{
    Console.WriteLine($"Testcase: nums-[{String.Join(',', nums)}]");
    var result = Subsets(nums);
    Console.WriteLine($"Subsets - [{String.Join(',', result.Select(s => $"[{String.Join(',', s)}]"))}]");
}
