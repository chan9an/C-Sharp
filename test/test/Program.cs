// See https://aka.ms/new-console-template for more information
using test;
using System;
using System.Linq;
using System.Collections.Generic;
namespace test;


public class Program
{

    public static void Main(string[] args)
    {
     List<Employee> list = new List<Employee>
    {
        new Employee("Abc",50000),
        new Employee("Ram",123454),
        new Employee("Rahul",234555)
    };
    var res = list.OrderByDescending(e => e.Salary).FirstOrDefault();

    System.Console.WriteLine($"high: {res.Name} - {res.Salary}");


    }
}