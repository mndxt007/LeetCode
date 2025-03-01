/*
Given an integer array nums where the elements are sorted in ascending order, convert it to a height-balanced binary search tree.

Example 1:
Input: nums = [-10,-3,0,5,9]
Output: [0,-3,9,-10,null,5]
Explanation: [0,-10,5,null,-3,null,9] is also accepted:

Example 2:
Input: nums = [1,3]
Output: [3,1]
Explanation: [1,null,3] and [3,1] are both height-balanced BSTs.
 

Constraints:

1 <= nums.length <= 104
-104 <= nums[i] <= 104
nums is sorted in a strictly increasing order.
*/


// Definition for a binary tree node.

public class TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
{
    public int val = val;
    public TreeNode left = left;
    public TreeNode right = right;
}

public static class Solution {
    public static TreeNode SortedArrayToBST(int[] nums) {
        var root = ConstructTree(nums);
        return root;
    }

    private static TreeNode ConstructTree(int[] nums)
    {
        switch(nums.Length)
        {
            case 0:
                return null;
            case 1:
                return new TreeNode(nums[0]);
            default:
                int mid = nums.Length/2;
                var root = new TreeNode(nums[mid]);
                root.left = ConstructTree(nums[0..mid]);
                root.right = ConstructTree(nums[(mid+1)..]);
                return root;
        }        
    }
}

List<int[]> testcases = [
    [-10,-3,0,5,9],
    [1,3]
];

foreach(var testcase in testcases)
{
    WriteLine($"Test Case - {String.Join(",",testcase)}");
    WriteLine($"BST Node - {Solution.SortedArrayToBST(testcase)}");
}
