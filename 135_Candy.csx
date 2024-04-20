/*
https://leetcode.com/problems/candy/?envType=study-plan-v2&envId=top-interview-150
There are n children standing in a line. Each child is assigned a rating value given in the integer array ratings.

You are giving candies to these children subjected to the following requirements:

Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.
Return the minimum number of candies you need to have to distribute the candies to the children.

 

Example 1:

Input: ratings = [1,0,2]
Output: 5
Explanation: You can allocate to the first, second and third child with 2, 1, 2 candies respectively.
Example 2:

Input: ratings = [1,2,2]
Output: 4
Explanation: You can allocate to the first, second and third child with 1, 2, 1 candies respectively.
The third child gets 1 candy because it satisfies the above two conditions.
 

Constraints:

n == ratings.length
1 <= n <= 2 * 104
0 <= ratings[i] <= 2 * 104
*/


using System.Reflection;

public static class Solution {
    public static int Candy(int[] ratings) {
        int total = ratings.Length;
        for (int i = 1; i < ratings.Length -1; i++)
        {
             if(ratings[i] != ratings[i-1]){
                total++;
            if (ratings[i] !=  ratings[i+1])
            {
                total++;
            }
            }
        }
        return total;
    }
}

List<int[]> testcases = new(){
new int[] {1,0,2},
new int[] {1,2,2},
};


foreach (var ratings in testcases)
{
    Console.WriteLine($"ratings - {string.Join(", ", ratings)} : Result - {Solution.Candy(ratings)}");
}

