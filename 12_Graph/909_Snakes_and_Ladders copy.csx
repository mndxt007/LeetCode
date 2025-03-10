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
    Queue<int> queue = new();
    int level = -1;
    HashSet<int> visited = new();
    queue.Enqueue(1);
    int currentpos = 1;
    int length = board.Length;
    int last = length * length;
    while (queue.Count > 0 && currentpos < last && level <= length)
    {
        int len = queue.Count;
        for (int i = 0; i < len; i++)
        {
            currentpos = queue.Dequeue();
            if (!visited.Contains(currentpos))
            {
                var indices = GetPosition(currentpos, length);
                currentpos = board[indices.Item1][indices.Item2] == -1 ? currentpos : board[indices.Item1][indices.Item2];
                if (currentpos == last)
                {
                    break;
                }
                for (int next = 1; next <= 6; next++)
                {
                    if (!visited.Contains(currentpos + next))
                    {
                        queue.Enqueue(currentpos + next);
                    }
                }
                visited.Add(currentpos);
            }
        }
        level++;
    }
    return level > length ? -1 : level;
}

private ValueTuple<Index, Index> GetPosition(int position, int length)
{
    var r = new Index(((position - 1) / length) + 1, true);
    int c = (position - 1) % length;
    if ((r.Value) % 2 != 1)
    {
        return (r, new Index(c + 1, true));
    }
    return (r, c < 0 ? 0 : c);

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
