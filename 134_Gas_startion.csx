public static class Solution
{

    public static int CanCompleteCircuit(int[] gas, int[] cost)
    {
        for (int i = 1; i < gas.Length; i++)
        {
            int gasleft;
            int iteration = i;
            int gasrequired;
            gasleft = gas[i];
            gasrequired = cost[(i - 1) % gas.Length];
            if (gasleft >= gasrequired)
            {
                while ((((++iteration) % gas.Length) != i))
                {
                    Console.WriteLine($"Index- {i}, Gas left - {gasleft}, Gas required - {gasrequired}");
                    if (gasrequired > gasleft)
                    {
                        break;
                    }
                    else
                    {
                        gasleft = gasleft + gas[(iteration) % (gas.Length)] - gasrequired;
                    }
                }
                gasrequired = cost[(iteration - 1) % gas.Length];
                if (gasleft >= gasrequired)
                    return i;
            }
        }
        return -1;
    }
}

// Tests

Dictionary<int[], int[]> testcases = new()
{
    //{new int[] {1,2,3,4,5},  new int[] {3,4,5,1,2}},
    //{new int[] {2,3,4},  new int[] {3,4,3}},
    //{new int[] {4,5,2,6,5,3},  new int[] {3,2,7,3,2,9}},
    {new int[] {5,8,2,8},  new int[] {6,5,6,6}}
}
;

foreach (var (gas, cost) in testcases)
{
    Console.WriteLine($"Gas - {gas.ToString()} , costs - {cost.ToString} : Result - {Solution.CanCompleteCircuit(gas, cost)}");
}




