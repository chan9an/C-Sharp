using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentDAL dal = new StudentDAL();

            Student s = new Student();
            s.RollNo = 106;
            s.Name = "Parth";
            s.Age = 22;         
            s.Address = "Lucknow";
            s.PhoneNo = "9876543311";

            bool result = dal.AddStudent(s);

            if (result)
                Console.WriteLine("Student added successfully");
            else
                Console.WriteLine("Insert failed");

            Console.ReadLine();
        }



    }
}
