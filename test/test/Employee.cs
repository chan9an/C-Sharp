using System;

namespace test;
//create an employee class having name and salary. add them to the list and fin the person with highest salary

public class Employee

{
    public string Name { get; set; }
    public double Salary { get; set; }
    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }

}

