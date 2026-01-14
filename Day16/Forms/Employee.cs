
using System;
using System.Diagnostics.Tracing;
namespace Forms
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NonSerialized]

        public decimal Salary { get; set; }


        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            //Department = department;
            Salary = salary;
        }
    
        
        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name},  Salary: {Salary:C}");
        }
    }
}