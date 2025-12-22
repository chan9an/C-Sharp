using System;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

namespace Day2Demo;

public class Exercise
{
    public void HeightCategory(int height)
    {
        if (height < 150)
        {
            System.Console.WriteLine("Dwarf!!");
        }
        else if (height >= 150 && height < 165)
        {
            System.Console.WriteLine("Average");
        }
        else if (height >= 165 && height < 190)
        {
            System.Console.WriteLine("Average");
        }
        else
        {
            System.Console.WriteLine("Abnormal");
        }


    }
    public void LargestOfThree(int num1, int num2, int num3)
    {
        if (num1 >= num2)
        {
            if (num1 >= num3)
            {
                System.Console.WriteLine("Biggest number:{0}", num1);
            }

        }
        if (num2 >= num1 && num2 >= num3)
        {
            System.Console.WriteLine("Biggest number:{0}", num2);

        }
        if (num3 >= num1 && num3 >= num2)
        {
            System.Console.WriteLine("Biggest number:{0}", num3);

        }



    }

    public void LeapYear(int year)
    {
        if (year % 400 == 0 || ((year % 4 == 0) && year % 100 != 0))
        {
            System.Console.WriteLine("{0} is a Leap Year", year);
        }
    }
    public void quadraticequ()
    {

    }
    public void admissionEligibility(int math, int phys, int chem)
    {
        if (math >= 65 && phys >= 55 && chem >= 50 && ((math + phys + chem >= 180) || (math + phys >= 140)))
        {
            System.Console.WriteLine("Eligibility criteria matched");
        }
        else
        {
            System.Console.WriteLine("Not matched");
        }

    }

    public void bill(int units)
    {
        int tempunits = units;
        double bill = 0;
        if (units <= 199)
        {
            System.Console.WriteLine("Bill:{0}", units * 1.20);
        }
        else if (units >= 200 && units < 400)
        {
            bill = 199 * 1.20 + (units - 199) * 1.50;

        }

        else if (units >= 400 && units < 600)
        {
            bill = 199 * 1.20 + 200 * 1.50 + (units - 399) * 1.80;
        }
        else
        {
            bill = 199 * 1.20 + 200 * 1.50 + 200 * 1.80 + (units - 599) * 2.00;
        }
    }
    public void VowelOrConst(char var)
    {
        switch (var)
        {
            case 'a':
                System.Console.WriteLine("Vowel");
                break;
            case 'e':
                System.Console.WriteLine("Vowel");
                break;
            case 'i':
                System.Console.WriteLine("Vowel");
                break;
            case 'o':
                System.Console.WriteLine("Vowel");
                break;
            case 'u':
                System.Console.WriteLine("Vowel");
                break;
            default:
                System.Console.WriteLine("Consonant");
                break;
        }
    }
    void triangle(int side1, int side2, int side3)
    {
        if (side1 == side2 && side1 == side3)
        {
            System.Console.WriteLine("Equilateral Triangle");
        }
        else if (side1 == side2 || side3 == side2 || side1 == side3)
        {
            System.Console.WriteLine("Isosceles Triangle");
        }
        else
        {
            System.Console.WriteLine("Scalene Triangle");
        }

    }
    void quadrant(int x_cord, int y_cord)
    {
        if (x_cord > 0 && y_cord > 0)
        {
            System.Console.WriteLine("Quad 1");


        }
        else if (x_cord < 0 && y_cord > 0)
        {
            System.Console.WriteLine("Quad 2");
        }
        else if (x_cord < 0 && y_cord < 0)
        {
            System.Console.WriteLine("Quad 3");
        }
        else
        {
            System.Console.WriteLine("Quad 4");
        }

    }
        
    void GradesDesc(char grades)
        {
            switch (grades)
                    {
            case 'E':
                System.Console.WriteLine("Excellent");
                break;
                case 'V':
                System.Console.WriteLine("Very Good");
                break;
                case 'G':
                System.Console.WriteLine("Good");
                break;
                case 'A':
                System.Console.WriteLine("Average");
                break;
                case 'F':
                System.Console.WriteLine("Fail");
                break;
            default:
                System.Console.WriteLine("Invalid");
                break;
                    }
        
        }    
    
            
        

}
