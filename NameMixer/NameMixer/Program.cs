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
    static (List<Person> validPersons, List<string> invalidLines) ReadPersonsFromFile(string filePath)
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

    static void Main(string[] args)
    {
        string filePath = @"C:\Users\Igor V\Documents\GitHub\NameMixer\NameMixer\NameMixer\TestData.dat"; // the input file location
        var result = ReadPersonsFromFile(filePath);

        Console.WriteLine("Valid Persons:");
        foreach (var person in result.validPersons)
        {
            Console.WriteLine(person);
        }

        Console.WriteLine("\nInvalid Lines:");
        foreach (var invalidLine in result.invalidLines)
        {
            Console.WriteLine(invalidLine);
        }
    }
}
