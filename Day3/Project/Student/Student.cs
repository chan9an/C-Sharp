using System;
using System.Dynamic;

namespace Day3.Project.Student;

public class Student
{
    #region Fields
    int rollNo;
    int phy;
    int chem;
    int math;
    int total;
    float percentage;

    //CLR properties
    public int RollNo
    {
        set
        {

            rollNo = value;
        }
        get
        {
            return rollNo;
        }

    }
    public int Phy
    {
        set

        {
            if (value >= 0 && value <= 100)
            {
                phy = value;
            }
            else
            {
                System.Console.WriteLine("Invalid Marks.Please keep it between 0 to 100");

            }
        }
        get
        {
            return phy;
        }

    }
    public int Chem
    {
        set
        {
            chem = value;
        }
        get
        {
            return chem;
        }

    }
    public int Math
    {
        set
        {
            math = value;
        }
        get
        {
            return math;
        }

    }
    public int Total //
    {
        get
        {
            return chem + math + phy; ;
        }


    }

    public float Percentage { get; set; }

    int t1;//Total
    float p1; //Percentage
        
    }
    #endregion


