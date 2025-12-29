using LPU_Entity;


namespace LPU_Common;

public interface IStudentCRUD
{
    Student SearchStudentByID(int rollNo);
    List<Student> SearchStudentByName(string name);
    bool EnrollStudent(Student obj);
    bool UpdateStudentDetails(int id, Student newObj);
    bool DropStudentDetails(int id);

}
