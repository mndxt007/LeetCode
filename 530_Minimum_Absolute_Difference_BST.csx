/*
https://leetcode.com/problems/minimum-absolute-difference-in-bst/?envType=study-plan-v2&envId=top-interview-150
Given the root of a Binary Search Tree (BST), return the minimum absolute difference between the values of any two different nodes in the tree.

Example 1:

Input: root = [4,2,6,1,3]
Output: 1

Example 2:

Input: root = [1,0,48,null,null,12,49]
Output: 1
 

Constraints:

The number of nodes in the tree is in the range [2, 104].
0 <= Node.val <= 105
 
Note: This question is the same as 783: https://leetcode.com/problems/minimum-distance-between-bst-nodes/
*/

using Spectre.Console.Rendering;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public static class Solution
{
    public static int GetMinimumDifference(TreeNode root)
    {
        var currentnode = root;
        int min = Int32.MaxValue;
        if(currentnode.left is not null && currentnode.right is not null)
        {
            min =  Int32.Min(Math.Abs(currentnode.val-currentnode.left.val),Math.Abs(currentnode.val-currentnode.right.val));
            min =  Int32.Min(min,Math.Abs(currentnode.left!.val-currentnode.right.val));
            min = Int32.Min(min,GetMinimumDifference(currentnode.left));
            min = Int32.Min(min,GetMinimumDifference(currentnode.right));
        }
       
        return min;
    }
}

