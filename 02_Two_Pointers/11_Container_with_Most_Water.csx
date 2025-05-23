/*
You are given an integer array height of length n. There are n vertical lines drawn such that the two endpoints of the ith line are (i, 0) and (i, height[i]).
Find two lines that together with the x-axis form a container, such that the container contains the most water.
Return the maximum amount of water a container can store.
Notice that you may not slant the container.

Example 1:
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.

Example 2:
Input: height = [1,1]
Output: 1
 
Constraints:
n == height.length
2 <= n <= 105
0 <= height[i] <= 104
*/

public int MaxArea(int[] height) 
{
    int start = 0;
    int end= height.Length-1;
    int curwidth,curheight;
    int area=0;
    while(start < end)
    {
        curwidth = end - start;
        curheight = Math.Min(height[start],height[end]);
        area = Math.Max(area,curheight*curwidth);
        if(height[start]<=height[end])
        {
            start++;
        }
        else
        {
            end--;
        }
    }
    return area;
}

List<int[]> testcases = [
    [1,8,6,2,5,4,8,3,7],
    [1,1],
    [1,2,4,3]
];

foreach(var testcase in testcases)
{
    Console.WriteLine($"hieght - [{String.Join(',',testcase)}]");
    Console.WriteLine($"Max area - {MaxArea(testcase)}");
}