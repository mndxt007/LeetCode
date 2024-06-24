/*
https://leetcode.com/problems/minimum-area-rectangle/description/

You are given an array of points in the X-Y plane points where points[i] = [xi, yi].

Return the minimum area of a rectangle formed from these points, with sides parallel to the X and Y axes. If there is not any such rectangle, return 0.

Example 1:


Input: points = [[1,1],[1,3],[3,1],[3,3],[2,2]]
Output: 4
Example 2:


Input: points = [[1,1],[1,3],[3,1],[3,3],[4,1],[4,3]]
Output: 2
 

Constraints:

1 <= points.length <= 500
points[i].length == 2
0 <= xi, yi <= 4 * 104
All the given points are unique.
*/


public static class Solution
{
    public static int MinAreaRect(int[][] points)
    {
        int minLength = Int16.MaxValue;
        int minHieght = Int16.MaxValue;
        Dictionary<int, HashSet<int>> xpointsGrouped = new();
        for (int i = 0; i < points.Length; i++)
        {
            if (xpointsGrouped.ContainsKey(points[i][0]))
            {
                xpointsGrouped[points[i][0]].Add(points[i][1]);
            }
            else
            {
                xpointsGrouped.Add(points[i][0], new HashSet<int> { points[i][1] });
            }
        }
        var sxpointsGrouped = xpointsGrouped.Where(item => item.Value.Count > 1).OrderBy(x => x.Key);
        if (sxpointsGrouped.Count() > 1)
        {
            var currX = sxpointsGrouped.First();
            var prevX = sxpointsGrouped.ElementAt(1);
            if (currX.Value.Intersect(prevX.Value).Count() > 1)
            {
                minHieght = FindMinDifference(sxpointsGrouped.First().Value.ToList<int>());
                minLength = (prevX.Key - currX.Key);
            }

            foreach (var xpoint in sxpointsGrouped.Skip(2))
            {
                if (xpoint.Value.Intersect(prevX.Value).Count() > 1)
                {
                    minHieght = Math.Min(minHieght, FindMinDifference(xpoint.Value.ToList<int>()));
                    minLength = Math.Min(minLength, xpoint.Key - prevX.Key);
                }
                prevX = xpoint;
            }
            return (minHieght==Int16.MaxValue ? 0 :  minHieght)  * (minLength ==Int16.MaxValue ? 0 : minLength) ;
        }
        else
        {
            return 0;
        }
    }

    private static int FindMinDifference(List<int> pointsY)
    {
        pointsY.Sort();
        int minDiff = pointsY[1] - pointsY[0];
        for (int i = 2; i != pointsY.Count; i++)
        {
            minDiff = Math.Min(minDiff, pointsY[i] - pointsY[i - 1]);
        }
        return minDiff;
    }
}


List<List<int[]>> testcases = [
    [[1,1],[1,3],[3,1],[3,3],[2,2]],
    [[1,1],[1,3],[3,1],[3,3],[4,1],[4,3]],
    [[3,2],[3,1],[4,4],[1,1],[4,3],[0,3],[0,2],[4,0]],
    [[0,1],[1,3],[3,3],[4,4],[1,4],[2,3],[1,0],[3,4]],
    [[1,1],[1,3],[3,1],[3,3],[4,1],[4,3]],
    [[3,2],[0,0],[3,3],[3,4],[4,4],[2,1],[4,3],[1,0],[4,1],[0,2]],
    [[1,1],[1,3],[3,1],[3,3],[2,2]]
];

foreach (var item in testcases)
{
    Console.WriteLine($"Testcase - {String.Join("|", item.Select(i => String.Join(",", i)))}");
    Console.WriteLine($"Minimum Rectangle Area - {Solution.MinAreaRect(item.ToArray())}");
}
