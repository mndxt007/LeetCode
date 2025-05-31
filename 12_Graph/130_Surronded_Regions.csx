/*
You are given an m x n matrix board containing letters 'X' and 'O', capture regions that are surrounded:
Connect: A cell is connected to adjacent cells horizontally or vertically.
Region: To form a region connect every 'O' cell.
Surround: The region is surrounded with 'X' cells if you can connect the region with 'X' cells and none of the region cells are on the edge of the board.
To capture a surrounded region, replace all 'O's with 'X's in-place within the original board. You do not need to return anything.

Example 1:
Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O","X","X"]]
Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]]
Explanation:
In the above diagram, the bottom region is not captured because it is on the edge of the board and cannot be surrounded.


Example 2:
Input: board = [["X"]]
Output: [["X"]]
 

Constraints:

m == board.length
n == board[i].length
1 <= m, n <= 200
board[i][j] is 'X' or 'O'.
*/

HashSet<(int, int)> NotRegion = [];

void Traverse(int row, int column, char[][] board)
{
    //return if conditions are not met:
    int rowLength = board.Length;
    int columnLength = board[0].Length;

    if (row >= rowLength | column >= columnLength | row < 0 | column < 0)
        return;

    if (board[row][column] == 'O' && !(NotRegion.Contains((row,column))))
    {
        NotRegion.Add((row, column));
        Traverse(row+1, column, board);
        Traverse(row-1, column, board);
        Traverse(row, column-1, board);
        Traverse(row, column+1, board);
    }
}

public void Solve(ref char[][] board)
{
    //Step 1 -> Start from boundary
    int rowLength = board.Length;
    int columnLength = board[0].Length;
    int row = 0;
    int column = 0;
    #region //Step 1 -> Start from boundary
    for (int i = 0; i < 4; i++)
    {
        switch (i)
        {
            case 0:
                for (; column < columnLength; column++)
                {
                    Traverse(row, column, board);
                }
                column--;
                break;
            case 1:
                for (; row < rowLength; row++)
                {
                    Traverse(row, column, board);
                }
                row--;
                break;
            case 2:
                for (; column > -1; column--)
                {
                    Traverse(row, column, board);
                }
                column++;
                break;
            case 3:
                for (; row > -1; row--)
                {
                    Traverse(row, column, board);
                }
                row++;
                break;
        }
    }
    #endregion
    #region //Step2 -> Claim all regions not surronded
    for (int r = 1; r < rowLength-1; r++)
    {
        for (int c = 1; c < columnLength - 1;c++)
        {
            if(board[r][c]=='O' && !(NotRegion.Contains((row,column))))
            {
                board[r][c] = 'X';
            }
        }
    }
    #endregion
}

List<char[][]> testcases = [
    [
       ['X','X','X','X'],
       ['X','O','O','X'],
       ['X','X','O','X'],
       ['X','O','X','X']
    ],
    [
        ['X']
    ],
    [
        ['O','O'],
        ['O','O']
    ]
];

for (int i = 0; i < testcases.Count; i++)
{
    var testcase = testcases[i];
    Console.WriteLine(
        $"Original Matrix:\n====\n{String.Join("\n", testcase.Select(x => String.Join(",", x)))}\n===="
    );
    Solve(ref testcase);
    Console.WriteLine(
        $"After Solving:\n====\n{String.Join("\n", testcase.Select(x => String.Join(",", x)))}\n===="
    );
}