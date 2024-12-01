using System;
using System.Collections.Generic;
using System.IO;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}

class Program
{
    public static (List<Person> validPersons, List<string> invalidLines) ReadPersonsFromFile(string filePath)
    {
        var validPersons = new List<Person>();
        var invalidLines = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');
                if (parts.Length == 2)
                {
                    var person = new Person
                    {
                        FirstName = parts[0],
                        LastName = parts[1]
                    };
                    validPersons.Add(person);
                }
                else
                {
                    invalidLines.Add(line);
                }
            }
        }

        return (validPersons, invalidLines);
    }

    static (HashSet<string> allFirstNames, HashSet<string> allLastNames) GetUniqueNames(List<Person> persons)
    {
        var allFirstNames = new HashSet<string>();
        var allLastNames = new HashSet<string>();
        foreach (var person in persons)
        {
            allFirstNames.Add(person.FirstName);
            allLastNames.Add(person.LastName);
        }
        return (allFirstNames, allLastNames);
    }



   static void Main(string[] args)
    {
        string filePath = @"C:\Users\Igor V\Documents\GitHub\NameMixer\NameMixer\NameMixer\TestData.dat"; // the input file location
        var readed = ReadPersonsFromFile(filePath);
        var uniqueEntities = GetUniqueNames(readed.validPersons);
        foreach (var firstName in uniqueEntities.allFirstNames) 
        {
            foreach (var lastName in uniqueEntities.allLastNames)
            {
                Console.WriteLine(firstName + ' ' + lastName);
            }
        }
    }
}
