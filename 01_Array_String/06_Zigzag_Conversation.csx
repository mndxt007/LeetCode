/*
The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

P   A   H   N
A P L S I I G
Y   I   R
And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows:

string convert(string s, int numRows);
 

Example 1:

Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"

Example 2:
Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I

Example 3:
Input: s = "A", numRows = 1
Output: "A"
 

Constraints:

1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000
*/

public string Convert(string s, int numRows)
{
    if(s.Length == 1 || numRows == 1) return s;
    int jump = (numRows - 1) * 2;
    StringBuilder sb = new();
    for(int r=0; r < numRows ; r++)
    {
      for(int j=r; j< s.Length; j+=jump)
      { 
        sb.Append(s[j]);
        if((r >0) && (r < numRows-1) && ((j+jump-(2*r))<s.Length))
        {
            sb.Append(s[(j+jump-(2*r))]);
        }
      }
    }
    return sb.ToString();
}

List<(string,int)> testcases = [
  ("PAYPALISHIRING",3),
  ("PAYPALISHIRING",4),
  ("A",1)
];

foreach (var (s,numRows) in testcases)
{
    Console.WriteLine($"Test Case - '{(s,numRows)}'");
    Console.WriteLine($"ZigZaged - '{Convert(s,numRows)}'");
}