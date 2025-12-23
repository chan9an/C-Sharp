using System;

namespace Day4.Assignment;

public class Employee

{
    #region Fields
    int _empId;
    string _name;
    int _age;
    enum department
    {
        IT = 1, HR = 2, Finance = 3

    }
    double _basicsalary;
    #endregion
    public int EmpID
    {
        get
        {
            return _empId;
        }
        set
        {
            _empId=value;
        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            value = _name;
        }
    }
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if (value < 21)
            {
                return;
            }
            else
            {
                _age = value;
            }
        }
    }
    public double Basicsalary
    {
        get
        {
            return _basicsalary;
        }
        set
        {
            _basicsalary=value;
        }
    }

}
