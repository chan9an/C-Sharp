using System;

namespace Day2Demo;

public class Student
{
    #region Fields
     int rollNo;
     string name;
    string address;
    #endregion

    /// <summary>
    /// Default Constructor
    /// </summary>

    public Student()
    {
        rollNo = 100;
        name = "Dummy";
       address = "Dummy City";
        
    }
    public Student(int id , string name ,string city){
        rollNo=id;
        this.name=name;
        address=city;
    }

    public void DisplayDetails(Student s1)
    {
        System.Console.WriteLine("RollNo:{0}\nName: {1}\nAddress:{2}\n",s1.rollNo,s1.name,s1.address);

    }
}
