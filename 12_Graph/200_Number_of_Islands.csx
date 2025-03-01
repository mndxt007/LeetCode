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
        HashSet< Tuple<int,int>> visited = new();
        int islands = 0;
        for(int row = 0; row < grid.Length; row++)
        {
            for(int column = 0; column < grid[0].Length; column++)
            {
                if(grid[row][column] == '1' && !visited.Contains(Tuple.Create<int,int>(row,column)))
                {
                    BFS(row,column,grid,visited);
                    islands++;
                }
            }
        }
        return islands;
    }

    private static void BFS(int row, int column,char[][] grid,HashSet< Tuple<int,int>> visited)
    {
        Queue<Tuple<int,int>> queue = new();
        int rowLength = grid.Length;
        int columnLength = grid[0].Length;
        queue.Enqueue(Tuple.Create<int,int>(row,column));
        while (queue.Count > 0) 
        {
            Tuple<int,int> current = queue.Dequeue();
            row = current.Item1; column=current.Item2;
            if(grid[row][column] == '1' && !visited.Contains(current))
            {
                if(row != 0)
                {
                    queue.Enqueue(Tuple.Create<int,int>(row-1,column));            
                }
                if(row+1 != rowLength)
                {
                    queue.Enqueue(Tuple.Create<int,int>(row+1,column));
                }
                if (column !=0)
                {
                    queue.Enqueue(Tuple.Create<int,int>(row,column-1));
                }
                if(column+1 != columnLength)
                {
                    queue.Enqueue(Tuple.Create<int,int>(row,column+1));
                }
                visited.Add(current);
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
    ]
];

foreach(var testcase in testcases)
{
    Console.WriteLine($"{String.Join("\n",testcase.Select(row => String.Join(",",row)))}");
    Console.WriteLine($"Number of Islands - {Solution.NumIslands(testcase)}");
}



