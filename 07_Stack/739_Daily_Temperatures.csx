/*
Given an array of integers temperatures represents the daily temperatures, return an array answer such that answer[i] is the number of days you have to wait after the ith day to get a warmer temperature. If there is no future day for which this is possible, keep answer[i] == 0 instead.

 

Example 1:

Input: temperatures = [73,74,75,71,69,72,76,73]
Output: [1,1,4,2,1,1,0,0]
Example 2:

Input: temperatures = [30,40,50,60]
Output: [1,1,1,0]
Example 3:

Input: temperatures = [30,60,90]
Output: [1,1,0]
 

Constraints:

1 <= temperatures.length <= 105
30 <= temperatures[i] <= 100
*/

 public int[] DailyTemperatures(int[] temperatures) 
 {
      int[] result = new int[temperatures.Length];
      Stack<int> mono = new();
      for(int i=temperatures.Length-1;i > -1;i--)
      {
         while(mono.Count > 0 && temperatures[mono.Peek()] <= temperatures[i])
            mono.Pop();
         if(mono.Count > 0)
         {
            result[i]=mono.Peek()-i;
         }
         mono.Push(i);
      }
      return result;
 }

 List<int[]> testcases = [
   //  [73,74,75,71,69,72,76,73],
   //  [30,40,50,60],
   //  [30,60,90],
    [89,62,70,58,47,47,46,76,100,70]
 ];

 foreach (var case_ in testcases)
 {
    Console.WriteLine($"Test case - [{String.Join(',',case_)}]");
    Console.WriteLine($"Daily Temperature - [{String.Join(',',DailyTemperatures(case_))}]");
 }