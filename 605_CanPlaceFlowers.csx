/*
https://leetcode.com/problems/can-place-flowers/description/?envType=study-plan-v2&envId=leetcode-75
You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.

Given an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.

 

Example 1:

Input: flowerbed = [1,0,0,0,1], n = 1
Output: true
Example 2:

Input: flowerbed = [1,0,0,0,1], n = 2
Output: false
 

Constraints:

1 <= flowerbed.length <= 2 * 104
flowerbed[i] is 0 or 1.
There are no two adjacent flowers in flowerbed.
0 <= n <= flowerbed.length
*/


public static class Solution
{
    public static bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        //breaking into 3 logic
        //logic to determine - if the flower can be placed in the first, last or middle.
        int count = 0;
        //edge condition
        int l = flowerbed.Length;

        if (l == 1)
        {
            if (flowerbed[0] == 0)
            {
                return true;
            }
            else
                return false;
        }

        //checking if the flower can be placed on 0th index:
        if ((flowerbed[1], flowerbed[0]) == (0, 0))
        {
            count++;
            flowerbed[0] = 1;
        }
        //checking if the flower can be placed between 0th and nth index:
        for (int i = 1; i < l - 2; i++)
        {
            if ((flowerbed[i - 1], flowerbed[i]) == (0, 0))
            {
                count++;
                flowerbed[i] = 1;
            }

        }
        if ((flowerbed[l - 1], flowerbed[l - 2]) == (0, 0))
        {
            count++;
        }
        if (count >= n)
            return true;
        else
            return false;



    }
}


Dictionary<int[], int> testcases = new(){
    {new int[] {1,0,0,0,1},1},
    {new int[] {1,0,0,0,1},2},
    {new int[] {0,0},1},
    {new int[] {1,0,0,0,0,1},2}
};

foreach (var (flowerbed, n) in testcases)
{
    Console.WriteLine($"Flower Bed - {String.Join(' ', flowerbed)} : n - {n}");
    Console.WriteLine($"Can place flowers - {Solution.CanPlaceFlowers(flowerbed, n)}");
}