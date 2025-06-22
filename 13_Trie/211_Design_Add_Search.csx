/*
Design a data structure that supports adding new words and finding if a string matches any previously added string.

Implement the WordDictionary class:

WordDictionary() Initializes the object.
void addWord(word) Adds word to the data structure, it can be matched later.
bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.
 

Example:

Input
["WordDictionary","addWord","addWord","addWord","search","search","search","search"]
[[],["bad"],["dad"],["mad"],["pad"],["bad"],[".ad"],["b.."]]
Output
[null,null,null,null,false,true,true,true]

Explanation
WordDictionary wordDictionary = new WordDictionary();
wordDictionary.addWord("bad");
wordDictionary.addWord("dad");
wordDictionary.addWord("mad");
wordDictionary.search("pad"); // return False
wordDictionary.search("bad"); // return True
wordDictionary.search(".ad"); // return True
wordDictionary.search("b.."); // return True
 

Constraints:

1 <= word.length <= 25
word in addWord consists of lowercase English letters.
word in search consist of '.' or lowercase English letters.
There will be at most 2 dots in word for search queries.
At most 104 calls will be made to addWord and search.
*/

public class Node
{
    public Dictionary<char, Node> Childrens { get; set; } = [];
    public bool EndOftheWord { get; set; } = false;
}

public class WordDictionary
{

    private Node _root;
    public WordDictionary()
    {
        _root = new();
    }

    public void AddWord(string word)
    {
        Node currentNode = _root;
        for (int i = 0; i < word.Length; i++)
        {
            var letter = word[i];
            if (!currentNode.Childrens.ContainsKey(letter))
            {
                currentNode.Childrens.Add(letter, new());
            }
            currentNode = currentNode.Childrens[letter];
        }
        currentNode.EndOftheWord = true;
    }

    public bool Search(string word, Node root = null, int index=0)
    {
        Node currentNode = root ?? _root;
        for (int i = index; i < word.Length; i++)
        {
            var letter = word[i];
            if (letter == '.')
            {
                foreach (var anyLetter in currentNode.Childrens.Keys)
                {
                    if (Search(word, currentNode.Childrens[anyLetter],i+1))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                if (!currentNode.Childrens.ContainsKey(letter))
                {
                    return false;
                }
                currentNode = currentNode.Childrens[letter];
            }

        }
        return currentNode.EndOftheWord;
    }
}

WordDictionary wordDictionary = new WordDictionary();
wordDictionary.AddWord("bad");
wordDictionary.AddWord("dad");
wordDictionary.AddWord("mad");
Console.WriteLine($"pad - {wordDictionary.Search("pad")}"); // return False
Console.WriteLine($"bad - {wordDictionary.Search("bad")}"); // return True
Console.WriteLine($".ad - {wordDictionary.Search(".ad")}"); // return True
Console.WriteLine($"b.. - {wordDictionary.Search("b..")}"); // return True