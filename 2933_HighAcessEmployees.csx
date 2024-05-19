/*
https://leetcode.com/problems/high-access-employees/description/

You are given a 2D 0-indexed array of strings, access_times, with size n. For each i where 0 <= i <= n - 1, access_times[i][0] represents the name of an employee, and access_times[i][1] represents the access time of that employee. All entries in access_times are within the same day.

The access time is represented as four digits using a 24-hour time format, for example, "0800" or "2250".

An employee is said to be high-access if he has accessed the system three or more times within a one-hour period.

Times with exactly one hour of difference are not considered part of the same one-hour period. For example, "0815" and "0915" are not part of the same one-hour period.

Access times at the start and end of the day are not counted within the same one-hour period. For example, "0005" and "2350" are not part of the same one-hour period.

Return a list that contains the names of high-access employees with any order you want.

 

Example 1:

Input: access_times = [["a","0549"],["b","0457"],["a","0532"],["a","0621"],["b","0540"]]
Output: ["a"]
Explanation: "a" has three access times in the one-hour period of [05:32, 06:31] which are 05:32, 05:49, and 06:21.
But "b" does not have more than two access times at all.
So the answer is ["a"].
Example 2:

Input: access_times = [["d","0002"],["c","0808"],["c","0829"],["e","0215"],["d","1508"],["d","1444"],["d","1410"],["c","0809"]]
Output: ["c","d"]
Explanation: "c" has three access times in the one-hour period of [08:08, 09:07] which are 08:08, 08:09, and 08:29.
"d" has also three access times in the one-hour period of [14:10, 15:09] which are 14:10, 14:44, and 15:08.
However, "e" has just one access time, so it can not be in the answer and the final answer is ["c","d"].
Example 3:

Input: access_times = [["cd","1025"],["ab","1025"],["cd","1046"],["cd","1055"],["ab","1124"],["ab","1120"]]
Output: ["ab","cd"]
Explanation: "ab" has three access times in the one-hour period of [10:25, 11:24] which are 10:25, 11:20, and 11:24.
"cd" has also three access times in the one-hour period of [10:25, 11:24] which are 10:25, 10:46, and 10:55.
So the answer is ["ab","cd"].
 

Constraints:

1 <= access_times.length <= 100
access_times[i].length == 2
1 <= access_times[i][0].length <= 10
access_times[i][0] consists only of English small letters.
access_times[i][1].length == 4
access_times[i][1] is in 24-hour time format.
access_times[i][1] consists only of '0' to '9'.
*/

using System.Collections;


public static class Solution {
    public static IList<string> FindHighAccessEmployees(IList<IList<string>> access_times) {
        //lets go LINQ and memory consumptions
        // var highaccess = access_times.Select(
        //     list => new ArrayList
        //         {
        //             list[0],new TimeOnly(Convert.ToInt32(list[1][..2]),Convert.ToInt32(list[1][2..4]))
        //         }
        // );
        // Ok scraping linq
        var orderedaccess = access_times.OrderBy(list => (list[0],list[1]));
        var firstpunch = orderedaccess.First();
        string prevEmp = firstpunch[0];
        string emp = "";
        int count = 0;
        List<string> result = new();
        TimeOnly prevTime = new TimeOnly(Convert.ToInt32(firstpunch[1][..2]),Convert.ToInt32(firstpunch[1][2..4])) ;
        TimeOnly currTime = new TimeOnly(0,0,0);
        TimeSpan oneHour = new TimeSpan(1,0,0);
        foreach(var accesspunch in orderedaccess.Skip(1))
        {
            emp = accesspunch[0];
            currTime = new TimeOnly(Convert.ToInt32(accesspunch[1][..2]),Convert.ToInt32(accesspunch[1][2..4]));
            if(emp==prevEmp)
            {
                if(currTime - prevTime < oneHour)
                {
                    count++;
                    if (count>=2)
                    {
                        result.Add(emp);
                    }
                }
                else
                {
                    prevTime = currTime;
                }
            }
            else
            {
                count=0;
                prevEmp = emp;
                prevTime = currTime;
            }
            
        }
        //very costly but should work
        return result.Distinct().ToList<string>();
    }
}

List<IList<IList<string>>> testcases = new List<IList<IList<string>>>
{
    new List<IList<string>>
    {
        new List<string> {"a", "0549"},
        new List<string> {"b", "0457"},
        new List<string> {"a", "0532"},
        new List<string> {"a", "0621"},
        new List<string> {"b", "0540"}
    },
    new List<IList<string>>
    {
        new List<string> {"d", "0002"},
        new List<string> {"c", "0808"},
        new List<string> {"c", "0829"},
        new List<string> {"e", "0215"},
        new List<string> {"d", "1508"},
        new List<string> {"d", "1444"},
        new List<string> {"d", "1410"},
        new List<string> {"c", "0809"}
    },
    new List<IList<string>>
    {
        new List<string> {"cd", "1025"},
        new List<string> {"ab", "1025"},
        new List<string> {"cd", "1046"},
        new List<string> {"cd", "1055"},
        new List<string> {"ab", "1124"},
        new List<string> {"ab", "1120"}
    },
      new List<IList<string>>
    {
        new List<string> {"jilsfmdd", "2020"},
        new List<string> {"tcvjyciwb", "2004"},
        new List<string> {"puqlqbde", "1928"},
        new List<string> {"tcvjyciwb", "2016"},
        new List<string> {"puqlqbde", "1939"},
        new List<string> {"puqlqbde", "1903"},
        new List<string> {"jilsfmdd", "2021"},
        new List<string> {"jilsfmdd", "1916"},
        new List<string> {"puqlqbde", "1922"},
        new List<string> {"tcvjyciwb", "1959"},
        new List<string> {"jilsfmdd", "1915"}
    }
};

foreach (var case_ in testcases)
{
    Console.WriteLine($"Test Case - {string.Join(',', case_.Select(innerList => string.Join("-", innerList)))}");
    Console.WriteLine($"Resutl - {String.Join(",",Solution.FindHighAccessEmployees(case_))}");
}
