/*
Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:
Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:
Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]
*/

public IList<int> SpiralOrder(int[][] matrix)
{
    var result = new List<int>();
    int n = matrix.Length;
    int m = matrix[0].Length;
    int totalcount = m * n;
    int counter = 1;
    int row = 0; int column = 0;
    int rem=0;
    while (result.Count < totalcount)
    {
        int iteration = counter % 5;
        rem = counter / 5 ;
        switch (iteration)
        {
            case 1:
                for (; column < m - rem; column++)
                {
                    result.Add(matrix[row][column]);
                }
                column--;row++;
                break;
            case 2:
                for (; row < n - rem; row++)
                {
                    result.Add(matrix[row][column]);
                }
                row--;column--;
                break;
            case 3:
                for (; column >= 0 + rem; column--)
                {
                    result.Add(matrix[row][column]);
                }
                column++;row--;
                break;
            case 4:
                for (; row >= 0 + rem+1; row--)
                {
                    result.Add(matrix[row][column]);
                }
                row++;column++;
                break;
            default:
                break;
        }
        counter++;
    }
    return result;
}

List<int[][]> testcases = [
    [
        [1,2,3],
        [4,5,6],
        [7,8,9]
    ],
    [
        [1,2,3,4],
        [5,6,7,8],
        [9,10,11,12]
    ],
    [
        [ 1, 2, 3, 4],
        [ 5, 6, 7, 8],
        [ 9,10,11,12],
        [13,14,15,16],
        [17,18,19,20],
        [21,22,23,24]
    ]
];

foreach (var testcase in testcases)
{
    Console.WriteLine(SpiralOrder(testcase));
}
