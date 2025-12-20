using System;

namespace Day3;

internal class Person
{
    public Person()
    {
        Console.WriteLine("Person Class Constructor Invoked.");
    }

    ~Person()
    {
        Console.WriteLine("Person Class Destructor Invoked.");
    }
    
    /// <summary>
    /// Display method for demo purpose
    /// </summary>
    /// <param name="obj">Object variable</param>
    public void Display(object obj)
    {

    }
    }
