using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGPA
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public Student(string id, string name, double gpa)
        {
            Id = id;
            Name = name;
            GPA = gpa;
        }
    }

    public class InvalidGPAException : Exception
    {
        public InvalidGPAException(string message) : base(message) { }
    }

    public class DuplicateStudentException : Exception
    {
        public DuplicateStudentException(string message) : base(message) { }
    }

    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message) { }
    }

    public class DescendingComparer : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            return y.CompareTo(x);
        }
    }

    public class StudentManager
    {
        private SortedDictionary<double, List<Student>> students = new SortedDictionary<double, List<Student>>(new DescendingComparer());

        public void AddStudent(Student student)
        {
            if (student.GPA < 0 || student.GPA > 10)
                throw new InvalidGPAException("GPA must be between 0 and 10.");

            foreach (var list in students.Values)
            {
                if (list.Any(s => s.Id == student.Id))
                    throw new DuplicateStudentException($"Student with ID {student.Id} already exists.");
            }

            if (!students.ContainsKey(student.GPA))
            {
                students[student.GPA] = new List<Student>();
            }
            students[student.GPA].Add(student);
        }

        public void UpdateGPA(string id, double newGPA)
        {
            if (newGPA < 0 || newGPA > 10)
                throw new InvalidGPAException("GPA must be between 0 and 10.");

            Student target = null;
            double oldGPA = -1;

            foreach (var pair in students)
            {
                var s = pair.Value.FirstOrDefault(x => x.Id == id);
                if (s != null)
                {
                    target = s;
                    oldGPA = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new StudentNotFoundException($"Student with ID {id} not found.");

            // Remove from old GPA list
            students[oldGPA].Remove(target);
            if (students[oldGPA].Count == 0)
                students.Remove(oldGPA);

            // Add to new GPA list
            target.GPA = newGPA;
            if (!students.ContainsKey(newGPA))
                students[newGPA] = new List<Student>();
            students[newGPA].Add(target);
        }

        public List<Student> GetRanking()
        {
            List<Student> ranking = new List<Student>();
            foreach (var pair in students)
            {
                ranking.AddRange(pair.Value);
            }
            return ranking;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Ranking");
                Console.WriteLine("2 -> Update GPA");
                Console.WriteLine("3 -> Add Student");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var ranking = manager.GetRanking();
                            if (ranking.Count == 0)
                            {
                                Console.WriteLine("No students found.");
                            }
                            else
                            {
                                foreach (var s in ranking)
                                {
                                    Console.WriteLine($"Details: {s.Id} {s.Name} {s.GPA}");
                                }
                            }
                            break;

                        case "2":
                            Console.Write("Enter Student ID: ");
                            string updateId = Console.ReadLine();
                            Console.Write("Enter New GPA: ");
                            if (double.TryParse(Console.ReadLine(), out double newGPA))
                            {
                                manager.UpdateGPA(updateId, newGPA);
                                Console.WriteLine("GPA updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid GPA input.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID Name GPA):");
                            string input = Console.ReadLine();
                            string[] parts = input.Split(' ');
                            if (parts.Length == 3)
                            {
                                string id = parts[0];
                                string name = parts[1];
                                double gpa = double.Parse(parts[2]);
                                manager.AddStudent(new Student(id, name, gpa));
                                Console.WriteLine("Student added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input format.");
                            }
                            break;

                        case "4":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
