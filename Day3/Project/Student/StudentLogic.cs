using System;

namespace Day3.Project.Student;

public class StudentLogic
{
    Student obj1 = null;

    public StudentLogic()
    {
        obj1 = new Student();
    }

    public void AcceptStudentDetails()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("====================================");
        Console.WriteLine("     STUDENT MANAGEMENT SYSTEM       ");
        Console.WriteLine("====================================");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter Roll No        : ");
        Console.ResetColor();
        obj1.RollNo = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter Physics Marks  : ");
        Console.ResetColor();
        obj1.Phy = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("Enter Chemistry Marks: ");
        Console.ResetColor();
        obj1.Chem = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter Maths Marks    : ");
        Console.ResetColor();
        obj1.Math = int.Parse(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine();
        Console.WriteLine("✔ Student details captured successfully!");
        Console.ResetColor();
    }
    public int CalcTotal()
    {
        return obj1.Total;

    }
    public float CalcAvg()

    {
        obj1.Percentage = obj1.Total / 3;
        return obj1.Percentage;
    }
    // System.Console.WriteLine("Total"); // Removed misplaced line
    //ystem.Console.WriteLine($"Total {obj1.CalcTotal}");

}
