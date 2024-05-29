/*
https://leetcode.com/problems/maximum-bags-with-full-capacity-of-rocks/description/
You have n bags numbered from 0 to n - 1. You are given two 0-indexed integer arrays capacity and rocks. The ith bag can hold a maximum of capacity[i] rocks and currently contains rocks[i] rocks. You are also given an integer additionalRocks, the number of additional rocks you can place in any of the bags.

Return the maximum number of bags that could have full capacity after placing the additional rocks in some bags.

 

Example 1:

Input: capacity = [2,3,4,5], rocks = [1,2,4,4], additionalRocks = 2
Output: 3
Explanation:
Place 1 rock in bag 0 and 1 rock in bag 1.
The number of rocks in each bag are now [2,3,4,4].
Bags 0, 1, and 2 have full capacity.
There are 3 bags at full capacity, so we return 3.
It can be shown that it is not possible to have more than 3 bags at full capacity.
Note that there may be other ways of placing the rocks that result in an answer of 3.
Example 2:

Input: capacity = [10,2,2], rocks = [2,2,0], additionalRocks = 100
Output: 3
Explanation:
Place 8 rocks in bag 0 and 2 rocks in bag 2.
The number of rocks in each bag are now [10,2,2].
Bags 0, 1, and 2 have full capacity.
There are 3 bags at full capacity, so we return 3.
It can be shown that it is not possible to have more than 3 bags at full capacity.
Note that we did not use all of the additional rocks.
 

Constraints:

n == capacity.length == rocks.length
1 <= n <= 5 * 104
1 <= capacity[i] <= 109
0 <= rocks[i] <= capacity[i]
1 <= additionalRocks <= 109
*/

public static class Solution {
    public static int MaximumBags(int[] capacity, int[] rocks, int additionalRocks) {
        int remainingcap=0;
        int fullcap=0;
        for(int i=0; i<capacity.Length;i++)
        {
            if(rocks[i]<capacity[i])
            {
                remainingcap=capacity[i]-rocks[i];
                if(additionalRocks - remainingcap >=0)
                {
                    additionalRocks-=remainingcap;
                    fullcap++;
                }
            }
            else if(rocks[i]==capacity[i])
            {
                fullcap++;
            }
            
        }
        return fullcap;
        
    }
}

public class Testcase
{
    public int[] capacity{get;set;}
    public int[] rocks{get;set;}
    public int additionalRocks{get;set;}
};

List<Testcase> testcases = new()
{
    new Testcase(){
        capacity = new int[] {2,3,4,5},
        rocks = new int[] {1,2,4,4},
        additionalRocks = 2
    },
    new Testcase(){
        capacity = new int[] {10,2,2},
        rocks = new int[] {2,2,0},
        additionalRocks = 100
    },
    new Testcase(){
        capacity = new int[] {54,18,91,49,51,45,58,54,47,91,90,20,85,20,90,49,10,84,59,29,40,9,100,1,64,71,30,46,91},
        rocks = new int[] {14,13,16,44,8,20,51,15,46,76,51,20,77,13,14,35,6,34,34,13,3,8,1,1,61,5,2,15,18},
        additionalRocks = 77
    },
};

foreach(var case_ in testcases)
{
    Console.WriteLine($"capacity - {String.Join(',',case_.capacity)} rocks - {String.Join(',',case_.rocks)} addtionalRocks - {case_.additionalRocks}");
    Console.WriteLine($"MaximumBags - {Solution.MaximumBags(case_.capacity,case_.rocks,case_.additionalRocks)}");

}

