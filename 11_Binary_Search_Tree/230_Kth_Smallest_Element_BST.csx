/*
Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.

Example 1:
Input: root = [3,1,4,null,2], k = 1
Output: 1

Example 2:
Input: root = [5,3,6,2,4,null,null,1], k = 3
Output: 3
 

Constraints:

The number of nodes in the tree is n.
1 <= k <= n <= 104
0 <= Node.val <= 104
 

Follow up: If the BST is modified often (i.e., we can do insert and delete operations) and you need to find the kth smallest frequently, how would you optimize?
*/

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

public static TreeNode LoadBST(int?[] rootArr)
{
    if (rootArr == null || rootArr.Length == 0 || rootArr[0] == null)
        return null;

    TreeNode root = new TreeNode(rootArr[0].Value);
    Queue<TreeNode> queue = new();
    queue.Enqueue(root);
    int i = 1;

    while (queue.Count > 0 && i < rootArr.Length)
    {
        var current = queue.Dequeue();

        if (i < rootArr.Length && rootArr[i] != null)
        {
            current.left = new TreeNode(rootArr[i].Value);
            queue.Enqueue(current.left);
        }
        i++;

        if (i < rootArr.Length && rootArr[i] != null)
        {
            current.right = new TreeNode(rootArr[i].Value);
            queue.Enqueue(current.right);
        }
        i++;
    }

    return root;
}

public int KthSmallest(TreeNode root, int k)
{
    int count = 0;
    int result = -1;
    InOrderTraversal(root, k, ref count, ref result);
    return result;
}

private void InOrderTraversal(TreeNode node, int k, ref int count, ref int result)
{
    if (node == null || count >= k) return;

    InOrderTraversal(node.left, k, ref count, ref result);

    count++;
    if (count == k)
    {
        result = node.val;
        return;
    }

    InOrderTraversal(node.right, k, ref count, ref result);
}

List<(int?[], int)> testcases = [
    ([3,1,4,null,2],1),
    ([5,3,6,2,4,null,null,1],3)
];

foreach (var (rootArr, k) in testcases)
{
    Console.WriteLine($"root - {String.Join(',', rootArr)} | k - {k}");
    var root = LoadBST(rootArr);
    Console.WriteLine($"Kth smallest element - {KthSmallest(root, k)}");
}