/*
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0's (water), return the number of islands.
An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

Example 1:
Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:
Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
 

Constraints:

m == grid.length
n == grid[i].length
1 <= m, n <= 300
grid[i][j] is '0' or '1'.
*/


public static class Solution {
    public static int NumIslands(char[][] grid) {
        int islands = 0;
        for(int row = 0; row < grid.Length; row++)
        {
            for(int column = 0; column < grid[0].Length; column++)
            {
                if(grid[row][column] == '1')
                {
                    Traverse(row,column,grid);
                    islands++;
                }
            }
        }
        return islands;
    }

    private static void Traverse(int row, int column,char[][] grid)
    {
        int rowLength = grid.Length;
        int columnLength = grid[0].Length;
        if(grid[row][column] == '1')
        {
            grid[row][column]= '0';
            if(row != 0)
            {
                Traverse(row-1,column,grid);           
            }
            if(row+1 != rowLength)
            {
                Traverse(row+1,column,grid);
            }
            if (column !=0)
            {
                Traverse(row,column-1,grid);
            }
            if(column+1 != columnLength)
            {
                Traverse(row,column+1,grid);
            }
        }
    }
}

List<char[][]> testcases = [
    [
        ['1','1','1','1','0'],
        ['1','1','0','1','0'],
        ['1','1','0','0','0'],
        ['0','0','0','0','0']
    ],
    [
        ['1','1','0','0','0'],
        ['1','1','0','0','0'],
        ['0','0','1','0','0'],
        ['0','0','0','1','1']
    ],
    [
        ['1','1','1'],
        ['0','1','0'],
        ['1','1','1']
    ]
];

foreach(var testcase in testcases)
{
    Console.WriteLine($"{String.Join("\n",testcase.Select(row => String.Join(",",row)))}");
    Console.WriteLine($"Number of Islands - {Solution.NumIslands(testcase)}");
}



