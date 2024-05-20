/*
hackerrank C# challenge for notes store
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class NotesStore
{
    List<string> validstates = new(){
            "completed", "active","others"
        };
    Dictionary<string, string> notes = new();
    public NotesStore() { }
    public void AddNote(String state, String name)
    {
        if (String.IsNullOrEmpty(name))
            throw new ArgumentNullException("Name cannot be empty");
        if (String.IsNullOrEmpty(state) || !validstates.Contains(state))
            throw new ArgumentException($"Invalid state {state}");
        else
        {
            notes.Add(name, state);
        }
    }
    public List<String> GetNotes(String state)
    {
        if (String.IsNullOrEmpty(state) || !validstates.Contains(state))
            throw new ArgumentException($"Invalid state {state}");
        var items = notes.Where(
            (item) => item.Value == state
        ).Select(
            (values) => values.Key
        );
        return items.ToList<string>();

    }
}

var notesStoreObj = new NotesStore();
var n = int.Parse(Console.ReadLine());
for (var i = 0; i < n; i++)
{
    var operationInfo = Console.ReadLine().Split(' ');
    try
    {
        if (operationInfo[0] == "AddNote")
            notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
        else if (operationInfo[0] == "GetNotes")
        {
            var result = notesStoreObj.GetNotes(operationInfo[1]);
            if (result.Count == 0)
                Console.WriteLine("No Notes");
            else
                Console.WriteLine(string.Join(",", result));
        }
        else
        {
            Console.WriteLine("Invalid Parameter");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("Error: " + e.Message);
    }
}
