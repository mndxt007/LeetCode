/*
You are given two integer arrays nums1 and nums2 sorted in non-decreasing order and an integer k.

Define a pair (u, v) which consists of one element from the first array and one element from the second array.

Return the k pairs (u1, v1), (u2, v2), ..., (uk, vk) with the smallest sums.

Example 1:
Input: nums1 = [1,7,11], nums2 = [2,4,6], k = 3
Output: [[1,2],[1,4],[1,6]]
Explanation: The first 3 pairs are returned from the sequence: [1,2],[1,4],[1,6],[7,2],[7,4],[11,2],[7,6],[11,4],[11,6]

Example 2:
Input: nums1 = [1,1,2], nums2 = [1,2,3], k = 2
Output: [[1,1],[1,1]]
Explanation: The first 2 pairs are returned from the sequence: [1,1],[1,1],[1,2],[2,1],[1,2],[2,2],[1,3],[1,3],[2,3]


Constraints:

1 <= nums1.length, nums2.length <= 105
-109 <= nums1[i], nums2[i] <= 109
nums1 and nums2 both are sorted in non-decreasing order.
1 <= k <= 104
k <= nums1.length * nums2.length
*/


public static class Solution {
    public static IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k) {
        IList<IList<int>> kSmallestPairs = [];
        PriorityQueue<ValueTuple<int,int>,int> queue = new();
        HashSet<ValueTuple<int,int>> visited = new();
        ValueTuple<int,int> tuple;
        int i;
        int j;
        queue.Enqueue((0,0), nums1[0]+nums2[0]);
        visited.Add((0,0));
        while(k-- > 0 && queue.Count > 0)
        {
            tuple = queue.Dequeue();
            i = tuple.Item1; j= tuple.Item2;
            kSmallestPairs.Add([nums1[i],nums2[j]]);      
            if(i+1 < nums1.Length && !visited.Contains((i+1,j)))
            {
                queue.Enqueue((i+1,j), nums1[i+1]+nums2[j]);
                visited.Add((i+1,j));
            }
            if(j+1 < nums2.Length && !visited.Contains((i,j+1)))
            {
                queue.Enqueue((i,j+1), nums1[i]+nums2[j+1]);
                visited.Add((i,j+1));
            }
        }
        return kSmallestPairs;
    }
}

public record TestCase(int[] nums1,int[] nums2,int k)
{
    public int[] Nums1 => nums1;
    public int[] Nums2 => nums2;
    public int K  => k;
}

List<TestCase> testCases = [
    new ([1,7,11],[2,4,6],3),
    new ([1,1,2],[1,2,3],2),
];

foreach(var testcase in testCases)
{
    Console.WriteLine($"Testcase -> nums1 - [{String.Join(',',testcase.Nums1)}] \t nums2 [{String.Join(',',testcase.Nums2)}] \t k - {testcase.K} ");
    var result = Solution.KSmallestPairs(testcase.Nums1,testcase.Nums2,testcase.K);
    Console.WriteLine($"KSmallestPairs - {String.Join('|',result.Select(pair => String.Join(',',pair)))}");
}