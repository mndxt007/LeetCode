//https://leetcode.com/discuss/interview-question/3410477/Codility-Pi-Code-Challenge/


public static class Solution {
    public static int solution(string P, string Q) {
        // Implement your solution here
        var pDict = new Dictionary<char,int>();
        var qDict = new Dictionary<char,int>();
        int count =1;
        var common = new HashSet<char>(P);
        common.IntersectWith(new HashSet<char>(Q));
        //Console.WriteLine("In Pdict");
        foreach(var item in P)
        {
            if(pDict.TryGetValue(item,out count))
            {
                pDict[item]++;
            }
            else{
                pDict.Add(item,1);
            }
        }
        //Console.WriteLine("In Qdict");
        foreach(var item in Q)
        {
            if(qDict.TryGetValue(item,out count))
            {
                qDict[item]++;
            }
            else{
                qDict.Add(item,1);
            }
        }
        var sb= new List<char>();
        //Console.WriteLine("In Sb");
        for(int i=0;i<P.Length;i++)
        {
            if(pDict[P[i]]>qDict[Q[i]])
            {
                sb.Add(P[i]);
            }
            else if(pDict[P[i]]==qDict[Q[i]])
            {
                if(common.Contains(P[i]) && sb.Contains(P[i]))
                {
                    sb.Add(P[i]);
                }
                else{
                     sb.Add(Q[i]);
                }
            }
            else
            {
                sb.Add(Q[i]);
            }
        }
        Console.WriteLine(String.Join("",sb));
        return sb.Distinct().Count();
    }
}

Dictionary<string, string> testcases = new()
{
    {"abc", "bcd"},
    //2
    {"axxz", "yzwy"},
    //2
    {"bacad", "abada"},
    //1
    {"amz", "amz"},
    //3
    {"xyz", "yxe"},
    //2
    {"ddee", "abac"}
    //2
};




foreach(var (P,Q) in testcases)
{
    Console.WriteLine($"P - {P}  Q - {Q}");
    Console.WriteLine($"Minimum - {Solution.solution(P,Q)}");
}