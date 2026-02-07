using System;
using System.Collections.Generic;

namespace student
{
    public class Program
    {
        public static Dictionary<int, Student> StudentDetails;

        public static void Main(string[] args)
        {
            StudentDetails = new Dictionary<int, Student>();

            StudentDetails[1] = new Student { Id = "ST01", Name = "Akshay", Course = "OS", Marks = 80 };
            StudentDetails[2] = new Student { Id = "ST02", Name = "Varun", Course = "CN", Marks = 85 };
            StudentDetails[3] = new Student { Id = "ST03", Name = "Parth", Course = "DSA", Marks = 55 };

            StudentUtility sUtil = new StudentUtility();

            while (true)
            {
                Console.WriteLine("1. Get Student Details");
                Console.WriteLine("2. Update Marks");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter the student id");
                    string sID = Console.ReadLine();

                    var ans = sUtil.GetStudentDetails(sID);

                    if (ans.Count == 0)
                    {
                        Console.WriteLine("Student id not found");
                    }
                    else
                    {
                        foreach (var x in ans)
                        {
                            Console.WriteLine(x.Key + "   " + x.Value);
                        }
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the student id");
                    string sID = Console.ReadLine();

                    Console.WriteLine("Enter the marks");
                    int m = int.Parse(Console.ReadLine());

                    var ans = sUtil.UpdateStudentMarks(sID, m);

                    if (ans.Count == 0)
                    {
                        Console.WriteLine("Student id not found");
                    }
                    else
                    {
                        Console.WriteLine("Marks updated");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Thank you");
                    break;
                }
            }
        }
    }
}
