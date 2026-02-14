# Boilerplate Code Examples

These examples show the exact output format for different problem types.

## Example 1: Simple array/int parameters (Two Sum)

```csharp
/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.
 
Example 1:
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:
Input: nums = [3,2,4], target = 6
Output: [1,2]

Example 3:
Input: nums = [3,3], target = 6
Output: [0,1]

 
Constraints:
2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
 
Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
*/


// TODO: Implement solution
public int[] TwoSum(int[] nums, int target)
{
    throw new NotImplementedException();
}


List<(int[] nums, int target)> testcases = [
    ([2,7,11,15], 9),
    ([3,2,4], 6),
    ([3,3], 6)
];

foreach (var (nums, target) in testcases)
{
    Console.WriteLine($"Testcase: nums-[{String.Join(',', nums)}] target-{target}");
    Console.WriteLine($"TwoSum - [{String.Join(',', TwoSum(nums, target))}]");
}
```

## Example 2: String + array parameter (Word Break)

```csharp
/*
Given a string s and a dictionary of strings wordDict, return true if s can be segmented into a space-separated sequence of one or more dictionary words.

Note that the same word in the dictionary may be reused multiple times in the segmentation.
Example 1:
Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".

Example 2:
Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
Note that you are allowed to reuse a dictionary word.

Example 3:
Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false
 

Constraints:

1 <= s.length <= 300
1 <= wordDict.length <= 1000
1 <= wordDict[i].length <= 20
s and wordDict[i] consist of only lowercase English letters.
All the strings of wordDict are unique.
*/


// TODO: Implement solution
public bool WordBreak(string s, IList<string> wordDict)
{
    throw new NotImplementedException();
}


List<(string s, string[] wordDict)> testcases = [
    ("leetcode",["leet","code"]),
    ("applepenapple", ["apple","pen"]),
    ("catsandog",["cats","dog","sand","and","cat"])
];

foreach (var (s,wordDict) in testcases)
{
    Console.WriteLine($"Testcase: s-{s} wordDict-{String.Join(',', wordDict)}");
    Console.WriteLine($"WordBreak - {WordBreak(s, wordDict)}");
}
```

## Example 3: 2D grid parameter (Number of Islands)

```csharp
/*
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.
*/


// TODO: Implement solution
public int NumIslands(char[][] grid)
{
    throw new NotImplementedException();
}


List<char[][]> testcases = [
    [
        ['1','1','1','1','0'],
        ['1','1','0','1','0'],
        ['1','1','0','0','0'],
        ['0','0','0','0','0']
    ],
    [
        ['1','1','0','0','0'],
        ['1','1','0','0','0'],
        ['0','0','1','0','0'],
        ['0','0','0','1','1']
    ]
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"{String.Join("\n",testcase.Select(row => String.Join(",",row)))}");
    Console.WriteLine($"NumIslands - {NumIslands(testcase)}");
}
```

## Example 4: Linked List problem (Add Two Numbers)

When the problem uses ListNode, TreeNode, or other custom data structures, include the class definition and helper methods.

```csharp
/*
You are given two non-empty linked lists representing two non-negative integers...
[problem description]
*/

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.next = next;
        this.val = val;
    }
}

public static ListNode LoadList(int[] values)
{
    if (values == null || values.Length == 0)
        return null;
    ListNode head = new ListNode(values[0]);
    ListNode current = head;
    for (int i = 1; i < values.Length; i++)
    {
        current.next = new ListNode(values[i]);
        current = current.next;
    }
    return head;
}

public static void PrintList(ListNode head)
{
    ListNode current = head;
    while (current != null)
    {
        Console.Write(current.val);
        if (current.next != null) Console.Write(",");
        current = current.next;
    }
    Console.WriteLine();
}


// TODO: Implement solution
public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    throw new NotImplementedException();
}


List<(int[], int[])> testcases = [
    ([2,4,3], [5,6,4]),
    ([0],[0]),
    ([9,9,9,9,9,9,9], [9,9,9,9])
];

foreach (var (l1, l2) in testcases)
{
    Console.WriteLine($"L1 - {String.Join(',', l1)} | L2 - {String.Join(',', l2)}");
    var listl1 = LoadList(l1);
    var listl2 = LoadList(l2);
    Console.Write("Result - ");
    var result = AddTwoNumbers(listl1, listl2);
    PrintList(result);
}
```

## Example 5: Binary Tree problem (Max Depth)

```csharp
/*
Given the root of a binary tree, return its maximum depth...
[problem description]
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


// TODO: Implement solution
public int MaxDepth(TreeNode root)
{
    throw new NotImplementedException();
}
```

## Key Patterns

- Test case tuples use C# 12 collection expressions: `[...]`
- Print format: `Console.WriteLine($"Testcase: param1-{val1} param2-{val2}")`
- Result format: `Console.WriteLine($"MethodName - {MethodName(args)}")`
- Array printing: `String.Join(',', array)`
- For IList parameters in signature, use concrete arrays in test cases
- Leave `// TODO: Implement solution` comment and a method stub with `throw new NotImplementedException()`
- Do NOT provide any solution hints, algorithm suggestions, or implementation details
