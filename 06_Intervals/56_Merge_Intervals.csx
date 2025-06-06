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
    if (intervals.Length < 1)
        return [];
    var orderInterval = intervals.OrderBy(rangeorder => rangeorder[0]);
    int start = orderInterval.FirstOrDefault()[0];
    int end = orderInterval.FirstOrDefault()[1];

    List<int[]> result = new();
    foreach (var range in orderInterval.Skip(1))
    {
        if (range[0] > end)
        {
            result.Add(new int[] { start, end });
            start = range[0];
            end = range[1];
            continue;
        }
        start = start > range[0] ? range[0] : start;
        end = end < range[1] ? range[1] : end;
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
    },
    new int[][]
    {
        [1,4],[0,0]
    }
};

foreach (var testcase in testcases)
{
    Console.WriteLine($"{String.Join('|', testcase.Select(row => String.Join(',', row)))}");
    var merged = Merge(testcase);
    Console.WriteLine($"Merged - {String.Join('|', merged.Select(row => String.Join(',', row)))} ");
}