
// https://www.youtube.com/watch?v=nLmhmB6NzcM&list=PLDN4rrl48XKpZkf03iYFl-O29szjTrs_O&index=54
#r "nuget: Dumpify, 0.6.6"
using Dumpify;
public static int KnapSack(int capacity, int[] weights, int[] values, int n)
{
    int[,] K = new int[n + 1, capacity + 1];

    // Build table K[,] in bottom-up manner
    for (int i = 0; i <= n; i++)
    {
        for (int w = 0; w <= capacity; w++)
        {
            if (i == 0 || w == 0)
                K[i, w] = 0;
            else if (weights[i - 1] <= w)
            {
                K[i, w] = Math.Max(values[i - 1] + K[i - 1, w - weights[i - 1]], K[i - 1, w]);
                K.Dump();
            }
                
            else
            {
                K[i, w] = K[i - 1, w];
                K.Dump();
            }
                
        }

    }
    K.Dump();
    return K[n, capacity];
}

List<int[][]> testcases = [
    [[1,2,5,6],[2,3,4,5]],
];

foreach (var case_ in testcases)
{
    Console.WriteLine($"Test Case - {String.Join('|', case_.Select(x => String.Join(',', x)))}");
    Console.WriteLine($"Maximum Profit - {KnapSack(8, case_[1], case_[0], 4)}");
}