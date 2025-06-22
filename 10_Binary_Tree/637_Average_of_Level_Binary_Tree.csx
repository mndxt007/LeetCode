/*
Given the root of a binary tree, return the average value of the nodes on each level in the form of an array. Answers within 10-5 of the actual answer will be accepted.
 

Example 1:

Input: root = [3,9,20,null,null,15,7]
Output: [3.00000,14.50000,11.00000]
Explanation: The average value of nodes on level 0 is 3, on level 1 is 14.5, and on level 2 is 11.
Hence return [3, 14.5, 11].

Example 2:
Input: root = [3,9,20,15,7]
Output: [3.00000,14.50000,11.00000]
 

Constraints:

The number of nodes in the tree is in the range [1, 104].
-231 <= Node.val <= 231 - 1
*/

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

public static void EnqueueIfNotNull(TreeNode node, Queue<TreeNode> queue)
{
    if(node is not null)
    {
        queue.Enqueue(node);
    }
}

public IList<double> AverageOfLevels(TreeNode root)
{
    Queue<TreeNode> queue = new();
    IList<double> averages = [];
    queue.Enqueue(root);
    int count;
    long sum=0;
    TreeNode node;
    while(queue.Count > 0)
    {
        count = queue.Count;
        for (int i = 0; i < count;i++)
        {
            node = queue.Dequeue();
            sum += node.val;
            EnqueueIfNotNull(node.left,queue);
            EnqueueIfNotNull(node.right,queue);
        }
        averages.Add((double)sum / count);
        sum = 0;
    }
    return averages;
}

