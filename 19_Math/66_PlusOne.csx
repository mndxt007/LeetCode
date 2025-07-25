/*
You are given a large integer represented as an integer array digits, where each digits[i] is the ith digit of the integer. The digits are ordered from most significant to least significant in left-to-right order. The large integer does not contain any leading 0's.

Increment the large integer by one and return the resulting array of digits.

Example 1:
Input: digits = [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Incrementing by one gives 123 + 1 = 124.
Thus, the result should be [1,2,4].

Example 2:
Input: digits = [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
Incrementing by one gives 4321 + 1 = 4322.
Thus, the result should be [4,3,2,2].

Example 3:
Input: digits = [9]
Output: [1,0]
Explanation: The array represents the integer 9.
Incrementing by one gives 9 + 1 = 10.
Thus, the result should be [1,0].
 

Constraints:

1 <= digits.length <= 100
0 <= digits[i] <= 9
digits does not contain any leading 0's.
*/

public int[] PlusOne(int[] digits)
{
    int carry = 0;
    //carry has to be calculated before overriden
    carry = (digits[^1] + 1) / 10;
    digits[^1] = (digits[^1] + 1) % 10;
    int temp = 0;
    for (int i = digits.Length - 2; i >= 0; i--)
    {
        //using temp varaible since the digits[i] will be overriden before we can calculate carry.
        temp = digits[i] + carry;
        digits[i] = (temp) % 10;
        carry = (temp) / 10;
    }
    if (carry > 0)
    {
        int[] newDigit = new int[digits.Length + 1];
        Array.Copy(digits, 0, newDigit, 1, digits.Length);
        newDigit[0] = carry;
        return newDigit;
    }
    return digits;
}


List<int[]> testcases = [
    [1,2,3],
    [4,3,2,1],
    [9],
    [9,9,9]
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase - {String.Join(',', testcase)}");
    Console.WriteLine($"PlusOne - {String.Join(',', PlusOne(testcase))}");
}