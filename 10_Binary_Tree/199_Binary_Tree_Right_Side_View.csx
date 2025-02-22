/*
https://leetcode.com/problems/binary-tree-right-side-view/description/?envType=study-plan-v2&envId=top-interview-150

Given the root of a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.

Example 1:
Input: root = [1,2,3,null,5,null,4]
Output: [1,3,4]

Explanation:

Example 2:
Input: root = [1,2,3,4,null,null,null,5]
Output: [1,3,4,5]
Explanation:

Example 3:
Input: root = [1,null,3]
Output: [1,3]

Example 4:
Input: root = []
Output: []

Constraints:
The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100
*/

// Definition for a binary tree node.
public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
         this.left = left;
         this.right = right;
     }
 }

public class Solution {
    public IList<int> RightSideView(TreeNode root) {
         if(root==null)
        {
            return [];
        }
        List<List<int>> rightnodes = new();
        rightnodes.Add(new());
        int level  = 0;
        int count = 0;
        Queue<TreeNode> queue = new();
        queue.Enqueue(root);
        TreeNode current;
        while(queue.Count > 0)
        {
            current = queue.Dequeue();
            count++;
            if(count > Math.Pow(2,level))
            {
                level++;
                rightnodes.Add(new());
                count= 1;
            }
            if(current == null)
            {
                Console.Write("null,");
                continue;
               
            }
            Console.Write($"{current.val},");
            rightnodes[level].Add(current.val);            
            queue.Enqueue(current.left);
            queue.Enqueue(current.right);
        }
        return rightnodes.Where(levelitems => levelitems.Count > 0).Select(levelitems => levelitems[^1]).ToList();
    }
}