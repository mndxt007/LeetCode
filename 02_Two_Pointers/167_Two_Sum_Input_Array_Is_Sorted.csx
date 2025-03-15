/*
Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.
Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.
The tests are generated such that there is exactly one solution. You may not use the same element twice.
Your solution must use only constant extra space.
 
Example 1:
Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].

Example 2:
Input: numbers = [2,3,4], target = 6
Output: [1,3]
Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].

Example 3:
Input: numbers = [-1,0], target = -1
Output: [1,2]
Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
 
Constraints:
2 <= numbers.length <= 3 * 104
-1000 <= numbers[i] <= 1000
numbers is sorted in non-decreasing order.
-1000 <= target <= 1000
The tests are generated such that there is exactly one solution.
*/

using System.Globalization;

public int[] TwoSum(int[] numbers, int target)
{
    int othernum;
    int index;
    for(int i=0; i< numbers.Length ; i++)
    {
        othernum = target - numbers[i];
        index = BinarySearch(othernum,numbers[(i+1)..],i+1);
        if(index!= -1)
        {
            return[i+1,index+1];
        }
    }
    return [];
}

int BinarySearch(int number,int[] numbers,int startindex)
{
    if(numbers.Length == 1)
    {
        return numbers[0]==number?startindex:-1;
    }
    int mid = numbers.Length / 2;
    if(number==numbers[mid])
    {
        return startindex+mid;
    }
    else if(number<numbers[mid])
    {
        return BinarySearch(number,numbers[..mid],startindex);
    }
    else
    {
         return BinarySearch(number,numbers[mid..],startindex+mid);
    }
}


List<ValueTuple<int[], int>> testcases = [
    ([2,7,11,15],17),
    ([2,3,4],6),
    ([-1,0], -1),
    ([-10,-8,-2,1,2,5,6],0)
];

foreach (var testcase in testcases)
{
    Console.WriteLine($"Testcase -> numbers=[{String.Join(',', testcase.Item1)}] target={testcase.Item2}");
    Console.WriteLine($"Two Sum - [{String.Join(',',TwoSum(testcase.Item1,testcase.Item2))}]");
}