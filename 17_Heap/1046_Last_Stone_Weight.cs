/*
You are given an array of integers stones where stones[i] is the weight of the ith stone.
We are playing a game with the stones. On each turn, we choose the heaviest two stones and smash them together.
Suppose the heaviest two stones have weights x and y with x <= y. The result of this smash is:
If x == y, both stones are destroyed, and
If x != y, the stone of weight x is destroyed, and the stone of weight y has new weight y - x.
At the end of the game, there is at most one stone left.
Return the weight of the last remaining stone. If there are no stones left, return 0.

Example 1:
Input: stones = [2,7,4,1,8,1]
Output: 1
Explanation:
We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
we combine 1 and 1 to get 0 so the array converts to [1] then that's the value of the last stone.

Example 2:
Input: stones = [1]
Output: 1

Constraints:
1 <= stones.length <= 30
1 <= stones[i] <= 1000
*/


// TODO: Implement solution

int LastStoneWeight(int[] stones)
{
    var pQueue = new PriorityQueue(stones);
    while(pQueue.Count > 1)
    {
        int x = pQueue.Dequeue();
        int y = pQueue.Dequeue();
        if(x!=y)
        {
            pQueue.Insert(x-y);
        }
    }
    return pQueue.Dequeue();
}


List<int[]> testcases = [
    [2,7,4,1,8,1],
    [1]
];

foreach (var stones in testcases)
{
    Console.WriteLine($"Testcase: stones-[{String.Join(',', stones)}]");
    Console.WriteLine($"LastStoneWeight - {LastStoneWeight(stones)}");
}


public class PriorityQueue
{
    private readonly List<int> _heap; 
    private int LeftNode(int i) => 2 * i;
    private int RightNode(int i) => (2 * i) + 1;
    private int ParentNode (int i) => i/2;
    public PriorityQueue(IEnumerable<int> items)
    {
        _heap=[];
        foreach(int item in items)
        {
            Insert(item);
        }
    }
    public int Count => _heap.Count;

    public void Insert(int element)
    {
        _heap.Add(element);
        HeapifyUp(_heap.Count -1);
    }

    public int Dequeue()
    {
        if(_heap.Count < 1)
        {
            return 0;
        }
        int maxVal = _heap[0];
        _heap[0] = _heap[^1];
        _heap.RemoveAt(_heap.Count-1);
        int i =0;
        while (i < _heap.Count)
        {
            int largest = i;
            int left = LeftNode(i);
            int right = RightNode(i);

            if (left < _heap.Count && _heap[left] > _heap[largest])
                largest = left;

            if (right < _heap.Count && _heap[right] > _heap[largest])
                largest = right;

            if (largest == i)
            {
                break; 
            }
            (_heap[i],_heap[largest]) = (_heap[largest],_heap[i]);
            i=largest;
        }
        return maxVal;
    }
    private void HeapifyUp(int i)
    {
        while (i > 0 && _heap[ParentNode(i)] < _heap[i])
        {
            (_heap[i], _heap[ParentNode(i)]) = (_heap[ParentNode(i)],_heap[i]);
            i = ParentNode(i);
        }
    }


}
