/*
Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.
Note that you must do this in-place without making a copy of the array.
 
Example 1:
Input: nums =
Output: [1,ample 2:
Input: nums =
Output:

 
Constraints:
1 <= nums.length <= 10^4
-2^31 <= nums[i] <= 2^31 - 1
 
Follow up: Could you minimize the total number of operations done?
*/

// Leave space for implementation here

void MoveZeroes(int[] nums)
{
    if (nums.Length <= 1)
    {
        return;
    }
    int l = 0;
    int r = 1;
    while (r < nums.Length)
    {
        if (nums[r] != 0)
        {
            while (l < nums.Length && nums[l] != 0)
                l++;
            if (l < nums.Length && nums[l] == 0 && l < r)
            {
                nums[l] = nums[r];
                nums[r] = 0;
            }

        }
        r++;
    }
}

List<int[]> testcases = new List<int[]>{
new int[] {0,1,0,3,12},
new int[] {0},
new int[] {1,0,2,0,0,3,4},
new int[] {2,1},
new int[] {4,2,4,0,0,3,0,5,1,0}
};

foreach (var nums in testcases)
{
    Console.WriteLine($"Testcase: [{String.Join(',', nums)}]");
    MoveZeroes(nums);
    Console.WriteLine($"After MoveZeroes: [{String.Join(',', nums)}]");
}