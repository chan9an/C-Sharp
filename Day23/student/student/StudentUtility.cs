using System;
using System.Collections.Generic;

namespace student
{
    public class StudentUtility
    {
        public Dictionary<string, string> GetStudentDetails(string id)
        {
            var res = new Dictionary<string, string>();

            foreach (var x in Program.StudentDetails.Values)
            {
                if (x.Id == id)
                {
                    res[id] = x.Name + "_" + x.Course;
                    break;
                }
            }

            return res;
        }

        public Dictionary<string, Student> UpdateStudentMarks(string id, int marks)
        {
            var res = new Dictionary<string, Student>();

            foreach (var x in Program.StudentDetails.Values)
            {
                if (x.Id == id)
                {
                    x.Marks = marks;
                    res[id] = x;
                    break;
                }
            }

            return res;
        }
    }
}
