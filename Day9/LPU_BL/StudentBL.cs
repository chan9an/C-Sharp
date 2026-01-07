using System;
using LPU_Common;
using LPU_DAL;
using LPU_Entity;


namespace LPU_BL;

public class StudentBL : IStudentCRUD
{

    StudentDAO sDao = null;

    bool IStudentCRUD.DropStudentDetails(int id)
    {
        throw new NotImplementedException();
    }

    bool IStudentCRUD.EnrollStudent(Student obj)
    {
        throw new NotImplementedException();
    }

    Student IStudentCRUD.SearchStudentByID(int rollNo)
    {
        Student s1 = null;
        try
        {
            s1 = sDao.SearchStudentByID(rollNo);
            return s1;

        }
        catch (Exception e)
        {
            throw e;
        }
    }

    List<Student> IStudentCRUD.SearchStudentByName(string name)
    {
        throw new NotImplementedException();
    }

    bool IStudentCRUD.UpdateStudentDetails(int id, Student newObj)
    {
        throw new NotImplementedException();
    }
}
