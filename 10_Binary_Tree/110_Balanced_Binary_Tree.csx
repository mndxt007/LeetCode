/*
Given a binary tree, determine if it is height-balanced.

Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: true

Example 2:
Input: root = [1,2,2,3,3,null,null,4,4]
Output: false

Example 3:
Input: root = []
Output: true

Constraints:
The number of nodes in the tree is in the range [0, 5000].
-104 <= Node.val <= 104
*/

#r "nuget: Spectre.Console, 0.54.0"

using Spectre.Console;

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

// Leave space for implementation here
public bool IsBalanced(TreeNode root)
{
    if(Height(root) < 0)
        return false;

    return true; 
}

//Helper function - Leave space for implementation here
int Height(TreeNode node)
{
    //leaf
    if (node == null)
        return 0;
    int leftHieght = Height(node.left); 
    int rightHieght = Height(node.right); 

    //parent exit
    if(leftHieght < 0 || rightHieght < 0)
        return -1;
    
    //Tree imbalance
    if(Math.Abs(leftHieght-rightHieght) > 1)
        return -1;

    return 1 + Math.Max(leftHieght,rightHieght);    
}

//Test case builder helper
TreeNode BuildTree(int[] arr)
{
    if (arr.Length == 0) return null;
    Queue<TreeNode> queue = new Queue<TreeNode>();
    TreeNode root = new TreeNode(arr[0]);
    queue.Enqueue(root);
    int i = 1;
    while (i < arr.Length)
    {
        TreeNode parent = queue.Dequeue();
        if (i < arr.Length && arr[i] != -1)
        {
            parent.left = new TreeNode(arr[i]);
            queue.Enqueue(parent.left);
        }
        i++;
        if (i < arr.Length && arr[i] != -1)
        {
            parent.right = new TreeNode(arr[i]);
            queue.Enqueue(parent.right);
        }
        i++;
    }
    return root;
}

List<int[]> testcases = [
    [3,9,20,-1,-1,15,7],  // true
    [1,2,2,3,3,-1,-1,4,4], // false
    []                  // true
];




foreach (var tree in testcases)
{
    TreeNode root = BuildTree(tree);
    Console.WriteLine($"Testcase: {string.Join(",", tree)}");
    AnsiConsole.Write(BuildSpectreTree(root)); // structure view
    Console.WriteLine($"IsBalanced: {IsBalanced(root)}");
    Console.WriteLine();
}


Tree BuildSpectreTree(TreeNode node)
{
    if (node == null)
        return new Tree("[grey]<empty>[/]");

    var tree = new Tree($"[yellow]{node.val}[/]");

    if (node.left != null)
        tree.AddNode(BuildSpectreTree(node.left));

    if (node.right != null)
        tree.AddNode(BuildSpectreTree(node.right));

    return tree;
}

