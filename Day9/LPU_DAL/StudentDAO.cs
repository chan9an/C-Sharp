
using LPU_Common;
using LPU_Entity;
using LPU_Exceptions;

namespace LPU_DAL;
/// <summary>
/// StudentDAO class is used for CRUD operations
/// </summary>
public class StudentDAO  : IStudentCRUD
{   
    static List<Student> studentList=null;
    public StudentDAO()
    {
        studentList=  new List<Student>(){
        new Student(){StudentID=101,Name="Alok",Course=CourseType.ComputerScience,Address="Chandigrah"},
        new Student(){StudentID=102,Name="Aman",Course=CourseType.ComputerScience,Address="Shimla"},
        new Student(){StudentID=103,Name="Riya",Course=CourseType.InformationTech,Address="Bilaspur"},
        new Student(){StudentID=104,Name="Rajat",Course=CourseType.Electrical,Address="Kangra"},
        new Student(){StudentID=105,Name="Lakshay",Course=CourseType.Civil,Address="Hamirpur"},
        new Student(){StudentID=106,Name="Akshay",Course=CourseType.Mechenical,Address="Solan"},
    };
    }
    public bool DropStudentDetails(int id)
    {
        throw new NotImplementedException();
    }

    public bool EnrollStudent(Student obj)
    {
        throw new NotImplementedException();
    }

    public Student SearchStudentByID(int rollNo)
    {
        Student myStud = null;
        if (rollNo != 0)
        {
            myStud = studentList.Find(s => s.StudentID == rollNo);
            if (myStud == null)
            {
                return myStud;
            }
            else
            {
                throw new NotImplementedException();
            }

        }
        return myStud;
    }

    public List<Student> SearchStudentByName(string name)
    {
        throw new NotImplementedException();
    }

    public bool UpdateStudentDetails(int id, Student newObj)
    {
        throw new NotImplementedException();
    }

    
    

}