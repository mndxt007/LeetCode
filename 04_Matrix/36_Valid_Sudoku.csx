/*
Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:

Each row must contain the digits 1-9 without repetition.
Each column must contain the digits 1-9 without repetition.
Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
Note:

A Sudoku board (partially filled) could be valid but is not necessarily solvable.
Only the filled cells need to be validated according to the mentioned rules.
 

Example 1:


Input: board = 
[['5','3','.','.','7','.','.','.','.']
,['6','.','.','1','9','5','.','.','.']
,['.','9','8','.','.','.','.','6','.']
,['8','.','.','.','6','.','.','.','3']
,['4','.','.','8','.','3','.','.','1']
,['7','.','.','.','2','.','.','.','6']
,['.','6','.','.','.','.','2','8','.']
,['.','.','.','4','1','9','.','.','5']
,['.','.','.','.','8','.','.','7','9']]
Output: true
Example 2:

Input: board = 
[['8','3','.','.','7','.','.','.','.']
,['6','.','.','1','9','5','.','.','.']
,['.','9','8','.','.','.','.','6','.']
,['8','.','.','.','6','.','.','.','3']
,['4','.','.','8','.','3','.','.','1']
,['7','.','.','.','2','.','.','.','6']
,['.','6','.','.','.','.','2','8','.']
,['.','.','.','4','1','9','.','.','5']
,['.','.','.','.','8','.','.','7','9']]
Output: false
Explanation: Same as Example 1, except with the 5 in the top left corner being modified to 8. Since there are two 8's in the top left 3x3 sub-box, it is invalid.
 

Constraints:

board.length == 9
board[i].length == 9
board[i][j] is a digit 1-9 or '.'.
*/

public bool IsValidSudoku(char[][] board)
{
    HashSet<char> nonDupes = [];
    int count = 0;
    //Check Sub-Boxes
    List<(int, int)> subBoxStarts = [(0, 0), (0, 3), (0, 6), (3, 0), (3, 3), (3, 6), (6, 0), (6, 3), (6, 6)];
    foreach (var (row, column) in subBoxStarts)
    {
        for (int r = row; r < row + 3; r++)
        {
            for (int c = column; c < column + 3; c++)
            {
                if (board[r][c] != '.')
                {
                    nonDupes.Add(board[r][c]);
                    count++;
                }
            }
        }
        if (count > nonDupes.Count)
            return false;
        count = 0;
        nonDupes = [];
    }
    
    //Check Colums
    for (int c = 0; c < 9; c++)
    {
        for (int r = 0; r < 9; r++)
        {
            if (board[r][c] != '.')
            {
                nonDupes.Add(board[r][c]);
                count++;
            }
        }
        if (count > nonDupes.Count)
            return false;
        count = 0;
        nonDupes = [];
    }

    //Check  Rows
    for (int r = 0; r < 9; r++)
    {
        for (int c = 0; c < 9; c++)
        {
            if (board[r][c] != '.')
            {
                nonDupes.Add(board[r][c]);
                count++;
            }
        }
        if (count > nonDupes.Count)
            return false;
        count = 0;
        nonDupes = [];
    }
    return true;
}

List<char[][]> testcases = [
    [
         ['5','3','.','.','7','.','.','.','.']
        ,['6','.','.','1','9','5','.','.','.']
        ,['.','9','8','.','.','.','.','6','.']
        ,['8','.','.','.','6','.','.','.','3']
        ,['4','.','.','8','.','3','.','.','1']
        ,['7','.','.','.','2','.','.','.','6']
        ,['.','6','.','.','.','.','2','8','.']
        ,['.','.','.','4','1','9','.','.','5']
        ,['.','.','.','.','8','.','.','7','9']
    ],
    [
         ['8','3','.','.','7','.','.','.','.']
        ,['6','.','.','1','9','5','.','.','.']
        ,['.','9','8','.','.','.','.','6','.']
        ,['8','.','.','.','6','.','.','.','3']
        ,['4','.','.','8','.','3','.','.','1']
        ,['7','.','.','.','2','.','.','.','6']
        ,['.','6','.','.','.','.','2','8','.']
        ,['.','.','.','4','1','9','.','.','5']
        ,['.','.','.','.','8','.','.','7','9']
    ]
];

foreach (var item in testcases)
{
    Console.WriteLine("TestCase -");

    Console.WriteLine("[");
    for (int i = 0; i < item.Length; i++)
    {
        string rowString = " ['" + string.Join("','", item[i]) + "']";
        Console.WriteLine(i == item.Length - 1 ? rowString : rowString + ",");
    }
    Console.WriteLine("]");

    Console.WriteLine($"Result - {IsValidSudoku(item)}");
    Console.WriteLine(); // Extra space between test cases
}
