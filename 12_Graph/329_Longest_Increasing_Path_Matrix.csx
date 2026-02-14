/*
Given an m x n integers matrix, return the length of the longest increasing path in matrix.

From each cell, you can either move in four directions: left, right, up, or down. You may not move diagonally or move outside the boundary (i.e., wrap-around is not allowed).

Example 1:
Input: matrix = [[9,9,4],[6,6,8],[2,1,1]]
Output: 4
Explanation: The longest increasing path is [1, 2, 6, 9].

Example 2:
Input: matrix = [[3,4,5],[3,2,6],[2,2,1]]
Output: 4
Explanation: The longest increasing path is [3, 4, 5, 6]. Moving diagonally is not allowed.

Example 3:
Input: matrix = [[1]]
Output: 1

Constraints:
m == matrix.length
n == matrix[i].length
1 <= m, n <= 200
0 <= matrix[i][j] <= 231 - 1
*/

//Leave space for implementation here
int[][] visited;
(int,int)[] DFSMap = [
    (0,1),
    (0,-1),
    (1,0),
    (-1,0)
];

public int LongestIncreasingPath(int[][] matrix)
{
    //create a cache
    visited = new int[matrix.Length][];
    int maxSequence=0;
    for(int i=0; i < matrix.Length; i++)
    {
        visited[i] = new int[matrix[0].Length];
    }
    //run DFS
    for(int r=0; r<matrix.Length;r++)
    {
        for(int c=0; c<matrix[0].Length;c++)
        {
            maxSequence= Math.Max(DFS(matrix,(r,c)),maxSequence);
        }
    }

    return maxSequence;
}

int DFS(int[][] matrix, (int r, int c) location)
{
    int visitedVal = visited[location.r][location.c];
    if (visitedVal > 0)
    {
        return visitedVal;
    }
    
    int maxSequence = 1;
    foreach (var (dr, dc) in DFSMap)
    {
        int nextR = location.r + dr;
        int nextC = location.c + dc;
        if (IsNextLocationValid(matrix, nextR, nextC) && 
            matrix[nextR][nextC] > matrix[location.r][location.c])
        {
            maxSequence = Math.Max(1+DFS(matrix, (nextR, nextC)), maxSequence);
        }
    }
    
    visited[location.r][location.c] = maxSequence;
    return maxSequence;
}


bool IsNextLocationValid(int[][] matrix,int r,int c)
{
    return (r < 0 || r >= matrix.Length) && (c < 0 || c >= matrix[0].Length);
}


List<int[][]> testcases = [
    [[9,9,4],[6,6,8],[2,1,1]],
    [[3,4,5],[3,2,6],[2,2,1]],
    [[1]]
];

foreach (var matrix in testcases)
{
    Console.WriteLine($"Testcase: matrix- [{string.Join("],[", matrix.Select(row => string.Join(",", row)))}]");
    Console.WriteLine($"LongestIncreasingPath - {LongestIncreasingPath(matrix)}");
}
