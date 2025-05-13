/*
You are given an n x n integer matrix board where the cells are labeled from 1 to n2 in a Boustrophedon style starting from the bottom left of the board (i.e. board[n - 1][0]) and alternating direction each row.

You start on square 1 of the board. In each move, starting from square curr, do the following:

Choose a destination square next with a label in the range [curr + 1, min(curr + 6, n2)].
This choice simulates the result of a standard 6-sided die roll: i.e., there are always at most 6 destinations, regardless of the size of the board.
If next has a snake or ladder, you must move to the destination of that snake or ladder. Otherwise, you move to next.
The game ends when you reach the square n2.
A board square on row r and column c has a snake or ladder if board[r][c] != -1. The destination of that snake or ladder is board[r][c]. Squares 1 and n2 are not the starting points of any snake or ladder.

Note that you only take a snake or ladder at most once per dice roll. If the destination to a snake or ladder is the start of another snake or ladder, you do not follow the subsequent snake or ladder.

For example, suppose the board is [[-1,4],[-1,3]], and on the first move, your destination square is 2. You follow the ladder to square 3, but do not follow the subsequent ladder to 4.
Return the least number of dice rolls required to reach the square n2. If it is not possible to reach the square, return -1.

Example 1:
Input: board = [[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,-1,-1,-1,-1,-1],[-1,35,-1,-1,13,-1],[-1,-1,-1,-1,-1,-1],[-1,15,-1,-1,-1,-1]]
Output: 4
Explanation: 
In the beginning, you start at square 1 (at row 5, column 0).
You decide to move to square 2 and must take the ladder to square 15.
You then decide to move to square 17 and must take the snake to square 13.
You then decide to move to square 14 and must take the ladder to square 35.
You then decide to move to square 36, ending the game.
This is the lowest possible number of moves to reach the last square, so return 4.

Example 2:
Input: board = [[-1,-1],[-1,3]]
Output: 1
*/


public int SnakesAndLadders(int[][] board)
{
    Queue<ValueTuple<int, int>> queue = new();
    int level = -1;
    HashSet<int> visited = new();
    queue.Enqueue((1, 0));
    int currentpos = 1;
    int length = board.Length;
    int last = length * length;
    while (queue.Count > 0)
    {
        (currentpos, level) = queue.Dequeue();
        for (int next = 1; next <= 6; next++)
        {
            int nextpos = currentpos+next;
            var indices = GetPosition(nextpos, length);
            nextpos = board[indices.Item1][indices.Item2] == -1 ? nextpos : board[indices.Item1][indices.Item2];
            if (nextpos == last)
            {
                return level+1;
            }
            if (!visited.Contains(nextpos))
            {
                visited.Add(nextpos);
                queue.Enqueue((nextpos,level+1));
            }
        }
    }
    return -1;
}

private (int, int) GetPosition(int s, int n)
{
    int quot = (s - 1) / n;
    int rem = (s - 1) % n;
    int row = n - 1 - quot;  // Convert to board's row index (bottom row is at index n-1)
    int col = (quot % 2 == 0) ? rem : n - 1 - rem;  // Reverse column order on alternating rows
    return (row, col);
}


List<int[][]> testcases = [
    [
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,35,-1,-1,13,-1],
        [-1,-1,-1,-1,-1,-1],
        [-1,15,-1,-1,-1,-1]
    ],
    [
        [-1,-1],
        [-1,3]
    ],
    [
        [-1,-1,-1],
        [-1,9,8],
        [-1,8,9]
    ],
    [
        [1,1,-1],
        [1,1,1],
        [-1,1,1]
    ],
    [
        [-1,-1,-1,46,47,-1,-1,-1],
        [51,-1,-1,63,-1,31,21,-1],
        [-1,-1,26,-1,-1,38,-1,-1],
        [-1,-1,11,-1,14,23,56,57],
        [11,-1,-1,-1,49,36,-1,48],
        [-1,-1,-1,33,56,-1,57,21],
        [-1,-1,-1,-1,-1,-1,2,-1],
        [-1,-1,-1,8,3,-1,6,56]
    ],
    [
        [1,1,-1],
        [1,1,1],
        [-1,1,1]
    ],
    [
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1],
        [-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1]
    ]
];

int[][] testindex = [
    [36, 35, 34, 33, 32, 31],
    [25, 26, 27, 28, 29, 30],
    [24, 23, 22, 21, 20, 19],
    [13, 14, 15, 16, 17, 18],
    [12, 11, 10, 9, 8, 7],
    [1, 2, 3, 4, 5, 6]
];

// for (int i = 1; i <= Math.Pow(testindex.Length, 2); i++)
// {
//     var indices = GetPosition(i, testindex.Length);
//     Console.WriteLine($"position - {i} - derived - {testindex[indices.Item1][indices.Item2]}");

// }

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase \n{String.Join("\n", testcase.Select(row => String.Join(",", row)))}");
    Console.WriteLine($"Minimum steps - {SnakesAndLadders(testcase)}");
}
