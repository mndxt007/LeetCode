/*
A gene string can be represented by an 8-character long string, with choices from 'A', 'C', 'G', and 'T'.
Suppose we need to investigate a mutation from a gene string startGene to a gene string endGene where one mutation is defined as one single character changed in the gene string.
For example, "AACCGGTT" --> "AACCGGTA" is one mutation.
There is also a gene bank bank that records all the valid gene mutations. A gene must be in bank to make it a valid gene string.
Given the two gene strings startGene and endGene and the gene bank bank, return the minimum number of mutations needed to mutate from startGene to endGene. If there is no such a mutation, return -1.
Note that the starting point is assumed to be valid, so it might not be included in the bank.


Example 1:
Input: startGene = "AACCGGTT", endGene = "AACCGGTA", bank = ["AACCGGTA"]
Output: 1

Example 2:
Input: startGene = "AACCGGTT", endGene = "AAACGGTA", bank = ["AACCGGTA","AACCGCTA","AAACGGTA"]
Output: 2
 

Constraints:

0 <= bank.length <= 10
startGene.length == endGene.length == bank[i].length == 8
startGene, endGene, and bank[i] consist of only the characters ['A', 'C', 'G', 'T'].
*/

public int MinMutation(string startGene, string endGene, string[] bank)
{
    HashSet<string> bankHash = new(bank);
    HashSet<string> visited = new();
    if (!bank.Contains(endGene))
        return -1;
    Queue<(int level, string gene)> bfsQueue = new();
    bfsQueue.Enqueue((0, startGene));
    visited.Add(startGene);

    while (bfsQueue.Count > 0)
    {
        var (level, gene) = bfsQueue.Dequeue();
        if (gene == endGene)
        {
            return level;
        }
        foreach (var newGene in bankHash)
        {
            if (!visited.Contains(newGene))
            {
                if (IsValidMutation(gene, newGene))
                {
                    bfsQueue.Enqueue((level + 1, newGene));
                    visited.Add(newGene);
                }
            }

        }
    }

    return -1;
}

bool IsValidMutation(string gene, string newGene)
{
    int count = 0;
    for (int i = 0; i < gene.Length; i++)
    {
        if (gene[i] != newGene[i])
        {
            count++;
            if (count > 1)
                return false;
        }
    }
    return true;
}

List<(string startGene, string endGene, string[] bank)> testcases = new()
{
    {
        ("AACCGGTT", "AACCGGTA", ["AACCGGTA"])
    },
    {
        ("AACCGGTT", "AAACGGTA", ["AACCGGTA","AACCGCTA","AAACGGTA"])
    }
};

foreach (var (startGene, endGene, bank) in testcases)
{
    Console.WriteLine($"Testcase - {(startGene, endGene, String.Join(',', bank))}");
    Console.WriteLine($"MinMutation - {MinMutation(startGene, endGene, bank)}");
}