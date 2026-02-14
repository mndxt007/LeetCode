/*
Given an array nums of distinct integers, return all the possible permutations. You can return the answer in any order.

Example 1:

Input: nums = [1,2,3]
Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]

Example 2:
Input: nums = [0,1]
Output: [[0,1],[1,0]]

Example 3:
Input: nums = [1]
Output: [[1]]
 

Constraints:

1 <= nums.length <= 6
-10 <= nums[i] <= 10
All the integers of nums are unique.
*/

IList<IList<int>> result;

public IList<IList<int>> Permute(int[] nums)
{
    return Backtrack(nums);
}

IList<IList<int>> Backtrack(Span<int> nums)
{
    if(nums.Length==0)
        return [[]];
    
    var perms = Backtrack(nums[1..]);
    IList<IList<int>> result = [];
    foreach(var permutation in perms)
    {
        for(int i=0; i<=permutation.Count;i++)
        {
            var copy = new List<int>(permutation);
            copy.Insert(i,nums[0]);
            result.Add(copy);
        }
        
    }
    return result;
}

public IList<IList<int>> Permute1(int[] nums)
{
    result = [];
    Backtrack1(nums, new List<int>(), new bool[nums.Length]);
    return result;
}

void Backtrack1(int[] nums, List<int> current, bool[] used)
{
    if (current.Count == nums.Length)
    {
        result.Add(new List<int>(current)); // Copy to avoid reference issues
        return;
    }

    for (int i = 0; i < nums.Length; i++)
    {
        if (used[i]) continue;

        used[i] = true;
        current.Add(nums[i]);
        Backtrack1(nums, current, used);
        current.RemoveAt(current.Count - 1);
        used[i] = false;
    }
}

List<int[]> testcases = new()
{
    new int[] {1,2,3},
    new int[] {0,1},
    new int[] {1}
};

    foreach (var testcase in testcases)
    {
        Console.WriteLine($"Testcase - {String.Join(',', testcase)}");
        //var permutations = Permute1(testcase);
        var permutations = Permute(testcase);
        Console.WriteLine($"Permutations - {String.Join('|', permutations.Select(permute => String.Join(',', permute)))}");
    }