/*
Given an m x n grid of characters board and a string word, return true if word exists in the grid.
The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighboring.
The same letter cell may not be used more than once.

Example 1:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true

Example 2:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true

Example 3:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false

Constraints:
m == board.length
n == board[i].length
1 <= m, n <= 6
1 <= word.length <= 15
board and word consists of only lowercase and uppercase English letters.
*/


// TODO: Implement solution
List<(int xDelta,int yDelta)> deltas; 
bool exist;
public bool Exist(char[][] board, string word)
{
    deltas = [
    (0,1),
    (0,-1),
    (1,0),
    (-1,0)
];
    exist=false;
    for(int i=0;i<board.Length;i++)
    {
        for(int j=0;j<board[0].Length;j++)
        {
            if(BackTrack(0,(i,j),board,word))
                return true;
        }
    }
    return false;

}

bool BackTrack(int currentIndex,(int x, int y) location, char[][] board, string word)
{
    if(!IsInvalidPosition(currentIndex,(location.x,location.y),board,word) && board[location.x][location.y]==word[currentIndex])
    {
        if(currentIndex == (word.Length-1))
        {
            return true;
        }
        board[location.x][location.y]='#';
        foreach ((int xDelta,int yDelta) in deltas)
        {
            if(BackTrack(currentIndex+1,(location.x+xDelta,location.y+yDelta),board,word))
            {
                return true;
            }
        }
        board[location.x][location.y]=word[currentIndex];
    }
    return false;
}

bool IsInvalidPosition(int currentIndex,(int x, int y) location, char[][] board, string word)
{
    return location.x < 0 || location.x >= board.Length || location.y < 0 || location.y >= board[0].Length || currentIndex >= word.Length;
}

List<(char[][] board, string word)> testcases = [
    ([
        ['A','B','C','E'],
        ['S','F','C','S'],
        ['A','D','E','E']
    ], "ABCCED"),
    ([
        ['A','B','C','E'],
        ['S','F','C','S'],
        ['A','D','E','E']
    ], "SEE"),
    ([
        ['A','B','C','E'],
        ['S','F','C','S'],
        ['A','D','E','E']
    ], "ABCB"),
    ([['a']],"a")
];

foreach (var (board, word) in testcases)
{
    Console.WriteLine($"Testcase: board-\n{String.Join("\n", board.Select(row => $"[{String.Join(',', row)}]"))} word-{word}");
    Console.WriteLine($"Exist - {Exist(board, word)}");
}
