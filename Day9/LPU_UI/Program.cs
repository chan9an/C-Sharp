using System;

namespace LPU_UI;

public class Program
{
    static void Menu()
    {
        System.Console.WriteLine("Student Management System");
        System.Console.WriteLine("=========================");
        System.Console.WriteLine("1. Search Student By ID");
        System.Console.WriteLine("2. Show All Students");
        System.Console.WriteLine("3. Add Student Details");
        System.Console.WriteLine("4. Update Student Details");
        System.Console.WriteLine("5. Update Student Details");
        System.Console.WriteLine("6. Drop Student Details");
        System.Console.WriteLine("7. Exit");
    }
    static void Main(string[] args)
    {
        do
        {
            Menu();
            int choice = 0;
            System.Console.WriteLine("Please enter your choice");
            choice = Int32.Parse(Console.ReadLine());
            
        } while (true)
    }

}
