/*
https://leetcode.com/problems/check-if-every-row-and-column-contains-all-numbers/description/
An n x n matrix is valid if every row and every column contains all the integers from 1 to n (inclusive).

Given an n x n integer matrix matrix, return true if the matrix is valid. Otherwise, return false.

 

Example 1:


Input: matrix = [[1,2,3],[3,1,2],[2,3,1]]
Output: true
Explanation: In this case, n = 3, and every row and column contains the numbers 1, 2, and 3.
Hence, we return true.
Example 2:


Input: matrix = [[1,1,1],[1,2,3],[1,2,3]]
Output: false
Explanation: In this case, n = 3, but the first row and the first column do not contain the numbers 2 or 3.
Hence, we return false.
 

Constraints:

n == matrix.length == matrix[i].length
1 <= n <= 100
1 <= matrix[i][j] <= n
*/

public static class Solution {
    public static bool CheckValid(int[][] matrix) {
        int expectedSum = Enumerable.Range(1,matrix.Length).Sum();
        //this one breaks my logic - [[2,2,2],[2,2,2],[2,2,2]]
        foreach (var row in matrix)
        {
            if(row.Sum()!=expectedSum)
            {
                return false;
            }
        }

        for(int i=0;i<matrix.Length;i++)
        {
            var columnsum = matrix.Select(
                array => array[i]
            ).Sum();
             if(columnsum!=expectedSum)
            {
                return false;
            }
        }

        return true;
        
    }
}

List<int[][]> testcases = new()
{
    new int[][]{[1,2,3],[3,1,2],[2,3,1]},
    new int[][]{[1,1,1],[1,2,3],[1,2,3]},
    new int[][]{[2,2,2],[2,2,2],[2,2,2]}
};

foreach (var case_ in testcases)
{
    Console.WriteLine($"Test Case - {String.Join("  ",case_.Select(innerList => string.Join(",", innerList)))}");
    Console.WriteLine($"CheckValid - {Solution.CheckValid(case_)}");
}