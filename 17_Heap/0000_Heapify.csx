using System;

class MinHeap
{
    private int[] heap;
    private int size;

    public MinHeap(int[] array, int k)
    {
        heap = array; // Use original array
        size = k;  // Only consider first k elements for heap
        BuildMinHeap();

        // Process remaining elements
        for (int i = k;   i < array.Length; i++)
        {
            if (array[i] > heap[0]) // Compare with root
            {
                heap[0] = array[i]; // Replace root
                HeapifyDown(0); // Restore heap property
            }
        }
    }

    // Get left and right child indexes
    private int LeftChild(int i) => 2 * i + 1;
    private int RightChild(int i) => 2 * i + 2;

    // Heapify Down (used to maintain min heap property)
    private void HeapifyDown(int index)
    {
        int smallest = index;
        int left = LeftChild(index);
        int right = RightChild(index);

        if (left < size && heap[left] < heap[smallest])
            smallest = left;

        if (right < size && heap[right] < heap[smallest])
            smallest = right;

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    // Build Min Heap (Bottom-Up approach)
    private void BuildMinHeap()
    {
        for (int i = (size / 2) - 1; i >= 0; i--)
        {
            HeapifyDown(i);
        }
    }

    // Swap elements in the heap
    private void Swap(int i, int j)
    {
        (heap[j], heap[i]) = (heap[i], heap[j]);
    }

    // Print only the heap portion
    public void PrintHeap()
    {
        Console.WriteLine(string.Join(" ", heap[..size])); // Print first k elements
    }

    public int GetKthLargest()
    {
        return heap[0]; // Root contains Kth largest element
    }
}


int[] array = { 10, 20, 15, 30, 40, 50, 5 };
Console.WriteLine("Original Array: " + string.Join(" ", array));
int k = 3;

MinHeap minHeap = new MinHeap(array, k);

Console.WriteLine($"Converted Min Heap (first {k} elements):");
minHeap.PrintHeap();

Console.WriteLine($"{k}th Largest Element: {minHeap.GetKthLargest()}");

