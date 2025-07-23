/*
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the MinStack class:

MinStack() initializes the stack object.
void push(int val) pushes the element val onto the stack.
void pop() removes the element on the top of the stack.
int top() gets the top element of the stack.
int getMin() retrieves the minimum element in the stack.
You must implement a solution with O(1) time complexity for each function.

Example 1:

Input
["MinStack","push","push","push","getMin","pop","top","getMin"]
[[],[-2],[0],[-3],[],[],[],[]]

Output
[null,null,null,null,-3,null,0,-2]

Explanation
MinStack minStack = new MinStack();
minStack.push(-2);
minStack.push(0);
minStack.push(-3);
minStack.getMin(); // return -3
minStack.pop();
minStack.top();    // return 0
minStack.getMin(); // return -2

Constraints:

-2^31 <= val <= 2^31 - 1
Methods pop, top and getMin operations will always be called on non-empty stacks.
At most 3 * 10^4 calls will be made to push, pop, top, and getMin.
*/

public class MinStack {

    private readonly Stack<(int val, int min)> _innerStack; 

    public MinStack() {
        _innerStack = [];
    }
    
    public void Push(int val) {
        if (_innerStack.TryPeek(out var top))
        {
            _innerStack.Push((val, (top.min < val ? top.min : val)));
        }
        else
        {
            _innerStack.Push((val, val));
        }
    }
    
    public void Pop() {
        _innerStack.Pop();
    }
    
    public int Top() {
        if(_innerStack.TryPeek(out var result))
        {
            return result.val;
        }
        return -1;
    }
    
    public int GetMin() {
        if(_innerStack.TryPeek(out var result))
        {
            return result.min;
        }
        return -1;
    }
}

// Test cases
List<(string[] operations, int[][] values)> testcases = [
    (["MinStack","push","push","push","getMin","pop","top","getMin"],
     [[], [-2], [0], [-3], [], [], [], []]),
    (["MinStack","push","push","getMin","push","getMin","pop","top","getMin"],
     [[], [1], [2], [], [0], [], [], [], []])
];

foreach (var (operations, values) in testcases)
{
    Console.WriteLine($"Operations: {String.Join(',', operations)}");
    MinStack minStack = null;
    List<object> results = new List<object>();
    
    for (int i = 0; i < operations.Length; i++)
    {
        switch (operations[i])
        {
            case "MinStack":
                minStack = new MinStack();
                results.Add(null);
                break;
            case "push":
                minStack.Push(values[i][0]);
                results.Add(null);
                break;
            case "pop":
                minStack.Pop();
                results.Add(null);
                break;
            case "top":
                results.Add(minStack.Top());
                break;
            case "getMin":
                results.Add(minStack.GetMin());
                break;
        }
    }
    
    Console.WriteLine($"Results: [{String.Join(',', results.Select(r => r?.ToString() ?? "null"))}]");
    Console.WriteLine();
}
