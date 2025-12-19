using System;
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
        int bill = 0;
        if (units <= 199)
        {
            System.Console.WriteLine("Bill:{0}", units * 1.20);
        }
        else if (units>=200 && units < 400)
        {
            
                    
        }
                
        else
        {
            

        }
    }
            
        

}
