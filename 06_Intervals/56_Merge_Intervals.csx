/*
Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input.

Example 1:
Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
Output: [[1,6],[8,10],[15,18]]
Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].

Example 2:
Input: intervals = [[1,4],[4,5]]
Output: [[1,5]]
Explanation: Intervals [1,4] and [4,5] are considered overlapping.
 

Constraints:

1 <= intervals.length <= 104
intervals[i].length == 2
0 <= starti <= endi <= 104
*/

public int[][] Merge(int[][] intervals)
{
   //Assuming the Array is sorted.
    if (intervals.Length < 1)
        return [];
     Array.Sort(intervals, (x,y) => x[0].CompareTo(y[0]));
    int start = intervals[0][0];
    int end = intervals[0][1];
    int [] range;
    List<int[]> result = new();
    for (int i =1; i<intervals.Length ; i++ )
    {
        range = intervals[i];
        if (range[0] > end)
        {
            result.Add(new int[] { start, end });
            start = range[0];
            end = range[1];
            continue;
        }
         start = Math.Min(range[0],start);
        end = Math.Max(range[1],end);
    }
    if (start <= end)
    {
        result.Add(new int[] { start, end });
    }
    return result.ToArray();
}

List<int[][]> testcases = new()
{
    new int[][] {
       [1,3],[2,6],[8,10],[15,18]
    },
    new int[][] {
        [1,4],[4,5]
    },
    new int[][]
    {
        [1,4],[0,4]
    }
};

foreach (var testcase in testcases)
{
    Console.WriteLine($"{String.Join('|', testcase.Select(row => String.Join(',', row)))}");
    var merged = Merge(testcase);
    Console.WriteLine($"Merged - {String.Join('|', merged.Select(row => String.Join(',', row)))} ");
}