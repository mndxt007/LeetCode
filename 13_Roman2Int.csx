public static class Solution
{

    public enum RomanNumeral
    {
        A = 0,
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }




    public static int RomanToInt(string s)
    {
        int total = 0;
        for (int i = 0; i < s.Length; i++)
        {
            Enum.TryParse(s[i].ToString(), out RomanNumeral current);
            if (i != s.Length - 1)
            {
                Enum.TryParse(s[i + 1].ToString(), out RomanNumeral next);
                if (current < next)
                    total -= (int)current;
                else
                    total += (int)current;
            }
            else
            {
                total += (int)current;
            }
        }
        return total;
    }


}


List<string> testcases = new(){
"III",
"LVIII",
"MCMXCIV",
};


foreach (var cases in testcases)
{
    Console.WriteLine($"ratings - {string.Join(", ", cases)} : Result - {Solution.RomanToInt(cases)}");
}
