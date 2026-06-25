/*
You are given an array target of n integers. From a starting array arr consisting of n 1's, you may perform the following procedure:

let x be the sum of all elements currently in your array.
choose index i, such that 0 <= i < n and set the value of arr at index i to x.
You may repeat this procedure as many times as needed.

Return true if it is possible to construct the target array from arr, otherwise, return false.

Example 1:
Input: target = [9,3,5]
Output: true
Explanation: Start with arr = [1, 1, 1]
[1, 1, 1], sum = 3 choose index 1
[1, 3, 1], sum = 5 choose index 2
[1, 3, 5], sum = 9 choose index 0
[9, 3, 5] Done

Example 2:
Input: target = [1,1,1,2]
Output: false
Explanation: Impossible to create target array from [1,1,1,1].

Example 3:
Input: target = [8,5]
Output: true

Constraints:
n == target.length
1 <= n <= 5 * 10^4
1 <= target[i] <= 10^9
*/

bool IsPossible(int[] target)
{
    var heap = new MaxHeap(target);
    while(true)
    {
        long currentMax = heap.DeQueue();
        if(currentMax == 1)
            return true;

        long rest = heap.Sum - currentMax;

        if(rest == 1)
            return true;
        if(rest == 0 || rest >= currentMax)
            return false;

        long newVal = currentMax % rest;
        if(newVal == 0)
            return false;

        heap.Sum -= currentMax;
        heap.EnQueue(newVal);
        heap.Sum += newVal;
    }
}

List<int[]> testcases = [
    [9,3,5],
    [1,1,1,2],
    [8,5]
];

foreach (var target in testcases)
{
    Console.WriteLine($"Testcase: target-[{String.Join(',', target)}]");
    Console.WriteLine($"IsPossible - {IsPossible(target)}");
}

public class MaxHeap
{
    private readonly long[] _heap;
    public long Sum { get; set; }
    private int _heapLength;
    private static int Left(int parent)=> 2*parent+1;
    private static int Right(int parent)=> 2*parent+2;
    private static int Parent(int nodeIndex)=> (nodeIndex-1)/2;
    public MaxHeap(int[] heap)
    {
        _heap = heap.Select(x => (long)x).ToArray();
        _heapLength = _heap.Length;
         for (int i = _heap.Length - 1; i >= 0; i--)
        {
            Sum+=_heap[i];
            if(i <= (_heap.Length/2)-1)
                HeapifyDown(i);
        }
    }

    public long DeQueue()
    {
        if(_heapLength < 1)
            return -1;
        long result = _heap[0];
        _heap[0] = _heap[(_heapLength--)-1];
        HeapifyDown(0);
        return result;
    }
    public void EnQueue(long value)
    {
        if(_heapLength < _heap.Length)
        {
           _heap[(++_heapLength)-1] = value;
           HeapifyUp(_heapLength-1);
           return;
        }
        throw new InvalidOperationException("Insert failed");
    }


    private void HeapifyUp(int index)
    {
        if(index <= 0) return;
        int parentIndex = Parent(index);
        if(_heap[parentIndex] < _heap[index])
        {
            (_heap[parentIndex],_heap[index]) = (_heap[index],_heap[parentIndex]);
            HeapifyUp(parentIndex);
        }
    }

    private void HeapifyDown(int index)
    {
        int largest = index;
        int leftNodeIndex = Left(index);
        int rightNodeIndex = Right(index);

        if(leftNodeIndex < _heapLength && _heap[largest] < _heap[leftNodeIndex])
            largest = leftNodeIndex;
        if(rightNodeIndex < _heapLength && _heap[largest] < _heap[rightNodeIndex])
            largest = rightNodeIndex;
        if(index !=largest)
        {
            (_heap[index],_heap[largest]) = (_heap[largest],_heap[index]);
            HeapifyDown(largest);
        }
    }
}
