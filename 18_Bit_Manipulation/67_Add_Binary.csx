/*
Given two binary strings a and b, return their sum as a binary string.

Example 1:
Input: a = "11", b = "1"
Output: "100"

Example 2:
Input: a = "1010", b = "1011"
Output: "10101"
 

Constraints:

1 <= a.length, b.length <= 104
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/

using System.Numerics;

public string AddBinary(string a, string b)
{
    StringBuilder result = new();

    int i = a.Length - 1;
    int j = b.Length - 1;
    int carry = 0;

    while (i >= 0 || j >= 0 || carry > 0)
    {
        int bitA = (i >= 0 && a[i] == '1') ? 1 : 0;
        int bitB = (j >= 0 && b[j] == '1') ? 1 : 0;

        int sum = bitA + bitB + carry;
        result.Insert(0, sum % 2);   // append current bit
        carry = sum / 2;             // update carry

        i--;
        j--;
    }

    return result.ToString();
}



List<(string,string)> testcases = [
    ("11","1"),
    ("1010","1011"),
];

foreach(var (a,b) in testcases)
{
    Console.WriteLine($"a={a} b={b}");
    Console.WriteLine($"Isisomorphic  - {AddBinary(a,b)}");
}