using System;
using System.Dynamic;

namespace Day4;

public class Employee
{

    #region
    string name;
    int empid;
    int basicSal;

    public String Name { get; set; }
    public int EmpID { get; set; }
    public int BasicSal { get; set; }

    #endregion
    public virtual int CalculateSalary(int sal)
    {
        int mySal = 0;
        mySal = (sal + 15000 + 3000 + 1500 - 2500);
        return mySal;
    }

}