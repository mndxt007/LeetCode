/*
Given an integer n, return the nth digit of the infinite integer sequence [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ...].
Example 1:

Input: n = 3
Output: 3
Example 2:

Input: n = 11
Output: 0
Explanation: The 11th digit of the sequence 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, ... is a 0, which is part of the number 10.
 
Constraints:

1 <= n <= 231 - 1
*/


using System.Globalization;

public int FindNthDigit(int n) {
        //Brute Force
        int digit = 0;
        foreach (var item in Enumerable.Range(1,n))
        {
            switch(item)
            {
                case > 9999:
                    digit+=4;
                    break;
                case > 999:
                    digit+=4;
                    break; 
                case > 99:
                    digit+=3;
                    break; 
                case > 9:
                    digit+=2;
                    break;
                default:
                    digit+=1;
                    break;
            }
            if(digit == n)
            {
                return item%10;
            }
        }
        return 0;
    }

List<int> testcases = [
    3,
    11,
    25
];

foreach (var item in testcases)
{
    Console.WriteLine($"Testcase - {item}, Nth Digit - {FindNthDigit(item)}");
}