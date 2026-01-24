/*
Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.
 
Example 1:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]

Example 2:
Input: nums = [1], k = 1
Output: [1]

Example 3:
Input: nums = [1,2,1,2,1,2,3,1,3,2], k = 2
Output: [1,2]
 
Constraints:
1 <= nums.length <= 105
-104 <= nums[i] <= 104
k is in the range [1, the number of unique elements in the array].
It is guaranteed that the answer is unique.
 
Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
*/

public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int,int> dict = [];
        int[] result = new int[k];
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(nums[i]))
            {
                dict[nums[i]]--;
            }
            else
            {
                dict.Add(nums[i], -1);
            }
        }
        PriorityQueue<int, int> queue = new(dict.Select(kvp => (kvp.Key, kvp.Value)));;
        for(int i=0; i < k ; i++)
        {
            result[i]=queue.Dequeue();;
        }
        return result;
    }


List<(int[] nums, int k)> testcases = [
    (new int[]{1,1,1,2,2,3}, 2),
    (new int[]{1}, 1),
    (new int[]{1,2,1,2,1,2,3,1,3,2}, 2)
];

foreach (var (nums, k) in testcases)
{
    Console.WriteLine($"Testcase: nums=[{String.Join(',', nums)}] k={k}");
    Console.WriteLine($"TopKFrequent - [{String.Join(',', TopKFrequent(nums, k))}]");
}