/*
Given an integer x, return true if x is a palindrome, and false otherwise. 

Example 1:
Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.

Example 2:
Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.

Example 3:
Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
 
Constraints:

-231 <= x <= 231 - 1
 
Follow up: Could you solve it without converting the integer to a string?
*/

public bool IsPalindrome(int x)
{
    if(x < 0)
        return false;
    long newX= x;
    //find the div
    long div = 1;
    while(x > 10 * div)
        div *= 10;
    long left = 0; long right = 0;

    //compare left and right
    while(newX > 0)
    {
        right = newX % 10;
        left = newX / div;
        if(right!=left)
            return false;
        newX = (newX % div) / 10;
        div /= 100;
    }
    return true;

}

List<int> testcases = [
    121,
    -121,
    10
];

foreach(var testcase in testcases)
{
    Console.WriteLine($"Testcase - {testcase}");
    Console.WriteLine($"{IsPalindrome(testcase)}");
}