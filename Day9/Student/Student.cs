using System;

namespace LPU_Entity;

public enum CourseType {
    Mechenical,Electrical , Civil , ComputerScience ,InformationTech
}

public class Student
{
    #region Fields
    public int StudentID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public CourseType Course { get; set; }

    #endregion



}
